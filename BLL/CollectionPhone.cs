using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public class CollectionPhone
    {
        public CollectionPhone()
        {
            catalogueList = new List<Catalogue>();
            dictionary = new Dictionary<string, string>();
            headDictionary = new Dictionary<string, string>();
        }

        public Dictionary<string, string> dictionary { get; set; }
        public List<Catalogue> catalogueList { get; set; }
        public Dictionary<string, string> headDictionary { get; set; }

        public string PageUrl { get; set; }
        public T GetResualt<T>()
        {
            var jsonStr = PostHttpResponse.PostData(PageUrl, dictionary, headDictionary);
            if (string.IsNullOrEmpty(jsonStr))
            {
                return default(T);
            }
            return JsonHelper.JsonToObj<T>(jsonStr);
        }

        public T GetEpinLeResualt<T>()
        {
            var jsonStr = PostHttpResponse.PostData(PageUrl, dictionary, headDictionary);
            var jsonNum = jsonStr.IndexOf(']');
            if (jsonNum > 0)
            {
                jsonStr = jsonStr.Substring(0, jsonNum + 1).Replace(@"[[", @"[");
            }
            if (string.IsNullOrEmpty(jsonStr))
            {
                return default(T);
            }
            return JsonHelper.JsonToObj<T>(jsonStr);
        }
    }
}
