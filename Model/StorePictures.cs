/**  版本信息模板在安装目录下，可自行修改。
* StorePictures.cs
*
* 功 能： N/A
* 类 名： StorePictures
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/12 15:32:56   N/A    初版
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
	/// 商店图片
	/// </summary>
	[Serializable]
	public partial class StorePictures
	{
		public StorePictures()
		{}
		#region Model
		private string _storepicturesid;
		private string _busphotoalbumid;
		private string _businessid;
		private string _usersid;
		private string _pictureaddress;
		private string _picname;
		private bool _isuserupload;
		private int? _picstate;
		private DateTime? _uploadtime;
		private string _nickname;
		private bool _issettop;
		private int? _likecount=0;
		private int? _sharecount=0;
		/// <summary>
		/// 商家图片表ID
		/// </summary>
		public string StorePicturesID
		{
			set{ _storepicturesid=value;}
			get{return _storepicturesid;}
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
		/// 商家帐号ID
		/// </summary>
		public string BusinessID
		{
			set{ _businessid=value;}
			get{return _businessid;}
		}
		/// <summary>
		/// 普通用户表ID
		/// </summary>
		public string UsersID
		{
			set{ _usersid=value;}
			get{return _usersid;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string PictureAddress
		{
			set{ _pictureaddress=value;}
			get{return _pictureaddress;}
		}
		/// <summary>
		/// 图片名称
		/// </summary>
		public string PicName
		{
			set{ _picname=value;}
			get{return _picname;}
		}
		/// <summary>
		/// 是否会员上传
		/// </summary>
		public bool IsUserUpload
		{
			set{ _isuserupload=value;}
			get{return _isuserupload;}
		}
		/// <summary>
		/// 1：未审核，2：通过
		/// </summary>
		public int? PicState
		{
			set{ _picstate=value;}
			get{return _picstate;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public DateTime? UploadTime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
		}
		/// <summary>
		/// 会员昵称
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsSetTop
		{
			set{ _issettop=value;}
			get{return _issettop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LikeCount
		{
			set{ _likecount=value;}
			get{return _likecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShareCount
		{
			set{ _sharecount=value;}
			get{return _sharecount;}
		}
		#endregion Model

	}
}

