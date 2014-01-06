/**  版本信息模板在安装目录下，可自行修改。
* DishesTable.cs
*
* 功 能： N/A
* 类 名： DishesTable
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/12 17:39:42   N/A    初版
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
	/// 数据访问类:DishesTable
	/// </summary>
	public partial class DishesTable
	{
		public DishesTable()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.DishesTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DishesTable(");
			strSql.Append("DishesID,DishesName,DishesMoney,DishesUnit,DishesTypeID,BusinessID,IsCurrentPrice,DishesBrief,ImageUrl,CookingStyleID,Popularity,Special,IsTakeAway,State,PraiseCount,ShareCount,ComCount,SortID,CreateDate,ChainStoreDishesID,ChainStoreID,ChainStoreDishesTypeID,IsSetMeal,VisibityType,DishCode,DisheCate,IsEvaluate,SpicyNum,RecNum)");
			strSql.Append(" values (");
			strSql.Append("@DishesID,@DishesName,@DishesMoney,@DishesUnit,@DishesTypeID,@BusinessID,@IsCurrentPrice,@DishesBrief,@ImageUrl,@CookingStyleID,@Popularity,@Special,@IsTakeAway,@State,@PraiseCount,@ShareCount,@ComCount,@SortID,@CreateDate,@ChainStoreDishesID,@ChainStoreID,@ChainStoreDishesTypeID,@IsSetMeal,@VisibityType,@DishCode,@DisheCate,@IsEvaluate,@SpicyNum,@RecNum)");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesID", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesName", SqlDbType.NVarChar,200),
					new SqlParameter("@DishesMoney", SqlDbType.Float,8),
					new SqlParameter("@DishesUnit", SqlDbType.NVarChar,10),
					new SqlParameter("@DishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsCurrentPrice", SqlDbType.Bit,1),
					new SqlParameter("@DishesBrief", SqlDbType.NVarChar,1000),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@CookingStyleID", SqlDbType.NVarChar,50),
					new SqlParameter("@Popularity", SqlDbType.Int,4),
					new SqlParameter("@Special", SqlDbType.Bit,1),
					new SqlParameter("@IsTakeAway", SqlDbType.Bit,1),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@PraiseCount", SqlDbType.Int,4),
					new SqlParameter("@ShareCount", SqlDbType.Int,4),
					new SqlParameter("@ComCount", SqlDbType.Int,4),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ChainStoreDishesID", SqlDbType.NVarChar,50),
					new SqlParameter("@ChainStoreID", SqlDbType.NVarChar,50),
					new SqlParameter("@ChainStoreDishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsSetMeal", SqlDbType.Bit,1),
					new SqlParameter("@VisibityType", SqlDbType.Int,4),
					new SqlParameter("@DishCode", SqlDbType.NVarChar,10),
					new SqlParameter("@DisheCate", SqlDbType.Int,4),
					new SqlParameter("@IsEvaluate", SqlDbType.Bit,1),
					new SqlParameter("@SpicyNum", SqlDbType.Int,4),
					new SqlParameter("@RecNum", SqlDbType.Int,4)};
			parameters[0].Value = model.DishesID;
			parameters[1].Value = model.DishesName;
			parameters[2].Value = model.DishesMoney;
			parameters[3].Value = model.DishesUnit;
			parameters[4].Value = model.DishesTypeID;
			parameters[5].Value = model.BusinessID;
			parameters[6].Value = model.IsCurrentPrice;
			parameters[7].Value = model.DishesBrief;
			parameters[8].Value = model.ImageUrl;
			parameters[9].Value = model.CookingStyleID;
			parameters[10].Value = model.Popularity;
			parameters[11].Value = model.Special;
			parameters[12].Value = model.IsTakeAway;
			parameters[13].Value = model.State;
			parameters[14].Value = model.PraiseCount;
			parameters[15].Value = model.ShareCount;
			parameters[16].Value = model.ComCount;
			parameters[17].Value = model.SortID;
			parameters[18].Value = model.CreateDate;
			parameters[19].Value = model.ChainStoreDishesID;
			parameters[20].Value = model.ChainStoreID;
			parameters[21].Value = model.ChainStoreDishesTypeID;
			parameters[22].Value = model.IsSetMeal;
			parameters[23].Value = model.VisibityType;
			parameters[24].Value = model.DishCode;
			parameters[25].Value = model.DisheCate;
			parameters[26].Value = model.IsEvaluate;
			parameters[27].Value = model.SpicyNum;
			parameters[28].Value = model.RecNum;

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
		public bool Update(Maticsoft.Model.DishesTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DishesTable set ");
			strSql.Append("DishesID=@DishesID,");
			strSql.Append("DishesName=@DishesName,");
			strSql.Append("DishesMoney=@DishesMoney,");
			strSql.Append("DishesUnit=@DishesUnit,");
			strSql.Append("DishesTypeID=@DishesTypeID,");
			strSql.Append("BusinessID=@BusinessID,");
			strSql.Append("IsCurrentPrice=@IsCurrentPrice,");
			strSql.Append("DishesBrief=@DishesBrief,");
			strSql.Append("ImageUrl=@ImageUrl,");
			strSql.Append("CookingStyleID=@CookingStyleID,");
			strSql.Append("Popularity=@Popularity,");
			strSql.Append("Special=@Special,");
			strSql.Append("IsTakeAway=@IsTakeAway,");
			strSql.Append("State=@State,");
			strSql.Append("PraiseCount=@PraiseCount,");
			strSql.Append("ShareCount=@ShareCount,");
			strSql.Append("ComCount=@ComCount,");
			strSql.Append("SortID=@SortID,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("ChainStoreDishesID=@ChainStoreDishesID,");
			strSql.Append("ChainStoreID=@ChainStoreID,");
			strSql.Append("ChainStoreDishesTypeID=@ChainStoreDishesTypeID,");
			strSql.Append("IsSetMeal=@IsSetMeal,");
			strSql.Append("VisibityType=@VisibityType,");
			strSql.Append("DishCode=@DishCode,");
			strSql.Append("DisheCate=@DisheCate,");
			strSql.Append("IsEvaluate=@IsEvaluate,");
			strSql.Append("SpicyNum=@SpicyNum,");
			strSql.Append("RecNum=@RecNum");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@DishesID", SqlDbType.NVarChar,50),
					new SqlParameter("@DishesName", SqlDbType.NVarChar,200),
					new SqlParameter("@DishesMoney", SqlDbType.Float,8),
					new SqlParameter("@DishesUnit", SqlDbType.NVarChar,10),
					new SqlParameter("@DishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsCurrentPrice", SqlDbType.Bit,1),
					new SqlParameter("@DishesBrief", SqlDbType.NVarChar,1000),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@CookingStyleID", SqlDbType.NVarChar,50),
					new SqlParameter("@Popularity", SqlDbType.Int,4),
					new SqlParameter("@Special", SqlDbType.Bit,1),
					new SqlParameter("@IsTakeAway", SqlDbType.Bit,1),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@PraiseCount", SqlDbType.Int,4),
					new SqlParameter("@ShareCount", SqlDbType.Int,4),
					new SqlParameter("@ComCount", SqlDbType.Int,4),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ChainStoreDishesID", SqlDbType.NVarChar,50),
					new SqlParameter("@ChainStoreID", SqlDbType.NVarChar,50),
					new SqlParameter("@ChainStoreDishesTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsSetMeal", SqlDbType.Bit,1),
					new SqlParameter("@VisibityType", SqlDbType.Int,4),
					new SqlParameter("@DishCode", SqlDbType.NVarChar,10),
					new SqlParameter("@DisheCate", SqlDbType.Int,4),
					new SqlParameter("@IsEvaluate", SqlDbType.Bit,1),
					new SqlParameter("@SpicyNum", SqlDbType.Int,4),
					new SqlParameter("@RecNum", SqlDbType.Int,4)};
			parameters[0].Value = model.DishesID;
			parameters[1].Value = model.DishesName;
			parameters[2].Value = model.DishesMoney;
			parameters[3].Value = model.DishesUnit;
			parameters[4].Value = model.DishesTypeID;
			parameters[5].Value = model.BusinessID;
			parameters[6].Value = model.IsCurrentPrice;
			parameters[7].Value = model.DishesBrief;
			parameters[8].Value = model.ImageUrl;
			parameters[9].Value = model.CookingStyleID;
			parameters[10].Value = model.Popularity;
			parameters[11].Value = model.Special;
			parameters[12].Value = model.IsTakeAway;
			parameters[13].Value = model.State;
			parameters[14].Value = model.PraiseCount;
			parameters[15].Value = model.ShareCount;
			parameters[16].Value = model.ComCount;
			parameters[17].Value = model.SortID;
			parameters[18].Value = model.CreateDate;
			parameters[19].Value = model.ChainStoreDishesID;
			parameters[20].Value = model.ChainStoreID;
			parameters[21].Value = model.ChainStoreDishesTypeID;
			parameters[22].Value = model.IsSetMeal;
			parameters[23].Value = model.VisibityType;
			parameters[24].Value = model.DishCode;
			parameters[25].Value = model.DisheCate;
			parameters[26].Value = model.IsEvaluate;
			parameters[27].Value = model.SpicyNum;
			parameters[28].Value = model.RecNum;

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
			strSql.Append("delete from DishesTable ");
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
		public Maticsoft.Model.DishesTable GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DishesID,DishesName,DishesMoney,DishesUnit,DishesTypeID,BusinessID,IsCurrentPrice,DishesBrief,ImageUrl,CookingStyleID,Popularity,Special,IsTakeAway,State,PraiseCount,ShareCount,ComCount,SortID,CreateDate,ChainStoreDishesID,ChainStoreID,ChainStoreDishesTypeID,IsSetMeal,VisibityType,DishCode,DisheCate,IsEvaluate,SpicyNum,RecNum from DishesTable ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.DishesTable model=new Maticsoft.Model.DishesTable();
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
		public Maticsoft.Model.DishesTable DataRowToModel(DataRow row)
		{
			Maticsoft.Model.DishesTable model=new Maticsoft.Model.DishesTable();
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
				if(row["DishesMoney"]!=null && row["DishesMoney"].ToString()!="")
				{
					model.DishesMoney=decimal.Parse(row["DishesMoney"].ToString());
				}
				if(row["DishesUnit"]!=null)
				{
					model.DishesUnit=row["DishesUnit"].ToString();
				}
				if(row["DishesTypeID"]!=null)
				{
					model.DishesTypeID=row["DishesTypeID"].ToString();
				}
				if(row["BusinessID"]!=null)
				{
					model.BusinessID=row["BusinessID"].ToString();
				}
				if(row["IsCurrentPrice"]!=null && row["IsCurrentPrice"].ToString()!="")
				{
					if((row["IsCurrentPrice"].ToString()=="1")||(row["IsCurrentPrice"].ToString().ToLower()=="true"))
					{
						model.IsCurrentPrice=true;
					}
					else
					{
						model.IsCurrentPrice=false;
					}
				}
				if(row["DishesBrief"]!=null)
				{
					model.DishesBrief=row["DishesBrief"].ToString();
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["CookingStyleID"]!=null)
				{
					model.CookingStyleID=row["CookingStyleID"].ToString();
				}
				if(row["Popularity"]!=null && row["Popularity"].ToString()!="")
				{
					model.Popularity=int.Parse(row["Popularity"].ToString());
				}
				if(row["Special"]!=null && row["Special"].ToString()!="")
				{
					if((row["Special"].ToString()=="1")||(row["Special"].ToString().ToLower()=="true"))
					{
						model.Special=true;
					}
					else
					{
						model.Special=false;
					}
				}
				if(row["IsTakeAway"]!=null && row["IsTakeAway"].ToString()!="")
				{
					if((row["IsTakeAway"].ToString()=="1")||(row["IsTakeAway"].ToString().ToLower()=="true"))
					{
						model.IsTakeAway=true;
					}
					else
					{
						model.IsTakeAway=false;
					}
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
				if(row["PraiseCount"]!=null && row["PraiseCount"].ToString()!="")
				{
					model.PraiseCount=int.Parse(row["PraiseCount"].ToString());
				}
				if(row["ShareCount"]!=null && row["ShareCount"].ToString()!="")
				{
					model.ShareCount=int.Parse(row["ShareCount"].ToString());
				}
				if(row["ComCount"]!=null && row["ComCount"].ToString()!="")
				{
					model.ComCount=int.Parse(row["ComCount"].ToString());
				}
				if(row["SortID"]!=null && row["SortID"].ToString()!="")
				{
					model.SortID=int.Parse(row["SortID"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["ChainStoreDishesID"]!=null)
				{
					model.ChainStoreDishesID=row["ChainStoreDishesID"].ToString();
				}
				if(row["ChainStoreID"]!=null)
				{
					model.ChainStoreID=row["ChainStoreID"].ToString();
				}
				if(row["ChainStoreDishesTypeID"]!=null)
				{
					model.ChainStoreDishesTypeID=row["ChainStoreDishesTypeID"].ToString();
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
				if(row["VisibityType"]!=null && row["VisibityType"].ToString()!="")
				{
					model.VisibityType=int.Parse(row["VisibityType"].ToString());
				}
				if(row["DishCode"]!=null)
				{
					model.DishCode=row["DishCode"].ToString();
				}
				if(row["DisheCate"]!=null && row["DisheCate"].ToString()!="")
				{
					model.DisheCate=int.Parse(row["DisheCate"].ToString());
				}
				if(row["IsEvaluate"]!=null && row["IsEvaluate"].ToString()!="")
				{
					if((row["IsEvaluate"].ToString()=="1")||(row["IsEvaluate"].ToString().ToLower()=="true"))
					{
						model.IsEvaluate=true;
					}
					else
					{
						model.IsEvaluate=false;
					}
				}
				if(row["SpicyNum"]!=null && row["SpicyNum"].ToString()!="")
				{
					model.SpicyNum=int.Parse(row["SpicyNum"].ToString());
				}
				if(row["RecNum"]!=null && row["RecNum"].ToString()!="")
				{
					model.RecNum=int.Parse(row["RecNum"].ToString());
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
			strSql.Append("select DishesID,DishesName,DishesMoney,DishesUnit,DishesTypeID,BusinessID,IsCurrentPrice,DishesBrief,ImageUrl,CookingStyleID,Popularity,Special,IsTakeAway,State,PraiseCount,ShareCount,ComCount,SortID,CreateDate,ChainStoreDishesID,ChainStoreID,ChainStoreDishesTypeID,IsSetMeal,VisibityType,DishCode,DisheCate,IsEvaluate,SpicyNum,RecNum ");
			strSql.Append(" FROM DishesTable ");
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
			strSql.Append(" DishesID,DishesName,DishesMoney,DishesUnit,DishesTypeID,BusinessID,IsCurrentPrice,DishesBrief,ImageUrl,CookingStyleID,Popularity,Special,IsTakeAway,State,PraiseCount,ShareCount,ComCount,SortID,CreateDate,ChainStoreDishesID,ChainStoreID,ChainStoreDishesTypeID,IsSetMeal,VisibityType,DishCode,DisheCate,IsEvaluate,SpicyNum,RecNum ");
			strSql.Append(" FROM DishesTable ");
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
			strSql.Append("select count(1) FROM DishesTable ");
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
			strSql.Append(")AS Row, T.*  from DishesTable T ");
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
			parameters[0].Value = "DishesTable";
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

