
namespace MasterYUGIOHAppFinal.Views
{

    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Models;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
        }

        public ItemsPage(MenuItemType type)
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel(type);
        }
    }
}