using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiServer_Setup.Business
{
    public class StructureMapDependencyResolver : IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
    {
        readonly IContainer _container;
        public StructureMapDependencyResolver(IContainer container)
        {
            _container = container;
        }
        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface || serviceType.IsAbstract)
            {
                return GetInterfaceService(serviceType);
            }
            return GetConcreteService(serviceType);
        }
        private object GetConcreteService(Type serviceType)
        {
            try
            {
                return _container.GetInstance(serviceType);
            }
            catch (StructureMapException)
            {
                return null;
            }
        }
        private object GetInterfaceService(Type serviceType)
        {
            return _container.TryGetInstance(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            var childContainer = _container.GetNestedContainer();
            return new StructureMapScope(childContainer);
        }
        public void Dispose()
        {
            _container.Dispose();
        }
    }
}