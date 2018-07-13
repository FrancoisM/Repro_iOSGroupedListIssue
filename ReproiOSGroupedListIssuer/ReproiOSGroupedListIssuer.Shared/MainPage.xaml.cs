using ReproiOSGroupedListIssuer.Shared;

namespace ReproiOSGroupedListIssuer
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }
}
