using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MasterYUGIOHAppFinal.Models;
using MasterYUGIOHAppFinal.Views;

namespace MasterYUGIOHAppFinal.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private MenuItemType ItemType;
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            IsBusy = true;
            ItemType = MenuItemType.link_monster_cards;
            Title = MenuItemType.link_monster_cards.ToString();
            Items = new ObservableCollection<Item>();

            //Aqui cargo los datos la primera vez!!!
            IsBusy = false;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

           
        }
        public ItemsViewModel(MenuItemType itemType)
        {
            ItemType = itemType;
            Title = itemType.ToString();
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}