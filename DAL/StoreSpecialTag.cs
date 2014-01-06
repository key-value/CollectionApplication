/**  版本信息模板在安装目录下，可自行修改。
* StoreSpecialTag.cs
*
* 功 能： N/A
* 类 名： StoreSpecialTag
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/11 17:43:09   N/A    初版
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
	/// 数据访问类:StoreSpecialTag
	/// </summary>
	public partial class StoreSpecialTag
	{
		public StoreSpecialTag()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StoreSpecialTagID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreSpecialTag");
			strSql.Append(" where StoreSpecialTagID=@StoreSpecialTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreSpecialTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = StoreSpecialTagID;

			return ServerDbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.StoreSpecialTag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreSpecialTag(");
			strSql.Append("StoreSpecialTagID,BizID,SpecialTagID,TagName)");
			strSql.Append(" values (");
			strSql.Append("@StoreSpecialTagID,@BizID,@SpecialTagID,@TagName)");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreSpecialTagID", SqlDbType.NVarChar,50),
					new SqlParameter("@BizID", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecialTagID", SqlDbType.NVarChar,50),
					new SqlParameter("@TagName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.StoreSpecialTagID;
			parameters[1].Value = model.BizID;
			parameters[2].Value = model.SpecialTagID;
			parameters[3].Value = model.TagName;

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
		public bool Update(Maticsoft.Model.StoreSpecialTag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreSpecialTag set ");
			strSql.Append("BizID=@BizID,");
			strSql.Append("SpecialTagID=@SpecialTagID,");
			strSql.Append("TagName=@TagName");
			strSql.Append(" where StoreSpecialTagID=@StoreSpecialTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BizID", SqlDbType.NVarChar,50),
					new SqlParameter("@SpecialTagID", SqlDbType.NVarChar,50),
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreSpecialTagID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.BizID;
			parameters[1].Value = model.SpecialTagID;
			parameters[2].Value = model.TagName;
			parameters[3].Value = model.StoreSpecialTagID;

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
		public bool Delete(string StoreSpecialTagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreSpecialTag ");
			strSql.Append(" where StoreSpecialTagID=@StoreSpecialTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreSpecialTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = StoreSpecialTagID;

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
		public bool DeleteList(string StoreSpecialTagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreSpecialTag ");
			strSql.Append(" where StoreSpecialTagID in ("+StoreSpecialTagIDlist + ")  ");
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
		public Maticsoft.Model.StoreSpecialTag GetModel(string StoreSpecialTagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreSpecialTagID,BizID,SpecialTagID,TagName from StoreSpecialTag ");
			strSql.Append(" where StoreSpecialTagID=@StoreSpecialTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreSpecialTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = StoreSpecialTagID;

			Maticsoft.Model.StoreSpecialTag model=new Maticsoft.Model.StoreSpecialTag();
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
		public Maticsoft.Model.StoreSpecialTag DataRowToModel(DataRow row)
		{
			Maticsoft.Model.StoreSpecialTag model=new Maticsoft.Model.StoreSpecialTag();
			if (row != null)
			{
				if(row["StoreSpecialTagID"]!=null)
				{
					model.StoreSpecialTagID=row["StoreSpecialTagID"].ToString();
				}
				if(row["BizID"]!=null)
				{
					model.BizID=row["BizID"].ToString();
				}
				if(row["SpecialTagID"]!=null)
				{
					model.SpecialTagID=row["SpecialTagID"].ToString();
				}
				if(row["TagName"]!=null)
				{
					model.TagName=row["TagName"].ToString();
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
			strSql.Append("select StoreSpecialTagID,BizID,SpecialTagID,TagName ");
			strSql.Append(" FROM StoreSpecialTag ");
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
			strSql.Append(" StoreSpecialTagID,BizID,SpecialTagID,TagName ");
			strSql.Append(" FROM StoreSpecialTag ");
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
			strSql.Append("select count(1) FROM StoreSpecialTag ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = ServerDbHelperSQL.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.StoreSpecialTagID desc");
			}
			strSql.Append(")AS Row, T.*  from StoreSpecialTag T ");
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
			parameters[0].Value = "StoreSpecialTag";
			parameters[1].Value = "StoreSpecialTagID";
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

