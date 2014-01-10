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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:StorePicture
	/// </summary>
	public partial class StorePicture
	{
		public StorePicture()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StorePicture");
			strSql.Append(" where PID=@PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = PID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.StorePicture model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StorePicture(");
			strSql.Append("PID,StoreId,PictureName,PicturePath,PicType)");
			strSql.Append(" values (");
			strSql.Append("@PID,@StoreId,@PictureName,@PicturePath,@PicType)");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreId", SqlDbType.NVarChar,50),
					new SqlParameter("@PictureName", SqlDbType.NVarChar,50),
					new SqlParameter("@PicturePath", SqlDbType.NVarChar,500),
					new SqlParameter("@PicType", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.StoreId;
			parameters[2].Value = model.PictureName;
			parameters[3].Value = model.PicturePath;
			parameters[4].Value = model.PicType;

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
		public bool Update(Maticsoft.Model.StorePicture model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StorePicture set ");
			strSql.Append("StoreId=@StoreId,");
			strSql.Append("PictureName=@PictureName,");
			strSql.Append("PicturePath=@PicturePath,");
			strSql.Append("PicType=@PicType");
			strSql.Append(" where PID=@PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreId", SqlDbType.NVarChar,50),
					new SqlParameter("@PictureName", SqlDbType.NVarChar,50),
					new SqlParameter("@PicturePath", SqlDbType.NVarChar,500),
					new SqlParameter("@PicType", SqlDbType.NVarChar,50),
					new SqlParameter("@PID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.StoreId;
			parameters[1].Value = model.PictureName;
			parameters[2].Value = model.PicturePath;
			parameters[3].Value = model.PicType;
			parameters[4].Value = model.PID;

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
        public bool Remove(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StorePicture");
            strSql.Append(" where 1=1 and ");
            strSql.Append(strWhere);

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), new SqlParameter[0]);
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
		public bool Delete(string PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StorePicture ");
			strSql.Append(" where PID=@PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = PID;

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
		public bool DeleteList(string PIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StorePicture ");
			strSql.Append(" where PID in ("+PIDlist + ")  ");
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
		public Maticsoft.Model.StorePicture GetModel(string PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PID,StoreId,PictureName,PicturePath,PicType from StorePicture ");
			strSql.Append(" where PID=@PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = PID;

			Maticsoft.Model.StorePicture model=new Maticsoft.Model.StorePicture();
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
		public Maticsoft.Model.StorePicture DataRowToModel(DataRow row)
		{
			Maticsoft.Model.StorePicture model=new Maticsoft.Model.StorePicture();
			if (row != null)
			{
				if(row["PID"]!=null)
				{
					model.PID=row["PID"].ToString();
				}
				if(row["StoreId"]!=null)
				{
					model.StoreId=row["StoreId"].ToString();
				}
				if(row["PictureName"]!=null)
				{
					model.PictureName=row["PictureName"].ToString();
				}
				if(row["PicturePath"]!=null)
				{
					model.PicturePath=row["PicturePath"].ToString();
				}
				if(row["PicType"]!=null)
				{
					model.PicType=row["PicType"].ToString();
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
			strSql.Append("select PID,StoreId,PictureName,PicturePath,PicType ");
			strSql.Append(" FROM StorePicture ");
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
			strSql.Append(" PID,StoreId,PictureName,PicturePath,PicType ");
			strSql.Append(" FROM StorePicture ");
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
			strSql.Append("select count(1) FROM StorePicture ");
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
				strSql.Append("order by T.PID desc");
			}
			strSql.Append(")AS Row, T.*  from StorePicture T ");
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
			parameters[0].Value = "StorePicture";
			parameters[1].Value = "PID";
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

