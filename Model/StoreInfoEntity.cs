/**  版本信息模板在安装目录下，可自行修改。
* StoreInfo.cs
*
* 功 能： N/A
* 类 名： StoreInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/8 17:42:31   N/A    初版
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
    /// StoreInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StoreInfoEntity 
    {
        public StoreInfoEntity()
        { }
        #region Model
        private string _bizid;
        private string _storename;
        private string _branchname;
        private string _storeaddress;
        private string _businesstypeid;
        private DateTime? _businessaddtime;
        private string _chainstoreid;
        private string _cityid;
        private string _districtid;
        private int? _businessstate;
        private string _shortid;
        private string _storephone;
        private string _storephoto;
        private string _storehours;
        private string _basicintroduction;
        private string _telphone;
        private bool _cod;
        private bool _onlinepay;
        private string _takeawaytype;
        private string _videoaddress;
        private int? _takeordernum;
        private string _createusername;
        private string _updateusername;
        private DateTime? _lastupdatedate;
        private string _bizsld;
        private string _bizbannerurl;
        private string _bizweibourl;
        private string _biznotice;
        private string _glat;
        private string _glng;
        private string _blat;
        private string _blng;
        private bool _isqueue;
        private bool _ispointmenu;
        private bool _istakeaway;
        private bool _isreservation;
        private bool _ischeck;
        private int? _likecount;
        private int? _ordercount;
        private int? _sortid;
        private bool _iscitysend;
        private bool _iscoupon;
        private bool _isprivileges;
        private int? _issend;
        private int? _sharecount;
        private int? _collectioncount;
        private int? _comcount;
        private int? _foodcount;
        private bool _isgroup;
        private string _qrcodeurl;
        private string _bus;
        private decimal? _minprice;
        private decimal? _maxprice;
        private bool _carpark;
        private bool _box;
        private bool _paycar;
        private bool _wifi;
        private bool _nosmoke;
        private bool _childrenchair;
        private string _senddesc;
        private decimal? _takerange;
        private bool _kcvip;
        private int? _onlineorder;
        /// <summary>
        /// 
        /// </summary>
        public string BizID
        {
            set { _bizid = value; }
            get { return _bizid; }
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
        public string BranchName
        {
            set { _branchname = value; }
            get { return _branchname; }
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
        public string BusinessTypeID
        {
            set { _businesstypeid = value; }
            get { return _businesstypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BusinessAddTime
        {
            set { _businessaddtime = value; }
            get { return _businessaddtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChainStoreID
        {
            set { _chainstoreid = value; }
            get { return _chainstoreid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DistrictID
        {
            set { _districtid = value; }
            get { return _districtid; }
        }
        /// <summary>
        /// 商户状态 :  10：正常 ，20：禁止，30：即将，40：审核，50：删除，60：停业
        /// </summary>
        public int? BusinessState
        {
            set { _businessstate = value; }
            get { return _businessstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortID
        {
            set { _shortid = value; }
            get { return _shortid; }
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
        public string StorePhoto
        {
            set { _storephoto = value; }
            get { return _storephoto; }
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
        public string TelPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Cod
        {
            set { _cod = value; }
            get { return _cod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool OnlinePay
        {
            set { _onlinepay = value; }
            get { return _onlinepay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TakeAwayType
        {
            set { _takeawaytype = value; }
            get { return _takeawaytype; }
        }
        /// <summary>
        /// 只能用Flash格式
        /// </summary>
        public string VideoAddress
        {
            set { _videoaddress = value; }
            get { return _videoaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TakeOrderNum
        {
            set { _takeordernum = value; }
            get { return _takeordernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUserName
        {
            set { _createusername = value; }
            get { return _createusername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUserName
        {
            set { _updateusername = value; }
            get { return _updateusername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastUpdateDate
        {
            set { _lastupdatedate = value; }
            get { return _lastupdatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BizSLD
        {
            set { _bizsld = value; }
            get { return _bizsld; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BizBannerUrl
        {
            set { _bizbannerurl = value; }
            get { return _bizbannerurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BizWeiBoUrl
        {
            set { _bizweibourl = value; }
            get { return _bizweibourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BizNotice
        {
            set { _biznotice = value; }
            get { return _biznotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GLat
        {
            set { _glat = value; }
            get { return _glat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GLng
        {
            set { _glng = value; }
            get { return _glng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BLat
        {
            set { _blat = value; }
            get { return _blat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BLng
        {
            set { _blng = value; }
            get { return _blng; }
        }
        /// <summary>
        /// 是否支持排队
        /// </summary>
        public bool IsQueue
        {
            set { _isqueue = value; }
            get { return _isqueue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPointMenu
        {
            set { _ispointmenu = value; }
            get { return _ispointmenu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTakeAway
        {
            set { _istakeaway = value; }
            get { return _istakeaway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsReservation
        {
            set { _isreservation = value; }
            get { return _isreservation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCheck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LikeCount
        {
            set { _likecount = value; }
            get { return _likecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderCount
        {
            set { _ordercount = value; }
            get { return _ordercount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCitySend
        {
            set { _iscitysend = value; }
            get { return _iscitysend; }
        }
        /// <summary>
        /// 是否有卖开吃券
        /// </summary>
        public bool IsCoupon
        {
            set { _iscoupon = value; }
            get { return _iscoupon; }
        }
        /// <summary>
        /// 是否有优惠活动
        /// </summary>
        public bool IsPrivileges
        {
            set { _isprivileges = value; }
            get { return _isprivileges; }
        }
        /// <summary>
        /// 是否送餐服务 :  0 ：没有 1：餐厅外送 2：第三方外送
        /// </summary>
        public int? IsSend
        {
            set { _issend = value; }
            get { return _issend; }
        }
        /// <summary>
        /// 分享次数
        /// </summary>
        public int? ShareCount
        {
            set { _sharecount = value; }
            get { return _sharecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CollectionCount
        {
            set { _collectioncount = value; }
            get { return _collectioncount; }
        }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int? ComCount
        {
            set { _comcount = value; }
            get { return _comcount; }
        }
        /// <summary>
        /// 菜品数量
        /// </summary>
        public int? FoodCount
        {
            set { _foodcount = value; }
            get { return _foodcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsGroup
        {
            set { _isgroup = value; }
            get { return _isgroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QRcodeUrl
        {
            set { _qrcodeurl = value; }
            get { return _qrcodeurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Bus
        {
            set { _bus = value; }
            get { return _bus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinPrice
        {
            set { _minprice = value; }
            get { return _minprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxPrice
        {
            set { _maxprice = value; }
            get { return _maxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CarPark
        {
            set { _carpark = value; }
            get { return _carpark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Box
        {
            set { _box = value; }
            get { return _box; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool PayCar
        {
            set { _paycar = value; }
            get { return _paycar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool WIFI
        {
            set { _wifi = value; }
            get { return _wifi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool NoSmoke
        {
            set { _nosmoke = value; }
            get { return _nosmoke; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ChildrenChair
        {
            set { _childrenchair = value; }
            get { return _childrenchair; }
        }
        /// <summary>
        /// 外送说明: 起送份数，起送价格，或是起送说明，打包说明
        /// </summary>
        public string SendDesc
        {
            set { _senddesc = value; }
            get { return _senddesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TakeRange
        {
            set { _takerange = value; }
            get { return _takerange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool KCVIP
        {
            set { _kcvip = value; }
            get { return _kcvip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Onlineorder
        {
            set { _onlineorder = value; }
            get { return _onlineorder; }
        }
        #endregion Model

    }
}

