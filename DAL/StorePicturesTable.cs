/**  版本信息模板在安装目录下，可自行修改。
* StorePicturesTable.cs
*
* 功 能： N/A
* 类 名： StorePicturesTable
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/12 17:12:57   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:StorePicturesTable
	/// </summary>
	public partial class StorePicturesTable
	{
		public StorePicturesTable()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StorePicturesID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StorePicturesTable");
			strSql.Append(" where StorePicturesID=@StorePicturesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StorePicturesID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = StorePicturesID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.StorePicturesTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StorePicturesTable(");
			strSql.Append("StorePicturesID,BusPhotoAlbumID,BusinessID,UsersID,PictureAddress,PicName,IsUserUpload,PicState,UploadTime,NickName,IsSetTop,LikeCount,ShareCount)");
			strSql.Append(" values (");
			strSql.Append("@StorePicturesID,@BusPhotoAlbumID,@BusinessID,@UsersID,@PictureAddress,@PicName,@IsUserUpload,@PicState,@UploadTime,@NickName,@IsSetTop,@LikeCount,@ShareCount)");
			SqlParameter[] parameters = {
					new SqlParameter("@StorePicturesID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusPhotoAlbumID", SqlDbType.VarChar,50),
					new SqlParameter("@BusinessID", SqlDbType.NVarChar,50),
					new SqlParameter("@UsersID", SqlDbType.NVarChar,50),
					new SqlParameter("@PictureAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@PicName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsUserUpload", SqlDbType.Bit,1),
					new SqlParameter("@PicState", SqlDbType.Int,4),
					new SqlParameter("@UploadTime", SqlDbType.DateTime),
					new SqlParameter("@NickName", SqlDbType.NVarChar,30),
					new SqlParameter("@IsSetTop", SqlDbType.Bit,1),
					new SqlParameter("@LikeCount", SqlDbType.Int,4),
					new SqlParameter("@ShareCount", SqlDbType.Int,4)};
			parameters[0].Value = model.StorePicturesID;
			parameters[1].Value = model.BusPhotoAlbumID;
			parameters[2].Value = model.BusinessID;
			parameters[3].Value = model.UsersID;
			parameters[4].Value = model.PictureAddress;
			parameters[5].Value = model.PicName;
			parameters[6].Value = model.IsUserUpload;
			parameters[7].Value = model.PicState;
			parameters[8].Value = model.UploadTime;
			parameters[9].Value = model.NickName;
			parameters[10].Value = model.IsSetTop;
			parameters[11].Value = model.LikeCount;
			parameters[12].Value = model.ShareCount;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.StorePicturesTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StorePicturesTable set ");
			strSql.Append("BusPhotoAlbumID=@BusPhotoAlbumID,");
			strSql.Append("BusinessID=@BusinessID,");
			strSql.Append("UsersID=@UsersID,");
			strSql.Append("PictureAddress=@PictureAddress,");
			strSql.Append("PicName=@PicName,");
			strSql.Append("IsUserUpload=@IsUserUpload,");
			strSql.Append("PicState=@PicState,");
			strSql.Append("UploadTime=@UploadTime,");
			strSql.Append("NickName=@NickName,");
			strSql.Append("IsSetTop=@IsSetTop,");
			strSql.Append("LikeCount=@LikeCount,");
			strSql.Append("ShareCount=@ShareCount");
			strSql.Append(" where StorePicturesID=@StorePicturesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BusPhotoAlbumID", SqlDbType.VarChar,50),
					new SqlParameter("@BusinessID", SqlDbType.NVarChar,50),
					new SqlParameter("@UsersID", SqlDbType.NVarChar,50),
					new SqlParameter("@PictureAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@PicName", SqlDbType.NVarChar,50),
					new SqlParameter("@IsUserUpload", SqlDbType.Bit,1),
					new SqlParameter("@PicState", SqlDbType.Int,4),
					new SqlParameter("@UploadTime", SqlDbType.DateTime),
					new SqlParameter("@NickName", SqlDbType.NVarChar,30),
					new SqlParameter("@IsSetTop", SqlDbType.Bit,1),
					new SqlParameter("@LikeCount", SqlDbType.Int,4),
					new SqlParameter("@ShareCount", SqlDbType.Int,4),
					new SqlParameter("@StorePicturesID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.BusPhotoAlbumID;
			parameters[1].Value = model.BusinessID;
			parameters[2].Value = model.UsersID;
			parameters[3].Value = model.PictureAddress;
			parameters[4].Value = model.PicName;
			parameters[5].Value = model.IsUserUpload;
			parameters[6].Value = model.PicState;
			parameters[7].Value = model.UploadTime;
			parameters[8].Value = model.NickName;
			parameters[9].Value = model.IsSetTop;
			parameters[10].Value = model.LikeCount;
			parameters[11].Value = model.ShareCount;
			parameters[12].Value = model.StorePicturesID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string StorePicturesID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StorePicturesTable ");
			strSql.Append(" where StorePicturesID=@StorePicturesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StorePicturesID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = StorePicturesID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string StorePicturesIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StorePicturesTable ");
			strSql.Append(" where StorePicturesID in ("+StorePicturesIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.StorePicturesTable GetModel(string StorePicturesID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StorePicturesID,BusPhotoAlbumID,BusinessID,UsersID,PictureAddress,PicName,IsUserUpload,PicState,UploadTime,NickName,IsSetTop,LikeCount,ShareCount from StorePicturesTable ");
			strSql.Append(" where StorePicturesID=@StorePicturesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StorePicturesID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = StorePicturesID;

			Maticsoft.Model.StorePicturesTable model=new Maticsoft.Model.StorePicturesTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.StorePicturesTable DataRowToModel(DataRow row)
		{
			Maticsoft.Model.StorePicturesTable model=new Maticsoft.Model.StorePicturesTable();
			if (row != null)
			{
				if(row["StorePicturesID"]!=null)
				{
					model.StorePicturesID=row["StorePicturesID"].ToString();
				}
				if(row["BusPhotoAlbumID"]!=null)
				{
					model.BusPhotoAlbumID=row["BusPhotoAlbumID"].ToString();
				}
				if(row["BusinessID"]!=null)
				{
					model.BusinessID=row["BusinessID"].ToString();
				}
				if(row["UsersID"]!=null)
				{
					model.UsersID=row["UsersID"].ToString();
				}
				if(row["PictureAddress"]!=null)
				{
					model.PictureAddress=row["PictureAddress"].ToString();
				}
				if(row["PicName"]!=null)
				{
					model.PicName=row["PicName"].ToString();
				}
				if(row["IsUserUpload"]!=null && row["IsUserUpload"].ToString()!="")
				{
					if((row["IsUserUpload"].ToString()=="1")||(row["IsUserUpload"].ToString().ToLower()=="true"))
					{
						model.IsUserUpload=true;
					}
					else
					{
						model.IsUserUpload=false;
					}
				}
				if(row["PicState"]!=null && row["PicState"].ToString()!="")
				{
					model.PicState=int.Parse(row["PicState"].ToString());
				}
				if(row["UploadTime"]!=null && row["UploadTime"].ToString()!="")
				{
					model.UploadTime=DateTime.Parse(row["UploadTime"].ToString());
				}
				if(row["NickName"]!=null)
				{
					model.NickName=row["NickName"].ToString();
				}
				if(row["IsSetTop"]!=null && row["IsSetTop"].ToString()!="")
				{
					if((row["IsSetTop"].ToString()=="1")||(row["IsSetTop"].ToString().ToLower()=="true"))
					{
						model.IsSetTop=true;
					}
					else
					{
						model.IsSetTop=false;
					}
				}
				if(row["LikeCount"]!=null && row["LikeCount"].ToString()!="")
				{
					model.LikeCount=int.Parse(row["LikeCount"].ToString());
				}
				if(row["ShareCount"]!=null && row["ShareCount"].ToString()!="")
				{
					model.ShareCount=int.Parse(row["ShareCount"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StorePicturesID,BusPhotoAlbumID,BusinessID,UsersID,PictureAddress,PicName,IsUserUpload,PicState,UploadTime,NickName,IsSetTop,LikeCount,ShareCount ");
			strSql.Append(" FROM StorePicturesTable ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" StorePicturesID,BusPhotoAlbumID,BusinessID,UsersID,PictureAddress,PicName,IsUserUpload,PicState,UploadTime,NickName,IsSetTop,LikeCount,ShareCount ");
			strSql.Append(" FROM StorePicturesTable ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM StorePicturesTable ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.StorePicturesID desc");
			}
			strSql.Append(")AS Row, T.*  from StorePicturesTable T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "StorePicturesTable";
			parameters[1].Value = "StorePicturesID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

