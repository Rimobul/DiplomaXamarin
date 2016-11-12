using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace CameraAndLocation.ViewModels
{
    public class CameraViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The picture chooser.
        /// </summary>
        private IMediaPicker _mediaPicker;
        private ImageSource _imageSource;
        private string _status;
        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

        public CameraViewModel()
        {
            TakePictureCommand = new Command(
                async () => await TakePicture(),
                () => true);
        }

        public ICommand TakePictureCommand { get; private set; }

        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                if(_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Status
        {
            get { return _status; }
            private set
            {
                if(_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public string GPSTest { get { return "WIP"; } }

        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task<MediaFile> TakePicture()
        {
            Setup();

            ImageSource = null;

            return await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Status = t.Exception.InnerException.ToString();
                }
                else if (t.IsCanceled)
                {
                    Status = "Canceled";
                }
                else
                {
                    var mediaFile = t.Result;

                    ImageSource = ImageSource.FromStream(() => mediaFile.Source);

                    return mediaFile;
                }

                return null;
            }, _scheduler);
        }

        private void Setup()
        {
            if (_mediaPicker != null)
            {
                return;
            }

            var device = Resolver.Resolve<IDevice>();

            ////RM: hack for working on windows phone? 
            _mediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
        }
    }
}