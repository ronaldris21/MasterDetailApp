using MasterYUGIOHAppFinal.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterYUGIOHAppFinal.ViewModels
{
    public class ItemsViewModel : MvvmHelpers.BaseViewModel
    {
        private MenuItemType ItemType;
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            IsBusy = true;
            ItemType = MenuItemType.link_monster_cards;
            Title = MenuItemType.link_monster_cards.ToString();
            //Cargo los datos del Json, primer tanda!

            //Aqui cargo los datos la primera vez!!!
            IsBusy = false;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

           
        }
        public ItemsViewModel(MenuItemType itemType)
        {
            ItemType = itemType;
            Title = itemType.ToString();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //Aqui halo los datos que requiero

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