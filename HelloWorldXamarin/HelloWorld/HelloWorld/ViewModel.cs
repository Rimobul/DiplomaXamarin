using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld
{
    public class ViewModel : INotifyPropertyChanged
    {
        private bool helloWorldVisible;

        public string ButtonText { get { return "Click me!"; } }

        public bool HelloWorldVisible
        {
            get
            {
                return helloWorldVisible;
            }
            set
            {
                if(helloWorldVisible != value)
                {
                    helloWorldVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HelloWorldText { get { return "Hello world!"; } }

        public ICommand ToggleCommand { get { return new Command(() => this.HelloWorldVisible = !this.HelloWorldVisible); } }

        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
