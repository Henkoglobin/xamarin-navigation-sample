using System.Threading.Tasks;

namespace NavigationSample.ViewModels.Core {
    public interface IViewModel {
        Task ActivateAsync();
    }
}
