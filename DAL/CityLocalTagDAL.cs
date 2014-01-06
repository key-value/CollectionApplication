/**  版本信息模板在安装目录下，可自行修改。
* CityLocalTag.cs
*
* 功 能： N/A
* 类 名： CityLocalTag
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
	/// 数据访问类:CityLocalTag
	/// </summary>
	public partial class CityLocalTagDAL
	{
        public CityLocalTagDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string LocalTagID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CityLocalTag");
			strSql.Append(" where LocalTagID=@LocalTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LocalTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = LocalTagID;

			return ServerDbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.CityLocalTagEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CityLocalTag(");
			strSql.Append("LocalTagID,TagName,DistrictID,CityID,TagGrade,Sort,GLat,GLng,BLat,BLng,FLetter,BusinessesNumber)");
			strSql.Append(" values (");
			strSql.Append("@LocalTagID,@TagName,@DistrictID,@CityID,@TagGrade,@Sort,@GLat,@GLng,@BLat,@BLng,@FLetter,@BusinessesNumber)");
			SqlParameter[] parameters = {
					new SqlParameter("@LocalTagID", SqlDbType.NVarChar,50),
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictID", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@TagGrade", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@GLat", SqlDbType.NVarChar,50),
					new SqlParameter("@GLng", SqlDbType.NVarChar,50),
					new SqlParameter("@BLat", SqlDbType.NVarChar,50),
					new SqlParameter("@BLng", SqlDbType.NVarChar,50),
					new SqlParameter("@FLetter", SqlDbType.NVarChar,20),
					new SqlParameter("@BusinessesNumber", SqlDbType.Int,4)};
			parameters[0].Value = model.LocalTagID;
			parameters[1].Value = model.TagName;
			parameters[2].Value = model.DistrictID;
			parameters[3].Value = model.CityID;
			parameters[4].Value = model.TagGrade;
			parameters[5].Value = model.Sort;
			parameters[6].Value = model.GLat;
			parameters[7].Value = model.GLng;
			parameters[8].Value = model.BLat;
			parameters[9].Value = model.BLng;
			parameters[10].Value = model.FLetter;
			parameters[11].Value = model.BusinessesNumber;

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
		public bool Update(Maticsoft.Model.CityLocalTagEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CityLocalTag set ");
			strSql.Append("TagName=@TagName,");
			strSql.Append("DistrictID=@DistrictID,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("TagGrade=@TagGrade,");
			strSql.Append("Sort=@Sort,");
			strSql.Append("GLat=@GLat,");
			strSql.Append("GLng=@GLng,");
			strSql.Append("BLat=@BLat,");
			strSql.Append("BLng=@BLng,");
			strSql.Append("FLetter=@FLetter,");
			strSql.Append("BusinessesNumber=@BusinessesNumber");
			strSql.Append(" where LocalTagID=@LocalTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TagName", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictID", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@TagGrade", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@GLat", SqlDbType.NVarChar,50),
					new SqlParameter("@GLng", SqlDbType.NVarChar,50),
					new SqlParameter("@BLat", SqlDbType.NVarChar,50),
					new SqlParameter("@BLng", SqlDbType.NVarChar,50),
					new SqlParameter("@FLetter", SqlDbType.NVarChar,20),
					new SqlParameter("@BusinessesNumber", SqlDbType.Int,4),
					new SqlParameter("@LocalTagID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.TagName;
			parameters[1].Value = model.DistrictID;
			parameters[2].Value = model.CityID;
			parameters[3].Value = model.TagGrade;
			parameters[4].Value = model.Sort;
			parameters[5].Value = model.GLat;
			parameters[6].Value = model.GLng;
			parameters[7].Value = model.BLat;
			parameters[8].Value = model.BLng;
			parameters[9].Value = model.FLetter;
			parameters[10].Value = model.BusinessesNumber;
			parameters[11].Value = model.LocalTagID;

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
		public bool Delete(string LocalTagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CityLocalTag ");
			strSql.Append(" where LocalTagID=@LocalTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LocalTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = LocalTagID;

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
		public bool DeleteList(string LocalTagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CityLocalTag ");
			strSql.Append(" where LocalTagID in ("+LocalTagIDlist + ")  ");
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
		public Maticsoft.Model.CityLocalTagEntity GetModel(string LocalTagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LocalTagID,TagName,DistrictID,CityID,TagGrade,Sort,GLat,GLng,BLat,BLng,FLetter,BusinessesNumber from CityLocalTag ");
			strSql.Append(" where LocalTagID=@LocalTagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LocalTagID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = LocalTagID;

			Maticsoft.Model.CityLocalTagEntity model=new Maticsoft.Model.CityLocalTagEntity();
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
		public Maticsoft.Model.CityLocalTagEntity DataRowToModel(DataRow row)
		{
			Maticsoft.Model.CityLocalTagEntity model=new Maticsoft.Model.CityLocalTagEntity();
			if (row != null)
			{
				if(row["LocalTagID"]!=null)
				{
					model.LocalTagID=row["LocalTagID"].ToString();
				}
				if(row["TagName"]!=null)
				{
					model.TagName=row["TagName"].ToString();
				}
				if(row["DistrictID"]!=null)
				{
					model.DistrictID=row["DistrictID"].ToString();
				}
				if(row["CityID"]!=null)
				{
					model.CityID=row["CityID"].ToString();
				}
				if(row["TagGrade"]!=null && row["TagGrade"].ToString()!="")
				{
					model.TagGrade=int.Parse(row["TagGrade"].ToString());
				}
				if(row["Sort"]!=null && row["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(row["Sort"].ToString());
				}
				if(row["GLat"]!=null)
				{
					model.GLat=row["GLat"].ToString();
				}
				if(row["GLng"]!=null)
				{
					model.GLng=row["GLng"].ToString();
				}
				if(row["BLat"]!=null)
				{
					model.BLat=row["BLat"].ToString();
				}
				if(row["BLng"]!=null)
				{
					model.BLng=row["BLng"].ToString();
				}
				if(row["FLetter"]!=null)
				{
					model.FLetter=row["FLetter"].ToString();
				}
				if(row["BusinessesNumber"]!=null && row["BusinessesNumber"].ToString()!="")
				{
					model.BusinessesNumber=int.Parse(row["BusinessesNumber"].ToString());
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
			strSql.Append("select LocalTagID,TagName,DistrictID,CityID,TagGrade,Sort,GLat,GLng,BLat,BLng,FLetter,BusinessesNumber ");
			strSql.Append(" FROM CityLocalTag ");
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
			strSql.Append(" LocalTagID,TagName,DistrictID,CityID,TagGrade,Sort,GLat,GLng,BLat,BLng,FLetter,BusinessesNumber ");
			strSql.Append(" FROM CityLocalTag ");
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
			strSql.Append("select count(1) FROM CityLocalTag ");
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
				strSql.Append("order by T.LocalTagID desc");
			}
			strSql.Append(")AS Row, T.*  from CityLocalTag T ");
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
			parameters[0].Value = "CityLocalTag";
			parameters[1].Value = "LocalTagID";
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

