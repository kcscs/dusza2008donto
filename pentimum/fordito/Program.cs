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
            using (StreamReader sr = new StreamReader("1pelda.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    sorelemek=new List<string>();
                    if(sor[0]!='#')
                    {
                        string[] elemek =sor.Split(' ');
                    }
                }

            }
        }
    }
}
