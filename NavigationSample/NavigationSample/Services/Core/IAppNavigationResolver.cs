using System;
using System.Threading.Tasks;
using NavigationSample.ViewModels.Core;

namespace NavigationSample.Services.Core {
    public interface IAppNavigationResolver {
        Task NavigateAsync<TViewModel>(Type pageType, TViewModel viewModel)
            where TViewModel : IViewModel;
        Task<IViewModel> GoBackAsync();
    }
}
