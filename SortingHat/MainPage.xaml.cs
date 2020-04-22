using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SortingHat
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public int index = -1;


        public MainPage()
        {
            InitializeComponent();
            listView.BindingContext = Questions.All;

            NextQuestion();
        }

        void OnItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e == null) return;
            ((ListView)sender).SelectedItem = null;
        }

        void OnLeftButtonClicked(object sender, EventArgs args)
        {
            Houses.All[Questions.All[index].Affirmative].Points++;
            NextQuestion();
        }

        void OnRightButtonClicked(object sender, EventArgs args)
        {
            Houses.All[Questions.All[index].Negative].Points++;
            NextQuestion();
        }

        private void NextQuestion()
        {
            index++;
            //DisplayAlert("positive points /n negitive points", Houses.All[Questions.All[index].Affirmative].Points.ToString() + "/n"+
            //    Houses.All[Questions.All[index].Negative].Points.ToString(), "ok");
            if (index < Questions.All.Count)
            {

                //Question.Text = Questions.All[index].Prompt;
                //Left_Button.Text = Questions.All[index].Left;
                //Right_Button.Text = Questions.All[index].Right;
            }
            else
            {

                int Result_House_Points = 0;
                string Result_House = "";
                foreach (Houses home in Houses.All)
                {
                    if (home.Points > Result_House_Points)
                    {
                        Result_House = home.Name;
                        Result_House_Points = home.Points;
                    }
                }
                listView.IsVisible = false;
                HouseName.IsVisible = true;
                HouseImage.IsVisible = true;
                string Image_Name = Result_House.ToLower() + ".jpg";
                HouseName.Text = Result_House;
                HouseImage.Source = Image_Name;
                //Banner.IsVisible = true;

                //Question.Text = Result_House;
                //Banner.Source = Image_Name;
            }

        }
    }
}
