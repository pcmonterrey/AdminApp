using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;

namespace Resources
{
    //  [
    //    DesignTimeResourceProviderFactoryAttribute(
    //        typeof(CustomDesignTimeResourceProviderFactory))
    //]
    public class AdminRokuResourceProviderFactory : ResourceProviderFactory
    {
        public override IResourceProvider
          CreateGlobalResourceProvider(string classname)
        {
            return new HEBResourceProvider(null, classname);
        }
        public override IResourceProvider
          CreateLocalResourceProvider(string virtualPath)
        {
            return new HEBResourceProvider(virtualPath, null);
        }
    }

    // Define the resource provider for global and local resources.
    internal class HEBResourceProvider : IResourceProvider
    {


        /// <summary>
        /// Cache for each culture of this ResourceSet. Once
        /// loaded we just cache the resources.
        /// </summary>
        private IDictionary _resourceCache;


        string _virtualPath;
        string _className;

        public HEBResourceProvider(string virtualPath, string classname)
        {
            _virtualPath = virtualPath; // ?? System.Web.HttpContext.Current.Server.MapPath("~/App_GlobalResource");
            _className = classname;
        }

        private IDictionary GetResourceCache(string cultureName)
        {

            if (string.IsNullOrEmpty(cultureName))
                cultureName = "es-MX";

            if (this._resourceCache == null)
                this._resourceCache = new ListDictionary();

            IDictionary Resources = System.Web.HttpContext.Current.Cache[cultureName] as IDictionary;
            if (Resources == null)
            {
                System.Web.HttpContext.Current.Cache[cultureName] = Initialize(cultureName);

            }

            return (IDictionary)
                System.Web.HttpContext.Current.Cache[cultureName];

        }

        public IDictionary Initialize(string cultureName)
        {


            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_GlobalResources");
            var directoryInfo = new DirectoryInfo(path);

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (var fileInfo in directoryInfo.GetFiles("*.resx"))
            {
                var reader = new ResXResourceReader(fileInfo.FullName);
                var items = reader.Cast<DictionaryEntry>().ToDictionary(a => a.Key.ToString().ToLower(), a => a.Value.ToString());
                var names = fileInfo.Name.Split('.');

                if (fileInfo.Name.Contains(cultureName))
                {
                    dictionary.AddRange(items);
                }
                //else if( cultureName.Equals("es-MX")) {
                //    dictionary.AddRange(items);
                //}

            }
            return dictionary;
        }


        object IResourceProvider.GetObject
            (string resourceKey, CultureInfo culture)
        {
            object value;

            string cultureName = null;
            if (culture != null)
            {
                cultureName = culture.Name;
            }
            else
            {
                cultureName = CultureInfo.CurrentUICulture.Name;
            }

            value = GetResourceCache(cultureName)[resourceKey.ToLower()];
            if (value == null)
            {
                value = GetResourceCache(null)[resourceKey];
            }
            return value ?? resourceKey;
        }


        //IResourceReader IResourceProvider.ResourceReader
        IResourceReader IResourceProvider.ResourceReader
        {
            get
            {
                string cultureName = null;
                CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
                if (!String.Equals(currentUICulture.Name,
                    CultureInfo.InstalledUICulture.Name))
                {
                    cultureName = currentUICulture.Name;
                }

                return new HEBResourceReader(GetResourceCache(cultureName));
            }
        }
    }


    internal sealed class HEBResourceReader : IResourceReader
    {
        private IDictionary _resources;

        public HEBResourceReader(IDictionary resources)
        {
            _resources = resources;
        }

        IDictionaryEnumerator IResourceReader.GetEnumerator()
        {
            return _resources.GetEnumerator();
        }

        void IResourceReader.Close() { }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _resources.GetEnumerator();
        }

        void IDisposable.Dispose() { return; }
    }



}
