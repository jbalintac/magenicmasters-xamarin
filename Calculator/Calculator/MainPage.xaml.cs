using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public enum Operations
    {
        NotSet = 0,
        Plus = 1,
        Minus,
        Multiply,
        Divided
    }

    public partial class MainPage : ContentPage
    {
        public decimal CurrentValue { get; set; } = 0;
        public decimal PreviousValue { get; set; } = 0;
        public Operations PreviousOperation { get; set; } =  Operations.NotSet;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_7_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "7";
        }

        private void Button_8_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "8";
        }

        private void Button_9_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "9";
        }

        private void Button_Div_Clicked(object sender, EventArgs e)
        {
            if (PreviousOperation == Operations.Divided)
            {
                PreviousValue = PreviousValue / Convert.ToDecimal(LedDisplay.Text);
                LedDisplay.Text = PreviousValue.ToString();
                return;
            }

            PreviousValue = Convert.ToDecimal(LedDisplay.Text);
            PreviousOperation = Operations.Divided;

            LedDisplay.Text = "0";
        }

        private void Button_4_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "4";
        }

        private void Button_5_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "5";
        }

        private void Button_6_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "6";
        }

        private void Button_1_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "1";
        }

        private void Button_2_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "2";
        }

        private void Button_3_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "3";
        }

        private void Button_Min_Clicked(object sender, EventArgs e)
        {
            if (PreviousOperation == Operations.Minus)
            {
                PreviousValue = PreviousValue - Convert.ToDecimal(LedDisplay.Text);
                LedDisplay.Text = PreviousValue.ToString();
                return;
            }

            PreviousValue = Convert.ToDecimal(LedDisplay.Text);
            PreviousOperation = Operations.Minus;

            LedDisplay.Text = "0";
        }

        private void Button_0_Clicked(object sender, EventArgs e)
        {
            if (LedDisplay.Text == "0")
                LedDisplay.Text = "";

            LedDisplay.Text += "0";
        }

        private void Button_Pls_Clicked(object sender, EventArgs e)
        {
            if (PreviousOperation == Operations.Plus)
            {
                PreviousValue = PreviousValue + Convert.ToDecimal(LedDisplay.Text);
                LedDisplay.Text = PreviousValue.ToString();
                return;
            }

            PreviousValue = Convert.ToDecimal(LedDisplay.Text);
            PreviousOperation = Operations.Plus;

            LedDisplay.Text = "0";
        }

        private void Button_C_Clicked(object sender, EventArgs e)
        {
            LedDisplay.Text = "0";
        }

        private void Button_Eql_Clicked(object sender, EventArgs e)
        {
            if(PreviousOperation == Operations.Plus)
                LedDisplay.Text = (PreviousValue + Convert.ToDecimal(LedDisplay.Text)).ToString();

            if (PreviousOperation == Operations.Minus)
                LedDisplay.Text = (PreviousValue - Convert.ToDecimal(LedDisplay.Text)).ToString();

            if (PreviousOperation == Operations.Multiply)
                LedDisplay.Text = (PreviousValue * Convert.ToDecimal(LedDisplay.Text)).ToString();

            if (PreviousOperation == Operations.Divided)
            {
                if(Convert.ToDecimal(LedDisplay.Text) == 0M)
                {
                    LedDisplay.Text = "Cannot divide by zero";
                    PreviousOperation = Operations.NotSet;
                    return;
                }

                LedDisplay.Text = (PreviousValue / Convert.ToDecimal(LedDisplay.Text)).ToString();
            }

            PreviousOperation = Operations.NotSet;
        }

        private void Button_Mul_Clicked(object sender, EventArgs e)
        {
            if (PreviousOperation == Operations.Multiply)
            {
                PreviousValue = PreviousValue * Convert.ToDecimal(LedDisplay.Text);
                LedDisplay.Text = PreviousValue.ToString();
                return;
            }

            PreviousValue = Convert.ToDecimal(LedDisplay.Text);
            PreviousOperation = Operations.Multiply;

            LedDisplay.Text = "0";
        }
    }
}
