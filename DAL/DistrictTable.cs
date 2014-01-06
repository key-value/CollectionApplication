/**  版本信息模板在安装目录下，可自行修改。
* DistrictTable.cs
*
* 功 能： N/A
* 类 名： DistrictTable
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/18 17:09:16   N/A    初版
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
	/// 数据访问类:DistrictTable
	/// </summary>
	public partial class DistrictTable
	{
		public DistrictTable()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.DistrictTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DistrictTable(");
			strSql.Append("DistrictID,DistrictName,CityID,SortID,SiteID)");
			strSql.Append(" values (");
			strSql.Append("@DistrictID,@DistrictName,@CityID,@SortID,@SiteID)");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@SiteID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.DistrictID;
			parameters[1].Value = model.DistrictName;
			parameters[2].Value = model.CityID;
			parameters[3].Value = model.SortID;
			parameters[4].Value = model.SiteID;

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
		public bool Update(Maticsoft.Model.DistrictTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DistrictTable set ");
			strSql.Append("DistrictID=@DistrictID,");
			strSql.Append("DistrictName=@DistrictName,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("SortID=@SortID,");
			strSql.Append("SiteID=@SiteID");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictID", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@SiteID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.DistrictID;
			parameters[1].Value = model.DistrictName;
			parameters[2].Value = model.CityID;
			parameters[3].Value = model.SortID;
			parameters[4].Value = model.SiteID;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DistrictTable ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.DistrictTable GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DistrictID,DistrictName,CityID,SortID,SiteID from DistrictTable ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.DistrictTable model=new Maticsoft.Model.DistrictTable();
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
		public Maticsoft.Model.DistrictTable DataRowToModel(DataRow row)
		{
			Maticsoft.Model.DistrictTable model=new Maticsoft.Model.DistrictTable();
			if (row != null)
			{
				if(row["DistrictID"]!=null)
				{
					model.DistrictID=row["DistrictID"].ToString();
				}
				if(row["DistrictName"]!=null)
				{
					model.DistrictName=row["DistrictName"].ToString();
				}
				if(row["CityID"]!=null)
				{
					model.CityID=row["CityID"].ToString();
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
				if(row["SiteID"]!=null)
				{
					model.SiteID=row["SiteID"].ToString();
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
			strSql.Append("select DistrictID,DistrictName,CityID,SortID,SiteID ");
			strSql.Append(" FROM DistrictTable ");
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
			strSql.Append(" DistrictID,DistrictName,CityID,SortID,SiteID ");
			strSql.Append(" FROM DistrictTable ");
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
			strSql.Append("select count(1) FROM DistrictTable ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from DistrictTable T ");
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
			parameters[0].Value = "DistrictTable";
			parameters[1].Value = "";
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

