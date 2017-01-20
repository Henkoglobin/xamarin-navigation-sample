using Microsoft.Practices.Unity;
using NavigationSample.Services.Core;

namespace NavigationSample.Services {
    public class UnityDependencyContainer : IDependencyContainer {
        private readonly IUnityContainer unityContainer;

        public UnityDependencyContainer() {
            this.unityContainer = new UnityContainer();
        }

        public T Resolve<T>() {
            return this.unityContainer.Resolve<T>();
        }

        public IDependencyContainer Register<TInterface, TImplementation>()
            where TImplementation : TInterface {
            this.unityContainer.RegisterType<TInterface, TImplementation>();
            return this;
        }

        public IDependencyContainer Register<T>(T instance) {
            this.unityContainer.RegisterInstance(instance);
            return this;
        }
    }
}
