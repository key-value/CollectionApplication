/**  版本信息模板在安装目录下，可自行修改。
* DishesTable.cs
*
* 功 能： N/A
* 类 名： DishesTable
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/12 17:39:42   N/A    初版
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
	/// DishesTable:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DishesTable
	{
		public DishesTable()
		{}
		#region Model
		private string _dishesid;
		private string _dishesname;
		private decimal? _dishesmoney;
		private string _dishesunit;
		private string _dishestypeid;
		private string _businessid;
		private bool _iscurrentprice;
		private string _dishesbrief;
		private string _imageurl;
		private string _cookingstyleid;
		private int? _popularity;
		private bool _special;
		private bool _istakeaway;
		private int? _state;
		private int? _praisecount;
		private int? _sharecount;
		private int? _comcount;
		private int? _sortid;
		private DateTime? _createdate;
		private string _chainstoredishesid;
		private string _chainstoreid;
		private string _chainstoredishestypeid;
		private bool _issetmeal;
		private int? _visibitytype;
		private string _dishcode;
		private int? _dishecate;
		private bool _isevaluate;
		private int? _spicynum;
		private int? _recnum;
		/// <summary>
		/// 
		/// </summary>
		public string DishesID
		{
			set{ _dishesid=value;}
			get{return _dishesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DishesName
		{
			set{ _dishesname=value;}
			get{return _dishesname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DishesMoney
		{
			set{ _dishesmoney=value;}
			get{return _dishesmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DishesUnit
		{
			set{ _dishesunit=value;}
			get{return _dishesunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DishesTypeID
		{
			set{ _dishestypeid=value;}
			get{return _dishestypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BusinessID
		{
			set{ _businessid=value;}
			get{return _businessid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsCurrentPrice
		{
			set{ _iscurrentprice=value;}
			get{return _iscurrentprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DishesBrief
		{
			set{ _dishesbrief=value;}
			get{return _dishesbrief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CookingStyleID
		{
			set{ _cookingstyleid=value;}
			get{return _cookingstyleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Popularity
		{
			set{ _popularity=value;}
			get{return _popularity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Special
		{
			set{ _special=value;}
			get{return _special;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsTakeAway
		{
			set{ _istakeaway=value;}
			get{return _istakeaway;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PraiseCount
		{
			set{ _praisecount=value;}
			get{return _praisecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShareCount
		{
			set{ _sharecount=value;}
			get{return _sharecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ComCount
		{
			set{ _comcount=value;}
			get{return _comcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChainStoreDishesID
		{
			set{ _chainstoredishesid=value;}
			get{return _chainstoredishesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChainStoreID
		{
			set{ _chainstoreid=value;}
			get{return _chainstoreid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChainStoreDishesTypeID
		{
			set{ _chainstoredishestypeid=value;}
			get{return _chainstoredishestypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsSetMeal
		{
			set{ _issetmeal=value;}
			get{return _issetmeal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VisibityType
		{
			set{ _visibitytype=value;}
			get{return _visibitytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DishCode
		{
			set{ _dishcode=value;}
			get{return _dishcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DisheCate
		{
			set{ _dishecate=value;}
			get{return _dishecate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsEvaluate
		{
			set{ _isevaluate=value;}
			get{return _isevaluate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SpicyNum
		{
			set{ _spicynum=value;}
			get{return _spicynum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RecNum
		{
			set{ _recnum=value;}
			get{return _recnum;}
		}
		#endregion Model

	}
}

