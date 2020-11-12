/****************************************************************************
**					     SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					    2018-2019 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: Proje
**				ÖĞRENCİ ADI............: Sedanur SARIKOÇ
**				ÖĞRENCİ NUMARASI.......: b181210110
**              DERSİN ALINDIĞI GRUP...: 1C
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public interface IOlduMu
        {
            bool OlduMu();
        }

        public abstract class Canlı
        {
            public int toplam = 0;

            public virtual int YemVer() { return 0; }
        }

        public class Tavuk : Canlı, IOlduMu
        {
            public int tavukYumurtası;
            public int tavukCan = 100;
            public int tavukSesCalmaSayisi = 0;

            public override int YemVer()
            {
                tavukCan = 100;
                return tavukCan;
            }

            public int TavukYumurtasıSat(int toplamTL)
            {
                toplam += tavukYumurtası * 1;
                return toplam + toplamTL;
            }

            bool IOlduMu.OlduMu()
            {
                if (tavukCan <= 0) //Tavuğun canı 0 veya daha az olursa öldüğünü doğruluyoruz.
                {
                    return true;
                }
                else //Tavuğun canı 0'dan fazlaysa ölmediği için false döndürüyoruz.
                    return false;
            }
            
        }

        public class Ordek : Canlı, IOlduMu
        {
            public int ordekYumurtası;
            public int ordekCan = 100;
            public int ordekSesCalmaSayisi = 0;

            public override int YemVer()
            {
                 ordekCan = 100;
                 return ordekCan;
            }

            public int OrdekYumurtasıSat(int toplamTL)
            {
                toplam += ordekYumurtası * 3;
                return toplam + toplamTL;
            }

            bool IOlduMu.OlduMu()
            {
                if (ordekCan <= 0) //Ördeğin canı 0 veya daha az olursa öldüğünü doğruluyoruz.
                {
                    return true;
                }
                else //Ördeğin canı 0'dan fazlaysa ölmediği için false döndürüyoruz.
                    return false;
            }
        }

        public class Inek : Canlı, IOlduMu
        {
            public int inekSutu;
            public int inekCan = 100;
            public int inekSesCalmaSayisi = 0;

            public override int YemVer()
            {
                 inekCan = 100;
                 return inekCan;
            }

            public int InekSutuSat(int toplamTL)
            {
                toplam += inekSutu * 5;
                return toplam + toplamTL;
            }

            bool IOlduMu.OlduMu()
            {
                if (inekCan <= 0) //İneğin canı 0 veya daha az olursa öldüğünü doğruluyoruz.
                {
                    return true;
                }
                else //İneğin canı 0'dan fazlaysa ölmediği için false döndürüyoruz.
                    return false;
            }
        }

        public class Keci : Canlı, IOlduMu
        {
            public int keciSutu;
            public int keciCan = 100;
            public int keciSesCalmaSayisi = 0;

            public override int YemVer()
            {
                keciCan = 100;
                return keciCan;
            }

            public int KeciSutuSat(int toplamTL)
            {
                toplam += keciSutu * 8;
                return toplam + toplamTL;
            }

            bool IOlduMu.OlduMu()
            {
                if (keciCan <= 0) //Keçinin canı 0 veya daha az olursa öldüğünü doğruluyoruz.
                {
                    return true;
                }
                else //Keçinin canı 0'dan fazlaysa ölmediği için false döndürüyoruz.
                    return false;
            }
        }

        Tavuk t1 = new Tavuk();
        Ordek o1 = new Ordek();
        Inek i1 = new Inek();
        Keci k1 = new Keci();

        int saniye = 0; 
        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            label25.Text = Convert.ToString(saniye) + " SN";
            t1.tavukCan -= 2;
            o1.ordekCan -= 3;
            i1.inekCan -= 8;
            k1.keciCan -= 6;

            IOlduMu tavukOlduMu = (IOlduMu)t1;
            IOlduMu ordekOlduMu = (IOlduMu)o1;
            IOlduMu inekOlduMu = (IOlduMu)i1;
            IOlduMu keciOlduMu = (IOlduMu)k1;

            if (!tavukOlduMu.OlduMu()) //Tavuk öldü mü diye kontrol ediyoruz.
            {
                progressBar1.Value = t1.tavukCan; // Ölmediyse güncel can değerini atıyoruz.
                if (saniye % 3 == 0) //Ölmediyse 3 saniyede bir ürün deposundaki tavuk yumurtasını 1 tane arttırıyoruz.
                {
                    t1.tavukYumurtası += 1;
                    label21.Text = t1.tavukYumurtası + " ADET";
                }
            }
            else //Tavuk öldüyse can değerini 0 olarak atıyoruz ve ses dosyasını çalıyoruz.
            {
                t1.tavukSesCalmaSayisi++;
                progressBar1.Value = 0;
                button5.Click -= button5_Click;
                label27.Text = "ÖLDÜ";
                if (t1.tavukSesCalmaSayisi == 1) //Ses dosyasının 1 kere çalması için
                {
                    System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
                    ses.SoundLocation = "tavuk.wav";
                    ses.Play();
                }
            }
                
            if (!ordekOlduMu.OlduMu()) //Ördek öldü mü diye kontrol ediyoruz.
            {
                progressBar2.Value = o1.ordekCan; // Ölmediyse güncel can değerini atıyoruz.
                if (saniye % 5 == 0)//Ölmediyse 5 saniyede bir ürün deposundaki ördek yumurtasını 1 tane arttırıyoruz.
                {
                    o1.ordekYumurtası += 1;
                    label22.Text = o1.ordekYumurtası + " ADET";
                }
            }
            else //Ördek öldüyse can değerini 0 olarak atıyoruz ve ses dosyasını çalıyoruz.
            {
                o1.ordekSesCalmaSayisi++;
                progressBar2.Value = 0;
                button6.Click -= button6_Click;
                label28.Text = "ÖLDÜ";
                if (o1.ordekSesCalmaSayisi == 1) //Ses dosyasının 1 kere çalması için
                {
                    System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
                    ses.SoundLocation = "ordek.wav";
                    ses.Play();
                }
            }
            
            if (!inekOlduMu.OlduMu()) //İnek öldü mü diye kontrol ediyoruz.
            {
                progressBar4.Value = i1.inekCan; // Ölmediyse güncel can değerini atıyoruz.
                if (saniye % 8 == 0) //Ölmediyse 8 saniyede bir ürün deposundaki inek sütünü 1 kg arttırıyoruz.
                {
                    i1.inekSutu += 1;
                    label23.Text = i1.inekSutu + " KG";
                }
            }
            else //İnek öldüyse can değerini 0 olarak atıyoruz ve ses dosyasını çalıyoruz.
            {
                i1.inekSesCalmaSayisi++;
                progressBar4.Value = 0;
                button8.Click -= button8_Click;
                label29.Text = "ÖLDÜ";
                if (i1.inekSesCalmaSayisi == 1) //Ses dosyasının 1 kere çalması için
                {
                    System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
                    ses.SoundLocation = "inek.wav";
                    ses.Play();
                }
                
            }

            if (!keciOlduMu.OlduMu()) //Keçi öldü mü diye kontrol ediyoruz.
            { 
                progressBar3.Value = k1.keciCan; // Ölmediyse güncel can değerini atıyoruz.
                if (saniye % 7 == 0)  //Ölmediyse 7 saniyede bir ürün deposundaki keçi sütünü 1 kg arttırıyoruz.
                {
                    k1.keciSutu += 1;
                    label24.Text = k1.keciSutu + " KG";
                }
            }
            else //Keçi öldüyse can değerini 0 olarak atıyoruz ve ses dosyasını çalıyoruz.
            {
                k1.keciSesCalmaSayisi++;
                progressBar3.Value = 0;
                button7.Click -= button7_Click;
                label30.Text = "ÖLDÜ";
                if (k1.keciSesCalmaSayisi == 1) //Ses dosyasının 1 kere çalması için
                {
                    System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
                    ses.SoundLocation = "keci.wav";
                    ses.Play();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        { 
            progressBar1.Value = t1.YemVer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            progressBar2.Value = o1.YemVer();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            progressBar3.Value = k1.YemVer();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            progressBar4.Value = i1.YemVer();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            label26.Text = Convert.ToString(t1.TavukYumurtasıSat(o1.toplam + i1.toplam + k1.toplam)) + " TL";
            t1.tavukYumurtası = 0;
            label21.Text = Convert.ToString(t1.tavukYumurtası) + " ADET";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label26.Text = Convert.ToString(o1.OrdekYumurtasıSat(t1.toplam + i1.toplam + k1.toplam)) + " TL";
            o1.ordekYumurtası = 0;
            label22.Text = Convert.ToString(o1.ordekYumurtası) + " ADET";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label26.Text = Convert.ToString(i1.InekSutuSat(t1.toplam + o1.toplam + k1.toplam)) + " TL";
            i1.inekSutu = 0;
            label23.Text = Convert.ToString(i1.inekSutu) + " KG";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label26.Text = Convert.ToString(k1.KeciSutuSat(t1.toplam + o1.toplam + i1.toplam)) + " TL";
            k1.keciSutu = 0;
            label24.Text = Convert.ToString(k1.keciSutu) + " KG";
        }
    }
}
