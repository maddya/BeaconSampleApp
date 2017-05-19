using Estimotes;
using Xamarin.Forms;

namespace BeaconForms
{
    public partial class BeaconFormsPage : ContentPage
    {
        BeaconService beacons;

        bool UserAlerted;

        public BeaconFormsPage()
        {
            beacons = new BeaconService();
            beacons.Initialize();
            InitializeComponent();

            UserAlerted = false;


			EstimoteManager.Instance.Ranged += (sender, beacons) =>
			{
                if (!UserAlerted)
                {
                    DisplayAlert("You're in that range", null, "cool");
                    UserAlerted = true;
                }
                EstimoteManager.Instance.StopRanging(new BeaconRegion("estimote", "B9407F30-F5F8-466E-AFF9-25556B57FE6D"));
			};
        }
    }
}
