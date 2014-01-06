/**  版本信息模板在安装目录下，可自行修改。
* StoreLocalTag.cs
*
* 功 能： N/A
* 类 名： StoreLocalTag
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/13 15:03:12   N/A    初版
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
	/// 数据访问类:StoreLocalTag
	/// </summary>
	public partial class StoreLocalTag
	{
		public StoreLocalTag()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreLocalTag");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = KeyID;

			return ServerDbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.StoreLocalTag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreLocalTag(");
			strSql.Append("KeyID,LocalTagID,LocalTagName,BizID,DistrictID,BizType)");
			strSql.Append(" values (");
			strSql.Append("@KeyID,@LocalTagID,@LocalTagName,@BizID,@DistrictID,@BizType)");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50),
					new SqlParameter("@LocalTagID", SqlDbType.NVarChar,50),
					new SqlParameter("@LocalTagName", SqlDbType.NVarChar,50),
					new SqlParameter("@BizID", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictID", SqlDbType.NVarChar,50),
					new SqlParameter("@BizType", SqlDbType.Int,4)};
			parameters[0].Value = model.KeyID;
			parameters[1].Value = model.LocalTagID;
			parameters[2].Value = model.LocalTagName;
			parameters[3].Value = model.BizID;
			parameters[4].Value = model.DistrictID;
			parameters[5].Value = model.BizType;

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
		public bool Update(Maticsoft.Model.StoreLocalTag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreLocalTag set ");
			strSql.Append("LocalTagID=@LocalTagID,");
			strSql.Append("LocalTagName=@LocalTagName,");
			strSql.Append("BizID=@BizID,");
			strSql.Append("DistrictID=@DistrictID,");
			strSql.Append("BizType=@BizType");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LocalTagID", SqlDbType.NVarChar,50),
					new SqlParameter("@LocalTagName", SqlDbType.NVarChar,50),
					new SqlParameter("@BizID", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictID", SqlDbType.NVarChar,50),
					new SqlParameter("@BizType", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.LocalTagID;
			parameters[1].Value = model.LocalTagName;
			parameters[2].Value = model.BizID;
			parameters[3].Value = model.DistrictID;
			parameters[4].Value = model.BizType;
			parameters[5].Value = model.KeyID;

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
		public bool Delete(string KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreLocalTag ");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = KeyID;

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
		public bool DeleteList(string KeyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreLocalTag ");
			strSql.Append(" where KeyID in ("+KeyIDlist + ")  ");
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
		public Maticsoft.Model.StoreLocalTag GetModel(string KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,LocalTagID,LocalTagName,BizID,DistrictID,BizType from StoreLocalTag ");
			strSql.Append(" where KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = KeyID;

			Maticsoft.Model.StoreLocalTag model=new Maticsoft.Model.StoreLocalTag();
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
		public Maticsoft.Model.StoreLocalTag DataRowToModel(DataRow row)
		{
			Maticsoft.Model.StoreLocalTag model=new Maticsoft.Model.StoreLocalTag();
			if (row != null)
			{
				if(row["KeyID"]!=null)
				{
					model.KeyID=row["KeyID"].ToString();
				}
				if(row["LocalTagID"]!=null)
				{
					model.LocalTagID=row["LocalTagID"].ToString();
				}
				if(row["LocalTagName"]!=null)
				{
					model.LocalTagName=row["LocalTagName"].ToString();
				}
				if(row["BizID"]!=null)
				{
					model.BizID=row["BizID"].ToString();
				}
				if(row["DistrictID"]!=null)
				{
					model.DistrictID=row["DistrictID"].ToString();
				}
				if(row["BizType"]!=null && row["BizType"].ToString()!="")
				{
					model.BizType=int.Parse(row["BizType"].ToString());
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
			strSql.Append("select KeyID,LocalTagID,LocalTagName,BizID,DistrictID,BizType ");
			strSql.Append(" FROM StoreLocalTag ");
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
			strSql.Append(" KeyID,LocalTagID,LocalTagName,BizID,DistrictID,BizType ");
			strSql.Append(" FROM StoreLocalTag ");
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
			strSql.Append("select count(1) FROM StoreLocalTag ");
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
			strSql.Append(")AS Row, T.*  from StoreLocalTag T ");
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
			parameters[0].Value = "StoreLocalTag";
			parameters[1].Value = "KeyID";
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

