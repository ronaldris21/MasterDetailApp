using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MasterYUGIOHAppFinal.Models;

namespace MasterYUGIOHAppFinal.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<MenuItemType, NavigationPage> MenuPages = new Dictionary<MenuItemType, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //Defino el Detail
            Detail = new NavigationPage(new ItemsPage());

            MenuPages.Add(MenuItemType.link_monster_cards, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItemType id)
        {

            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuItemType.monster_cards:
                        break;
                    case MenuItemType.ritual_monster_cards:
                        break;
                    case MenuItemType.link_monster_cards:
                        break;
                    case MenuItemType.synchro_monster_cards:
                        break;
                    case MenuItemType.xyz_monster_cards:
                        break;
                    case MenuItemType.pendulum_monster_cards:
                        break;
                    case MenuItemType.spell_cards:
                        break;
                    case MenuItemType.trap_cards:
                        break;
                    default:
                        break;
                }
                //Ahorita solo lo agrego una vez porque reusare la vista!
                MenuPages.Add(id, new NavigationPage(new ItemsPage(id)));
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}