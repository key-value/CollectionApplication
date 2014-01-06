/**  版本信息模板在安装目录下，可自行修改。
* City.cs
*
* 功 能： N/A
* 类 名： City
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/11 11:25:09   N/A    初版
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
	/// 数据访问类:City
	/// </summary>
	public partial class City
	{
		public City()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CityID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from City");
			strSql.Append(" where CityID=@CityID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = CityID;

			return ServerDbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into City(");
			strSql.Append("CityID,ProvincesID,CityName,SortID,CityCode,IsOpen,Letter)");
			strSql.Append(" values (");
			strSql.Append("@CityID,@ProvincesID,@CityName,@SortID,@CityCode,@IsOpen,@Letter)");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@ProvincesID", SqlDbType.NVarChar,50),
					new SqlParameter("@CityName", SqlDbType.NVarChar,30),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@CityCode", SqlDbType.VarChar,10),
					new SqlParameter("@IsOpen", SqlDbType.Bit,1),
					new SqlParameter("@Letter", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.CityID;
			parameters[1].Value = model.ProvincesID;
			parameters[2].Value = model.CityName;
			parameters[3].Value = model.SortID;
			parameters[4].Value = model.CityCode;
			parameters[5].Value = model.IsOpen;
			parameters[6].Value = model.Letter;

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
		public bool Update(Maticsoft.Model.City model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update City set ");
			strSql.Append("ProvincesID=@ProvincesID,");
			strSql.Append("CityName=@CityName,");
			strSql.Append("SortID=@SortID,");
			strSql.Append("CityCode=@CityCode,");
			strSql.Append("IsOpen=@IsOpen,");
			strSql.Append("Letter=@Letter");
			strSql.Append(" where CityID=@CityID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvincesID", SqlDbType.NVarChar,50),
					new SqlParameter("@CityName", SqlDbType.NVarChar,30),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@CityCode", SqlDbType.VarChar,10),
					new SqlParameter("@IsOpen", SqlDbType.Bit,1),
					new SqlParameter("@Letter", SqlDbType.NVarChar,20),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ProvincesID;
			parameters[1].Value = model.CityName;
			parameters[2].Value = model.SortID;
			parameters[3].Value = model.CityCode;
			parameters[4].Value = model.IsOpen;
			parameters[5].Value = model.Letter;
			parameters[6].Value = model.CityID;

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
		public bool Delete(string CityID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from City ");
			strSql.Append(" where CityID=@CityID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = CityID;

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
		public bool DeleteList(string CityIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from City ");
			strSql.Append(" where CityID in ("+CityIDlist + ")  ");
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
		public Maticsoft.Model.City GetModel(string CityID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CityID,ProvincesID,CityName,SortID,CityCode,IsOpen,Letter from City ");
			strSql.Append(" where CityID=@CityID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CityID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = CityID;

			Maticsoft.Model.City model=new Maticsoft.Model.City();
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
		public Maticsoft.Model.City DataRowToModel(DataRow row)
		{
			Maticsoft.Model.City model=new Maticsoft.Model.City();
			if (row != null)
			{
				if(row["CityID"]!=null)
				{
					model.CityID=row["CityID"].ToString();
				}
				if(row["ProvincesID"]!=null)
				{
					model.ProvincesID=row["ProvincesID"].ToString();
				}
				if(row["CityName"]!=null)
				{
					model.CityName=row["CityName"].ToString();
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
				if(row["CityCode"]!=null)
				{
					model.CityCode=row["CityCode"].ToString();
				}
				if(row["IsOpen"]!=null && row["IsOpen"].ToString()!="")
				{
					if((row["IsOpen"].ToString()=="1")||(row["IsOpen"].ToString().ToLower()=="true"))
					{
						model.IsOpen=true;
					}
					else
					{
						model.IsOpen=false;
					}
				}
				if(row["Letter"]!=null)
				{
					model.Letter=row["Letter"].ToString();
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
			strSql.Append("select CityID,ProvincesID,CityName,SortID,CityCode,IsOpen,Letter ");
			strSql.Append(" FROM City ");
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
			strSql.Append(" CityID,ProvincesID,CityName,SortID,CityCode,IsOpen,Letter ");
			strSql.Append(" FROM City ");
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
			strSql.Append("select count(1) FROM City ");
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
				strSql.Append("order by T.CityID desc");
			}
			strSql.Append(")AS Row, T.*  from City T ");
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
			parameters[0].Value = "City";
			parameters[1].Value = "CityID";
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

