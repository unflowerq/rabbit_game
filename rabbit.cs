using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 소실과제마지막_2
{
    public partial class Form1 : Form
    {
        int maximum = 500;
        int minimum = 0;
        int speed = 8;
        int star = 2;
        int score = 0;
        int life = 10;
        int scorelevel = 500;
        int level = 1;
        int cloudspeed = 5;
        
        Thread clo;
        Thread angryrabit;

        Thread makefruit;      
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox2;
            pictureBox4.Parent = pictureBox2;
            //pictureBox5.Parent = pictureBox2;            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad4)
            {
                timer1.Interval = 20;
                timer1.Enabled = true;
            }

            if (e.KeyCode == Keys.NumPad6)
            {
                timer2.Interval = 20;
                timer2.Enabled = true;
            }

            if (e.KeyCode == Keys.Q)
            {
                if (speed > 1)
                {
                    speed--;
                    label6.Text = Convert.ToString(speed);
                }
            }

            else if (e.KeyCode == Keys.W)
            {
                speed++;
                label6.Text = Convert.ToString(speed);
            }
            //무적토끼
            if (e.KeyCode == Keys.E)
            {
                if (star == 0)
                {

                }

                else
                {
                    star--;
                    label4.Text = Convert.ToString(star);

                    pictureBox3.Image = global::소실과제마지막_2.Properties.Resources.화난토끼;
                    pictureBox3.Name = "화가나";
                    angryrabit = new Thread(new ThreadStart(AngryRabit));
                    angryrabit.Start();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manual mn = new Manual();
            mn.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            button4.Enabled = false;

            clo = new Thread(new ThreadStart(cloud));
            clo.Start();

            timer3.Interval = 1000;
            timer3.Enabled = true;

            if (timer1.Enabled == true)
                timer1.Enabled = false;
            if (timer2.Enabled == true)
                timer2.Enabled = false;
        }

        private void cloud()
        {
            while (true)
            {
                Random ran = new Random(unchecked((int)DateTime.Now.Ticks));

                int loc = ran.Next(minimum, maximum-30);

                if (pictureBox4.Location.X - loc > 0)
                {
                    for (int i = pictureBox4.Location.X; i > loc; i-=cloudspeed)
                    {
                        Thread.Sleep(30);
                        if (pictureBox4.Location.X > minimum)
                        {
                            this.Invoke(new MethodInvoker(delegate () { pictureBox4.Location 
                                = new Point(pictureBox4.Location.X - cloudspeed, pictureBox4.Location.Y); }));                            
                        }
                    }
                }

                else if (pictureBox4.Location.X - loc < 0)
                {
                    for (int i = pictureBox4.Location.X; i < loc; i+=cloudspeed)
                    {
                        Thread.Sleep(30);
                        if (pictureBox4.Location.X > minimum)
                        {
                            this.Invoke(new MethodInvoker(delegate () { pictureBox4.Location 
                                = new Point(pictureBox4.Location.X + cloudspeed, pictureBox4.Location.Y); }));
                        }
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            clo.Abort();
            makefruit.Abort();
            //fallfruit.Abort();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            clo.Abort();
            makefruit.Abort();
            //fallfruit.Abort();
        }

        private void AngryRabit()
        {
            System.Threading.Thread.Sleep(3000);
            pictureBox3.Image = global::소실과제마지막_2.Properties.Resources.토끼;
            pictureBox3.Name = "화가안나";
        }

        public void MakeFruit()
        {
            if (label2.Text == "0")
            {
                timer3.Enabled = false;
                timer1.Enabled = false;
                timer2.Enabled = false;
                
                clo.Abort();
                this.Invoke(new MethodInvoker(delegate () { button4.Enabled = true; }));
                MessageBox.Show("Game Over");

                speed = 8;
                star = 2;
                score = 0;
                life = 10;
                level = 1;
                cloudspeed = 5;

                this.Invoke(new MethodInvoker(delegate () {
                    label2.Text = life.ToString();
                    label4.Text = star.ToString();
                    label6.Text = speed.ToString();
                    label8.Text = score.ToString();
                    label10.Text = level.ToString();
                }));
            }
            
            int firstlocX = pictureBox4.Location.X + 25;
            int firstlocY = pictureBox4.Location.Y;
            
            int k = 1;
            int j = 0;
            
            Random ran = new Random(unchecked((int)DateTime.Now.Ticks));

            int randFruit = ran.Next(0, 14);
            
            PictureBox fruit = new PictureBox();

            switch (randFruit)
            {
                case 0:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_apple; }));
                    break;
                case 1:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_bomb; }));
                    break;
                case 2:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_cherry; }));
                    break;
                case 3:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_grapes; }));
                    break;
                case 4:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_heart; }));
                    break;
                case 5:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_kiwi; }));
                    break;
                case 6:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_orange; }));
                    break;
                case 7:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_pear; }));
                    break;
                case 8:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_pineapple; }));
                    break;
                case 9:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_star; }));
                    break;
                case 10:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_strawberry; }));
                    break;
                case 11:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_watermelon; }));
                    break;
                case 12:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_bomb; }));
                    break;
                case 13:
                    this.Invoke(new MethodInvoker(delegate () { fruit.Image = global::소실과제마지막_2.Properties.Resources.f_bomb; }));
                    break;
            }

            Point a1 = new Point(firstlocX + 20, firstlocY);
            this.Invoke(new MethodInvoker(delegate ()
            {
                fruit.Parent = pictureBox2;
                fruit.SizeMode = PictureBoxSizeMode.StretchImage;
                fruit.Size = new Size(31, 31);
                fruit.Location = a1;
                fruit.BackColor = Color.Transparent;
            }));

            while (a1.Y <= 310)
            {
                Thread.Sleep(50);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    fruit.Location = a1;
                }));

                ++j;

                a1.Y = a1.Y + k + j;
            }

            if (fruit.Location.X >= pictureBox3.Location.X -20 && fruit.Location.X <= pictureBox3.Location.X + 66)
            {
                this.Invoke(new MethodInvoker(delegate () {
                    fruit.Location = new Point(0, 0);
                    fruit.Dispose();
                }));
                
                if (score == scorelevel * level)
                {
                    level++;
                    this.Invoke(new MethodInvoker(delegate () { label10.Text = level.ToString(); }));
                    cloudspeed++;
                }

                switch (randFruit)
                {
                    case 0:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 1:
                        if (pictureBox3.Name == "화가나")
                        {
                            break;
                        }

                        else
                        {
                            life--;
                            this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                            break;
                        }
                    case 2:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 3:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 4:
                        life++;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 5:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 6:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 7:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 8:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 9:
                        star++;
                        this.Invoke(new MethodInvoker(delegate () { label4.Text = Convert.ToString(star); }));
                        break;
                    case 10:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 11:
                        score += 50;
                        this.Invoke(new MethodInvoker(delegate () { label8.Text = Convert.ToString(score); }));
                        break;
                    case 12:
                        if (pictureBox3.Name == "화가나")
                        {
                            break;
                        }

                        else
                        {
                            life--;
                            this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                            break;
                        }
                    case 13:
                        if (pictureBox3.Name == "화가나")
                        {
                            break;
                        }

                        else
                        {
                            life--;
                            this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                            break;
                        }
                }
                return;
            }

            while (a1.Y <= 470)
            {
                Thread.Sleep(50);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    fruit.Location = a1;
                }));

                ++j;

                a1.Y = a1.Y + k + j;
            }

            if (a1.Y > 460)
            {
                switch (randFruit)
                {
                    case 0:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 2:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 3:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 5:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 6:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 7:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 8:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 10:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                    case 11:
                        life--;
                        this.Invoke(new MethodInvoker(delegate () { label2.Text = Convert.ToString(life); }));
                        break;
                }
                this.Invoke(new MethodInvoker(delegate () { fruit.Dispose(); }));
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            speed--;
            label6.Text = Convert.ToString(speed);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            speed++;
            label6.Text = Convert.ToString(speed);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Location.X >= minimum)
                pictureBox3.Location = new Point(pictureBox3.Location.X - speed, pictureBox3.Location.Y);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Location.X <= maximum-50)
                pictureBox3.Location = new Point(pictureBox3.Location.X + speed, pictureBox3.Location.Y);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad4)
            {
                timer1.Enabled = false;

            }
            else if (e.KeyCode == Keys.NumPad6)
            {
                timer2.Enabled = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(score == scorelevel*level)
            {
                timer3.Interval -= 50;
            }

            makefruit = new Thread(new ThreadStart(MakeFruit));
            makefruit.Start();
        }
    }
}
