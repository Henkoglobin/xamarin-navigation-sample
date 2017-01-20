using System;
using System.Windows.Input;

namespace NavigationSample.ViewModels.Core {
    public interface ISubViewModel : IViewModel {
        ICommand GoBackCommand { get; }
        String Something { get; }
        void Configure(string something);
    }
}
