/**  版本信息模板在安装目录下，可自行修改。
* City.cs
*
* 功 能： N/A
* 类 名： City
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/11 11:25:09   N/A    初版
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
	/// 城市表
	/// </summary>
	[Serializable]
	public partial class City
	{
		public City()
		{}
		#region Model
		private string _cityid;
		private string _provincesid;
		private string _cityname;
		private int? _sortid;
		private string _citycode;
		private bool _isopen;
		private string _letter;
		/// <summary>
		/// 城市ID
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 省份ID
		/// </summary>
		public string ProvincesID
		{
			set{ _provincesid=value;}
			get{return _provincesid;}
		}
		/// <summary>
		/// 城市名
		/// </summary>
		public string CityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
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
		public string CityCode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsOpen
		{
			set{ _isopen=value;}
			get{return _isopen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Letter
		{
			set{ _letter=value;}
			get{return _letter;}
		}
		#endregion Model

	}
}

