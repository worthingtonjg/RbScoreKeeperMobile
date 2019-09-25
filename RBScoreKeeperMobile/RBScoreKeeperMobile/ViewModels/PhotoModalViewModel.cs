using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RBScoreKeeperMobile.ViewModels
{
    public class PhotoModalViewModel : BaseViewModel
    {
        public ImageSource Photo { get; set; }

        public Command TakePhotoCommand { get; set; }

        public PhotoModalViewModel()
        {
            TakePhotoCommand = new Command(async() => await DoTakePhoto());
        }

        private async Task DoTakePhoto()
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if(photo != null)
            {
                SetValue(() => Photo, ImageSource.FromStream(() => { return photo.GetStream(); }));
            }
        }
    }
}
