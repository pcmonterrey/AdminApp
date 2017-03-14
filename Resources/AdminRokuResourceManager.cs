using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resources
{
    public static class AdminRokuResourceManager
    {



        /// <summary>
        /// Obtiene el Valor del Recurso de acuerdo a la cultura de la variable de sesión
        /// </summary>
        /// <param name="key">Nombre del Atributo</param>
        /// <param name="aculture"></param>
        /// <returns></returns>
        public static string GetKeyValue(string key, string aculture = null)
        {


            string value = System.Web.HttpContext.GetGlobalResourceObject(null, key).ToString();
            return value ?? key;
        }

        /// <summary>
        /// Obtiene el valor de un recurso de acuerdo a la cultura que se encuentre en sesión
        /// </summary>
        /// <param name="key">Nombre del atributo</param>
        /// <param name="aculture"></param>
        /// <returns></returns>
        public static string GetString(string key, string aculture = null)
        {
            string value = System.Web.HttpContext.GetGlobalResourceObject(null, key).ToString();
            return value ?? key;
        }

        /// <summary>
        /// [FAE] Obtiene un Listado de recursos por Modulo
        /// </summary>
        /// <param name="filterFileName"></param>
        /// <param name="keyFilter">indicador de subtipo de recurso [Ctrl|Msg|Url]</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetResourcesByFilter(string filterFileName, string keyFilter = null, string culture = null)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (string.IsNullOrEmpty(culture))
                culture = currentCulture.Name;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_GlobalResources");
            var directoryInfo = new DirectoryInfo(path);
            List<FileInfo> filesInfo = new List<FileInfo>();
            if (string.IsNullOrWhiteSpace(filterFileName))
                filesInfo = directoryInfo.GetFiles("*." + culture + ".resx").ToList();
            else
                filesInfo = directoryInfo.GetFiles("*" + filterFileName + "*." + culture + ".resx").ToList();

            foreach (var fileInfo in filesInfo)
            {
                var reader = new ResXResourceReader(fileInfo.FullName);
                dictionary = reader.Cast<DictionaryEntry>().ToDictionary(a => a.Key.ToString(), a => a.Value.ToString());
            }

            if (!string.IsNullOrWhiteSpace(keyFilter))
            {
                dictionary = dictionary.Where(r => r.Key.ToUpper().Contains(keyFilter.ToUpper())).ToDictionary(r => r.Key, r => r.Value);
            }
            return dictionary;
        }
        public static string GetKeyValueLocalResource(string fileName, string key, string culture = null)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            if (string.IsNullOrEmpty(culture))
                culture = currentCulture.Name;
            var dir = System.Web.HttpContext.Current.Server.MapPath("~/App_GlobalResources");
            var pathFile = Path.Combine(dir, fileName + "." + culture + ".resx");
            var reader = new ResXResourceReader(pathFile);
            ResourceSet resourceset = new ResourceSet(reader);
            string value = resourceset.GetString(key);
            return value ?? key;
        }

    }
}
