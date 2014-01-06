﻿/**  版本信息模板在安装目录下，可自行修改。
* Dishes.cs
*
* 功 能： N/A
* 类 名： Dishes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/19 15:47:37   N/A    初版
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
	/// 数据访问类:Dishes
	/// </summary>
	public partial class Dishes
	{
		public Dishes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DishesID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Dishes");
			strSql.Append(" where DishesID=@DishesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = DishesID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Dishes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Dishes(");
			strSql.Append("DishesID,DishesName,DishesMoney,popularity,StoreId,PictureName,dishTypeID,DishesUnit,DishesBrief)");
			strSql.Append(" values (");
			strSql.Append("@DishesID,@DishesName,@DishesMoney,@popularity,@StoreId,@PictureName,@dishTypeID,@DishesUnit,@DishesBrief)");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesID", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesName", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@popularity", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreId", SqlDbType.NVarChar,50),
					new SqlParameter("@PictureName", SqlDbType.NVarChar,50),
					new SqlParameter("@dishTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesBrief", SqlDbType.NVarChar,1000)};
			parameters[0].Value = model.DishesID;
			parameters[1].Value = model.DishesName;
			parameters[2].Value = model.DishesMoney;
			parameters[3].Value = model.popularity;
			parameters[4].Value = model.StoreId;
			parameters[5].Value = model.PictureName;
			parameters[6].Value = model.dishTypeID;
			parameters[7].Value = model.DishesUnit;
			parameters[8].Value = model.DishesBrief;

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
		public bool Update(Maticsoft.Model.Dishes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Dishes set ");
			strSql.Append("DishesName=@DishesName,");
			strSql.Append("DishesMoney=@DishesMoney,");
			strSql.Append("popularity=@popularity,");
			strSql.Append("StoreId=@StoreId,");
			strSql.Append("PictureName=@PictureName,");
			strSql.Append("dishTypeID=@dishTypeID,");
			strSql.Append("DishesUnit=@DishesUnit,");
			strSql.Append("DishesBrief=@DishesBrief");
			strSql.Append(" where DishesID=@DishesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesName", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@popularity", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreId", SqlDbType.NVarChar,50),
					new SqlParameter("@PictureName", SqlDbType.NVarChar,50),
					new SqlParameter("@dishTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesBrief", SqlDbType.NVarChar,1000),
					new SqlParameter("@DishesID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.DishesName;
			parameters[1].Value = model.DishesMoney;
			parameters[2].Value = model.popularity;
			parameters[3].Value = model.StoreId;
			parameters[4].Value = model.PictureName;
			parameters[5].Value = model.dishTypeID;
			parameters[6].Value = model.DishesUnit;
			parameters[7].Value = model.DishesBrief;
			parameters[8].Value = model.DishesID;

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
		public bool Delete(string DishesID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Dishes ");
			strSql.Append(" where DishesID=@DishesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = DishesID;

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
		public bool DeleteList(string DishesIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Dishes ");
			strSql.Append(" where DishesID in ("+DishesIDlist + ")  ");
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
		public Maticsoft.Model.Dishes GetModel(string DishesID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DishesID,DishesName,DishesMoney,popularity,StoreId,PictureName,dishTypeID,DishesUnit,DishesBrief from Dishes ");
			strSql.Append(" where DishesID=@DishesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = DishesID;

			Maticsoft.Model.Dishes model=new Maticsoft.Model.Dishes();
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
		public Maticsoft.Model.Dishes DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Dishes model=new Maticsoft.Model.Dishes();
			if (row != null)
			{
				if(row["DishesID"]!=null)
				{
					model.DishesID=row["DishesID"].ToString();
				}
				if(row["DishesName"]!=null)
				{
					model.DishesName=row["DishesName"].ToString();
				}
				if(row["DishesMoney"]!=null)
				{
					model.DishesMoney=row["DishesMoney"].ToString();
				}
				if(row["popularity"]!=null)
				{
					model.popularity=row["popularity"].ToString();
				}
				if(row["StoreId"]!=null)
				{
					model.StoreId=row["StoreId"].ToString();
				}
				if(row["PictureName"]!=null)
				{
					model.PictureName=row["PictureName"].ToString();
				}
				if(row["dishTypeID"]!=null)
				{
					model.dishTypeID=row["dishTypeID"].ToString();
				}
				if(row["DishesUnit"]!=null)
				{
					model.DishesUnit=row["DishesUnit"].ToString();
				}
				if(row["DishesBrief"]!=null)
				{
					model.DishesBrief=row["DishesBrief"].ToString();
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
			strSql.Append("select DishesID,DishesName,DishesMoney,popularity,StoreId,PictureName,dishTypeID,DishesUnit,DishesBrief ");
			strSql.Append(" FROM Dishes ");
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
			strSql.Append(" DishesID,DishesName,DishesMoney,popularity,StoreId,PictureName,dishTypeID,DishesUnit,DishesBrief ");
			strSql.Append(" FROM Dishes ");
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
			strSql.Append("select count(1) FROM Dishes ");
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
				strSql.Append("order by T.DishesID desc");
			}
			strSql.Append(")AS Row, T.*  from Dishes T ");
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
			parameters[0].Value = "Dishes";
			parameters[1].Value = "DishesID";
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

