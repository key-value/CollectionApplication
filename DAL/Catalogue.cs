﻿/**  版本信息模板在安装目录下，可自行修改。
* Catalogue.cs
*
* 功 能： N/A
* 类 名： Catalogue
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/20 9:58:04   N/A    初版
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
	/// 数据访问类:Catalogue
	/// </summary>
	public partial class Catalogue
	{
		public Catalogue()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Catalogue");
			strSql.Append(" where FId=@FId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FId", SqlDbType.VarChar,50)			};
			parameters[0].Value = FId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Catalogue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Catalogue(");
			strSql.Append("FId,href,title,LocalTagID,StoreId,picName)");
			strSql.Append(" values (");
			strSql.Append("@FId,@href,@title,@LocalTagID,@StoreId,@picName)");
			SqlParameter[] parameters = {
					new SqlParameter("@FId", SqlDbType.VarChar,50),
					new SqlParameter("@href", SqlDbType.VarChar,200),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@LocalTagID", SqlDbType.Int,4),
					new SqlParameter("@StoreId", SqlDbType.NVarChar,50),
					new SqlParameter("@picName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.FId;
			parameters[1].Value = model.href;
			parameters[2].Value = model.title;
			parameters[3].Value = model.LocalTagID;
			parameters[4].Value = model.StoreId;
			parameters[5].Value = model.picName;

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
		public bool Update(Maticsoft.Model.Catalogue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Catalogue set ");
			strSql.Append("href=@href,");
			strSql.Append("title=@title,");
			strSql.Append("LocalTagID=@LocalTagID,");
			strSql.Append("StoreId=@StoreId,");
			strSql.Append("picName=@picName");
			strSql.Append(" where FId=@FId ");
			SqlParameter[] parameters = {
					new SqlParameter("@href", SqlDbType.VarChar,200),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@LocalTagID", SqlDbType.Int,4),
					new SqlParameter("@StoreId", SqlDbType.NVarChar,50),
					new SqlParameter("@picName", SqlDbType.NVarChar,50),
					new SqlParameter("@FId", SqlDbType.VarChar,50)};
			parameters[0].Value = model.href;
			parameters[1].Value = model.title;
			parameters[2].Value = model.LocalTagID;
			parameters[3].Value = model.StoreId;
			parameters[4].Value = model.picName;
			parameters[5].Value = model.FId;

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
		public bool Delete(string FId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Catalogue ");
			strSql.Append(" where FId=@FId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FId", SqlDbType.VarChar,50)			};
			parameters[0].Value = FId;

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
		public bool DeleteList(string FIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Catalogue ");
			strSql.Append(" where FId in ("+FIdlist + ")  ");
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
		public Maticsoft.Model.Catalogue GetModel(string FId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FId,href,title,LocalTagID,StoreId,picName from Catalogue ");
			strSql.Append(" where FId=@FId ");
			SqlParameter[] parameters = {
					new SqlParameter("@FId", SqlDbType.VarChar,50)			};
			parameters[0].Value = FId;

			Maticsoft.Model.Catalogue model=new Maticsoft.Model.Catalogue();
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
		public Maticsoft.Model.Catalogue DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Catalogue model=new Maticsoft.Model.Catalogue();
			if (row != null)
			{
				if(row["FId"]!=null)
				{
					model.FId=row["FId"].ToString();
				}
				if(row["href"]!=null)
				{
					model.href=row["href"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["LocalTagID"]!=null && row["LocalTagID"].ToString()!="")
				{
					model.LocalTagID=int.Parse(row["LocalTagID"].ToString());
				}
				if(row["StoreId"]!=null)
				{
					model.StoreId=row["StoreId"].ToString();
				}
				if(row["picName"]!=null)
				{
					model.picName=row["picName"].ToString();
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
			strSql.Append("select FId,href,title,LocalTagID,StoreId,picName ");
			strSql.Append(" FROM Catalogue ");
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
			strSql.Append(" FId,href,title,LocalTagID,StoreId,picName ");
			strSql.Append(" FROM Catalogue ");
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
			strSql.Append("select count(1) FROM Catalogue ");
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
				strSql.Append("order by T.FId desc");
			}
			strSql.Append(")AS Row, T.*  from Catalogue T ");
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
			parameters[0].Value = "Catalogue";
			parameters[1].Value = "FId";
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

