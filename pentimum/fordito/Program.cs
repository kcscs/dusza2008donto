using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fordito
{
    class Program
    {
        static void Main(string[] args) {
            List<string> sorelemek = new List<string>();
            string bytekod ="";
            string keszbytekod = "";
            using (StreamReader sr = new StreamReader("1pelda.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    sorelemek=new List<string>();
                    if(sor[0]!='#')
                    {
                        string[] elemek =sor.Split(' ');
                        
                        if(elemek[0]=="MOV")
                        {
                            if(elemek[2].Contains("$")) // Ha a $-es MOV
                            {
                                int paramaterHossz = elemek[1].Length - 2;


                                elemek[1] = elemek[1].Substring(1, paramaterHossz);
                                for(int i=0;i<3-paramaterHossz;i++)
                                {
                                    elemek[1] = "0" + elemek[1];
                                }

                                int parameterHossz2 = elemek[2].Length - 1;

                                elemek[2] = elemek[2].Substring(1);
                                for(int i=0;i<2-parameterHossz2;i++)
                                {
                                    elemek[2] = "0" + elemek[2];
                                }

                                bytekod = bytekod + "01 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + "\n";
                                

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

                                elemek[2] = elemek[2].Substring(1,parameterHossz2);
                                for (int i = 0; i < 4 - parameterHossz2; i++)
                                {
                                    elemek[2] = "0" + elemek[2];
                                }

                                bytekod = bytekod + "00 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + " " + elemek[2][2] + elemek[2][3] +"\n";


                            }

                        }
                        switch (elemek[0])
                        {
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

                                    bytekod = bytekod + "03 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + "\n";

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

                                    bytekod = bytekod + "02 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + " " + elemek[2][2] + elemek[2][3] + "\n";
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

                                    bytekod = bytekod + "04 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + "\n";

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

                                    bytekod = bytekod + "05 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + " " + elemek[2][0] + elemek[2][1] + " " + elemek[2][2] + elemek[2][3] + "\n";
                                }
                                break;

                            case "JMP":
                                int parameterhossz = elemek[1].Length;
                                for(int i=0;i<3-parameterhossz;i++)
                                {
                                    elemek[1] = "0" + elemek[1];
                                }
                                bytekod = bytekod + "06 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + "\n";
                                break;

                            case "JZ":
                                int parameterhossza = elemek[1].Length;
                                for (int i = 0; i < 3 - parameterhossza; i++)
                                {
                                    elemek[1] = "0" + elemek[1];
                                }
                                bytekod = bytekod + "07 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + "\n";
                                break;

                            case "JC":
                                int parameterhosszb = elemek[1].Length;
                                for (int i = 0; i < 3 - parameterhosszb; i++)
                                {
                                    elemek[1] = "0" + elemek[1];
                                }
                                bytekod = bytekod + "08 " + "0" + elemek[1][0] + " " + elemek[1][1] + elemek[1][2] + "\n";
                                break;

                            case "WAIT":
                                bytekod = bytekod + "09 \n";
                                break;

                            case "END":
                                bytekod = bytekod + "0A \n";
                                break;
                        }








                    }
                }

            }
            keszbytekod = bytekod.Replace(" ", string.Empty);
            keszbytekod = keszbytekod.Replace("\n", string.Empty);

            //Console.WriteLine(bytekod);
           // Console.Write(keszbytekod);
            Console.ReadKey();
        }
    }
}
