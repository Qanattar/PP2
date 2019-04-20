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
        Double value = 0;
        String operation = "";
        bool operation_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (operation_pressed))
                result.Clear();
            operation_pressed = false;
            Button b = (Button)sender;
            result.Text = result.Text + b.Text;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }
        private void buttonC_Click(object sender, EventArgs e)
        {
            result.Clear();
            equation.Text = "";
            result.Text = "0";
            value = 0;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse(result.Text);
            operation_pressed = true;
            equation.Text = value + " " + operation;
        }
        public string k;
        public void buttonEqual_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "%":
                    result.Text = (value * Double.Parse(result.Text) / 100).ToString();
                    break;
                case "-":
                    result.Text = (value -(Double.Parse(result.Text))).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":  
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                case "x²":
                    result.Text = Convert.ToString(Math.Pow(Double.Parse(result.Text), 2));
                    break;
                case "⅟ ":
                    result.Text = Convert.ToString(1 / Double.Parse(result.Text));
                    break;

            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            operation_pressed = true;
            equation.Text = "√" + Double.Parse(result.Text) + " ="; 
            result.Text = Convert.ToString(Math.Sqrt(Double.Parse(result.Text)));
        }
    }
}
