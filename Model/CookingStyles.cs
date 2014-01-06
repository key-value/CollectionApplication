/**  版本信息模板在安装目录下，可自行修改。
* CookingStyles.cs
*
* 功 能： N/A
* 类 名： CookingStyles
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/11 13:47:55   N/A    初版
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
	/// CookingStyles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CookingStyles
	{
		public CookingStyles()
		{}
		#region Model
		private string _cookingstyleid;
		private string _cookingstylename;
		private string _parentid;
		private int? _state;
		private string _photo;
		private int? _sortid;
		private string _cityid;
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
		public string CookingStyleName
		{
			set{ _cookingstylename=value;}
			get{return _cookingstylename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		public string Photo
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 排序ID
		/// </summary>
		public int? SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		#endregion Model

	}
}

