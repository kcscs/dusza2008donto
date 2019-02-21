using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace pentimum
{
    class Processzor
    {
        public readonly int memoriaMeret = Eszkozok.Hex2Dec("400"); //1024
        public readonly int programStart = Eszkozok.Hex2Dec("64"); //100

        const int byteHelyiErtekSzorzo = 255;
        const int varakozasHossz = 100; // ms

        public byte[] ram;

        public bool kepFrissult = false;
        public bool fut = false;

        private string[] utasitasok = new string[11] { "MOV", "MOV", "ADD", "ADD", "SUB", "SUB", "JMP", "JZ", "JC", "WAIT", "END" };

        public Processzor() {
            ram = new byte[memoriaMeret];
        }

        public void Betolt(string fajl) {
            for (int i = 0; i < programStart; i++) {
                ram[i] = (byte)Eszkozok.Hex2Dec("20");  //space ASCII-ben
            }

            string kod;

            using(StreamReader sr = new StreamReader(fajl)) {
                kod = sr.ReadToEnd();
            }

            for (int i = 0; i < kod.Length; i+=2) {
                byte val = (byte)Eszkozok.Hex2Dec(kod[i] + "" + kod[i + 1]);
                ram[programStart + i/2] = val;
            }

            pos = programStart;
        }

        int pos;
        int a = -1, b = -1, c;
        bool kicsordult = false;
        bool elozo0 = false;

        public void Futtat() {
            fut = true;
            kepFrissult = true;
            Program.Kepfrissit();
            

            while (ram[pos] != 10) {    // 10 = END
                Lep();
            }
            fut = false;
        }

        public void Lep() {
            Program.TorolStatusz();
            Console.WriteLine("Cim: " + Eszkozok.Dec2Hex(pos));
            Console.Write("Utasitas: "+Eszkozok.Dec2Hex(ram[pos]));

            if (ram[pos] <= 8) { // a 9-nel kisebb utasitasoknal az elso parameter egy memoriacim: [ABC]
                a = ram[pos + 1] * byteHelyiErtekSzorzo + ram[pos + 2];
                Console.Write(" " + Eszkozok.Dec2Hex(a));
            }

            if (ram[pos] <= 5) { // van 3. parameter
                if (ram[pos] % 2 == 0) {  // a 3. parameter memoriacim
                    b = ram[pos + 3] * byteHelyiErtekSzorzo + ram[pos + 4];
                } else { // a 3. parameter egy 1 byte-os konstans
                    b = ram[pos + 3];
                }
                Console.Write(" " + Eszkozok.Dec2Hex(b));
            }

            switch (ram[pos]) {
                case 0: // MOV [ABC] [DEF]
                    ram[a] = ram[b];
                    break;
                case 1: // MOV [ABC] $XY
                    ram[a] = (byte)b;
                    break;
                case 2: // ADD [ABC] [DEF]
                    c = ram[a] + ram[b];
                    if (c > byte.MaxValue) {
                        kicsordult = true;
                        c = c % (byte.MaxValue + 1);
                    } else {
                        kicsordult = false;
                    }
                    ram[a] = (byte)c;
                    break;
                case 3: // ADD [ABC] $XY
                    c = ram[a] + b;
                    if (c > byte.MaxValue) {
                        kicsordult = true;
                        c = c % (byte.MaxValue + 1);
                    } else {
                        kicsordult = false;
                    }
                    ram[a] = (byte)c;
                    break;
                case 4: // SUB [ABC] [DEF]
                    c = ram[a] - ram[b];
                    if (c < 0) {
                        kicsordult = true;
                        c += byte.MaxValue + 1;
                    } else
                        kicsordult = false;
                    ram[a] = (byte)c;
                    break;
                case 5: // SUB [ABC] $XY
                    c = ram[a] - b;
                    if (c < 0) {
                        kicsordult = true;
                        c += byte.MaxValue + 1;
                    } else
                        kicsordult = false;
                    ram[a] = (byte)c;
                    break;
                case 6: // JMP ABC
                    pos = a;
                    return; // nehogy atlepje a kovetkezot, amugy sincs mar tobb dolgunk
                case 7: // JZ
                    if (elozo0)
                        pos = a;
                    else
                        pos += 3;
                    return; // nehogy atlepje a kovetkezot, amugy sincs mar tobb dolgunk
                case 8: // JC
                    if (kicsordult)
                        pos = a;
                    else
                        pos += 3;
                    return; // nehogy atlepje a kovetkezot, amugy sincs mar tobb dolgunk
                case 9: // WAIT
                    Thread.Sleep(varakozasHossz);
                    break;
                    /*case 10:    // END

                        break;*/

            }

            if (ram[pos] <= 5) { // ram[a]-t modosito utasitasok: MOV, ADD, SUB
                elozo0 = ram[a] == 0;
                if (a < programStart) {    // kepernyore irunk
                    kepFrissult = true;
                    Program.Kepfrissit();
                }
            }

            if (ram[pos] <= 5) {
                if (ram[pos] % 2 == 0) {    // 5 byte-os utasitasok
                    pos += 5;
                } else {    // 4 byte-os utasitasok
                    pos += 4;
                }
            } else if (ram[pos] == 9)   //WAIT-nel
                pos++;

        }
    }
}
