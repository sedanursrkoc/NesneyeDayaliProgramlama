/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2014-2015 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1
**				ÖĞRENCİ ADI............: Sedanur SARIKOÇ
**				ÖĞRENCİ NUMARASI.......: B181210110
**              DERSİN ALINDIĞI GRUP...: 1C
****************************************************************************/


using System;
using System;
using System;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[] satirlar;
        public string[] kelimeler;
        public string bilgiler;
        public string[] parcaliBilgiler;
        public double burutMaas;
        public double damgaVergisi;
        public double gelirVegisi;
        public double emekliKesintisi;
        public double netMaas;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Seçilen dosyayı programda açar
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Text Files|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] readText = File.ReadAllLines(openFileDialog1.FileName);
                richTextBox1.LoadFile(openFileDialog1.FileName,
                  RichTextBoxStreamType.PlainText);
            }

            bilgiler = "TC:^Adi:^Soyadi:^Yas:^Çalışma süresi:^Evlilik durumu:^Eşi çalışıyor mu:^Çocuk sayısı:^Taban maas:^Makam tazminatı:^İdari görev tazminatı:^Fazla mesai saati:^Fazla mesai saat ücreti:^Vergi matrahı:^Personel resmi yolu:";
            parcaliBilgiler = bilgiler.Split('^');

            string hepsi = richTextBox1.Text;
            satirlar = hepsi.Split('\n'); //dosya satırlara ayrılıyor

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox2.Clear();
            pictureBox1.Image = null;

            //dosyadaki her satırı kelimelere ayırıp girilen tc değerine göre kontrol yapılır
            foreach (string s in satirlar)
            {
                kelimeler = s.Split(' ');

                //Dosyadaki tc ile girdiğimiz değer eşleşirse gerekli işlemler yapılarak net maaş yazdırılır
                if (kelimeler[0] == textBox1.Text)
                {
                    //Girilen tc'ye göre personel bilgileri yazdırılır
                    for (int i = 0; i < kelimeler.Length; i++)
                    {
                        listBox1.Items.Add(" " + parcaliBilgiler[i] + " " + kelimeler[i]);
                    }

                    pictureBox1.Image = Image.FromFile(kelimeler[14]);

                    {
                        //Bürüt maaş hesaplanır
                        if (kelimeler[5] == "B") //bekarsa
                        {
                            burutMaas = Convert.ToDouble(kelimeler[8]) + Convert.ToDouble(kelimeler[9]) + Convert.ToDouble(kelimeler[10])
                                     + (Convert.ToDouble(kelimeler[7])) * 30 + (Convert.ToDouble(kelimeler[11])) * (Convert.ToDouble(kelimeler[12]));
                        }
                        else if (kelimeler[5] == "E" && kelimeler[6] == "E") //evli ve eşi çalışıyorsa
                        {
                            burutMaas = Convert.ToDouble(kelimeler[8]) + Convert.ToDouble(kelimeler[9]) + Convert.ToDouble(kelimeler[10])
                                     + (Convert.ToDouble(kelimeler[7])) * 30 + (Convert.ToDouble(kelimeler[11])) * (Convert.ToDouble(kelimeler[12]));
                        }
                        else //evli ve eşi çalışmıyorsa
                        {
                            burutMaas = Convert.ToDouble(kelimeler[8]) + Convert.ToDouble(kelimeler[9]) + Convert.ToDouble(kelimeler[10])
                                     + (Convert.ToDouble(kelimeler[7])) * 30 + (Convert.ToDouble(kelimeler[11])) * (Convert.ToDouble(kelimeler[12]))
                                     + Convert.ToDouble(200);
                        }
                        listBox1.Items.Add(" ");
                        listBox1.Items.Add(" " + "Bürüt Maaş: " + burutMaas.ToString());
                    }

                    damgaVergisi = (burutMaas * 10) / 100;
                    listBox1.Items.Add(" " + "Damga Vergisi: " + damgaVergisi.ToString());

                    {
                        //Vergi matrahı hangi aralıktaysa ona göre gelir vergisi hesaplanır
                        if (Convert.ToInt32(kelimeler[13]) < 10000)
                        {
                            gelirVegisi = (burutMaas * 15) / 100;
                        }
                        else if (Convert.ToInt32(kelimeler[13]) >= 10000 && Convert.ToInt32(kelimeler[13]) < 20000)
                        {
                            gelirVegisi = (burutMaas * 20) / 100;
                        }
                        else if (Convert.ToInt32(kelimeler[13]) >= 20000 && Convert.ToInt32(kelimeler[13]) < 30000)
                        {
                            gelirVegisi = (burutMaas * 25) / 100;
                        }
                        else
                        {
                            gelirVegisi = (burutMaas * 30) / 100;
                        }
                        listBox1.Items.Add(" " + "Gelir Vergisi: " + gelirVegisi.ToString());
                    }

                    emekliKesintisi = (burutMaas * 15) / 100;
                    listBox1.Items.Add(" " + "Emekli Kesintisi: " + emekliKesintisi.ToString());

                    netMaas = burutMaas - (emekliKesintisi + gelirVegisi + damgaVergisi);

                    textBox2.Text = netMaas.ToString();
                }
            }
           
            if (!(textBox2.Text == netMaas.ToString())) //Tc yanlış girilmişse ekrana hata mesajı çıkartır
            {
                MessageBox.Show("Hatalı tc girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

            
    

