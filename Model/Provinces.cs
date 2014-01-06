/**  版本信息模板在安装目录下，可自行修改。
* Provinces.cs
*
* 功 能： N/A
* 类 名： Provinces
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/11 11:25:08   N/A    初版
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
	/// 省份
	/// </summary>
	[Serializable]
	public partial class Provinces
	{
		public Provinces()
		{}
		#region Model
		private string _provincesid;
		private string _provincesname;
		/// <summary>
		/// 省份ID
		/// </summary>
		public string ProvincesID
		{
			set{ _provincesid=value;}
			get{return _provincesid;}
		}
		/// <summary>
		/// 省份名称
		/// </summary>
		public string ProvincesName
		{
			set{ _provincesname=value;}
			get{return _provincesname;}
		}
		#endregion Model

	}
}

