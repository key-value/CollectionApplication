/**  版本信息模板在安装目录下，可自行修改。
* BusPhotoAlbum.cs
*
* 功 能： N/A
* 类 名： BusPhotoAlbum
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/12 15:32:57   N/A    初版
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
	/// 商家相册
	/// </summary>
	[Serializable]
	public partial class BusPhotoAlbum
	{
		public BusPhotoAlbum()
		{}
		#region Model
		private string _businessid;
		private string _busphotoalbumid;
		private string _albumname;
		private string _albumdesc;
		private bool _isdefault;
		/// <summary>
		/// 商家帐号ID
		/// </summary>
		public string BusinessID
		{
			set{ _businessid=value;}
			get{return _businessid;}
		}
		/// <summary>
		/// 商家相册ID
		/// </summary>
		public string BusPhotoAlbumID
		{
			set{ _busphotoalbumid=value;}
			get{return _busphotoalbumid;}
		}
		/// <summary>
		/// 最长不超过10个汉字
		/// </summary>
		public string AlbumName
		{
			set{ _albumname=value;}
			get{return _albumname;}
		}
		/// <summary>
		/// 相册说明
		/// </summary>
		public string AlbumDesc
		{
			set{ _albumdesc=value;}
			get{return _albumdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		#endregion Model

	}
}

