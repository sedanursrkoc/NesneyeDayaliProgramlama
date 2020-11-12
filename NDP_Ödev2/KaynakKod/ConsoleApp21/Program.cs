/****************************************************************************
**					     SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				     BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				    NESNEYE DAYALI PROGRAMLAMA DERSİ
**					    2018-2019 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 2
**				ÖĞRENCİ ADI............: Sedanur SARIKOÇ
**				ÖĞRENCİ NUMARASI.......: b181210110
**              DERSİN ALINDIĞI GRUP...: 1C
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Program
    {
  
        public class Futbolcu
        {
            public string adsoyad { get; set; }
            public int formaNo { get; set; }
            public double hiz;
            public double dayaniklik;
            public double pas;
            public double sut;
            public double yetenek;
            public double kararlilik;
            public double dogalForm;
            public double sans;
            public double PasSkor;
            public double GolSkor;

            public Futbolcu()
            {
                Random RastgeleDegerAta = new Random();
                hiz = RastgeleDegerAta.Next(50, 100);
                dayaniklik = RastgeleDegerAta.Next(50, 100);
                pas = RastgeleDegerAta.Next(50, 100);
                sut = RastgeleDegerAta.Next(50, 100);
                yetenek = RastgeleDegerAta.Next(50, 100);
                kararlilik = RastgeleDegerAta.Next(50, 100);
                dogalForm = RastgeleDegerAta.Next(50, 100);
                sans = RastgeleDegerAta.Next(50, 100);
            }

            public Futbolcu(string adsoyad, int formaNo)
            {
                this.adsoyad = adsoyad;
                this.formaNo = formaNo;
            }

            public virtual bool pasVer()
            {
                PasSkor = pas * 0.3 + yetenek * 0.3 + dayaniklik * 0.1 + dogalForm * 0.1 + sans * 0.2;
                if (PasSkor > 60) //futbolcunun özelliklerine göre hesaplanan pas skor değeri 60'tan büyükse pas başarılı olur
                {
                    return true;
                }
                else //pas skor değeri 60'tan küçükse pas başarısız olur
                    return false;
            }

            public virtual bool GolVurusu()
            {
                GolSkor = yetenek * 0.3 + sut * 0.2 + kararlilik * 0.1 + dogalForm * 0.1 + hiz * 0.1 + sans * 0.2;

                if (GolSkor > 70) //futbolcunun özelliklerine göre hesaplanan gol skor değeri 70'ten büyükse gol atışı başarılı olur
                {
                    return true;
                }
                else //gol skor değeri 70'ten küçükse gol atışı başarısız olur
                    return false;
            }

        }

        public class Defans : Futbolcu
        {
            public double pozisyonAlma;
            public double kafa;
            public double sicrama;

            public Defans(string AdSoyad, int FormaNo) : base(AdSoyad,FormaNo)
            {
                Random RastgeleDegerAta = new Random();
                hiz = RastgeleDegerAta.Next(50, 90);
                dayaniklik = RastgeleDegerAta.Next(50, 90);
                pas = RastgeleDegerAta.Next(50, 90);
                sut = RastgeleDegerAta.Next(50, 90);
                yetenek = RastgeleDegerAta.Next(50, 90);
                kararlilik = RastgeleDegerAta.Next(50, 90);
                dogalForm = RastgeleDegerAta.Next(50, 90);
                sans = RastgeleDegerAta.Next(50, 90);
                pozisyonAlma = RastgeleDegerAta.Next(50, 90);
                kafa = RastgeleDegerAta.Next(50, 90);
                sicrama = RastgeleDegerAta.Next(50, 90);
            }

            public override bool pasVer()
            {
                PasSkor = pas * 0.3 + yetenek * 0.3 + dayaniklik * 0.1 + dogalForm * 0.1 + pozisyonAlma * 0.1 + sans * 0.2;
                if (PasSkor > 60) //futbolcunun (defans) özelliklerine göre hesaplanan pas skor değeri 60'tan büyükse pas başarılı olur
                {
                    return true;
                }
                else //pas skor değeri 60'tan küçükse pas başarısız olur
                    return false;
            }

            public override bool GolVurusu()
            {
                GolSkor = yetenek * 0.3 + sut * 0.2 + kararlilik * 0.1 + dogalForm * 0.1 + kafa * 0.1 + sicrama * 0.1 + sans * 0.1;

                if (GolSkor > 70) //futbolcunun (defans) özelliklerine göre hesaplanan gol skor değeri 70'ten büyükse gol atışı başarılı olur
                {
                    return true;
                }
                else //gol skor değeri 70'ten küçükse gol atışı başarısız olur
                    return false;
            }

        }

        public class OrtaSaha : Futbolcu
        {
            public int uzunTop;
            public int ilkDokunus;
            public int uretkenlik;
            public int topSurme;
            public int ozelYetenek;

            public OrtaSaha(string AdSoyad, int FormaNo) : base(AdSoyad, FormaNo)
            {
                Random RastgeleDegerAta = new Random();
                hiz = RastgeleDegerAta.Next(60, 100);
                dayaniklik = RastgeleDegerAta.Next(60, 100);
                pas = RastgeleDegerAta.Next(60, 100);
                sut = RastgeleDegerAta.Next(60, 100);
                yetenek = RastgeleDegerAta.Next(60, 100);
                kararlilik = RastgeleDegerAta.Next(60, 100);
                dogalForm = RastgeleDegerAta.Next(60, 100);
                sans = RastgeleDegerAta.Next(60, 100);
                uzunTop = RastgeleDegerAta.Next(60, 100);
                ilkDokunus = RastgeleDegerAta.Next(60, 100);
                uretkenlik = RastgeleDegerAta.Next(60, 100);
                topSurme = RastgeleDegerAta.Next(60, 100);
                ozelYetenek = RastgeleDegerAta.Next(60, 100);       
            }

            public override bool pasVer()
            {
                PasSkor = pas * 0.3 + yetenek * 0.2 + ozelYetenek * 0.2 + dayaniklik * 0.1 + 
                    dogalForm * 0.1 + uzunTop * 0.1 + topSurme * 0.1 + sans * 0.1;

                if (PasSkor > 60) //futbolcunun (orta saha) özelliklerine göre hesaplanan pas skor değeri 60'tan büyükse pas başarılı olur
                {
                    return true;
                }
                else //pas skor değeri 60'tan küçükse pas başarısız olur
                    return false;
            }

            public override bool GolVurusu() 
            {
                GolSkor = yetenek * 0.3 + ozelYetenek * 0.2 + sut * 0.2 + ilkDokunus * 0.1 + kararlilik * 0.1 + dogalForm * 0.1 + sans * 0.1;

                if (GolSkor > 70) //futbolcunun (orta saha) özelliklerine göre hesaplanan gol skor değeri 70'ten büyükse gol atışı başarılı olur
                {
                    return true;
                }
                else //gol skor değeri 70'ten küçükse gol atışı başarısız olur
                    return false;
            }

        }

        public class Forvet : Futbolcu
        {
            public int bitiricilik;
            public int ilkDokunus;
            public int kafa;
            public int ozelYetenek;
            public int sogukKanlilik;

            public Forvet(string AdSoyad, int FormaNo) : base(AdSoyad, FormaNo)
            {
                Random RastgeleDegerAta = new Random();
                hiz = RastgeleDegerAta.Next(70, 100);
                dayaniklik = RastgeleDegerAta.Next(70, 100);
                pas = RastgeleDegerAta.Next(70, 100);
                sut = RastgeleDegerAta.Next(70, 100);
                yetenek = RastgeleDegerAta.Next(70, 100);
                kararlilik = RastgeleDegerAta.Next(70, 100);
                dogalForm = RastgeleDegerAta.Next(70, 100);
                sans = RastgeleDegerAta.Next(70, 100);
                bitiricilik = RastgeleDegerAta.Next(70, 100);
                ilkDokunus = RastgeleDegerAta.Next(70, 100);
                kafa = RastgeleDegerAta.Next(70, 100);
                ozelYetenek = RastgeleDegerAta.Next(70, 100);
                sogukKanlilik = RastgeleDegerAta.Next(70, 100);
            }

            public override bool pasVer()
            {
                PasSkor = pas * 0.3 + yetenek * 0.2 + ozelYetenek * 0.2 + dayaniklik * 0.1 + dogalForm * 0.1 + sans * 0.1;
                if (PasSkor > 60) //futbolcunun (forvet) özelliklerine göre hesaplanan pas skor değeri 60'tan büyükse pas başarılı olur
                {
                    return true;
                }
                else //pas skor değeri 60'tan küçükse pas başarısız olur
                    return false;
            }

            public override bool GolVurusu() 
            {
                GolSkor = yetenek * 0.2 + ozelYetenek * 0.2 + sut * 0.1 + kafa * 0.1 + ilkDokunus * 0.1 +
                    bitiricilik * 0.1 + sogukKanlilik * 0.1 + kararlilik * 0.1 + dogalForm * 0.1 + sans * 0.1;

                if (GolSkor > 70) //futbolcunun (forvet) özelliklerine göre hesaplanan gol skor değeri 70'ten büyükse gol atışı başarılı olur
                {
                    return true;
                }
                else //gol skor değeri 70'ten küçükse gol atışı başarısız olur
                    return false;
            }

        }
        
        static void Main(string[] args)
        {
            Random RastgeleSayi = new Random();
            int FormaNo = RastgeleSayi.Next(2, 11); //Başlangıç için oyuncu seçiliyor

            //takım oyuncuları oluşturuluyor
            List<Futbolcu> takim = new List<Futbolcu>();
            takim.Add(new Futbolcu("Aykut Berat Yıldız", 1)); //kaleci
	        takim.Add(new Defans("Berkay Can Değirmencioğlu", 2));
            takim.Add(new Defans("Alper Tursun", 3));
            takim.Add(new Defans("Ümit Yasin Arslan", 4));
            takim.Add(new Defans("Ferhat Yazgan", 5));
            takim.Add(new OrtaSaha("Savaş Tağa", 6));
            takim.Add(new OrtaSaha("Umut Sözen", 7));
            takim.Add(new OrtaSaha("Oğuz Kocabal", 8));
            takim.Add(new OrtaSaha("Serkan Odabaşoğlu", 9));
            takim.Add(new Forvet("Berk İsmail Ünsal", 10));
            takim.Add(new Forvet("İlyas Çakmak", 11));

            Console.WriteLine(takim[FormaNo - 1].adsoyad + "(" + takim[FormaNo - 1].formaNo + ") oyuna başlıyor..");

            Boolean gololabilir = true;

            for (int i = 1; i <= 3; i++) //3 kere pas atışı gerçekleştirilmesini döngüyle gerçekleştiriyoruz
            {
                int guncelFormaNo = FormaNo;

                if (takim[FormaNo - 1].pasVer()) //topun bulunduğu futbolcu için pas verme metodu başarılı olursa top başka oyuncuya geçer
                {
                    while (guncelFormaNo == FormaNo) //futbolcunun kendine pas verme durumu önlenir
                    {
                        FormaNo = RastgeleSayi.Next(2, 11);
                    }
                }
                else //pas verme metodu başarılı olmazsa döngüden çıkılır ve top rakip takıma geçer
                {
                    gololabilir = false;
                    break;
                }
                
                Console.WriteLine("Top " + takim[FormaNo - 1].adsoyad +"(" + takim[FormaNo - 1].formaNo + ")'da");

            }

            if (gololabilir) //bütün paslar başarılı olursa gol vuruşu için kontroller yapılır
            {
                if (takim[FormaNo - 1].GolVurusu()) //topun bulunduğu futbolcu için gol vuruşu metodu başarılı olursa gol olur
                { 
                    Console.WriteLine("GOOL - " + takim[FormaNo - 1].adsoyad + " " + takim[FormaNo - 1].formaNo);
                }
                else //topun bulunduğu futbolcu için gol vuruşu metodu başarılı olmazsa gol olmaz
                {
                    Console.WriteLine("Gol vuruşu başarısız...");
                }
            }
            else //pas vuruşlarından biri başarısız olursa top rakip takıma geçer
            {
                Console.WriteLine("Top rakip takıma geçti...");
            }

            Console.ReadLine();
        }
    }
}
