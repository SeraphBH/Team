using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
            textBox1.GotFocus += new EventHandler(textBox1_GotFocus);
            textBox1.LostFocus += new EventHandler(textBox1_LostFocus);
            textBox2.GotFocus += new EventHandler(textBox2_GotFocus);
            textBox2.LostFocus += new EventHandler(textBox2_LostFocus);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter1);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter2);
        }

        private void CheckEnter1(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox1.Text != "" && textBox1.Text != "Homme")
                {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Text = "";
                }
                
            }
        }
        private void CheckEnter2(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox2.Text != "" && textBox2.Text != "Femme")
                {
                    listBox2.Items.Add(textBox2.Text);
                    textBox2.Text = "";
                }
               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox1.Text != "Homme")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != "Femme")
            {
                listBox2.Items.Add(textBox2.Text);
                textBox2.Text = "";
            }
        }

        private void textBox1_GotFocus(Object sender, EventArgs e)
        {
            textBox1.Text = "";
         }
        private void textBox1_LostFocus(Object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            textBox1.Text = "Homme";
        }
        private void textBox2_GotFocus(Object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
        private void textBox2_LostFocus(Object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            textBox2.Text = "Femme";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public int Azdine(int limite)
        {
                 int nProcessId = Process.GetCurrentProcess().Id;
            Random randomClass = new Random(DateTime.Now.Millisecond * nProcessId);
            int preRandom = randomClass.Next(0, Int32.MaxValue);
            int randomNumber = randomClass.Next(0, Int32.MaxValue) * preRandom;

            randomNumber = (randomNumber < 0) ? (randomNumber * (-1)) : (randomNumber);
            randomNumber %= limite;

            return randomNumber;
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            
            String Homme = "";
            String Femme = "";
          
            //int[] Tab= new int[10]{1,9,9,9,5,8,9,8,7,4};
            int Homme1 = listBox1.Items.Count;
            int Femme1 = listBox2.Items.Count;

          Random randomClass = new Random(DateTime.Now.Millisecond);
          int A = Azdine(Homme1);
          int B = Azdine(Femme1);
            
            //int A = randomClass.Next(0, Homme1);
            //int B = randomClass.Next(0, Femme1);
            if (Homme1 > 0 && Femme1 > 0)
                label1.Text = "Couple Mixte";
            else if (Homme1 == 0 || Femme1 == 0)
                label1.Text = "Couple Non Mixte";


            if (Homme1 == 0 && Femme1 == 0)
            label1.Text = "Plus de couple Possible";

            else if (Homme1 == 1 && Femme1 == 0)
            label1.Text = "Plus de couple Possible";

            else if (Homme1 == 0 && Femme1 == 1)
            label1.Text = "Plus de couple Possible";
                
            else if (Homme1 >= 1 && Femme1 >= 1)
            {
             Homme = listBox1.Items[A].ToString();
             textBox3.Text = Homme + " ";
             listBox1.Items.RemoveAt(A);
             Femme = listBox2.Items[B].ToString();
             textBox3.Text += Femme + " ";
             listBox2.Items.RemoveAt(B);
             
            }
            else if (Femme1 >= 2)
            {
                Femme = listBox2.Items[B].ToString();
                textBox3.Text = Femme + " ";
                listBox2.Items.RemoveAt(B);

                Femme1 = listBox1.Items.Count;
                B = Azdine(Femme1);
                //B = randomClass.Next(0, Femme1);

                Femme = listBox2.Items[B].ToString();
                textBox3.Text += Femme + " ";
                listBox2.Items.RemoveAt(B);
            }
            else if (Homme1 >= 2)
            {
                Homme = listBox1.Items[A].ToString();
                textBox3.Text = Homme + " ";
                listBox1.Items.RemoveAt(A);

                Homme1 = listBox1.Items.Count;
                A = Azdine(Homme1);
                //A = randomClass.Next(0, Homme1);

                Homme = listBox1.Items[A].ToString();
                textBox3.Text += Homme + " ";
                listBox1.Items.RemoveAt(A);
            }
            
        
        }
    }
}
