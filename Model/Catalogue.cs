/**  版本信息模板在安装目录下，可自行修改。
* Catalogue.cs
*
* 功 能： N/A
* 类 名： Catalogue
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/20 9:58:04   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// Catalogue:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Catalogue
    {
        public Catalogue()
        {
            IsRead = false;
            StoreInfo = new NullStoreInfo();
        }
        #region Model
        private string _fid;
        private string _href;
        private string _title;
        private int? _localtagid;
        private string _storeid;
        private string _picname;
        /// <summary>
        /// 
        /// </summary>
        public string FId
        {
            set { _fid = value; }
            get { return _fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string href
        {
            set { _href = value; }
            get { return _href; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LocalTagID
        {
            set { _localtagid = value; }
            get { return _localtagid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreId
        {
            set { _storeid = value; }
            get { return _storeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string picName
        {
            set { _picname = value; }
            get { return _picname; }
        }
        #endregion Model


        public bool IsRead
        {
            get;
            set;
        }


        public StoreInfo StoreInfo { get; set; }

        public bool IsNull
        {
            get { return _isNull; }
        }

        protected bool _isNull;

        public string StorePictureHref { get; set; }
    }

    public class NullCatalogue : Catalogue
    {
        public NullCatalogue()
        {
            _isNull = true;
        }
    }
}

