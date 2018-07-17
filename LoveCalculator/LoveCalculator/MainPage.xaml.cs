using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace LoveCalculator
{
    public partial class MainPage : ContentPage
	{

        private const string FLAMES = "FLAMES";
        private readonly List<Tuple<char,string, string>> RESULT_LIST;

        public MainPage()
		{
			InitializeComponent();
            ResultView.IsVisible = false;

            RESULT_LIST = new List<Tuple<char, string, string>>
            {
                new Tuple<char, string, string>('F', "Friends", "You both will have an amazing friendship forever"),
                new Tuple<char, string, string>('L', "Lovers", "You guys love each other. True lovers" ),
                new Tuple<char, string, string>('A', "Attraction", "You are attracted to each other for many reasons." ),
                new Tuple<char, string, string>('M', "Married", "You will get married to your partner very soon." ),
                new Tuple<char, string, string>('E', "Enemies", "Lot of hate. You will be enemies and won't take to each other" ),
                new Tuple<char, string, string>('S', "Siblings",  "You both are great siblings and care for each other." )
            };
        }

        private void CheckFlames_Clicked(object sender, EventArgs e)
        {
            if(YourName.Text == null || YourName.Text.Length == 0)
            {
                DisplayAlert(null, "Your Name is empty", "Ok");
                ResultView.IsVisible = false;
                return;
            }

            if (PartnerName.Text == null || PartnerName.Text.Length == 0)
            {
                DisplayAlert(null, "Partner Name is empty", "Ok");
                ResultView.IsVisible = false;
                return;
            }

            var flames = GetFlames(YourName.Text, PartnerName.Text);
            var relationship = RESULT_LIST.ToDictionary(l => l.Item1, l => l.Item2 )[flames];
            var meaningResult = RESULT_LIST.ToDictionary(l => l.Item1, l => l.Item3 )[flames];
            
            RelationshipResult.Text = relationship;
            MeaningResult.Text = meaningResult;

            ResultView.IsVisible = true;
        }


        private char GetFlames(string firstname, string secondname)
        {
            var nameCollisionLength = GetFlamesNameCount(firstname, secondname);
            return GetFlamesLetter(nameCollisionLength);
        }

        private static char GetFlamesLetter(int nameCollisionLength)
        {
            var flames = FLAMES;

            do
            {
                var currentFlamesLenght = flames.Length;
                var currentIndex = nameCollisionLength;

                while (currentIndex > currentFlamesLenght)
                {
                    currentIndex -= currentFlamesLenght;
                }

                var flamesTobeRemoved = Convert.ToChar(flames.ElementAt(currentIndex - 1));
                var grouped = flames.Split(flamesTobeRemoved);

                flames = grouped.Count() > 1 ? grouped[1] + grouped[0] : grouped[0];

            } while (flames.Length > 1);

            return Convert.ToChar(flames);
        }

        private int GetFlamesNameCount(string firstname, string secondname)
        {
            var cleanFirst = firstname.ToUpperInvariant();
            var cleanSecond = secondname.ToUpperInvariant();

            var firstRemove = new List<char>(cleanFirst);
            var secondRemove = new List<char>(cleanSecond);

            secondRemove.Remove(' ');
            foreach (var item in cleanFirst)
            {
                secondRemove.Remove(item);
            }

            firstRemove.Remove(' ');
            foreach (var item in cleanSecond)
            {
                firstRemove.Remove(item);
            }

            var nameCollisionLength = firstRemove.Union(secondRemove);
            var result = new List<char>();
            result.AddRange(firstRemove);
            result.AddRange(secondRemove);

            return result.Count();
        }
      



    }
}
