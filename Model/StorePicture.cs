/**  版本信息模板在安装目录下，可自行修改。
* StorePicture.cs
*
* 功 能： N/A
* 类 名： StorePicture
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/20 10:14:07   N/A    初版
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
	/// StorePicture:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StorePicture
	{
		public StorePicture()
		{}
		#region Model
		private string _pid;
		private string _storeid;
		private string _picturename;
		private string _picturepath;
		private string _pictype;
		/// <summary>
		/// 
		/// </summary>
		public string PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreId
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureName
		{
			set{ _picturename=value;}
			get{return _picturename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicturePath
		{
			set{ _picturepath=value;}
			get{return _picturepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicType
		{
			set{ _pictype=value;}
			get{return _pictype;}
		}
		#endregion Model

	}
}

