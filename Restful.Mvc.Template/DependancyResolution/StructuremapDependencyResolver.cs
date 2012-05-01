using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace Restful.Mvc.Template.DependancyResolution
{
    public class StructuremapDependencyResolver : IDependencyResolver {

        public StructuremapDependencyResolver() {
            ObjectFactory.Initialize(x => x.AddRegistry<ApplicationRegistry>());
        }

        public object GetService(Type serviceType) {
            if (serviceType == null) return null;
            try {
                  return serviceType.IsAbstract || serviceType.IsInterface
                           ? ObjectFactory.Container.TryGetInstance(serviceType)
                           : ObjectFactory.Container.GetInstance(serviceType);
            }
            catch {

                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return ObjectFactory.Container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}