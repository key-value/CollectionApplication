/**  版本信息模板在安装目录下，可自行修改。
* StoreCookingStylesTable.cs
*
* 功 能： N/A
* 类 名： StoreCookingStylesTable
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
	/// 数据访问类:StoreCookingStylesTable
	/// </summary>
	public partial class StoreCookingStylesTable
	{
		public StoreCookingStylesTable()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreCookingStylesTable");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = KeyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.StoreCookingStylesTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreCookingStylesTable(");
			strSql.Append("KeyID,BizID,CookingStyleID,CookingStyleName)");
			strSql.Append(" values (");
			strSql.Append("@KeyID,@BizID,@CookingStyleID,@CookingStyleName)");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50),
					new SqlParameter("@BizID", SqlDbType.NVarChar,50),
					new SqlParameter("@CookingStyleID", SqlDbType.NVarChar,50),
					new SqlParameter("@CookingStyleName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.KeyID;
			parameters[1].Value = model.BizID;
			parameters[2].Value = model.CookingStyleID;
			parameters[3].Value = model.CookingStyleName;

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
		public bool Update(Maticsoft.Model.StoreCookingStylesTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreCookingStylesTable set ");
			strSql.Append("BizID=@BizID,");
			strSql.Append("CookingStyleID=@CookingStyleID,");
			strSql.Append("CookingStyleName=@CookingStyleName");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BizID", SqlDbType.NVarChar,50),
					new SqlParameter("@CookingStyleID", SqlDbType.NVarChar,50),
					new SqlParameter("@CookingStyleName", SqlDbType.NVarChar,50),
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.BizID;
			parameters[1].Value = model.CookingStyleID;
			parameters[2].Value = model.CookingStyleName;
			parameters[3].Value = model.KeyID;

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
		public bool Delete(string KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreCookingStylesTable ");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = KeyID;

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
		public bool DeleteList(string KeyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreCookingStylesTable ");
			strSql.Append(" where KeyID in ("+KeyIDlist + ")  ");
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
		public Maticsoft.Model.StoreCookingStylesTable GetModel(string KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,BizID,CookingStyleID,CookingStyleName from StoreCookingStylesTable ");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = KeyID;

			Maticsoft.Model.StoreCookingStylesTable model=new Maticsoft.Model.StoreCookingStylesTable();
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
		public Maticsoft.Model.StoreCookingStylesTable DataRowToModel(DataRow row)
		{
			Maticsoft.Model.StoreCookingStylesTable model=new Maticsoft.Model.StoreCookingStylesTable();
			if (row != null)
			{
				if(row["KeyID"]!=null)
				{
					model.KeyID=row["KeyID"].ToString();
				}
				if(row["BizID"]!=null)
				{
					model.BizID=row["BizID"].ToString();
				}
				if(row["CookingStyleID"]!=null)
				{
					model.CookingStyleID=row["CookingStyleID"].ToString();
				}
				if(row["CookingStyleName"]!=null)
				{
					model.CookingStyleName=row["CookingStyleName"].ToString();
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
			strSql.Append("select KeyID,BizID,CookingStyleID,CookingStyleName ");
			strSql.Append(" FROM StoreCookingStylesTable ");
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
			strSql.Append(" KeyID,BizID,CookingStyleID,CookingStyleName ");
			strSql.Append(" FROM StoreCookingStylesTable ");
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
			strSql.Append("select count(1) FROM StoreCookingStylesTable ");
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
				strSql.Append("order by T.KeyID desc");
			}
			strSql.Append(")AS Row, T.*  from StoreCookingStylesTable T ");
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
			parameters[0].Value = "StoreCookingStylesTable";
			parameters[1].Value = "KeyID";
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

