using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using HtmlAgilityPack;
using Maticsoft.Model;

namespace ISite
{
    public interface ICatalogue : IProgress
    {
        string PageUrl
        {
            get;
            set;
        }
        int PageNum
        {
            get;
            set;
        }
        int PageCount
        {
            get;
            set;
        }
        int CircleId { get; set; }

        string PicType { get; }
        int IflastPage { get; set; }

        /// <summary>
        /// 页面目录
        /// </summary>
        /// <param name="poIndex"></param>
        /// <returns></returns>
        List<Catalogue> GetPageCatalogue(int poIndex);

        List<Catalogue> GetCataloguePage(int poIndex);

        string NextPage { get; set; }
        string BeforePage { get; set; }

    }
}
