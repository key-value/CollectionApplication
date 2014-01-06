/**  版本信息模板在安装目录下，可自行修改。
* District.cs
*
* 功 能： N/A
* 类 名： District
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/11 14:42:52   N/A    初版
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
	/// 行政区域
	/// </summary>
	[Serializable]
	public partial class District
	{
		public District()
		{}
		#region Model
		private string _districtid;
		private string _districtname;
		private string _cityid;
		private int? _sortid;
		/// <summary>
		/// 区ID
		/// </summary>
		public string DistrictID
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		/// <summary>
		/// 区名
		/// </summary>
		public string DistrictName
		{
			set{ _districtname=value;}
			get{return _districtname;}
		}
		/// <summary>
		/// 城市ID
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
		#endregion Model

	}
}

