using Plugin.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CameraAndLocation.ViewModels
{
    public delegate Task AlertDelegate(string title, string message, string cancel);

    public class CameraLocationViewModel : INotifyPropertyChanged
    {
        private string locationText;
        private ImageSource photoSource;

        public CameraLocationViewModel()
        {
            TakePhoto = new Command(async () => await TakePhotoImplementation());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AlertDelegate AlertDisplayer { get; set; }

        public ICommand TakePhoto { get; private set; }

        public ImageSource PhotoSource
        {
            get { return photoSource; }
            set
            {
                if(photoSource != value)
                {
                    photoSource = value;
                    OnPropertyChanched();
                }
            }
        }

        public string LocationText
        {
            get { return locationText; }
            set
            {
                if(locationText != value)
                {
                    locationText = value;
                    OnPropertyChanched();
                }
            }
        }

        private async Task TakePhotoImplementation()
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await AlertDisplayer("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                AllowCropping = false,
                Directory = "Sample",
                Name = "test.jpg",
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
                return;

            await AlertDisplayer("File Location", file.Path, "OK");

            PhotoSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private void OnPropertyChanched([CallerMemberName]string name = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
