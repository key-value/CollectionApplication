/**  版本信息模板在安装目录下，可自行修改。
* StoreInfo.cs
*
* 功 能： N/A
* 类 名： StoreInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/20 9:46:50   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;

namespace Maticsoft.Model
{
    /// <summary>
    /// StoreInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StoreInfo
    {
        public StoreInfo()
        {
            storeTagList = new List<string>();
            DishTypeList = new List<DishesTyep>();
        }
        #region Model
        private string _storeid;
        private string _fid;
        private string _storename;
        private string _storeaddress;
        private string _storephone;
        private string _basicintroduction;
        private string _storehours;
        private string _facilities;
        private bool _paycar;
        private string _subway;
        private string _bus;
        private bool _box;
        private string _carpark;
        private string _storetag;
        private int? _minprice;
        private int? _maxprice;
        private string _picname;
        /// <summary>
        /// 
        /// </summary>
        public string storeId
        {
            set { _storeid = value; }
            get { return _storeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fid
        {
            set { _fid = value; }
            get { return _fid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreName
        {
            set { _storename = value; }
            get { return _storename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreAddress
        {
            set { _storeaddress = value; }
            get { return _storeaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StorePhone
        {
            set { _storephone = value; }
            get { return _storephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BasicIntroduction
        {
            set { _basicintroduction = value; }
            get { return _basicintroduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreHours
        {
            set { _storehours = value; }
            get { return _storehours; }
        }
        /// <summary>
        /// 设施
        /// </summary>
        public string Facilities
        {
            set { _facilities = value; }
            get { return _facilities; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool payCar
        {
            set { _paycar = value; }
            get { return _paycar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string subway
        {
            set { _subway = value; }
            get { return _subway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bus
        {
            set { _bus = value; }
            get { return _bus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool box
        {
            set { _box = value; }
            get { return _box; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string carPark
        {
            set { _carpark = value; }
            get { return _carpark; }
        }
        /// <summary>
        /// 标签
        /// </summary>
        public string StoreTag
        {
            set { _storetag = value; }
            get { return _storetag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MinPrice
        {
            set { _minprice = value; }
            get { return _minprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MaxPrice
        {
            set { _maxprice = value; }
            get { return _maxprice; }
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



        #region Add
        public List<string> storeTagList
        {
            get;
            set;
        }

        public bool ChangeDishes
        {
            get;
            set;
        }

        public bool ChangePic
        {
            get;
            set;
        }

        public int DishesNum { get; set; }
        public bool IsNull
        {
            get { return _isNull; }
            set { _isNull = value; }
        }

        private bool _isNull;

        public List<DishesTyep> DishTypeList { get; set; }

        #endregion

    }

    public class NullStoreInfo : StoreInfo
    {
        public NullStoreInfo()
        {
            IsNull = true;
        }
    }
}

