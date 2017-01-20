using System;
using System.Threading.Tasks;
using NavigationSample.Pages;
using NavigationSample.Services;
using NavigationSample.Services.Core;
using NavigationSample.ViewModels;
using NavigationSample.ViewModels.Core;
using Xamarin.Forms;

namespace NavigationSample {
    public partial class App : Application, IAppNavigationResolver {
        public App() {
            InitializeComponent();

            var container = new UnityDependencyContainer()
                .Register<ISubViewModel, SubViewModel>()
                .Register<IMainViewModel, MainViewModel>();

            var navigationService = new NavigationService(this, container);
            container.Register<INavigationService>(navigationService);

            navigationService
                .RegisterPage<IMainViewModel, MainPage>()
                .RegisterPage<ISubViewModel, SubPage>();

            var viewModel = container.Resolve<IMainViewModel>();
            viewModel.ActivateAsync();

            MainPage = new NavigationPage(new MainPage() {
                BindingContext = viewModel
            });
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }

        public async Task NavigateAsync<TViewModel>(Type pageType, TViewModel viewModel)
            where TViewModel : IViewModel {
            var page = (Page)Activator.CreateInstance(pageType);
            page.BindingContext = viewModel;

            await ((NavigationPage)this.MainPage).Navigation.PushAsync(page);
        }

        public async Task<IViewModel> GoBackAsync() {
            await ((NavigationPage)this.MainPage).Navigation.PopAsync();

            var newPage = ((NavigationPage)this.MainPage).CurrentPage;
            return (IViewModel)newPage.BindingContext;
        }
    }
}
