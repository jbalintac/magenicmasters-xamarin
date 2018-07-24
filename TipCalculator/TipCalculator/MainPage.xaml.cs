using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TipCalculator
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            TipPercent.Value = 15;
		}

        private void RoundUp_Clicked(object sender, EventArgs e)
        {
            Calculate();

            var total = Convert.ToDecimal(Total.Text.Substring(1));
            var roundedUp  = Math.Ceiling(total); 
            Total.Text = $"${roundedUp.ToString("0.00")}"; 
        }

        private void RoundDown_Clicked(object sender, EventArgs e)
        {
            Calculate();

            var total = Convert.ToDecimal(Total.Text.Substring(1));
            var roundedDown = Math.Floor(total);
            Total.Text = $"${roundedDown.ToString("0.00")}";
        }

        private void TipPercent_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            TipPercentage.Text = Convert.ToInt32(TipPercent.Value).ToString() + "%";
            Calculate();
        }

        private void BillAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        private void FifteenPercent_Clicked(object sender, TextChangedEventArgs e)
        {
            TipPercent.Value = 15;
            Calculate();
        }

        private void TwentyPercent_Clicked(object sender, TextChangedEventArgs e)
        {
            TipPercent.Value = 20;
            Calculate();
        }

        private void Calculate()
        {
            var billAmount = 0M;

            if(!string.IsNullOrWhiteSpace(BillAmount.Text))
                billAmount = Convert.ToDecimal(BillAmount.Text);

            var tipPercent = Convert.ToInt32(TipPercent.Value) / 100M;
            var tipAmount = billAmount * tipPercent;
            var totalAmount = billAmount + tipAmount;

            Tip.Text = $"${tipAmount.ToString("0.00")}";
            Total.Text = $"${totalAmount.ToString("0.00")}";
        }

    }
}
