using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using pentimum;

namespace fordito
{
    class Program
    {
        static void Main(string[] args) {
            List<string> sorelemek = new List<string>();
            string bytekod ="";
            string keszbytekod = "";
            int sorszamlalo=0;
            int byteszamlalo = 0;
            int atvaltott = 0;
            int atvaltott2 = 0;
            using (StreamReader sr = new StreamReader("1pelda.txt"))
            {
                while (!sr.EndOfStream)
                {
                    
                    string sor = sr.ReadLine();
                    sorszamlalo++;
                    sorelemek=new List<string>();
                    if (sor == "")
                    {
                        
                    }
                    else if(sor[0]!='#')
                    {
                        string[] elemek =sor.Split(' ');
                        
                        
                        
                        
                            

                        
                        switch (elemek[0])
                        {
                            case "MOV":
                                if (elemek[2].Contains("$")) // Ha a $-es MOV
                                {
                                    int paramaterHossz = elemek[1].Length - 2;


                                    elemek[1] = elemek[1].Substring(1, paramaterHossz);
                                    for (int i = 0; i < 3 - paramaterHossz; i++)
                                    {
                                        elemek[1] = "0" + elemek[1];
                                    }

                                    int parameterHossz2 = elemek[2].Length - 1;

                                    elemek[2] = elemek[2].Substring(1);
                                    for (int i = 0; i < 2 - parameterHossz2; i++)
                                    {
                                        elemek[2] = "0" + elemek[2];
                                    }

                                    bytekod = bytekod + "01 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + "\r\n";
                                    byteszamlalo = byteszamlalo + 4;

                                    atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                    atvaltott2 = Eszkozok.Hex2Dec(elemek[2]);
                                    if(atvaltott<0||atvaltott>1023||atvaltott2<0||atvaltott2>1023)
                                    {
                                        Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                        goto Kilep;
                                    }
                                    if(byteszamlalo>924)
                                    {
                                        Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                        bytekod = "";
                                        goto Kilep;

                                    }
                                    



                                }
                                else // Ha sima MOV
                                {

                                    int paramaterHossz = elemek[1].Length - 2;


                                    elemek[1] = elemek[1].Substring(1, paramaterHossz);
                                    for (int i = 0; i < 3 - paramaterHossz; i++)
                                    {
                                        elemek[1] = "0" + elemek[1];
                                    }

                                    int parameterHossz2 = elemek[2].Length - 2;

                                    elemek[2] = elemek[2].Substring(1, parameterHossz2);
                                    for (int i = 0; i < 4 - parameterHossz2; i++)
                                    {
                                        elemek[2] = "0" + elemek[2];
                                    }

                                    bytekod = bytekod + "00 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + " " + elemek[2][2] + elemek[2][3] + "\r\n";
                                    byteszamlalo = byteszamlalo + 5;
                                    atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                    atvaltott2 = Eszkozok.Hex2Dec(elemek[2]);
                                    if (atvaltott < 0 || atvaltott > 1023 || atvaltott2 < 0 || atvaltott2 > 1023)
                                    {
                                        Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                        goto Kilep;
                                    }
                                    if (byteszamlalo > 924)
                                    {
                                        Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                        bytekod = "";
                                        goto Kilep;

                                    }

                                }
                                break;
                            case "ADD":
                                if (elemek[2].Contains("$")) // Ha a $-es ADD
                                {
                                    int paramaterHossz = elemek[1].Length - 2;


                                    elemek[1] = elemek[1].Substring(1, paramaterHossz);
                                    for (int i = 0; i < 3 - paramaterHossz; i++)
                                    {
                                        elemek[1] = "0" + elemek[1];
                                    }

                                    int parameterHossz2 = elemek[2].Length - 1;

                                    elemek[2] = elemek[2].Substring(1);
                                    for (int i = 0; i < 2 - parameterHossz2; i++)
                                    {
                                        elemek[2] = "0" + elemek[2];
                                    }

                                    bytekod = bytekod + "03 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + "\r\n";
                                    byteszamlalo = byteszamlalo + 4;
                                    atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                    atvaltott2 = Eszkozok.Hex2Dec(elemek[2]);
                                    if (atvaltott < 0 || atvaltott > 1023 || atvaltott2 < 0 || atvaltott2 > 1023)
                                    {
                                        Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                        goto Kilep;
                                    }
                                    if (byteszamlalo > 924)
                                    {
                                        Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                        bytekod = "";
                                        goto Kilep;

                                    }

                                }
                                else // Ha nem $-es ADD
                                {
                                    int paramaterHossz = elemek[1].Length - 2;


                                    elemek[1] = elemek[1].Substring(1, paramaterHossz);
                                    for (int i = 0; i < 3 - paramaterHossz; i++)
                                    {
                                        elemek[1] = "0" + elemek[1];
                                    }

                                    int parameterHossz2 = elemek[2].Length - 2;

                                    elemek[2] = elemek[2].Substring(1, parameterHossz2);
                                    for (int i = 0; i < 4 - parameterHossz2; i++)
                                    {
                                        elemek[2] = "0" + elemek[2];
                                    }

                                    bytekod = bytekod + "02 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + " " + elemek[2][2] + elemek[2][3] + "\r\n";
                                    byteszamlalo = byteszamlalo + 5;
                                    atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                    atvaltott2 = Eszkozok.Hex2Dec(elemek[2]);
                                    if (atvaltott < 0 || atvaltott > 1023 || atvaltott2 < 0 || atvaltott2 > 1023)
                                    {
                                        Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                        goto Kilep;
                                    }
                                    if (byteszamlalo > 924)
                                    {
                                        Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                        bytekod = "";
                                        goto Kilep;

                                    }
                                }
                                break;

                            case "SUB":
                                if (elemek[2].Contains("$")) // Ha a $-es SUB
                                {
                                    int paramaterHossz = elemek[1].Length - 2;


                                    elemek[1] = elemek[1].Substring(1, paramaterHossz);
                                    for (int i = 0; i < 3 - paramaterHossz; i++)
                                    {
                                        elemek[1] = "0" + elemek[1];
                                    }

                                    int parameterHossz2 = elemek[2].Length - 1;

                                    elemek[2] = elemek[2].Substring(1);
                                    for (int i = 0; i < 2 - parameterHossz2; i++)
                                    {
                                        elemek[2] = "0" + elemek[2];
                                    }

                                    bytekod = bytekod + "04 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + "\r\n";
                                    byteszamlalo = byteszamlalo + 4;
                                    atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                    atvaltott2 = Eszkozok.Hex2Dec(elemek[2]);
                                    if (atvaltott < 0 || atvaltott > 1023 || atvaltott2 < 0 || atvaltott2 > 1023)
                                    {
                                        Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                        goto Kilep;
                                    }
                                    if (byteszamlalo > 924)
                                    {
                                        Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                        bytekod = "";
                                        goto Kilep;

                                    }

                                }
                                else // Ha nem $-es SUB
                                {
                                    int paramaterHossz = elemek[1].Length - 2;


                                    elemek[1] = elemek[1].Substring(1, paramaterHossz);
                                    for (int i = 0; i < 3 - paramaterHossz; i++)
                                    {
                                        elemek[1] = "0" + elemek[1];
                                    }

                                    int parameterHossz2 = elemek[2].Length - 2;

                                    elemek[2] = elemek[2].Substring(1, parameterHossz2);
                                    for (int i = 0; i < 4 - parameterHossz2; i++)
                                    {
                                        elemek[2] = "0" + elemek[2];
                                    }

                                    bytekod = bytekod + "05 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + " " + elemek[2][2] + elemek[2][3] + "\r\n";
                                    byteszamlalo = byteszamlalo + 5;
                                    atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                    atvaltott2 = Eszkozok.Hex2Dec(elemek[2]);
                                    if (atvaltott < 0 || atvaltott > 1023 || atvaltott2 < 0 || atvaltott2 > 1023)
                                    {
                                        Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                        goto Kilep;
                                    }
                                    if (byteszamlalo > 924)
                                    {
                                        Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                        bytekod = "";
                                        goto Kilep;

                                    }
                                }
                                break;

                            case "JMP":
                                int parameterhossz = elemek[1].Length;
                                for(int i=0;i<3-parameterhossz;i++)
                                {
                                    elemek[1] = "0" + elemek[1];
                                }
                                bytekod = bytekod + "06 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + "\r\n";
                                byteszamlalo = byteszamlalo + 3;
                                atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                if (atvaltott < 0 || atvaltott > 1023)
                                {
                                    Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                    goto Kilep;
                                }
                                if (byteszamlalo > 924)
                                {
                                    Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                    bytekod = "";
                                    goto Kilep;

                                }
                                break;

                            case "JZ":
                                int parameterhossza = elemek[1].Length;
                                for (int i = 0; i < 3 - parameterhossza; i++)
                                {
                                    elemek[1] = "0" + elemek[1];
                                }
                                bytekod = bytekod + "07 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + "\r\n";
                                byteszamlalo = byteszamlalo + 3;
                                atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                if (atvaltott < 0 || atvaltott > 1023)
                                {
                                    Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                    goto Kilep;
                                }
                                if (byteszamlalo > 924)
                                {
                                    Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                    bytekod = "";
                                    goto Kilep;

                                }
                                break;

                            case "JC":
                                int parameterhosszb = elemek[1].Length;
                                for (int i = 0; i < 3 - parameterhosszb; i++)
                                {
                                    elemek[1] = "0" + elemek[1];
                                }
                                bytekod = bytekod + "08 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + "\r\n";
                                byteszamlalo = byteszamlalo + 3;
                                atvaltott = Eszkozok.Hex2Dec(elemek[1]);
                                if (atvaltott < 0 || atvaltott > 1023)
                                {
                                    Console.WriteLine("Olyan memóriacímre történt a hivatkozás ami nem létezik!");
                                    goto Kilep;
                                }
                                if (byteszamlalo > 924)
                                {
                                    Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                    bytekod = "";
                                    goto Kilep;

                                }
                                break;

                            case "WAIT":
                                bytekod = bytekod + "09 \r\n";
                                byteszamlalo = byteszamlalo + 1;
                                if (byteszamlalo > 924)
                                {
                                    Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                    bytekod = "";
                                    goto Kilep;

                                }

                                break;

                            case "END":
                                byteszamlalo = byteszamlalo + 1;
                                if (byteszamlalo > 924)
                                {
                                    Console.WriteLine("A program nem fér be a memóriába." + " Hiba a " + sorszamlalo + ". sorban");
                                    bytekod = "";
                                    goto Kilep;

                                }
                                bytekod = bytekod + "0A \r\n";
                                break;
                            default:
                               bytekod = "Szintaktikai hiba a " + sorszamlalo + ". sorban";
                               goto Kilep;
                                
                        }

                    }
                }

            }
            Kilep:
            keszbytekod = bytekod.Replace(" ", string.Empty);
            keszbytekod = keszbytekod.Replace("\r\n", string.Empty);

            Console.WriteLine(bytekod);
            Console.Write(keszbytekod);
            using (StreamWriter sw = new StreamWriter("2bytekod.txt"))
            {
                sw.Write(bytekod);
            }
            using (StreamWriter sw = new StreamWriter("keszbytekod.txt"))
            {
                sw.Write(keszbytekod);
            }
            Console.ReadKey();
        }
    }
}
