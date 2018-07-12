using ReproiOSGroupedListIssuer.Shared;

namespace ReproiOSGroupedListIssuer
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }
}
