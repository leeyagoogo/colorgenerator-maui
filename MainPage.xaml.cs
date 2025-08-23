
using System.Diagnostics;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
      
        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = slRed.Value;
                var green = slGreen.Value;
                var blue = slBlue.Value;

                Color color = Color.FromRgb(red, green, blue);

                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            Debug.WriteLine(color.ToString());
            this.BackgroundColor = color;
            btnRandom.BackgroundColor = color;
            lblHex.Text = color.ToHex();
            Overlay.Color = color;

        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();
            var color = Color.FromRgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));

            SetColor(color);

            slRed.Value = color.Red;
            slGreen.Value = color.Green;
            slBlue.Value = color.Blue;
            isRandom = false;
        }

        private async void ImageButtonColor(object sender, EventArgs e)
        {
            bool yes = await DisplayAlert("Color Generator", "Your color is generating on the way!", "OK", "Cancel");
            if (yes)
            {
                isRandom = true;
                var random = new Random();
                var color = Color.FromRgb(
                    random.Next(0, 256),
                    random.Next(0, 256),
                    random.Next(0, 256));

                SetColor(color);

                slRed.Value = color.Red;
                slGreen.Value = color.Green;
                slBlue.Value = color.Blue;
                isRandom = false;
            }

            else
            {

            }
        }
    }

}
