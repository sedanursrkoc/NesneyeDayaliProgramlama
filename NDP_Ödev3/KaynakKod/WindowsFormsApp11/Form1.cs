/****************************************************************************
**					    SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					    2018-2019 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 3
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Contains('*')) //İşlemde çarpım durumu var mı kontrolünü yapıyoruz 
            {
                
                 string[] gecici = textBox1.Text.Split('+');

                 string [] artiDizi = new string[gecici.Length];


                 //İşlemi önce '+' işlemine göre ayırıyoruz ve değerleri atıyoruz
                 for (int j = 0; j < gecici.Length; j++)
                 {
                     artiDizi[j] = gecici[j];
                 }

                 //Sadece çarpım işlemlerini yapacağımız için '+' işaretinin nerde olduğunu kaybetmemek için
                 //kendinden önceki elemanın sonuna ekliyoruz.
                 for (int i = 0; i < artiDizi.Length - 1; i++)
                 {
                     artiDizi[i] += "+";
                 }

                 int geciciDeger = 0;
                 for (int i = 0; i < artiDizi.Length; i++) // '-' işaretine göre böldüğümüzde kaç eleman olacağını hesaplıyoruz
                 {
                     gecici = artiDizi[i].Split('-');
                     for (int j = 0; j < gecici.Length; j++)
                     {
                         geciciDeger++;
                     }
                 }
                
               
                int yeniDiziElemanı = 0;
                int operatorSayi = 0;

                string[] eksiDizi = new string[geciciDeger];

                //Artı dizi elemanlarımızı '-' operatörüne göre parçalıyoruz.
                for (int i = 0; i < artiDizi.Length; i++)
                {
                    gecici = artiDizi[i].Split('-');

                    //Artı dizisinin her bir elemanı için gecici diziye atadığımız elemanları asıl diziye atıyoruz.
                    for (int j = 0; j < gecici.Length; j++) 
                    {
                        eksiDizi[yeniDiziElemanı] = gecici[j];

                        //Sadece çarpım işlemlerini yapacağımız için '-' işaretinin nerde olduğunu kaybetmemek için
                        //kendinden önceki elemanın sonuna ekliyoruz.
                        if (artiDizi[i].Contains('-') && operatorSayi < gecici.Length - 1 && yeniDiziElemanı < eksiDizi.Length - 1)
                        {
                            eksiDizi[yeniDiziElemanı] += "-";
                        }
                        yeniDiziElemanı++; operatorSayi++;
                    }
                    operatorSayi = 0;
                }

                geciciDeger = 0;
                for (int i = 0; i < eksiDizi.Length; i++) //Eksi dizisini '/' operatörüne göre parçalıyoruz.
                {
                    gecici = eksiDizi[i].Split('/');
                    for (int j = 0; j < gecici.Length; j++) // '/' işaretine göre böldüğümüzde kaç eleman olacağını hesaplıyoruz.
                    {
                        geciciDeger++;
                    }
                }

                string[] bolumDizi = new string[geciciDeger];
                yeniDiziElemanı = 0; operatorSayi = 0;

                for (int i = 0; i < eksiDizi.Length; i++) //Eksi dizi elemanlarımızı '/' operatörüne göre parçalıyoruz.
                {
                    gecici = eksiDizi[i].Split('/');

                    //Eksi dizisinin her bir elemanı için gecici diziye atadığımız elemanları asıl diziye atıyoruz.
                    for (int j = 0; j < gecici.Length; j++)
                    {
                        bolumDizi[yeniDiziElemanı] = gecici[j];

                        //Sadece çarpım işlemlerini yapacağımız için '/' işaretinin nerde olduğunu kaybetmemek için
                        //kendinden önceki elemanın sonuna ekliyoruz.
                        if (eksiDizi[i].Contains('/') && operatorSayi < gecici.Length - 1 && yeniDiziElemanı < bolumDizi.Length - 1)
                        {
                            bolumDizi[yeniDiziElemanı] += "/"; 
                        }
                        yeniDiziElemanı++; operatorSayi++;
                    }
                    operatorSayi = 0;
                }

                string operator_;
                for (int i = 0; i < bolumDizi.Length; i++) //Çarpım işlemlerini bu döngüde gerçekleştiriyoruz.
                {
                    if (bolumDizi[i].Contains('*')) //Bölüm dizisinde '*' operatör kontrolü yapılıyor.
                    {
                        //Bölüm dizisinin '*' içeren elemanı '+' operatörü içeriyorsa artı işaretini atıyoruz.
                        if (bolumDizi[i].Contains('+'))
                        {
                            operator_ = "+";
                            gecici = bolumDizi[i].Split('+');
                            gecici = gecici[0].Split('*');

                            //Çarpım işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.   
                            //Attığımız operatörü yeni elemanın yanına ekliyoruz.
                            for (int j = 0; j < gecici.Length - 1; j++)
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) * Convert.ToDouble(gecici[j + 1]));
                                bolumDizi[i] = gecici[j + 1] + operator_;
                            }
                        }

                        //Bölüm dizisinin '*' içeren elemanı '-' operatörü içeriyorsa eksi işaretini atıyoruz.
                        else if (bolumDizi[i].Contains('-'))
                        {
                            operator_ = "-";
                            gecici = bolumDizi[i].Split('-');

                            gecici = gecici[0].Split('*');

                            //Çarpım işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.   
                            //Attığımız operatörü yeni elemanın yanına ekliyoruz.
                            for (int j = 0; j < gecici.Length - 1; j++)
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) * Convert.ToDouble(gecici[j + 1]));
                                bolumDizi[i] = gecici[j + 1] + operator_;
                            }
                        }

                        //Bölüm dizisinin '*' içeren elemanı '/' operatörü içeriyorsa bölüm işaretini atıyoruz.
                        else if (bolumDizi[i].Contains('/'))
                        {
                            operator_ = "/";
                            gecici = bolumDizi[i].Split('/');

                            gecici = gecici[0].Split('*');

                            //Çarpım işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.   
                            //Attığımız operatörü yeni elemanın yanına ekliyoruz.
                            for (int j = 0; j < gecici.Length - 1; j++)
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) * Convert.ToDouble(gecici[j + 1]));
                                bolumDizi[i] = gecici[j + 1] + operator_;
                            }
                        }

                        //Bölüm dizisinin '*' içeren elemanı operatör içermiyorsa
                        else
                        {
                            gecici[0] = bolumDizi[i];
                            gecici = gecici[0].Split('*');

                            //Çarpım işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.   
                            for (int j = 0; j < gecici.Length - 1; j++)
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) * Convert.ToDouble(gecici[j + 1]));
                                bolumDizi[i] = gecici[j + 1];
                            }
                        }

                    }
                }

                for (int i = 1; i < bolumDizi.Length; i++) //İşlemimizde çarpım işlemlerinin yerine
                {                                          // sonuc değerleri yazan yeni işlemi oluşturuyoruz.
                    bolumDizi[0] += bolumDizi[i];
                }

                textBox2.Text = bolumDizi[0];
                
            }
            else //İşlemi değiştirmemek için güncel işlemi 2. textbox'a atıyoruz
            {
                textBox2.Text = textBox1.Text;
            }

            if (textBox2.Text.Contains('/')) //İşlemde bölüm durumu var mı kontrolünü yapıyoruz 
            {
                
                string[] gecici = textBox2.Text.Split('+');

                string[] artiDizi = new string[gecici.Length];



                for (int j = 0; j < gecici.Length; j++) //İşlemi önce '+' işlemine göre ayırıyoruz ve değerleri atıyoruz
                {
                    artiDizi[j] = gecici[j];
                }

                //Sadece bölüm işlemlerini yapacağımız için '+' işaretinin nerde olduğunu kaybetmemek için
                //kendinden önceki elemanın sonuna ekliyoruz.
                for (int i = 0; i < artiDizi.Length - 1; i++)
                {
                    artiDizi[i] += "+";
                }

                int geciciDeger = 0;
                for (int i = 0; i < artiDizi.Length; i++) // '-' işaretine göre böldüğümüzde kaç eleman olacağını hesaplıyoruz
                {
                    gecici = artiDizi[i].Split('-');
                    for (int j = 0; j < gecici.Length; j++)
                    {
                        geciciDeger++;
                    }
                }

                int yeniDiziElemanı = 0;
                int operatorSayi = 0;
                string[] eksiDizi = new string[geciciDeger];

                //Artı dizi elemanlarımızı '-' operatörüne göre parçalıyoruz.
                for (int i = 0; i < artiDizi.Length; i++)
                {
                    gecici = artiDizi[i].Split('-');

                    //Artı dizisinin her bir elemanı için gecici diziye atadığımız elemanları asıl diziye atıyoruz.
                    for (int j = 0; j < gecici.Length; j++) 
                    {
                        eksiDizi[yeniDiziElemanı] = gecici[j];

                        //Sadece bölme işlemlerini yapacağımız için '-' işaretinin nerde olduğunu kaybetmemek için
                        //kendinden önceki elemanın sonuna ekliyoruz.
                        if (artiDizi[i].Contains('-') && operatorSayi < gecici.Length - 1 && yeniDiziElemanı < eksiDizi.Length - 1)
                        {
                            eksiDizi[yeniDiziElemanı] += "-";
                        }
                        yeniDiziElemanı++; operatorSayi++;
                    }
                    operatorSayi = 0;
                }

                string operator_;
                for (int i = 0; i < eksiDizi.Length; i++) //Bölme işlemlerini bu döngüde gerçekleştiriyoruz.
                {
                    if (eksiDizi[i].Contains('/')) //Eksi dizisinde '/' operatör kontrolü yapılıyor.
                    {
                        if (eksiDizi[i].Contains('+'))  //Eksi dizisinin '/' içeren elemanı '+' operatörü içeriyorsa artı işaretini atıyoruz.
                        {
                            operator_ = "+";
                            gecici = eksiDizi[i].Split('+');

                            gecici = gecici[0].Split('/');

                            //Bölme işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.   
                            //Attığımız operatörü yeni elemanın yanına ekliyoruz.
                            for (int j = 0; j < gecici.Length - 1; j++)
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) / Convert.ToDouble(gecici[j + 1]));
                                eksiDizi[i] = gecici[j + 1] + operator_;
                            }
                        }

                        else if (eksiDizi[i].Contains('-')) //Eksi dizisinin '/' içeren elemanı '-' operatörü içeriyorsa eksi işaretini atıyoruz.
                        {
                            operator_ = "-";
                            gecici = eksiDizi[i].Split('-');

                            gecici = gecici[0].Split('/');

                            //Bölme işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.   
                            //Attığımız operatörü yeni elemanın yanına ekliyoruz.
                            for (int j = 0; j < gecici.Length - 1; j++)
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) / Convert.ToDouble(gecici[j + 1]));
                                eksiDizi[i] = gecici[j + 1] + operator_;
                            }
                        }

                        else //Eksi dizisinin '/' içeren elemanı operatör içermiyorsa
                        {
                            gecici[0] = eksiDizi[i];
                            gecici = gecici[0].Split('/');

                            //Bölme işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.
                            for (int j = 0; j < gecici.Length - 1; j++)  
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) / Convert.ToDouble(gecici[j + 1]));
                                eksiDizi[i] = gecici[j + 1];
                            }
                        }
                    }
                }

                for (int i = 1; i < eksiDizi.Length; i++) //İşlemimizde bölme işlemlerinin yerine
                {                                         // sonuc değerleri yazan yeni işlemi oluşturuyoruz.
                    eksiDizi[0] += eksiDizi[i];
                }

                textBox2.Text = eksiDizi[0];

            }

            if (textBox2.Text.Contains('-')) //İşlemde çıkarma durumu var mı kontrolünü yapıyoruz 
            {

                string[] gecici = textBox2.Text.Split('+');

                string[] artiDizi = new string[gecici.Length];



                for (int j = 0; j < gecici.Length; j++) //İşlemi önce '+' işlemine göre ayırıyoruz ve değerleri atıyoruz
                {
                    artiDizi[j] = gecici[j];
                }

                //Sadece çıkarma işlemlerini yapacağımız için '+' işaretinin nerde olduğunu kaybetmemek için
                //kendinden önceki elemanın sonuna ekliyoruz.
                for (int i = 0; i < artiDizi.Length - 1; i++)
                {
                    artiDizi[i] += "+";
                }

                int geciciDeger = 0;
                for (int i = 0; i < artiDizi.Length; i++) // '-' işaretine göre böldüğümüzde kaç eleman olacağını hesaplıyoruz
                {
                    gecici = artiDizi[i].Split('-');
                    for (int j = 0; j < gecici.Length; j++)
                    {
                        geciciDeger++;
                    }
                }

                string operator_;
                for (int i = 0; i < artiDizi.Length; i++) //Çıkarma işlemlerini bu döngüde gerçekleştiriyoruz.
                {
                    if (artiDizi[i].Contains('-')) //Artı dizisinde '-' operatör kontrolü yapılıyor.
                    {
                        if (artiDizi[i].Contains('+')) //Artı dizisinin '-' içeren elemanı '+' operatörü içeriyorsa artı işaretini atıyoruz.
                        {
                            operator_ = "+";
                            gecici = artiDizi[i].Split('+');

                            gecici = gecici[0].Split('-');

                            //Çıkarma işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.   
                            //Attığımız operatörü yeni elemanın yanına ekliyoruz.
                            for (int j = 0; j < gecici.Length - 1; j++)
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) - Convert.ToDouble(gecici[j + 1]));
                                artiDizi[i] = gecici[j + 1] + operator_;
                            }
                        }

                        else //Artı dizisinin '-' içeren elemanı operatör içermiyorsa
                        {
                            gecici[0] = artiDizi[i];
                            gecici = gecici[0].Split('-');

                            //Çıkarma işlemi gerçekleştiriliyor ve sonuç değerini dizinin elemanının yeni değeri olarak atıyoruz.
                            for (int j = 0; j < gecici.Length - 1; j++)
                            {
                                gecici[j + 1] = Convert.ToString(Convert.ToDouble(gecici[j]) - Convert.ToDouble(gecici[j + 1]));
                                artiDizi[i] = gecici[j + 1];
                            }
                        }
                    }     
                }

                for (int i = 1; i < artiDizi.Length; i++) //İşlemimizde çıkarma işlemlerinin yerine
                {                                         // sonuc değerleri yazan yeni işlemi oluşturuyoruz.
                    artiDizi[0] += artiDizi[i];
                }

                textBox2.Text = artiDizi[0];

            }

            if (textBox2.Text.Contains('+')) // İşlemde toplama durumu var mı kontrolünü yapıyoruz
            {
                double sonuc = 0;
                string[] artiDizi = textBox2.Text.Split('+');

                sonuc = Convert.ToDouble(artiDizi[0]);

                for (int i = 1; i < artiDizi.Length; i++) // '+' operatörüne göre böldüğümüz işlemin her bir dizi elemanını 
                {                                         //sonuc değerine ekliyoruz.
                    sonuc += Convert.ToDouble(artiDizi[i]);

                }

                textBox2.Text = Convert.ToString(sonuc);

            }
        }
    }
}
