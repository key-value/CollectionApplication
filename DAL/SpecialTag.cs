/**  版本信息模板在安装目录下，可自行修改。
* SpecialTag.cs
*
* 功 能： N/A
* 类 名： SpecialTag
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
	/// 数据访问类:SpecialTag
	/// </summary>
	public partial class SpecialTag
	{
		public SpecialTag()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SpecialTagID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SpecialTag");
			strSql.Append(" where SpecialTagID=@SpecialTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecialTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = SpecialTagID;

			return ServerDbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SpecialTag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SpecialTag(");
			strSql.Append("SpecialTagID,TagName,CityID,Sort)");
			strSql.Append(" values (");
			strSql.Append("@SpecialTagID,@TagName,@CityID,@Sort)");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecialTagID", SqlDbType.NVarChar,50),
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
			parameters[0].Value = model.SpecialTagID;
			parameters[1].Value = model.TagName;
			parameters[2].Value = model.CityID;
			parameters[3].Value = model.Sort;

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
		public bool Update(Maticsoft.Model.SpecialTag model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SpecialTag set ");
			strSql.Append("TagName=@TagName,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("Sort=@Sort");
			strSql.Append(" where SpecialTagID=@SpecialTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@SpecialTagID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.TagName;
			parameters[1].Value = model.CityID;
			parameters[2].Value = model.Sort;
			parameters[3].Value = model.SpecialTagID;

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
		public bool Delete(string SpecialTagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SpecialTag ");
			strSql.Append(" where SpecialTagID=@SpecialTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecialTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = SpecialTagID;

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
		public bool DeleteList(string SpecialTagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SpecialTag ");
			strSql.Append(" where SpecialTagID in ("+SpecialTagIDlist + ")  ");
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
		public Maticsoft.Model.SpecialTag GetModel(string SpecialTagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SpecialTagID,TagName,CityID,Sort from SpecialTag ");
			strSql.Append(" where SpecialTagID=@SpecialTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SpecialTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = SpecialTagID;

			Maticsoft.Model.SpecialTag model=new Maticsoft.Model.SpecialTag();
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
		public Maticsoft.Model.SpecialTag DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SpecialTag model=new Maticsoft.Model.SpecialTag();
			if (row != null)
			{
				if(row["SpecialTagID"]!=null)
				{
					model.SpecialTagID=row["SpecialTagID"].ToString();
				}
				if(row["TagName"]!=null)
				{
					model.TagName=row["TagName"].ToString();
				}
				if(row["CityID"]!=null)
				{
					model.CityID=row["CityID"].ToString();
				}
				if(row["Sort"]!=null && row["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(row["Sort"].ToString());
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
			strSql.Append("select SpecialTagID,TagName,CityID,Sort ");
			strSql.Append(" FROM SpecialTag ");
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
			strSql.Append(" SpecialTagID,TagName,CityID,Sort ");
			strSql.Append(" FROM SpecialTag ");
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
			strSql.Append("select count(1) FROM SpecialTag ");
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
				strSql.Append("order by T.SpecialTagID desc");
			}
			strSql.Append(")AS Row, T.*  from SpecialTag T ");
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
			parameters[0].Value = "SpecialTag";
			parameters[1].Value = "SpecialTagID";
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

