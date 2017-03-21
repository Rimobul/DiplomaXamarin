using NativeUIElement.Dependencies;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace NativeUIElement.ViewModels
{
    public class RandomViewModel : INotifyPropertyChanged
    {
        private double currentValue;

        public RandomViewModel()
        {
            GenerateRandomNumber = new Command(() => GenerateRandomNumberImplementation());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double Max { get { return 1; } }

        public string CurrentPercentage { get { return (CurrentValue * 100).ToString("0.") + "%"; } }

        public double CurrentValue
        {
            get { return currentValue; }
            set
            {
                if(currentValue != value)
                {
                    currentValue = value;
                    OnPropertyChanged();
                    OnPropertyChanged("CurrentPercentage");
                }
            }
        }

        public ICommand GenerateRandomNumber { get; private set; }

        private void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void GenerateRandomNumberImplementation()
        {
            CurrentValue = DependencyService.Get<IRandomProvider>()
                .GenerateRandomPercentage();
        }
    }
}
