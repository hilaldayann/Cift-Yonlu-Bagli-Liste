using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ödev2
{
    public partial class Form1 : Form
    {
        public class ciftDugum
        {
            public string ad;
            public string soyad;
            public int no;

            public ciftDugum sonraki;
            public ciftDugum onceki;
        }

        ciftDugum ilk = null;
        ciftDugum son = null;

        int sayac = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ciftDugum yeni = new ciftDugum();
            yeni.ad = textBox1.Text;
            yeni.soyad = textBox2.Text;
            yeni.no = Convert.ToInt32(textBox3.Text);

            if(ilk == null)
            {
                ilk = yeni;
                son = ilk;
                ilk.onceki = null;
                son.sonraki = null;
            }

            else
            {
                ilk.onceki = yeni;
                yeni.sonraki = ilk;
                ilk = yeni;
                yeni.onceki = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ciftDugum yeni = new ciftDugum();
            yeni.ad = textBox1.Text;
            yeni.soyad = textBox2.Text;
            yeni.no = Convert.ToInt32(textBox3.Text);
            int indeks = Convert.ToInt32(textBox4.Text);
            ciftDugum gecici = ilk;

            if (ilk == null && sayac >= 0)
            {
                ilk = yeni;
                son = ilk;
                ilk.onceki = null;
                son.sonraki = null;
                MessageBox.Show("Listede eleman olmadığından araya ekleme işleminiz gerçekleştirilemedi. Direkt olarak başa eklendi.");
            }

            else if (ilk == son && sayac > 0)
            {
                son.sonraki = yeni;
                yeni.onceki = son;
                son = yeni;
                son.sonraki = null;
                MessageBox.Show("Listede yalnızca bir eleman olduğundan araya ekleme işleminiz gerçekleştirilemedi. Direkt olarak sona eklendi.");
            }
            
            else if (ilk != null)
            {
                while (gecici.sonraki != null)
                {
                    if (gecici.no == indeks)
                    {
                        gecici.sonraki.onceki = yeni;
                        yeni.sonraki = gecici.sonraki;
                        gecici.sonraki = yeni;
                        yeni.onceki = gecici;
                        break;
                    }
                    
                    else
                    {
                        gecici = gecici.sonraki;
                    }
                }
                
                if (gecici == son && gecici.no == indeks)
                {
                    MessageBox.Show("Son elemandan sonra araya ekleme işlemi gerçekleştiremezsiniz.");
                }
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            ciftDugum yeni = new ciftDugum();
            yeni.ad = textBox1.Text;
            yeni.soyad = textBox2.Text;
            yeni.no = Convert.ToInt32(textBox3.Text);
            if(ilk == null)
            {
                ilk = yeni;
                son = ilk;
                ilk.onceki = null;
                son.sonraki = null;
            }
            
            else
            {
                son.sonraki = yeni;
                yeni.onceki = son;         
                son = yeni;               
                son.sonraki = null;
            }
        }
        
        private void listeyiYazdir(ciftDugum ilk)
        {
            richTextBox1.Text = null;
            richTextBox1.Text += "Listemiz : ";
            while (ilk != null)
            {
                richTextBox1.Text += "\n";
                richTextBox1.Text += ilk.ad + " : " + ilk.soyad + " : " + ilk.no.ToString() + " : " + "  -----  ";
                richTextBox1.Text += " --> ";
                ilk = ilk.sonraki;
                sayac++;
            }
            richTextBox1.Text += "null";
            richTextBox1.Text += "\n";
            richTextBox1.Text += "  " + (sayac) + " Tane Eleman Var";
            sayac = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listeyiYazdir(ilk);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(ilk == son)
            {
                ilk = null;
                son = null;
                //ilk.onceki = null;
                //son.sonraki = null;
            } 
            
            else     
            {
                ilk = ilk.sonraki;
                ilk.onceki = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int indeks = Convert.ToInt32(textBox5.Text);
            ciftDugum silinecek = new ciftDugum();
            ciftDugum gecici = new ciftDugum();
            silinecek = ilk;
            if (ilk.no == indeks)
            {
                MessageBox.Show("Baştaki elemanı silmeyi aradan silme butonu gerçekleştiremezsiniz.");
            }
            
            else if (son.no == indeks)
            {
                MessageBox.Show("Sondaki elemanı silmeyi aradan silme butonu gerçekleştiremezsiniz.");
            }
            
            else
            {
                while (silinecek.no != indeks)
                {
                    gecici = silinecek;
                    silinecek = silinecek.sonraki;
                }
                silinecek.onceki.sonraki = silinecek.sonraki;
                silinecek.sonraki.onceki = silinecek.onceki;
            }
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            if(ilk == son)
            {
                ilk = null;
                son = null;
                ////ilk.onceki = null;
                ////son.sonraki = null;
                //ilk.sonraki = null;
                //son.onceki = null;
            }  
            
            else   
            {
                son = son.onceki;
                son.sonraki = null;
            }
        }
    }
}