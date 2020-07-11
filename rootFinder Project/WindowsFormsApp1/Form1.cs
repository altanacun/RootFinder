using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

            
          

           

        }

        //NEWTON RAPHSON

         double epsilonNewton = 0.001;
         double funcnewton(double x)
        {
            //READING EQUATION
            string function = textBox3.Text;

            var xinserter = function.Replace("x", Convert.ToString(x));
            Mathos.Parser.MathParser parser = new Mathos.Parser.MathParser();
            double result = parser.Parse(xinserter);

            return result;

        }
         double derivative(double x)
        {
            //READING EQUATION
            string function = textBox4.Text;
            var xinserter = function.Replace("x", Convert.ToString(x));
            Mathos.Parser.MathParser parser = new Mathos.Parser.MathParser();
            double result = parser.Parse(xinserter);
            return result;
        }

        public void newtonRaphson(double x)
        {
            double h = funcnewton(x) / derivative(x);
            while (Math.Abs(h) >= epsilonNewton)
            {
                h = funcnewton(x) / derivative(x);

                x = x - h;
            }

           
           richTextBox1.Text = "The value of the root is : " + Math.Round(x * 100.0) / 100.0;

            //CALCULATING THE ERROR PERCENTAGE
            double errorStep1 = (Math.Round(x * 100.0) / 100.0 - x) / Math.Round(x * 100.0) / 100.0;
            double errorStep2 = errorStep1 * 100;
            richTextBox2.Text = "The absolute error percentage is : " + errorStep2 + "%";
        }


        //SECANT
        float f(float x)
        {
            //READING EQUATION
            float f = 0;

            string function = textBox3.Text;

            var xinserter = function.Replace("x", Convert.ToString(x));
            Mathos.Parser.MathParser parser = new Mathos.Parser.MathParser();
            double result = parser.Parse(xinserter);
            f = float.Parse(result.ToString());     
            return f;
        }
        public void secant(float x1, float x2,
                       float E)

        {
            float n = 0, xm, x0, c;
            if (f(x1) * f(x2) < 0)
            {
                do
                {

                    x0 = (x1 * f(x2) - x2 * f(x1))
                        / (f(x2) - f(x1));

                    c = f(x1) * f(x0);
                    x1 = x2;
                    x2 = x0;

                    n++;

                    if (c == 0)
                        break;
                    xm = (x1 * f(x2) - x2 * f(x1))
                        / (f(x2) - f(x1));

                }

                while (Math.Abs(xm - x0) >= E);

                richTextBox1.Text = "Root of the given equation = " + x0 + "\n";
            



                richTextBox1.AppendText("Number of iterations = " + n);
            }

            else {
                richTextBox1.AppendText("Can not find a root in the given inteval");
                }
            //CALCULATING THE ERROR PERCENTAGE
            double errorStep1 = (x2 - x1) / x2;
            double errorStep2 = errorStep1 * 100;
            richTextBox2.Text = "The absolute error percentage is : " + errorStep2 + "%";


        }


        // BISECTION

         float EPSILON = (float)0.01;

         double funcbisection(double x)
        {


            //READING EQUATION
            
            string function = textBox3.Text;

            var xinserter = function.Replace("x", Convert.ToString(x));
            Mathos.Parser.MathParser parser = new Mathos.Parser.MathParser();
            double result = parser.Parse(xinserter);

            return result;

        }

         void bisection(double a, double b)
        {
            if (funcbisection(a) * funcbisection(b) >= 0)
            {
                richTextBox1.Text = "You have not assumed right X0 and X1";
                return;
            }

            double c = a;
            while ((b - a) >= EPSILON)
            {
                c = (a + b) / 2;

                if (funcbisection(c) == 0.0)
                    break;

                else if (funcbisection(c) * funcbisection(a) < 0)
                    b = c;
                else
                    a = c;
            }

            richTextBox1.Text = "The value of root is : " + c;
            //CALCULATING THE ERROR PERCENTAGE
            double errorStep1 = (c - b)/b;
            double errorStep2 = errorStep1 * 100;
            richTextBox2.Text ="The absolute error percentage is : " + errorStep2 + "%";


        }


        private void Form1_Load(object sender, EventArgs e)
		{
            textBox4.Visible = false;
            label9.Visible = false;
            label10.Visible = false;


        }

		private void button1_Click(object sender, EventArgs e)
		{
            if (radioButton1.Checked == true && textBox1.Text != "" && textBox2.Text != "")
            {
                float x1 = Convert.ToInt32(textBox1.Text);
                float x2 = Convert.ToInt32(textBox2.Text);
                float E = 0.0001f;
                secant(x1, x2, E);
            }
            else if (radioButton2.Checked == true && textBox1.Text != "" && textBox2.Text != "")
            {
                double a = Convert.ToInt32(textBox1.Text), b = Convert.ToInt32(textBox2.Text);
                bisection(a, b);
            }
            else if (radioButton3.Checked == true && textBox1.Text != "" && textBox4.Text != "")
            {
                double x0 = Convert.ToDouble(textBox1.Text);
                newtonRaphson(x0);
            }
            else
            {
                MessageBox.Show("Please fill & check all entries");
            }
         
		}

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked == true)
            {
                textBox2.Text = "";
                textBox4.Text = "";
                textBox2.Visible = false;
                label3.Visible = false;
                textBox4.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
            }
            else if (radioButton3.Checked == false)
            {
                textBox2.Visible = true;
                label3.Visible = true;
                textBox4.Visible = false;
                label9.Visible = false;
                textBox2.Text = "";
                textBox4.Text = "";
                label10.Visible = false;

            }
        }

      
    }
}
