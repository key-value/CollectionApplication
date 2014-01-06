/**  版本信息模板在安装目录下，可自行修改。
* StoreCookingStyles.cs
*
* 功 能： N/A
* 类 名： StoreCookingStyles
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
	/// StoreCookingStyles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StoreCookingStyles
	{
		public StoreCookingStyles()
		{}
		#region Model
		private string _keyid;
		private string _bizid;
		private string _cookingstyleid;
		private string _cookingstylename;
		/// <summary>
		/// 
		/// </summary>
		public string KeyID
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BizID
		{
			set{ _bizid=value;}
			get{return _bizid;}
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
		public string CookingStyleName
		{
			set{ _cookingstylename=value;}
			get{return _cookingstylename;}
		}
		#endregion Model

	}
}

