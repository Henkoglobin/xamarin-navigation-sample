using System.Threading.Tasks;
using System.Windows.Input;
using NavigationSample.MVVM;
using NavigationSample.Services.Core;
using NavigationSample.ViewModels.Core;

namespace NavigationSample.ViewModels {
    public class MainViewModel : IMainViewModel {
        private INavigationService navigationService;

        public ICommand SubCommand { get; }

        public MainViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
            this.SubCommand = new RelayCommand(Navigate);
        }

        private async void Navigate() {
            var viewModel = await this.navigationService.NavigateAsync<ISubViewModel>();
            viewModel.Configure("This is awesome!");
        }

        public Task ActivateAsync()
            => Task.FromResult(0);
    }
}
