using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atYarisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        int horse1, horse2, horse3;
        Random random = new Random();
        double tutar;
        int finish = 0;
        int giris = 0;
        public void atOranlari()
        {
            //Nazilli Oran
            nazilliOran1 = random.NextDouble() + random.Next(1, 4);
            nazilliOran1 = Math.Round(nazilliOran1, 2);
            nazilliOran.Text = Convert.ToString(nazilliOran1);
            //Yadigar Oran
            yadigarOran1 = random.NextDouble() + random.Next(1, 4);
            yadigarOran1 = Math.Round(yadigarOran1, 2);
            yadigarOran.Text = Convert.ToString(yadigarOran1);
            //Kara Şimşek Oran
            karaSimsekOran1 = random.NextDouble() + random.Next(1, 4);
            karaSimsekOran1 = Math.Round(karaSimsekOran1, 2);
            karaSimsekOran.Text = Convert.ToString(karaSimsekOran1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            balance -= Convert.ToDouble(textBox1.Text);
            if (balance >= 0)
            {
                timer1.Enabled = true;
                comboBox1.Enabled = false;
                //İddiayı Bakiyeye işleme
                tutar = Convert.ToDouble(textBox1.Text);
                bakiye.Text = Convert.ToString(balance);

                //Hangi At seçildiği kontrolü
                if (comboBox1.SelectedIndex == 0)
                {
                    finish = 1;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    finish = 2;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    finish = 3;
                }
            }
            //Bakiye - düşürmeme
            else if (balance<0)
            {
                balance += Convert.ToDouble(textBox1.Text);
                MessageBox.Show("Bakiyeniz Yeterli Değil. Lütfen Hesabınıza Para Yatırınız.");
            }

            
            
        }
        double balance = 50.00;
        double yadigarOran1, nazilliOran1, karaSimsekOran1;

        private void button2_Click(object sender, EventArgs e)
        {
            balance += 50;
            bakiye.Text = balance + " ₺";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Atları eski haline getirme
            timer1.Enabled = false;
            pictureBox1.Left = 12;
            pictureBox2.Left = 12;
            pictureBox3.Left = 12;
            label5.Text = "";
            comboBox1.Enabled = true;
            atOranlari();
            button1.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Para Çekme
            balance -= 50;
            bakiye.Text = Convert.ToString(balance);
        }

        int nazilliGo, yadigarGo, karaSimsekGo;
        private void Form1_Load(object sender, EventArgs e)
        {

            horse1 = pictureBox1.Left;
            horse2 = pictureBox2.Left;
            horse3 = pictureBox3.Left;
            balance = Math.Round(balance, 2);
            bakiye.Text = balance + " ₺";

            atOranlari();
            if (nazilliOran1 >= yadigarOran1)
            {

                if (nazilliOran1 > karaSimsekOran1)
                {
                    nazilliGo = 4;
                    if (karaSimsekOran1 > yadigarOran1)
                    {
                        karaSimsekGo = 5;
                        yadigarGo = 6;
                    }
                    else if (yadigarOran1 > karaSimsekOran1)
                    {
                        karaSimsekGo = 6;
                        yadigarGo = 5;
                    }
                    else
                    {
                        karaSimsekGo = 5;
                        yadigarGo = 5;
                    }
                }
                else
                {
                    yadigarGo = 6;
                    nazilliGo = 5;
                    karaSimsekGo = 4;
                }

            }
            else
            {
                if (yadigarOran1 > karaSimsekOran1)
                {
                    yadigarGo = 4;
                    if (karaSimsekOran1 > nazilliOran1)
                    {
                        karaSimsekGo = 5;
                        nazilliGo = 6;
                    }
                    else if (karaSimsekOran1 < nazilliOran1)
                    {
                        karaSimsekGo = 6;
                        nazilliGo = 5;
                    }
                    else
                    {
                        karaSimsekGo = 5;
                        nazilliGo = 5;
                    }

                }
                else
                {
                    karaSimsekGo = 4;
                    nazilliGo = 6;
                    yadigarGo = 5;
                }
            }


        }
        double nazilliFinish, yadigarFinish, karaSimsekFinish;
        string[] atAd ={"Nazilli", "Yadigar", "Kara Şimsek"};
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            int horse1Width = pictureBox1.Width;
            int horse2Width = pictureBox2.Width;
            int horse3Width = pictureBox3.Width;

            //Atların İlerleyişi
            pictureBox1.Left += random.Next(0, nazilliGo+20);
            pictureBox2.Left += random.Next(0, yadigarGo+20);
            pictureBox3.Left += random.Next(0, karaSimsekGo+20);
           

            //Kazanan Kontrolü
            if (pictureBox1.Right >= label1.Left)
            {
                timer1.Enabled = false;
                label5.Text = ("Nazilli Yarışı Kazandı.");
                if(finish==1)
                {
                    balance = balance + (nazilliOran1 * tutar);
                    bakiye.Text = Convert.ToString(balance);
                }
                
            }
            else if (pictureBox2.Right >= label1.Left)
            {
                timer1.Enabled = false;
                label5.Text = ("Yadigar Yarışı Kazandı.");
                if (finish == 2)
                {
                    balance = balance +(yadigarOran1 * tutar);
                    bakiye.Text = Convert.ToString(balance);
                }
            }
            else if (pictureBox3.Right >= label1.Left)
            {
                timer1.Enabled = false;
                label5.Text = ("Kara Şimşek Yarışı Kazandı.");
                if (finish == 3)
                {
                    balance = balance + (karaSimsekOran1 * tutar);
                    bakiye.Text = Convert.ToString(balance);
                }

            }
            button1.Enabled = false;

            //Devamlı Önde Kontrolü
            if(pictureBox1.Right>pictureBox2.Right && pictureBox1.Right>pictureBox3.Right)
            {
                 if (pictureBox1.Right < label1.Left)
                    label5.Text = "Nazilli Yarışı Önde Götürüyor.";
            }
            
            else if(pictureBox2.Right>pictureBox1.Right && pictureBox2.Right>pictureBox3.Right)
            {
                if (pictureBox2.Right < label1.Left)
                    label5.Text = "Yadigar Yarışı Önde Götürüyor.";
            }
            else if(pictureBox3.Right>pictureBox2.Right && pictureBox3.Right>pictureBox1.Right)
            {
                if (pictureBox3.Right < label1.Left)
                    label5.Text = "Kara Şimşek Yarışı Önde Götürüyor.";
            }
        }
        
    }
}
