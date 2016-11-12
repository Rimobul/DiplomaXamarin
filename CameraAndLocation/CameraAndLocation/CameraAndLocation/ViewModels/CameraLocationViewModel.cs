using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Media;
using System;
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
        private string locationStatus;

        public CameraLocationViewModel()
        {
            locationStatus = "Location off";
            TakePhoto = new Command(async () => await TakePhotoImplementation());
            GetLocation = new Command(async () => await GetLocationImplementation());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AlertDelegate AlertDisplayer { get; set; }

        public ICommand TakePhoto { get; private set; }

        public ICommand GetLocation { get; private set; }

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

        public string LocationStatus
        {
            get { return locationStatus; }
            set
            {
                if(locationStatus != value)
                {
                    locationStatus = value;
                    OnPropertyChanched();
                }
            }
        }

        private async Task GetLocationImplementation()
        {
            try
            {
                var locator = CrossGeolocator.Current;

                if(!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    await AlertDisplayer?.Invoke("No geolocation", "Geolocation is not allowed or not available.", "OK");
                    return;
                }

                locator.DesiredAccuracy = 50;
                LocationStatus = "Starting location...";
                var position = await locator.GetPositionAsync();
                ChangeLocationText(position);
                LocationStatus = "Location on";
                locator.PositionChanged += PositionChanged;
            }
            catch (Exception ex)
            {
                await AlertDisplayer?.Invoke("No geolocation", ex.Message, "OK");
            }
        }

        private void PositionChanged(object sender, PositionEventArgs e)
        {
            ChangeLocationText(e.Position);
        }

        private void ChangeLocationText(Position position)
        {
            if (position == null) return;

            var north = position.Latitude > 0 ? "N" : "S";
            var east = position.Longitude > 0 ? "E" : "W";

            LocationText = Math.Abs(position.Latitude).ToString()
                + " " + north
                + Math.Abs(position.Longitude).ToString()
                + " " + east;
        }

        private async Task TakePhotoImplementation()
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await AlertDisplayer?.Invoke("No Camera", ":( No camera available.", "OK");
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

            await AlertDisplayer?.Invoke("File Location", file.Path, "OK");

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
