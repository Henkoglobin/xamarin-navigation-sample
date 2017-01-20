using System.Threading.Tasks;
using NavigationSample.ViewModels.Core;

namespace NavigationSample.Services.Core {
    public interface INavigationService {
        INavigationService RegisterPage<TViewModel, TPage>()
            where TViewModel : IViewModel
            where TPage : new();

        Task<TViewModel> NavigateAsync<TViewModel>()
            where TViewModel : IViewModel;

        Task<IViewModel> GoBackAsync();
    }
}
