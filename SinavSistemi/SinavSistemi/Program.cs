using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Sınav Biçimini Tanımlama

            Sinav sinavtanimla = new Sinav(); //Sınav sınıfının nesnesini oluşturduk
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("SINAV SİSTEMİNE HOŞGELDİNİZ");
            Console.ResetColor();
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.Write("Lütfen Sınav İsmini Giriniz= ");
            Console.ForegroundColor = ConsoleColor.Blue;
            sinavtanimla.sinavadi = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Lütfen Soru Sayısını Giriniz= ");
            Console.ForegroundColor = ConsoleColor.Blue;
            sinavtanimla.sorusayisi = Convert.ToByte(Console.ReadLine());
            Console.ResetColor();
            Soru[] soru = new Soru[sinavtanimla.sorusayisi];//Sınavın soru miktarına göre Soru sınıfının soru miktarını tanımladık

            Console.Write("Lütfen Geçme Notunu Giriniz= ");
            Console.ForegroundColor = ConsoleColor.Blue;
            sinavtanimla.gecmenotu = Convert.ToByte(Console.ReadLine());
            Console.ResetColor();
            double sorupuani = (100 / Convert.ToDouble(sinavtanimla.sorusayisi));
            //Console.WriteLine(Math.Round(sorupuani,2)); Bu kod ile de virgülden sonra iki karakter alması sağlanır, lakin string ifadeye çevirerek yaparsak aşağıdaki gibi bir kod gereklidir. Örnek olarak bu haliyle kalsın.
            string sorubasinapuan = "";
            char[] chr = (Convert.ToString(sorupuani).ToCharArray());//Burada soru sayısının 100 puana bölümü itirabiyle çıkacak sonuçlar tek basamaklı olursa for döngüsü içerisinde dizin hatası almamak için char a dönüştürüp sorubasipuan değişkenine hatasız yazdırmaya çalıştık.-->
            for (int i = 0; i < chr.Length; i++)
            {
                if (i < 4)
                {
                    sorubasinapuan += (Convert.ToString(sorupuani)[i]);//--> Bu kısımdan bahsediyorum.
                }
            }

            Console.Write("Soru Başına Puan= ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(sorubasinapuan);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Lütfen Enter Tuşuna Basınız");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

            #endregion

            #region Soru Ekleme - Sınav Başlatma

            double puaniniz = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("SINAV SİSTEMİNE HOŞGELDİNİZ");
                Console.ResetColor();
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine("1) Soru Ekleme");
                Console.WriteLine("2) Sınav Başlatma");
                Console.WriteLine("3) Soruları Görüntüleme");

                Console.Write("Lütfen yapmak istediğiniz işlemin sıra numarasını giriniz= ");
                Console.ForegroundColor = ConsoleColor.Green;
                string secim = Console.ReadLine();
                Console.ResetColor();

                switch (secim)
                {
                    case "1":

                        for (int i = 0; i < sinavtanimla.sorusayisi; i++)
                        {
                            Console.Write($"{i + 1}.) Soruyu Giriniz= ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string Sorusoru = Console.ReadLine();
                            Console.ResetColor();

                            Console.Write($"{i + 1}.) Sorunun A Şıkkını Giriniz= ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string SorusecenekA = Console.ReadLine();
                            Console.ResetColor();

                            Console.Write($"{i + 1}.) Sorunun B Şıkkını Giriniz= ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string SorusecenekB = Console.ReadLine();
                            Console.ResetColor();

                            Console.Write($"{i + 1}.) Sorunun C Şıkkını Giriniz= ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string SorusecenekC = Console.ReadLine();
                            Console.ResetColor();

                            Console.Write($"{i + 1}.) Sorunun D Şıkkını Giriniz= ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string SorusecenekD = Console.ReadLine();
                            Console.ResetColor();

                            Console.Write($"{i + 1}.) Sorunun Doğru Cevabını Giriniz= ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string Sorudogrucevap = Console.ReadLine();
                            Console.ResetColor();

                            soru[i] = new Soru() { soru = Sorusoru, secenekA = SorusecenekA, secenekB = SorusecenekB, secenekC = SorusecenekC, secenekD = SorusecenekD, dogruCevap = Sorudogrucevap };
                        }
                        break;

                    case "2":

                        if (soru[0] != null)
                        {
                            sinavtanimla.sorular = soru; //Soru sınıfının soru dizisine 1.seçenekte tanımlamış olduğumuz soruları Sınav sınıfının sınavtanimla nesnesinin sorular dizisine attık
                            puaniniz = 0;
                            for (int i = 0; i < sinavtanimla.sorusayisi; i++)
                            {
                                Console.WriteLine($"{i+1}.) {sinavtanimla.sorular[i].soru}");
                                Console.WriteLine($"A.) {sinavtanimla.sorular[i].secenekA}");
                                Console.WriteLine($"B.) {sinavtanimla.sorular[i].secenekB}");
                                Console.WriteLine($"C.) {sinavtanimla.sorular[i].secenekC}");
                                Console.WriteLine($"D.) {sinavtanimla.sorular[i].secenekD}");
                                Console.Write("Cevabınızı Giriniz= ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                string cevap = Console.ReadLine();
                                Console.ResetColor();
                                if (cevap == sinavtanimla.sorular[i].dogruCevap)
                                {
                                    puaniniz += sorupuani;
                                }
                            }
                            if (sinavtanimla.gecmenotu <= puaniniz)
                            {
                                Console.Write("Tebrikler Sınavı Başarı İle Tamamladınız Notunuz= ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine(puaniniz);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write("Sınav Başarısızlık İle Sonuçlandı Notunuz= ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(puaniniz);
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sınav İçin Soru Tanımlaması Yapmadığınızdan Bu Adımı Görüntüleyemezsiniz!");
                            Console.ResetColor();
                        }
                        break;

                    case "3":

                        if (soru[0] != null)
                        {
                            sinavtanimla.sorular = soru; //Soru sınıfının soru dizisine 1.seçenekte tanımlamış olduğumuz soruları Sınav sınıfının sınavtanimla nesnesinin sorular dizisine attık
                            puaniniz = 0;
                            for (int i = 0; i < sinavtanimla.sorusayisi; i++)
                            {
                                Console.WriteLine($"{i + 1}.) {sinavtanimla.sorular[i].soru}");
                                Console.WriteLine($"A.) {sinavtanimla.sorular[i].secenekA}");
                                Console.WriteLine($"B.) {sinavtanimla.sorular[i].secenekB}");
                                Console.WriteLine($"C.) {sinavtanimla.sorular[i].secenekC}");
                                Console.WriteLine($"D.) {sinavtanimla.sorular[i].secenekD}");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sınav İçin Soru Tanımlaması Yapmadığınızdan Bu Adımı Görüntüleyemezsiniz!");
                            Console.ResetColor();
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hatalı Bir Seçim Yaptınız Lütfen Seçeneklerden Birini Seçiniz!");
                        Console.ResetColor();
                        break;

                }
                Console.Write("Devam Etmek İstiyor Musunuz? e/h= ");
                Console.ForegroundColor = ConsoleColor.Green;
                string secenek = Console.ReadLine();
                Console.ResetColor();
                if (secenek != "e")
                {
                    break;
                }
                Console.Clear();
            }
            #endregion

        }
    }
}
