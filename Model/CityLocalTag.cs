/**  版本信息模板在安装目录下，可自行修改。
* CityLocalTag.cs
*
* 功 能： N/A
* 类 名： CityLocalTag
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/18 19:40:38   N/A    初版
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
	/// CityLocalTag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CityLocalTag
	{
		public CityLocalTag()
		{}
		#region Model
		private string _localtagid;
		private string _tagname;
		private string _circleid;
		private string _cityid;
		/// <summary>
		/// 
		/// </summary>
		public string LocalTagID
		{
			set{ _localtagid=value;}
			get{return _localtagid;}
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
		public string Circleid
		{
			set{ _circleid=value;}
			get{return _circleid;}
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

