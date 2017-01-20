using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NavigationSample.Services.Core;
using NavigationSample.ViewModels.Core;

namespace NavigationSample.Services {
    public class NavigationService : INavigationService {
        private readonly IAppNavigationResolver appNavigationResolver;
        private readonly IDependencyContainer dependencyContainer;
        private readonly Dictionary<Type, Type> registeredPages = new Dictionary<Type, Type>();

        public NavigationService(
            IAppNavigationResolver appNavigationResolver,
            IDependencyContainer dependencyContainer
        ) {
            this.appNavigationResolver = appNavigationResolver;
            this.dependencyContainer = dependencyContainer;
        }


        public async Task<IViewModel> GoBackAsync() {
            var viewModel = await this.appNavigationResolver.GoBackAsync();
            await viewModel.ActivateAsync();

            return viewModel;
        }

        public async Task<TViewModel> NavigateAsync<TViewModel>()
            where TViewModel : IViewModel {
            Type pageType;
            if (!registeredPages.TryGetValue(typeof(TViewModel), out pageType)) {
                throw new InvalidOperationException($"No View registered for ViewModel type {typeof(TViewModel).Name}");
            }

            var viewModel = this.dependencyContainer.Resolve<TViewModel>();

            await viewModel.ActivateAsync();

            await this.appNavigationResolver.NavigateAsync(pageType, viewModel);
            return viewModel;
        }

        public INavigationService RegisterPage<TViewModel, TPage>()
          where TViewModel : IViewModel
          where TPage : new() {
            this.registeredPages.Add(typeof(TViewModel), typeof(TPage));

            return this;
        }
    }
}