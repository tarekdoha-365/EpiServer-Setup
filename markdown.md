<div id="GoTop">
<h1> EPI Server Setup</h1>
</div>

- Add StructureMap solution for dependency Injection (DI) and Inversion of control (IOC)(APIs and MVC5)  
[1. StructureMapDependencyResolver](#StructureMapDependencyResolver)                
[2. StructureMapScope](#StructureMapScope)  
[3. DependencyResolverInitialization](#DependencyResolverInitialization)


- EPI Server Site Tabs Configuration  
[1.Create SiteTabNames class](#SiteTabNames)
- EPI Server Create basic media classes  
[1. Create GenericMedia class](#GenericMedia)  
[2. Create ImageFile class](#ImageFile)  
[3. Create VideoFile class](#VideoFile)

- Cache Manager Setup  
[1. ICacheManager](#ICacheManager)            
[2. CacheManager](#CacheManager)


<div id="StructureMapDependencyResolver">
<h3>StructureMapDependencyResolver</h3>

```
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
```
</div>

[GoTop](#GoTop)
<div id="StructureMapScope">
<h3>StructureMapScope</h3>

```
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace EpiServer_Setup.Business
{
    public class StructureMapScope : IDependencyScope
    {
        private readonly IContainer _container;
        public StructureMapScope(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container cannot be null");
            _container = container;
        }
        public object GetService(Type serviceType)
        {
            if (serviceType == null) return null;
            if (serviceType.IsAbstract || serviceType.IsInterface) 
                return _container.TryGetInstance(serviceType);
            return _container.GetInstance(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
        public void Dispose()
        {
            _container.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
```
<div>
<h3>DependencyResolverInitialization</h3>

```
using EpiServer_Setup.Business;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using StructureMap;
using System.Web.Http;
using System.Web.Mvc;

namespace EpiServer_Setup.Infrastructure.Initialization
{
    [InitializableModule]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.StructureMap().Configure(ConfigureContainer);
            var resolver = new StructureMapDependencyResolver(context.StructureMap());
            DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
        private static void ConfigureContainer(ConfigurationExpression container)
        {
            container.Scan(x =>
            {
                x.Assembly("EpiServer_Setup");
                x.WithDefaultConventions();
                x.LookForRegistries();
            });
        }
        public void Initialize(InitializationEngine context)
        {
        }
        public void Uninitialize(InitializationEngine context)
        {
        }
        public void Preload(string[] parameters)
        {
        }
    }
}
```
</div>

[GoTop](#GoTop)
</div>

<div id="SiteTabNames">
<h3>EPI Server Site Tabs Configuration</h3>

```
using EPiServer.DataAnnotations;
using EPiServer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Business
{
    [GroupDefinitions]
    public class SiteTabNames
    {
        [Display(Order = 100)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string Metadata = "Metadata";

        [Display(Order = 110)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string SiteOptions = "Site Options";

        [Display(Order = 120)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string EmployeeDetails = "Employee Details";

        [Display(Order = 130)]
        [RequiredAccess(AccessLevel.Edit)]
        public const string YourCustomTabName3 = "Your Custom Tab Name 3";
    }
}
```
</div>

[GoTop](#GoTop)

<div id="GenericMedia">
1- Create GenericMedia class:
in Infrastructure.Models.Media create GenericMedia.cs and use this code:

```
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
namespace Infrastructure.Models.Media
{
[ContentType(DisplayName = "GenericMedia", GUID = "ff441b4d-94a3-4640-b303-6cb72a7d4ecc", Descr [MediaDescriptor(ExtensionString = "pdf,doc,docx,ppt,pptx,xls,xlsx")]
public class GenericMedia : MediaData
{
[CultureSpecific]
[Editable(true)]
[Display(
Name = "Description",
Description = "Description field's description",
GroupName = SystemTabNames.Content,
Order = 10)]
public virtual string Description { get; set; }
}
}
```
</div>
 
[GoTop](#GoTop)
<div id="ImageFile">
2- Create ImageFile class:
in Infrastructure.Models.Media create ImageFile.cs and use this code:

```
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
namespace Infrastructure.Models.Media
{
[ContentType(DisplayName = "ImageFile", GUID = "50264228-bdbb-442e-92b0-9fb0a437080f", Descript [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,svg")]
public class ImageFile : ImageData
{
[CultureSpecific]
[Editable(true)]
[Display(
Name = "Description",
Description = "Description field's description",
GroupName = SystemTabNames.Content,
Order = 10)]
public virtual string Description { get; set; }
[CultureSpecific]
[Editable(true)]
[Display(
Name = "AlternativeText",
Description = "AlternativeText field's description",
GroupName = SystemTabNames.Content,
Order = 20)]
public virtual string AlternativeText { get; set; }
}
}
```
</div>

[GoTop](#GoTop)
<div id="VideoFile">

3- Create VideoFile class:
in Infrastructure.Models.Media create ImageFile.cs and use this code:
```
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
namespace Infrastructure.Models.Media
{
[ContentType(DisplayName = "VideoFile", GUID = "d04ac808-c6b6-469a-8d16-b645f55c8989", Descript [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
public class VideoFile : MediaData
{
[CultureSpecific]
[Editable(true)]
[Display(
Name = "Description",
Description = "Description field's description",
GroupName = SystemTabNames.Content,
Order = 10)]
public virtual string Description { get; set; }
/// /// Gets or sets the copyright. ///
public virtual string Copyright { get; set; }
/// /// Gets or sets the URL to the preview image. ///
[UIHint(UIHint.Image)]
public virtual ContentReference PreviewImage { get; set; }
}
}
```
</div>

[GoTop](#GoTop)
<div id="ICacheManager">
ICacheManager

```
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiServer_Setup.Interfaces
{
    public interface ICacheManager
    {
        CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes);
        CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes, IEnumerable<ContentReference> roots);
        void Remove(string cacheKey);
        void OnContentChange(object sender, ContentEventArgs e);
        T Get<T>(string key);
        void Insert(string key, object value, TimeSpan timespan, IEnumerable<Type> dependentTypes);
        void Insert(string key, object value, IEnumerable<Type> dependentTypes);
    }
}

```
</div>

[GoTop](#GoTop)

<div id="CacheManager">
CacheManager

```
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework.Cache;
using EpiServer_Setup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace EpiServer_Setup.Business
{
    public class CacheManager : ICacheManager
    {
        private readonly ISynchronizedObjectInstanceCache _cache;
        private readonly IContentLoader _contentLoader;
        private readonly IContentTypeRepository _contentTypeRepository;
        public CacheManager(IContentTypeRepository contentTypeRepository, IContentLoader contentLoader, ISynchronizedObjectInstanceCache cache)
        {
            _contentTypeRepository = contentTypeRepository;
            _contentLoader = contentLoader;
            _cache = cache;
        }
        public T Get<T>(string key)
        {
            return CastValue<T>(_cache.Get(key));
        }
        private static T CastValue<T>(object value)
        {
            if (value == null || value is DBNull)
            {
                return default(T);
            }
            var valType = value.GetType();
            if (valType.IsGenericType && valType.GetGenericTypeDefinition() == typeof(LazyObject<>))
            {
                return CastValue<T>(valType.GetProperty("Value").GetValue(value));
            }
            if (value is T)
            {
                return (T)value;
            }
            var t = typeof(T);
            t = (Nullable.GetUnderlyingType(t) ?? t);
            if (typeof(IConvertible).IsAssignableFrom(t) && typeof(IConvertible).IsAssignableFrom(value.GetType()))
            {
                return (T)Convert.ChangeType(value, t);
            }
            return default(T);
        }
        private class LazyObject<T> : Lazy<T>
        {
            public LazyObject(Func<T> valueFactory) : base(valueFactory) { }
            public LazyObject(Func<T> valueFactory, LazyThreadSafetyMode mode) : base(valueFactory, mode) { }
        }
        public CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes)
        {
            throw new NotImplementedException();
        }

        public CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes, IEnumerable<ContentReference> roots)
        {
            throw new NotImplementedException();
        }

        public void Insert(string key, object value, TimeSpan timespan, IEnumerable<Type> dependentTypes)
        {
            throw new NotImplementedException();
        }

        public void Insert(string key, object value, IEnumerable<Type> dependentTypes)
        {
            throw new NotImplementedException();
        }

        public void OnContentChange(object sender, ContentEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Remove(string cacheKey)
        {
            throw new NotImplementedException();
        }
    }
}
```
</div>


[GoTop](#GoTop)