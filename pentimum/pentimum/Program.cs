using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pentimum
{
    class Program
    {
        static Processzor proc;
        static void Main(string[] args) {
            Console.SetWindowSize(20, 20);
            Console.CursorTop = 13;
            string parancs;
            string[] darabok;

            /*Console.WriteLine(Eszkozok.Hex2Dec("200"));
            Console.WriteLine(Eszkozok.Dec2Hex(512));*/

            proc = new Processzor();
            Task futtatas = null;

            do {
                Console.CursorTop = 11;
                Console.CursorLeft = 0;
                Console.WriteLine(new string(' ', 30));
                Console.CursorTop = 11;
                parancs = Console.ReadLine().Trim();
                switch (parancs[0]) {
                    case 'L':
                        darabok = parancs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        proc.Betolt(darabok[1]);
                        break;
                    case 'R':
                        /*futtatas = Task.Run(new Action(proc.Futtat));
                        while(proc.fut) {
                            if (proc.kepFrissult) {
                                Console.CursorTop = Console.CursorLeft = 0;
                                StringBuilder sb = new StringBuilder();
                                for (int i = 0; i < 10; i++) {
                                    sb.Append(Encoding.ASCII.GetChars(proc.ram, i*10, 10));
                                    sb.AppendLine();
                                }
                                Console.Clear();
                                Console.Write(sb.ToString());
                                proc.kepFrissult = false;
                            }
                        }*/
                        proc.Futtat();
                        break;
                    case 'S':
                        proc.Lep();
                        break;
                    case 'M':
                        TorolStatusz();
                        darabok = parancs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(Eszkozok.Dec2Hex(proc.ram[Eszkozok.Hex2Dec(darabok[1])]));
                        break;
                }
            } while (parancs != "Q");

            Console.ReadLine();
        }

        public static void Kepfrissit() {
            Console.CursorTop = Console.CursorLeft = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++) {
                sb.Append(Encoding.ASCII.GetChars(proc.ram, i * 10, 10));
                sb.AppendLine();
            }
            //Console.Clear();
            Console.Write(sb.ToString());
            proc.kepFrissult = false;
        }

        public static void TorolStatusz() {
            Console.CursorTop = 12;
            Console.CursorLeft = 0;
            Console.WriteLine(new string(' ', 50));
            Console.WriteLine(new string(' ', 50));
            Console.CursorTop = 12;
            Console.CursorLeft = 0;
        }
    }
}
