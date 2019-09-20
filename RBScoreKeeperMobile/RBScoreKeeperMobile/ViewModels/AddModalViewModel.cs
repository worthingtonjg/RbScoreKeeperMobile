using RBScoreKeeperMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RBScoreKeeperMobile.ViewModels
{
    public class AddModalViewModel : BaseViewModel
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public string NamePlaceholder
        {
            get { return $"New {Type} Name"; }
        }

        public Command SaveCommand { get; set; }
        
        public AddModalViewModel(INavigation navigation, string type)
        {
            Navigation = navigation;
            Type = type;

            SaveCommand = new Command(() => MessagingCenter.Send(this, $"DoSave{Type}", Name));
        }
    }
}
