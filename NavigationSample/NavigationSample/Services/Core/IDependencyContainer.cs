namespace NavigationSample.Services.Core {
    public interface IDependencyContainer {
        T Resolve<T>();
        IDependencyContainer Register<TInterface, TImplementation>()
            where TImplementation : TInterface;
        IDependencyContainer Register<T>(T instance);
    }
}
