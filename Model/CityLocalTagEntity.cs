/**  版本信息模板在安装目录下，可自行修改。
* CityLocalTag.cs
*
* 功 能： N/A
* 类 名： CityLocalTag
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
	/// CityLocalTag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CityLocalTagEntity
	{
        public CityLocalTagEntity()
		{}
		#region Model
		private string _localtagid;
		private string _tagname;
		private string _districtid;
		private string _cityid;
		private int? _taggrade;
		private int? _sort;
		private string _glat;
		private string _glng;
		private string _blat;
		private string _blng;
		private string _fletter;
		private int? _businessesnumber;
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
		public string DistrictID
		{
			set{ _districtid=value;}
			get{return _districtid;}
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
		/// 地标级别 : 0：大楼，10：路段 ，20：商圈
		/// </summary>
		public int? TagGrade
		{
			set{ _taggrade=value;}
			get{return _taggrade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GLat
		{
			set{ _glat=value;}
			get{return _glat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GLng
		{
			set{ _glng=value;}
			get{return _glng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BLat
		{
			set{ _blat=value;}
			get{return _blat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BLng
		{
			set{ _blng=value;}
			get{return _blng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLetter
		{
			set{ _fletter=value;}
			get{return _fletter;}
		}
		/// <summary>
		/// 商家数量
		/// </summary>
		public int? BusinessesNumber
		{
			set{ _businessesnumber=value;}
			get{return _businessesnumber;}
		}
		#endregion Model

	}
}

