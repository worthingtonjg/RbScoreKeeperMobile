using RBScoreKeeperMobile.Models;
using RBScoreKeeperMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RBScoreKeeperMobile.ViewModels
{
    public class FlicsViewModel : BaseViewModel
    {
        public List<Flic> Flics { get; set; }
        public bool AddingFlic { get; set; }
        public string NewFlicName { get; set; }
        public Command AddFlicCommand { get; set; }
        public Command DeleteFlicCommand { get; set; }
        public Command CancelAddFlicCommand { get; set; }
        public Command SaveFlicCommand { get; set; }

        public FlicsViewModel()
        {
            AddFlicCommand = new Command(() => {
                SetValue(() => NewFlicName, string.Empty);
                SetValue(() => AddingFlic, true);
            });


            CancelAddFlicCommand = new Command(() =>
            {
                SetValue(() => AddingFlic, false);
            });

            SaveFlicCommand = new Command(async () => await DoSaveFlicCommand());
            DeleteFlicCommand = new Command(async (o) => await DoDeleteFlicCommand(o));
        }

        private async Task DoDeleteFlicCommand(object o)
        {
            Flic f = o as Flic;
            await HttpHelper.Instance.DeleteAsync($"flics/{f.FlicId}");
            SetValue(() => AddingFlic, false);
            await LoadAsync();
        }

        private async Task DoSaveFlicCommand()
        {
            await HttpHelper.Instance.PostAsync($"flics?name={NewFlicName}", "");
            SetValue(() => AddingFlic, false);
            await LoadAsync();
        }

        internal async Task LoadAsync()
        {
            var flics = await HttpHelper.Instance.GetListAsync<Flic>("flics");
            SetValue(() => Flics, flics);
        }
    }
}
