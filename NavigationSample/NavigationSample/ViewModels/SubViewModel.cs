using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NavigationSample.MVVM;
using NavigationSample.Services.Core;
using NavigationSample.ViewModels.Core;

namespace NavigationSample.ViewModels {
    public class SubViewModel : ISubViewModel, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigationService navigationService;

        public ICommand GoBackCommand { get; }

        private string something;
        public string Something {
            get { return this.something; }
            set {
                this.something = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Something)));
            }
        }

        public SubViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
            this.GoBackCommand = new RelayCommand(NavigateBack);
        }

        public void Configure(string something) {
            this.Something = something;
        }

        private async void NavigateBack() {
            await this.navigationService.GoBackAsync();
        }

        public Task ActivateAsync()
            => Task.FromResult(0);
    }
}
