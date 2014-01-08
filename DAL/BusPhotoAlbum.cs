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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:BusPhotoAlbum
	/// </summary>
	public partial class BusPhotoAlbum
	{
		public BusPhotoAlbum()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BusPhotoAlbumID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BusPhotoAlbum");
			strSql.Append(" where BusPhotoAlbumID=@BusPhotoAlbumID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BusPhotoAlbumID", SqlDbType.VarChar,50)			};
			parameters[0].Value = BusPhotoAlbumID;

			return ServerDbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BusPhotoAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BusPhotoAlbum(");
			strSql.Append("BusinessID,BusPhotoAlbumID,AlbumName,AlbumDesc,IsDefault)");
			strSql.Append(" values (");
			strSql.Append("@BusinessID,@BusPhotoAlbumID,@AlbumName,@AlbumDesc,@IsDefault)");
			SqlParameter[] parameters = {
					new SqlParameter("@BusinessID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusPhotoAlbumID", SqlDbType.VarChar,50),
					new SqlParameter("@AlbumName", SqlDbType.NVarChar,20),
					new SqlParameter("@AlbumDesc", SqlDbType.NVarChar,200),
					new SqlParameter("@IsDefault", SqlDbType.Bit,1)};
			parameters[0].Value = model.BusinessID;
			parameters[1].Value = model.BusPhotoAlbumID;
			parameters[2].Value = model.AlbumName;
			parameters[3].Value = model.AlbumDesc;
			parameters[4].Value = model.IsDefault;

			int rows=ServerDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Maticsoft.Model.BusPhotoAlbum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BusPhotoAlbum set ");
			strSql.Append("BusinessID=@BusinessID,");
			strSql.Append("AlbumName=@AlbumName,");
			strSql.Append("AlbumDesc=@AlbumDesc,");
			strSql.Append("IsDefault=@IsDefault");
			strSql.Append(" where BusPhotoAlbumID=@BusPhotoAlbumID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BusinessID", SqlDbType.NVarChar,50),
					new SqlParameter("@AlbumName", SqlDbType.NVarChar,20),
					new SqlParameter("@AlbumDesc", SqlDbType.NVarChar,200),
					new SqlParameter("@IsDefault", SqlDbType.Bit,1),
					new SqlParameter("@BusPhotoAlbumID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.BusinessID;
			parameters[1].Value = model.AlbumName;
			parameters[2].Value = model.AlbumDesc;
			parameters[3].Value = model.IsDefault;
			parameters[4].Value = model.BusPhotoAlbumID;

			int rows=ServerDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Remove(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BusPhotoAlbum ");
            strSql.Append(" where 1=1 and ");
            strSql.Append(strWhere);

            int rows = ServerDbHelperSQL.ExecuteSql(strSql.ToString(), new SqlParameter[0]);
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
		public bool Delete(string BusPhotoAlbumID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BusPhotoAlbum ");
			strSql.Append(" where BusPhotoAlbumID=@BusPhotoAlbumID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BusPhotoAlbumID", SqlDbType.VarChar,50)			};
			parameters[0].Value = BusPhotoAlbumID;

			int rows=ServerDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string BusPhotoAlbumIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BusPhotoAlbum ");
			strSql.Append(" where BusPhotoAlbumID in ("+BusPhotoAlbumIDlist + ")  ");
			int rows=ServerDbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.BusPhotoAlbum GetModel(string BusPhotoAlbumID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BusinessID,BusPhotoAlbumID,AlbumName,AlbumDesc,IsDefault from BusPhotoAlbum ");
			strSql.Append(" where BusPhotoAlbumID=@BusPhotoAlbumID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BusPhotoAlbumID", SqlDbType.VarChar,50)			};
			parameters[0].Value = BusPhotoAlbumID;

			Maticsoft.Model.BusPhotoAlbum model=new Maticsoft.Model.BusPhotoAlbum();
			DataSet ds=ServerDbHelperSQL.Query(strSql.ToString(),parameters);
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
		public Maticsoft.Model.BusPhotoAlbum DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BusPhotoAlbum model=new Maticsoft.Model.BusPhotoAlbum();
			if (row != null)
			{
				if(row["BusinessID"]!=null)
				{
					model.BusinessID=row["BusinessID"].ToString();
				}
				if(row["BusPhotoAlbumID"]!=null)
				{
					model.BusPhotoAlbumID=row["BusPhotoAlbumID"].ToString();
				}
				if(row["AlbumName"]!=null)
				{
					model.AlbumName=row["AlbumName"].ToString();
				}
				if(row["AlbumDesc"]!=null)
				{
					model.AlbumDesc=row["AlbumDesc"].ToString();
				}
				if(row["IsDefault"]!=null && row["IsDefault"].ToString()!="")
				{
					if((row["IsDefault"].ToString()=="1")||(row["IsDefault"].ToString().ToLower()=="true"))
					{
						model.IsDefault=true;
					}
					else
					{
						model.IsDefault=false;
					}
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
			strSql.Append("select BusinessID,BusPhotoAlbumID,AlbumName,AlbumDesc,IsDefault ");
			strSql.Append(" FROM BusPhotoAlbum ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return ServerDbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" BusinessID,BusPhotoAlbumID,AlbumName,AlbumDesc,IsDefault ");
			strSql.Append(" FROM BusPhotoAlbum ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return ServerDbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BusPhotoAlbum ");
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
				strSql.Append("order by T.BusPhotoAlbumID desc");
			}
			strSql.Append(")AS Row, T.*  from BusPhotoAlbum T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return ServerDbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "BusPhotoAlbum";
			parameters[1].Value = "BusPhotoAlbumID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return ServerDbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

