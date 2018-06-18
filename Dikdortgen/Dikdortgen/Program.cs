using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dikdortgen
{
    class Program
    {
        static void Main(string[] args)
        {baslangic:

            SetFontDefault();

            int height = 0;
            int weight = 0;
            bool full = true;

            Console.WriteLine("Bu program aşağıdaki şekilleri çizer.");
            Console.Write(@"
##########     ##########
##########     #        #
##########     #        #
##########     #        #
##########     #        #
##########     #        #
##########     #        #
##########     ##########
");
            genislik:
            Console.Write("Çizilecek şeklin genişliğini giriniz (Minimum 5): ");
            string readLine = Console.ReadLine();
            bool tryParse = Int32.TryParse(readLine, out weight);
            if (!tryParse)
            {
                SetFontError();
                Console.WriteLine($"Girilen değer ({readLine}) bir sayı değildir. Tekrar giriniz.");
                SetFontDefault();
                SetFontDefault();
                goto genislik;
            }

            yukseklik:
            Console.Write("Çizilecek şeklin yüksekliğini giriniz (Minimum 5): ");
            readLine = Console.ReadLine();
            tryParse = Int32.TryParse(readLine, out height);
            if (!tryParse)
            {
                SetFontError();
                Console.WriteLine($"Girilen değer ({readLine}) bir sayı değildir. Tekrar giriniz.");
                SetFontDefault();
                goto yukseklik;
            }

            sablon:
            int temp;
            Console.WriteLine("Şekil hangi şablonda çizilsin?\n1. İçi Boş\n2. İçi Dolu");
            Console.Write("Seçiminizi Giriniz: ");
            readLine = Console.ReadLine();
            tryParse = Int32.TryParse(readLine, out temp);

            if (!tryParse && (temp != 1 || temp != 2))
            {
                SetFontError();
                Console.WriteLine("Girilen değer geçerli bir değer değildir. Tekrar deneyiniz.");
                SetFontDefault();
                goto sablon;
            }

            full = Convert.ToBoolean(temp - 1);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\n\n\n");

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    if (i == 0 || i == height - 1 || j == 0 || j == weight -1 || full)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
            SetFontDefault();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Yeni şekil çizmek için E/e tuşuna basınız");
            if (String.Equals(Console.ReadLine(), "E", StringComparison.CurrentCultureIgnoreCase))
            {
                goto baslangic;
            }
        }

        private static void SetFontDefault()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void SetFontError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
