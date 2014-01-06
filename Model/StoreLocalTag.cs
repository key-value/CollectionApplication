/**  版本信息模板在安装目录下，可自行修改。
* StoreLocalTag.cs
*
* 功 能： N/A
* 类 名： StoreLocalTag
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/13 15:03:12   N/A    初版
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
	/// StoreLocalTag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StoreLocalTag
	{
		public StoreLocalTag()
		{}
		#region Model
		private string _keyid;
		private string _localtagid;
		private string _localtagname;
		private string _bizid;
		private string _districtid;
		private int? _biztype;
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
		public string LocalTagID
		{
			set{ _localtagid=value;}
			get{return _localtagid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocalTagName
		{
			set{ _localtagname=value;}
			get{return _localtagname;}
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
		public string DistrictID
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BizType
		{
			set{ _biztype=value;}
			get{return _biztype;}
		}
		#endregion Model

	}
}

