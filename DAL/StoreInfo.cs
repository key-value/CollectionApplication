/**  版本信息模板在安装目录下，可自行修改。
* StoreInfo.cs
*
* 功 能： N/A
* 类 名： StoreInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/20 9:46:50   N/A    初版
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
	/// 数据访问类:StoreInfo
	/// </summary>
	public partial class StoreInfo
	{
		public StoreInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string storeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StoreInfo");
			strSql.Append(" where storeId=@storeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@storeId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = storeId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.StoreInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreInfo(");
			strSql.Append("storeId,Fid,StoreName,StoreAddress,StorePhone,BasicIntroduction,StoreHours,Facilities,payCar,subway,bus,box,carPark,StoreTag,MinPrice,MaxPrice,picName)");
			strSql.Append(" values (");
			strSql.Append("@storeId,@Fid,@StoreName,@StoreAddress,@StorePhone,@BasicIntroduction,@StoreHours,@Facilities,@payCar,@subway,@bus,@box,@carPark,@StoreTag,@MinPrice,@MaxPrice,@picName)");
			SqlParameter[] parameters = {
					new SqlParameter("@storeId", SqlDbType.NVarChar,50),
					new SqlParameter("@Fid", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@StorePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@BasicIntroduction", SqlDbType.NText),
					new SqlParameter("@StoreHours", SqlDbType.NVarChar,50),
					new SqlParameter("@Facilities", SqlDbType.NVarChar,50),
					new SqlParameter("@payCar", SqlDbType.Bit,1),
					new SqlParameter("@subway", SqlDbType.NVarChar,50),
					new SqlParameter("@bus", SqlDbType.NVarChar,50),
					new SqlParameter("@box", SqlDbType.Bit,1),
					new SqlParameter("@carPark", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreTag", SqlDbType.NVarChar,200),
					new SqlParameter("@MinPrice", SqlDbType.Int,4),
					new SqlParameter("@MaxPrice", SqlDbType.Int,4),
					new SqlParameter("@picName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.storeId;
			parameters[1].Value = model.Fid;
			parameters[2].Value = model.StoreName;
			parameters[3].Value = model.StoreAddress;
			parameters[4].Value = model.StorePhone;
			parameters[5].Value = model.BasicIntroduction;
			parameters[6].Value = model.StoreHours;
			parameters[7].Value = model.Facilities;
			parameters[8].Value = model.payCar;
			parameters[9].Value = model.subway;
			parameters[10].Value = model.bus;
			parameters[11].Value = model.box;
			parameters[12].Value = model.carPark;
			parameters[13].Value = model.StoreTag;
			parameters[14].Value = model.MinPrice;
			parameters[15].Value = model.MaxPrice;
			parameters[16].Value = model.picName;

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
		public bool Update(Maticsoft.Model.StoreInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreInfo set ");
			strSql.Append("Fid=@Fid,");
			strSql.Append("StoreName=@StoreName,");
			strSql.Append("StoreAddress=@StoreAddress,");
			strSql.Append("StorePhone=@StorePhone,");
			strSql.Append("BasicIntroduction=@BasicIntroduction,");
			strSql.Append("StoreHours=@StoreHours,");
			strSql.Append("Facilities=@Facilities,");
			strSql.Append("payCar=@payCar,");
			strSql.Append("subway=@subway,");
			strSql.Append("bus=@bus,");
			strSql.Append("box=@box,");
			strSql.Append("carPark=@carPark,");
			strSql.Append("StoreTag=@StoreTag,");
			strSql.Append("MinPrice=@MinPrice,");
			strSql.Append("MaxPrice=@MaxPrice,");
			strSql.Append("picName=@picName");
			strSql.Append(" where storeId=@storeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Fid", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@StorePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@BasicIntroduction", SqlDbType.NText),
					new SqlParameter("@StoreHours", SqlDbType.NVarChar,50),
					new SqlParameter("@Facilities", SqlDbType.NVarChar,50),
					new SqlParameter("@payCar", SqlDbType.Bit,1),
					new SqlParameter("@subway", SqlDbType.NVarChar,50),
					new SqlParameter("@bus", SqlDbType.NVarChar,50),
					new SqlParameter("@box", SqlDbType.Bit,1),
					new SqlParameter("@carPark", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreTag", SqlDbType.NVarChar,200),
					new SqlParameter("@MinPrice", SqlDbType.Int,4),
					new SqlParameter("@MaxPrice", SqlDbType.Int,4),
					new SqlParameter("@picName", SqlDbType.NVarChar,50),
					new SqlParameter("@storeId", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Fid;
			parameters[1].Value = model.StoreName;
			parameters[2].Value = model.StoreAddress;
			parameters[3].Value = model.StorePhone;
			parameters[4].Value = model.BasicIntroduction;
			parameters[5].Value = model.StoreHours;
			parameters[6].Value = model.Facilities;
			parameters[7].Value = model.payCar;
			parameters[8].Value = model.subway;
			parameters[9].Value = model.bus;
			parameters[10].Value = model.box;
			parameters[11].Value = model.carPark;
			parameters[12].Value = model.StoreTag;
			parameters[13].Value = model.MinPrice;
			parameters[14].Value = model.MaxPrice;
			parameters[15].Value = model.picName;
			parameters[16].Value = model.storeId;

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
		public bool Delete(string storeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInfo ");
			strSql.Append(" where storeId=@storeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@storeId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = storeId;

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
		public bool DeleteList(string storeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreInfo ");
			strSql.Append(" where storeId in ("+storeIdlist + ")  ");
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
		public Maticsoft.Model.StoreInfo GetModel(string storeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 storeId,Fid,StoreName,StoreAddress,StorePhone,BasicIntroduction,StoreHours,Facilities,payCar,subway,bus,box,carPark,StoreTag,MinPrice,MaxPrice,picName from StoreInfo ");
			strSql.Append(" where storeId=@storeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@storeId", SqlDbType.NVarChar,50)			};
			parameters[0].Value = storeId;

			Maticsoft.Model.StoreInfo model=new Maticsoft.Model.StoreInfo();
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
		public Maticsoft.Model.StoreInfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.StoreInfo model=new Maticsoft.Model.StoreInfo();
			if (row != null)
			{
				if(row["storeId"]!=null)
				{
					model.storeId=row["storeId"].ToString();
				}
				if(row["Fid"]!=null)
				{
					model.Fid=row["Fid"].ToString();
				}
				if(row["StoreName"]!=null)
				{
					model.StoreName=row["StoreName"].ToString();
				}
				if(row["StoreAddress"]!=null)
				{
					model.StoreAddress=row["StoreAddress"].ToString();
				}
				if(row["StorePhone"]!=null)
				{
					model.StorePhone=row["StorePhone"].ToString();
				}
				if(row["BasicIntroduction"]!=null)
				{
					model.BasicIntroduction=row["BasicIntroduction"].ToString();
				}
				if(row["StoreHours"]!=null)
				{
					model.StoreHours=row["StoreHours"].ToString();
				}
				if(row["Facilities"]!=null)
				{
					model.Facilities=row["Facilities"].ToString();
				}
				if(row["payCar"]!=null && row["payCar"].ToString()!="")
				{
					if((row["payCar"].ToString()=="1")||(row["payCar"].ToString().ToLower()=="true"))
					{
						model.payCar=true;
					}
					else
					{
						model.payCar=false;
					}
				}
				if(row["subway"]!=null)
				{
					model.subway=row["subway"].ToString();
				}
				if(row["bus"]!=null)
				{
					model.bus=row["bus"].ToString();
				}
				if(row["box"]!=null && row["box"].ToString()!="")
				{
					if((row["box"].ToString()=="1")||(row["box"].ToString().ToLower()=="true"))
					{
						model.box=true;
					}
					else
					{
						model.box=false;
					}
				}
				if(row["carPark"]!=null)
				{
					model.carPark=row["carPark"].ToString();
				}
				if(row["StoreTag"]!=null)
				{
					model.StoreTag=row["StoreTag"].ToString();
				}
				if(row["MinPrice"]!=null && row["MinPrice"].ToString()!="")
				{
					model.MinPrice=int.Parse(row["MinPrice"].ToString());
				}
				if(row["MaxPrice"]!=null && row["MaxPrice"].ToString()!="")
				{
					model.MaxPrice=int.Parse(row["MaxPrice"].ToString());
				}
				if(row["picName"]!=null)
				{
					model.picName=row["picName"].ToString();
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
			strSql.Append("select storeId,Fid,StoreName,StoreAddress,StorePhone,BasicIntroduction,StoreHours,Facilities,payCar,subway,bus,box,carPark,StoreTag,MinPrice,MaxPrice,picName ");
			strSql.Append(" FROM StoreInfo ");
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
			strSql.Append(" storeId,Fid,StoreName,StoreAddress,StorePhone,BasicIntroduction,StoreHours,Facilities,payCar,subway,bus,box,carPark,StoreTag,MinPrice,MaxPrice,picName ");
			strSql.Append(" FROM StoreInfo ");
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
			strSql.Append("select count(1) FROM StoreInfo ");
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
				strSql.Append("order by T.storeId desc");
			}
			strSql.Append(")AS Row, T.*  from StoreInfo T ");
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
			parameters[0].Value = "StoreInfo";
			parameters[1].Value = "storeId";
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

