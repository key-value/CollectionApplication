/**  版本信息模板在安装目录下，可自行修改。
* SpecialTag.cs
*
* 功 能： N/A
* 类 名： SpecialTag
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/11 17:43:09   N/A    初版
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
	/// SpecialTag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SpecialTag
	{
		public SpecialTag()
		{}
		#region Model
		private string _specialtagid;
		private string _tagname;
		private string _cityid;
		private int? _sort;
		/// <summary>
		/// 
		/// </summary>
		public string SpecialTagID
		{
			set{ _specialtagid=value;}
			get{return _specialtagid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TagName
		{
			set{ _tagname=value;}
			get{return _tagname;}
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
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

