/**  版本信息模板在安装目录下，可自行修改。
* DishesTyepTable.cs
*
* 功 能： N/A
* 类 名： DishesTyepTable
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
	/// 数据访问类:DishesTyepTable
	/// </summary>
	public partial class DishesTyepTable
	{
		public DishesTyepTable()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DishesTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DishesTyepTable");
			strSql.Append(" where DishesTypeID=@DishesTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesTypeID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = DishesTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.DishesTyepTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DishesTyepTable(");
			strSql.Append("DishesTypeID,DishesTypeName,OldDishesTypeID,BusinessID,SortID,CreateDate,ChainStoreDishesTypeID,ChainStoreID,IsDeleted,IsSetMeal)");
			strSql.Append(" values (");
			strSql.Append("@DishesTypeID,@DishesTypeName,@OldDishesTypeID,@BusinessID,@SortID,@CreateDate,@ChainStoreDishesTypeID,@ChainStoreID,@IsDeleted,@IsSetMeal)");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesTypeName", SqlDbType.NVarChar,10),
					new SqlParameter("@OldDishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessID", SqlDbType.NVarChar,50),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ChainStoreDishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@ChainStoreID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsDeleted", SqlDbType.Bit,1),
					new SqlParameter("@IsSetMeal", SqlDbType.Bit,1)};
			parameters[0].Value = model.DishesTypeID;
			parameters[1].Value = model.DishesTypeName;
			parameters[2].Value = model.OldDishesTypeID;
			parameters[3].Value = model.BusinessID;
			parameters[4].Value = model.SortID;
			parameters[5].Value = model.CreateDate;
			parameters[6].Value = model.ChainStoreDishesTypeID;
			parameters[7].Value = model.ChainStoreID;
			parameters[8].Value = model.IsDeleted;
			parameters[9].Value = model.IsSetMeal;

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
		public bool Update(Maticsoft.Model.DishesTyepTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DishesTyepTable set ");
			strSql.Append("DishesTypeName=@DishesTypeName,");
			strSql.Append("OldDishesTypeID=@OldDishesTypeID,");
			strSql.Append("BusinessID=@BusinessID,");
			strSql.Append("SortID=@SortID,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("ChainStoreDishesTypeID=@ChainStoreDishesTypeID,");
			strSql.Append("ChainStoreID=@ChainStoreID,");
			strSql.Append("IsDeleted=@IsDeleted,");
			strSql.Append("IsSetMeal=@IsSetMeal");
			strSql.Append(" where DishesTypeID=@DishesTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesTypeName", SqlDbType.NVarChar,10),
					new SqlParameter("@OldDishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessID", SqlDbType.NVarChar,50),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ChainStoreDishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@ChainStoreID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsDeleted", SqlDbType.Bit,1),
					new SqlParameter("@IsSetMeal", SqlDbType.Bit,1),
					new SqlParameter("@DishesTypeID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.DishesTypeName;
			parameters[1].Value = model.OldDishesTypeID;
			parameters[2].Value = model.BusinessID;
			parameters[3].Value = model.SortID;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.ChainStoreDishesTypeID;
			parameters[6].Value = model.ChainStoreID;
			parameters[7].Value = model.IsDeleted;
			parameters[8].Value = model.IsSetMeal;
			parameters[9].Value = model.DishesTypeID;

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
		public bool Delete(string DishesTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DishesTyepTable ");
			strSql.Append(" where DishesTypeID=@DishesTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesTypeID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = DishesTypeID;

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
		public bool DeleteList(string DishesTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DishesTyepTable ");
			strSql.Append(" where DishesTypeID in ("+DishesTypeIDlist + ")  ");
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
		public Maticsoft.Model.DishesTyepTable GetModel(string DishesTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DishesTypeID,DishesTypeName,OldDishesTypeID,BusinessID,SortID,CreateDate,ChainStoreDishesTypeID,ChainStoreID,IsDeleted,IsSetMeal from DishesTyepTable ");
			strSql.Append(" where DishesTypeID=@DishesTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesTypeID", SqlDbType.NVarChar,50)			};
			parameters[0].Value = DishesTypeID;

			Maticsoft.Model.DishesTyepTable model=new Maticsoft.Model.DishesTyepTable();
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
		public Maticsoft.Model.DishesTyepTable DataRowToModel(DataRow row)
		{
			Maticsoft.Model.DishesTyepTable model=new Maticsoft.Model.DishesTyepTable();
			if (row != null)
			{
				if(row["DishesTypeID"]!=null)
				{
					model.DishesTypeID=row["DishesTypeID"].ToString();
				}
				if(row["DishesTypeName"]!=null)
				{
					model.DishesTypeName=row["DishesTypeName"].ToString();
				}
				if(row["OldDishesTypeID"]!=null)
				{
					model.OldDishesTypeID=row["OldDishesTypeID"].ToString();
				}
				if(row["BusinessID"]!=null)
				{
					model.BusinessID=row["BusinessID"].ToString();
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["ChainStoreDishesTypeID"]!=null)
				{
					model.ChainStoreDishesTypeID=row["ChainStoreDishesTypeID"].ToString();
				}
				if(row["ChainStoreID"]!=null)
				{
					model.ChainStoreID=row["ChainStoreID"].ToString();
				}
				if(row["IsDeleted"]!=null && row["IsDeleted"].ToString()!="")
				{
					if((row["IsDeleted"].ToString()=="1")||(row["IsDeleted"].ToString().ToLower()=="true"))
					{
						model.IsDeleted=true;
					}
					else
					{
						model.IsDeleted=false;
					}
				}
				if(row["IsSetMeal"]!=null && row["IsSetMeal"].ToString()!="")
				{
					if((row["IsSetMeal"].ToString()=="1")||(row["IsSetMeal"].ToString().ToLower()=="true"))
					{
						model.IsSetMeal=true;
					}
					else
					{
						model.IsSetMeal=false;
					}
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
			strSql.Append("select DishesTypeID,DishesTypeName,OldDishesTypeID,BusinessID,SortID,CreateDate,ChainStoreDishesTypeID,ChainStoreID,IsDeleted,IsSetMeal ");
			strSql.Append(" FROM DishesTyepTable ");
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
			strSql.Append(" DishesTypeID,DishesTypeName,OldDishesTypeID,BusinessID,SortID,CreateDate,ChainStoreDishesTypeID,ChainStoreID,IsDeleted,IsSetMeal ");
			strSql.Append(" FROM DishesTyepTable ");
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
			strSql.Append("select count(1) FROM DishesTyepTable ");
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
				strSql.Append("order by T.DishesTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from DishesTyepTable T ");
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
			parameters[0].Value = "DishesTyepTable";
			parameters[1].Value = "DishesTypeID";
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

