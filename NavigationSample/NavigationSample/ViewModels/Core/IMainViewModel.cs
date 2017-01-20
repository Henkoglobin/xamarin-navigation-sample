using System.Windows.Input;

namespace NavigationSample.ViewModels.Core {
    public interface IMainViewModel : IViewModel {
        ICommand SubCommand { get; }
    }
}
