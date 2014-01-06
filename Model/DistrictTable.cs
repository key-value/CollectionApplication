/**  版本信息模板在安装目录下，可自行修改。
* DistrictTable.cs
*
* 功 能： N/A
* 类 名： DistrictTable
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/18 17:09:16   N/A    初版
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
	/// DistrictTable:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DistrictTable
	{
		public DistrictTable()
		{}
		#region Model
		private string _districtid;
		private string _districtname;
		private string _cityid;
		private int? _sortid;
		private string _siteid;
		/// <summary>
		/// 
		/// </summary>
		public string DistrictID
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DistrictName
		{
			set{ _districtname=value;}
			get{return _districtname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
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
		public string SiteID
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		#endregion Model

	}
}

