using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pentimum
{
    public static class Eszkozok
    {
        public static int Hex2Dec(string hex) {
            int helyiErtek = 1;
            int ertek = 0;
            for (int i = hex.Length-1; i >= 0; i--) {
                ertek += Hex2Dec(hex[i]) * helyiErtek;
                helyiErtek *= 16;
            }
            return ertek;
        }

        public static int Hex2Dec(char hex) {
            hex = char.ToUpper(hex);
            if(char.IsLetter(hex) && hex >= 'A' && hex <= 'F') {
                return 10 + (hex - 'A');
            } else if (char.IsNumber(hex)) {
                return hex - '0';
            }
            throw new Exception("Rossz karakter: "+hex+" (nem 16-os szamrendszerbeli)");
        }

        public static string Dec2Hex(int dec) {
            if (dec == 0)
                return "0";

            StringBuilder sb = new StringBuilder();
            int helyiErtek = 16;
            int m;
            int d = dec;
            while(dec > 0) {
                m = dec % helyiErtek;
                dec /= helyiErtek;

                if (m < 10)
                    sb.Insert(0, m);
                else
                    sb.Insert(0, (char)('A' + (m - 10)));
            }
            //Console.WriteLine("dec2hex " + d + " -> " + sb.ToString());
            return sb.ToString();
        }
    }
}
