/**  版本信息模板在安装目录下，可自行修改。
* StoreInfo.cs
*
* 功 能： N/A
* 类 名： StoreInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/8 17:42:32   N/A    初版
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
    public partial class StoreInfoDal
    {
        public StoreInfoDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BizID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreInfo");
            strSql.Append(" where BizID=@BizID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BizID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = BizID;

            return ServerDbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.StoreInfoEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreInfo(");
            strSql.Append("BizID,StoreName,BranchName,StoreAddress,BusinessTypeID,BusinessAddTime,ChainStoreID,CityID,DistrictID,BusinessState,ShortID,StorePhone,StorePhoto,StoreHours,BasicIntroduction,TelPhone,Cod,OnlinePay,TakeAwayType,VideoAddress,TakeOrderNum,CreateUserName,UpdateUserName,LastUpdateDate,BizSLD,BizBannerUrl,BizWeiBoUrl,BizNotice,GLat,GLng,BLat,BLng,IsQueue,IsPointMenu,IsTakeAway,IsReservation,IsCheck,LikeCount,OrderCount,SortID,IsCitySend,IsCoupon,IsPrivileges,IsSend,ShareCount,CollectionCount,ComCount,FoodCount,IsGroup,QRcodeUrl,Bus,MinPrice,MaxPrice,CarPark,Box,PayCar,WIFI,NoSmoke,ChildrenChair,SendDesc,TakeRange,KCVIP,Onlineorder)");
            strSql.Append(" values (");
            strSql.Append("@BizID,@StoreName,@BranchName,@StoreAddress,@BusinessTypeID,@BusinessAddTime,@ChainStoreID,@CityID,@DistrictID,@BusinessState,@ShortID,@StorePhone,@StorePhoto,@StoreHours,@BasicIntroduction,@TelPhone,@Cod,@OnlinePay,@TakeAwayType,@VideoAddress,@TakeOrderNum,@CreateUserName,@UpdateUserName,@LastUpdateDate,@BizSLD,@BizBannerUrl,@BizWeiBoUrl,@BizNotice,@GLat,@GLng,@BLat,@BLng,@IsQueue,@IsPointMenu,@IsTakeAway,@IsReservation,@IsCheck,@LikeCount,@OrderCount,@SortID,@IsCitySend,@IsCoupon,@IsPrivileges,@IsSend,@ShareCount,@CollectionCount,@ComCount,@FoodCount,@IsGroup,@QRcodeUrl,@Bus,@MinPrice,@MaxPrice,@CarPark,@Box,@PayCar,@WIFI,@NoSmoke,@ChildrenChair,@SendDesc,@TakeRange,@KCVIP,@Onlineorder)");
            SqlParameter[] parameters = {
					new SqlParameter("@BizID", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreName", SqlDbType.NVarChar,50),
					new SqlParameter("@BranchName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@BusinessTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessAddTime", SqlDbType.DateTime),
					new SqlParameter("@ChainStoreID", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessState", SqlDbType.Int,4),
					new SqlParameter("@ShortID", SqlDbType.VarChar,10),
					new SqlParameter("@StorePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@StorePhoto", SqlDbType.NVarChar,60),
					new SqlParameter("@StoreHours", SqlDbType.NVarChar,50),
					new SqlParameter("@BasicIntroduction", SqlDbType.NText),
					new SqlParameter("@TelPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Cod", SqlDbType.Bit,1),
					new SqlParameter("@OnlinePay", SqlDbType.Bit,1),
					new SqlParameter("@TakeAwayType", SqlDbType.NVarChar,100),
					new SqlParameter("@VideoAddress", SqlDbType.NText),
					new SqlParameter("@TakeOrderNum", SqlDbType.Int,4),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@BizSLD", SqlDbType.NVarChar,100),
					new SqlParameter("@BizBannerUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@BizWeiBoUrl", SqlDbType.NText),
					new SqlParameter("@BizNotice", SqlDbType.NVarChar,500),
					new SqlParameter("@GLat", SqlDbType.NVarChar,50),
					new SqlParameter("@GLng", SqlDbType.NVarChar,50),
					new SqlParameter("@BLat", SqlDbType.NVarChar,50),
					new SqlParameter("@BLng", SqlDbType.NVarChar,50),
					new SqlParameter("@IsQueue", SqlDbType.Bit,1),
					new SqlParameter("@IsPointMenu", SqlDbType.Bit,1),
					new SqlParameter("@IsTakeAway", SqlDbType.Bit,1),
					new SqlParameter("@IsReservation", SqlDbType.Bit,1),
					new SqlParameter("@IsCheck", SqlDbType.Bit,1),
					new SqlParameter("@LikeCount", SqlDbType.Int,4),
					new SqlParameter("@OrderCount", SqlDbType.Int,4),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@IsCitySend", SqlDbType.Bit,1),
					new SqlParameter("@IsCoupon", SqlDbType.Bit,1),
					new SqlParameter("@IsPrivileges", SqlDbType.Bit,1),
					new SqlParameter("@IsSend", SqlDbType.Int,4),
					new SqlParameter("@ShareCount", SqlDbType.Int,4),
					new SqlParameter("@CollectionCount", SqlDbType.Int,4),
					new SqlParameter("@ComCount", SqlDbType.Int,4),
					new SqlParameter("@FoodCount", SqlDbType.Int,4),
					new SqlParameter("@IsGroup", SqlDbType.Bit,1),
					new SqlParameter("@QRcodeUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@Bus", SqlDbType.NVarChar,200),
					new SqlParameter("@MinPrice", SqlDbType.Money,8),
					new SqlParameter("@MaxPrice", SqlDbType.Money,8),
					new SqlParameter("@CarPark", SqlDbType.Bit,1),
					new SqlParameter("@Box", SqlDbType.Bit,1),
					new SqlParameter("@PayCar", SqlDbType.Bit,1),
					new SqlParameter("@WIFI", SqlDbType.Bit,1),
					new SqlParameter("@NoSmoke", SqlDbType.Bit,1),
					new SqlParameter("@ChildrenChair", SqlDbType.Bit,1),
					new SqlParameter("@SendDesc", SqlDbType.NVarChar,200),
					new SqlParameter("@TakeRange", SqlDbType.Float,8),
					new SqlParameter("@KCVIP", SqlDbType.Bit,1),
					new SqlParameter("@Onlineorder", SqlDbType.Int,4)};
            parameters[0].Value = model.BizID;
            parameters[1].Value = model.StoreName;
            parameters[2].Value = model.BranchName;
            parameters[3].Value = model.StoreAddress;
            parameters[4].Value = model.BusinessTypeID;
            parameters[5].Value = model.BusinessAddTime;
            parameters[6].Value = model.ChainStoreID;
            parameters[7].Value = model.CityID;
            parameters[8].Value = model.DistrictID;
            parameters[9].Value = model.BusinessState;
            parameters[10].Value = model.ShortID;
            parameters[11].Value = model.StorePhone;
            parameters[12].Value = model.StorePhoto;
            parameters[13].Value = model.StoreHours;
            parameters[14].Value = model.BasicIntroduction;
            parameters[15].Value = model.TelPhone;
            parameters[16].Value = model.Cod;
            parameters[17].Value = model.OnlinePay;
            parameters[18].Value = model.TakeAwayType;
            parameters[19].Value = model.VideoAddress;
            parameters[20].Value = model.TakeOrderNum;
            parameters[21].Value = model.CreateUserName;
            parameters[22].Value = model.UpdateUserName;
            parameters[23].Value = model.LastUpdateDate;
            parameters[24].Value = model.BizSLD;
            parameters[25].Value = model.BizBannerUrl;
            parameters[26].Value = model.BizWeiBoUrl;
            parameters[27].Value = model.BizNotice;
            parameters[28].Value = model.GLat;
            parameters[29].Value = model.GLng;
            parameters[30].Value = model.BLat;
            parameters[31].Value = model.BLng;
            parameters[32].Value = model.IsQueue;
            parameters[33].Value = model.IsPointMenu;
            parameters[34].Value = model.IsTakeAway;
            parameters[35].Value = model.IsReservation;
            parameters[36].Value = model.IsCheck;
            parameters[37].Value = model.LikeCount;
            parameters[38].Value = model.OrderCount;
            parameters[39].Value = model.SortID;
            parameters[40].Value = model.IsCitySend;
            parameters[41].Value = model.IsCoupon;
            parameters[42].Value = model.IsPrivileges;
            parameters[43].Value = model.IsSend;
            parameters[44].Value = model.ShareCount;
            parameters[45].Value = model.CollectionCount;
            parameters[46].Value = model.ComCount;
            parameters[47].Value = model.FoodCount;
            parameters[48].Value = model.IsGroup;
            parameters[49].Value = model.QRcodeUrl;
            parameters[50].Value = model.Bus;
            parameters[51].Value = model.MinPrice;
            parameters[52].Value = model.MaxPrice;
            parameters[53].Value = model.CarPark;
            parameters[54].Value = model.Box;
            parameters[55].Value = model.PayCar;
            parameters[56].Value = model.WIFI;
            parameters[57].Value = model.NoSmoke;
            parameters[58].Value = model.ChildrenChair;
            parameters[59].Value = model.SendDesc;
            parameters[60].Value = model.TakeRange;
            parameters[61].Value = model.KCVIP;
            parameters[62].Value = model.Onlineorder;

            int rows = ServerDbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Maticsoft.Model.StoreInfoEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreInfo set ");
            strSql.Append("StoreName=@StoreName,");
            strSql.Append("BranchName=@BranchName,");
            strSql.Append("StoreAddress=@StoreAddress,");
            strSql.Append("BusinessTypeID=@BusinessTypeID,");
            strSql.Append("BusinessAddTime=@BusinessAddTime,");
            strSql.Append("ChainStoreID=@ChainStoreID,");
            strSql.Append("CityID=@CityID,");
            strSql.Append("DistrictID=@DistrictID,");
            strSql.Append("BusinessState=@BusinessState,");
            strSql.Append("ShortID=@ShortID,");
            strSql.Append("StorePhone=@StorePhone,");
            strSql.Append("StorePhoto=@StorePhoto,");
            strSql.Append("StoreHours=@StoreHours,");
            strSql.Append("BasicIntroduction=@BasicIntroduction,");
            strSql.Append("TelPhone=@TelPhone,");
            strSql.Append("Cod=@Cod,");
            strSql.Append("OnlinePay=@OnlinePay,");
            strSql.Append("TakeAwayType=@TakeAwayType,");
            strSql.Append("VideoAddress=@VideoAddress,");
            strSql.Append("TakeOrderNum=@TakeOrderNum,");
            strSql.Append("CreateUserName=@CreateUserName,");
            strSql.Append("UpdateUserName=@UpdateUserName,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("BizSLD=@BizSLD,");
            strSql.Append("BizBannerUrl=@BizBannerUrl,");
            strSql.Append("BizWeiBoUrl=@BizWeiBoUrl,");
            strSql.Append("BizNotice=@BizNotice,");
            strSql.Append("GLat=@GLat,");
            strSql.Append("GLng=@GLng,");
            strSql.Append("BLat=@BLat,");
            strSql.Append("BLng=@BLng,");
            strSql.Append("IsQueue=@IsQueue,");
            strSql.Append("IsPointMenu=@IsPointMenu,");
            strSql.Append("IsTakeAway=@IsTakeAway,");
            strSql.Append("IsReservation=@IsReservation,");
            strSql.Append("IsCheck=@IsCheck,");
            strSql.Append("LikeCount=@LikeCount,");
            strSql.Append("OrderCount=@OrderCount,");
            strSql.Append("SortID=@SortID,");
            strSql.Append("IsCitySend=@IsCitySend,");
            strSql.Append("IsCoupon=@IsCoupon,");
            strSql.Append("IsPrivileges=@IsPrivileges,");
            strSql.Append("IsSend=@IsSend,");
            strSql.Append("ShareCount=@ShareCount,");
            strSql.Append("CollectionCount=@CollectionCount,");
            strSql.Append("ComCount=@ComCount,");
            strSql.Append("FoodCount=@FoodCount,");
            strSql.Append("IsGroup=@IsGroup,");
            strSql.Append("QRcodeUrl=@QRcodeUrl,");
            strSql.Append("Bus=@Bus,");
            strSql.Append("MinPrice=@MinPrice,");
            strSql.Append("MaxPrice=@MaxPrice,");
            strSql.Append("CarPark=@CarPark,");
            strSql.Append("Box=@Box,");
            strSql.Append("PayCar=@PayCar,");
            strSql.Append("WIFI=@WIFI,");
            strSql.Append("NoSmoke=@NoSmoke,");
            strSql.Append("ChildrenChair=@ChildrenChair,");
            strSql.Append("SendDesc=@SendDesc,");
            strSql.Append("TakeRange=@TakeRange,");
            strSql.Append("KCVIP=@KCVIP,");
            strSql.Append("Onlineorder=@Onlineorder");
            strSql.Append(" where BizID=@BizID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreName", SqlDbType.NVarChar,50),
					new SqlParameter("@BranchName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@BusinessTypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessAddTime", SqlDbType.DateTime),
					new SqlParameter("@ChainStoreID", SqlDbType.NVarChar,50),
					new SqlParameter("@CityID", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictID", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessState", SqlDbType.Int,4),
					new SqlParameter("@ShortID", SqlDbType.VarChar,10),
					new SqlParameter("@StorePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@StorePhoto", SqlDbType.NVarChar,60),
					new SqlParameter("@StoreHours", SqlDbType.NVarChar,50),
					new SqlParameter("@BasicIntroduction", SqlDbType.NText),
					new SqlParameter("@TelPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Cod", SqlDbType.Bit,1),
					new SqlParameter("@OnlinePay", SqlDbType.Bit,1),
					new SqlParameter("@TakeAwayType", SqlDbType.NVarChar,100),
					new SqlParameter("@VideoAddress", SqlDbType.NText),
					new SqlParameter("@TakeOrderNum", SqlDbType.Int,4),
					new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateUserName", SqlDbType.NVarChar,50),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@BizSLD", SqlDbType.NVarChar,100),
					new SqlParameter("@BizBannerUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@BizWeiBoUrl", SqlDbType.NText),
					new SqlParameter("@BizNotice", SqlDbType.NVarChar,500),
					new SqlParameter("@GLat", SqlDbType.NVarChar,50),
					new SqlParameter("@GLng", SqlDbType.NVarChar,50),
					new SqlParameter("@BLat", SqlDbType.NVarChar,50),
					new SqlParameter("@BLng", SqlDbType.NVarChar,50),
					new SqlParameter("@IsQueue", SqlDbType.Bit,1),
					new SqlParameter("@IsPointMenu", SqlDbType.Bit,1),
					new SqlParameter("@IsTakeAway", SqlDbType.Bit,1),
					new SqlParameter("@IsReservation", SqlDbType.Bit,1),
					new SqlParameter("@IsCheck", SqlDbType.Bit,1),
					new SqlParameter("@LikeCount", SqlDbType.Int,4),
					new SqlParameter("@OrderCount", SqlDbType.Int,4),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@IsCitySend", SqlDbType.Bit,1),
					new SqlParameter("@IsCoupon", SqlDbType.Bit,1),
					new SqlParameter("@IsPrivileges", SqlDbType.Bit,1),
					new SqlParameter("@IsSend", SqlDbType.Int,4),
					new SqlParameter("@ShareCount", SqlDbType.Int,4),
					new SqlParameter("@CollectionCount", SqlDbType.Int,4),
					new SqlParameter("@ComCount", SqlDbType.Int,4),
					new SqlParameter("@FoodCount", SqlDbType.Int,4),
					new SqlParameter("@IsGroup", SqlDbType.Bit,1),
					new SqlParameter("@QRcodeUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@Bus", SqlDbType.NVarChar,200),
					new SqlParameter("@MinPrice", SqlDbType.Money,8),
					new SqlParameter("@MaxPrice", SqlDbType.Money,8),
					new SqlParameter("@CarPark", SqlDbType.Bit,1),
					new SqlParameter("@Box", SqlDbType.Bit,1),
					new SqlParameter("@PayCar", SqlDbType.Bit,1),
					new SqlParameter("@WIFI", SqlDbType.Bit,1),
					new SqlParameter("@NoSmoke", SqlDbType.Bit,1),
					new SqlParameter("@ChildrenChair", SqlDbType.Bit,1),
					new SqlParameter("@SendDesc", SqlDbType.NVarChar,200),
					new SqlParameter("@TakeRange", SqlDbType.Float,8),
					new SqlParameter("@KCVIP", SqlDbType.Bit,1),
					new SqlParameter("@Onlineorder", SqlDbType.Int,4),
					new SqlParameter("@BizID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.StoreName;
            parameters[1].Value = model.BranchName;
            parameters[2].Value = model.StoreAddress;
            parameters[3].Value = model.BusinessTypeID;
            parameters[4].Value = model.BusinessAddTime;
            parameters[5].Value = model.ChainStoreID;
            parameters[6].Value = model.CityID;
            parameters[7].Value = model.DistrictID;
            parameters[8].Value = model.BusinessState;
            parameters[9].Value = model.ShortID;
            parameters[10].Value = model.StorePhone;
            parameters[11].Value = model.StorePhoto;
            parameters[12].Value = model.StoreHours;
            parameters[13].Value = model.BasicIntroduction;
            parameters[14].Value = model.TelPhone;
            parameters[15].Value = model.Cod;
            parameters[16].Value = model.OnlinePay;
            parameters[17].Value = model.TakeAwayType;
            parameters[18].Value = model.VideoAddress;
            parameters[19].Value = model.TakeOrderNum;
            parameters[20].Value = model.CreateUserName;
            parameters[21].Value = model.UpdateUserName;
            parameters[22].Value = model.LastUpdateDate;
            parameters[23].Value = model.BizSLD;
            parameters[24].Value = model.BizBannerUrl;
            parameters[25].Value = model.BizWeiBoUrl;
            parameters[26].Value = model.BizNotice;
            parameters[27].Value = model.GLat;
            parameters[28].Value = model.GLng;
            parameters[29].Value = model.BLat;
            parameters[30].Value = model.BLng;
            parameters[31].Value = model.IsQueue;
            parameters[32].Value = model.IsPointMenu;
            parameters[33].Value = model.IsTakeAway;
            parameters[34].Value = model.IsReservation;
            parameters[35].Value = model.IsCheck;
            parameters[36].Value = model.LikeCount;
            parameters[37].Value = model.OrderCount;
            parameters[38].Value = model.SortID;
            parameters[39].Value = model.IsCitySend;
            parameters[40].Value = model.IsCoupon;
            parameters[41].Value = model.IsPrivileges;
            parameters[42].Value = model.IsSend;
            parameters[43].Value = model.ShareCount;
            parameters[44].Value = model.CollectionCount;
            parameters[45].Value = model.ComCount;
            parameters[46].Value = model.FoodCount;
            parameters[47].Value = model.IsGroup;
            parameters[48].Value = model.QRcodeUrl;
            parameters[49].Value = model.Bus;
            parameters[50].Value = model.MinPrice;
            parameters[51].Value = model.MaxPrice;
            parameters[52].Value = model.CarPark;
            parameters[53].Value = model.Box;
            parameters[54].Value = model.PayCar;
            parameters[55].Value = model.WIFI;
            parameters[56].Value = model.NoSmoke;
            parameters[57].Value = model.ChildrenChair;
            parameters[58].Value = model.SendDesc;
            parameters[59].Value = model.TakeRange;
            parameters[60].Value = model.KCVIP;
            parameters[61].Value = model.Onlineorder;
            parameters[62].Value = model.BizID;

            int rows = ServerDbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string BizID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreInfo ");
            strSql.Append(" where BizID=@BizID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BizID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = BizID;

            int rows = ServerDbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string BizIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreInfo ");
            strSql.Append(" where BizID in (" + BizIDlist + ")  ");
            int rows = ServerDbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Maticsoft.Model.StoreInfoEntity GetModel(string BizID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BizID,StoreName,BranchName,StoreAddress,BusinessTypeID,BusinessAddTime,ChainStoreID,CityID,DistrictID,BusinessState,ShortID,StorePhone,StorePhoto,StoreHours,BasicIntroduction,TelPhone,Cod,OnlinePay,TakeAwayType,VideoAddress,TakeOrderNum,CreateUserName,UpdateUserName,LastUpdateDate,BizSLD,BizBannerUrl,BizWeiBoUrl,BizNotice,GLat,GLng,BLat,BLng,IsQueue,IsPointMenu,IsTakeAway,IsReservation,IsCheck,LikeCount,OrderCount,SortID,IsCitySend,IsCoupon,IsPrivileges,IsSend,ShareCount,CollectionCount,ComCount,FoodCount,IsGroup,QRcodeUrl,Bus,MinPrice,MaxPrice,CarPark,Box,PayCar,WIFI,NoSmoke,ChildrenChair,SendDesc,TakeRange,KCVIP,Onlineorder from StoreInfo ");
            strSql.Append(" where BizID=@BizID ");
            SqlParameter[] parameters = {
					new SqlParameter("@BizID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = BizID;

            Maticsoft.Model.StoreInfoEntity model = new Maticsoft.Model.StoreInfoEntity();
            DataSet ds = ServerDbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Maticsoft.Model.StoreInfoEntity DataRowToModel(DataRow row)
        {
            Maticsoft.Model.StoreInfoEntity model = new Maticsoft.Model.StoreInfoEntity();
            if (row != null)
            {
                if (row["BizID"] != null)
                {
                    model.BizID = row["BizID"].ToString();
                }
                if (row["StoreName"] != null)
                {
                    model.StoreName = row["StoreName"].ToString();
                }
                if (row["BranchName"] != null)
                {
                    model.BranchName = row["BranchName"].ToString();
                }
                if (row["StoreAddress"] != null)
                {
                    model.StoreAddress = row["StoreAddress"].ToString();
                }
                if (row["BusinessTypeID"] != null)
                {
                    model.BusinessTypeID = row["BusinessTypeID"].ToString();
                }
                if (row["BusinessAddTime"] != null && row["BusinessAddTime"].ToString() != "")
                {
                    model.BusinessAddTime = DateTime.Parse(row["BusinessAddTime"].ToString());
                }
                if (row["ChainStoreID"] != null)
                {
                    model.ChainStoreID = row["ChainStoreID"].ToString();
                }
                if (row["CityID"] != null)
                {
                    model.CityID = row["CityID"].ToString();
                }
                if (row["DistrictID"] != null)
                {
                    model.DistrictID = row["DistrictID"].ToString();
                }
                if (row["BusinessState"] != null && row["BusinessState"].ToString() != "")
                {
                    model.BusinessState = int.Parse(row["BusinessState"].ToString());
                }
                if (row["ShortID"] != null)
                {
                    model.ShortID = row["ShortID"].ToString();
                }
                if (row["StorePhone"] != null)
                {
                    model.StorePhone = row["StorePhone"].ToString();
                }
                if (row["StorePhoto"] != null)
                {
                    model.StorePhoto = row["StorePhoto"].ToString();
                }
                if (row["StoreHours"] != null)
                {
                    model.StoreHours = row["StoreHours"].ToString();
                }
                if (row["BasicIntroduction"] != null)
                {
                    model.BasicIntroduction = row["BasicIntroduction"].ToString();
                }
                if (row["TelPhone"] != null)
                {
                    model.TelPhone = row["TelPhone"].ToString();
                }
                if (row["Cod"] != null && row["Cod"].ToString() != "")
                {
                    if ((row["Cod"].ToString() == "1") || (row["Cod"].ToString().ToLower() == "true"))
                    {
                        model.Cod = true;
                    }
                    else
                    {
                        model.Cod = false;
                    }
                }
                if (row["OnlinePay"] != null && row["OnlinePay"].ToString() != "")
                {
                    if ((row["OnlinePay"].ToString() == "1") || (row["OnlinePay"].ToString().ToLower() == "true"))
                    {
                        model.OnlinePay = true;
                    }
                    else
                    {
                        model.OnlinePay = false;
                    }
                }
                if (row["TakeAwayType"] != null)
                {
                    model.TakeAwayType = row["TakeAwayType"].ToString();
                }
                if (row["VideoAddress"] != null)
                {
                    model.VideoAddress = row["VideoAddress"].ToString();
                }
                if (row["TakeOrderNum"] != null && row["TakeOrderNum"].ToString() != "")
                {
                    model.TakeOrderNum = int.Parse(row["TakeOrderNum"].ToString());
                }
                if (row["CreateUserName"] != null)
                {
                    model.CreateUserName = row["CreateUserName"].ToString();
                }
                if (row["UpdateUserName"] != null)
                {
                    model.UpdateUserName = row["UpdateUserName"].ToString();
                }
                if (row["LastUpdateDate"] != null && row["LastUpdateDate"].ToString() != "")
                {
                    model.LastUpdateDate = DateTime.Parse(row["LastUpdateDate"].ToString());
                }
                if (row["BizSLD"] != null)
                {
                    model.BizSLD = row["BizSLD"].ToString();
                }
                if (row["BizBannerUrl"] != null)
                {
                    model.BizBannerUrl = row["BizBannerUrl"].ToString();
                }
                if (row["BizWeiBoUrl"] != null)
                {
                    model.BizWeiBoUrl = row["BizWeiBoUrl"].ToString();
                }
                if (row["BizNotice"] != null)
                {
                    model.BizNotice = row["BizNotice"].ToString();
                }
                if (row["GLat"] != null)
                {
                    model.GLat = row["GLat"].ToString();
                }
                if (row["GLng"] != null)
                {
                    model.GLng = row["GLng"].ToString();
                }
                if (row["BLat"] != null)
                {
                    model.BLat = row["BLat"].ToString();
                }
                if (row["BLng"] != null)
                {
                    model.BLng = row["BLng"].ToString();
                }
                if (row["IsQueue"] != null && row["IsQueue"].ToString() != "")
                {
                    if ((row["IsQueue"].ToString() == "1") || (row["IsQueue"].ToString().ToLower() == "true"))
                    {
                        model.IsQueue = true;
                    }
                    else
                    {
                        model.IsQueue = false;
                    }
                }
                if (row["IsPointMenu"] != null && row["IsPointMenu"].ToString() != "")
                {
                    if ((row["IsPointMenu"].ToString() == "1") || (row["IsPointMenu"].ToString().ToLower() == "true"))
                    {
                        model.IsPointMenu = true;
                    }
                    else
                    {
                        model.IsPointMenu = false;
                    }
                }
                if (row["IsTakeAway"] != null && row["IsTakeAway"].ToString() != "")
                {
                    if ((row["IsTakeAway"].ToString() == "1") || (row["IsTakeAway"].ToString().ToLower() == "true"))
                    {
                        model.IsTakeAway = true;
                    }
                    else
                    {
                        model.IsTakeAway = false;
                    }
                }
                if (row["IsReservation"] != null && row["IsReservation"].ToString() != "")
                {
                    if ((row["IsReservation"].ToString() == "1") || (row["IsReservation"].ToString().ToLower() == "true"))
                    {
                        model.IsReservation = true;
                    }
                    else
                    {
                        model.IsReservation = false;
                    }
                }
                if (row["IsCheck"] != null && row["IsCheck"].ToString() != "")
                {
                    if ((row["IsCheck"].ToString() == "1") || (row["IsCheck"].ToString().ToLower() == "true"))
                    {
                        model.IsCheck = true;
                    }
                    else
                    {
                        model.IsCheck = false;
                    }
                }
                if (row["LikeCount"] != null && row["LikeCount"].ToString() != "")
                {
                    model.LikeCount = int.Parse(row["LikeCount"].ToString());
                }
                if (row["OrderCount"] != null && row["OrderCount"].ToString() != "")
                {
                    model.OrderCount = int.Parse(row["OrderCount"].ToString());
                }
                if (row["SortID"] != null && row["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(row["SortID"].ToString());
                }
                if (row["IsCitySend"] != null && row["IsCitySend"].ToString() != "")
                {
                    if ((row["IsCitySend"].ToString() == "1") || (row["IsCitySend"].ToString().ToLower() == "true"))
                    {
                        model.IsCitySend = true;
                    }
                    else
                    {
                        model.IsCitySend = false;
                    }
                }
                if (row["IsCoupon"] != null && row["IsCoupon"].ToString() != "")
                {
                    if ((row["IsCoupon"].ToString() == "1") || (row["IsCoupon"].ToString().ToLower() == "true"))
                    {
                        model.IsCoupon = true;
                    }
                    else
                    {
                        model.IsCoupon = false;
                    }
                }
                if (row["IsPrivileges"] != null && row["IsPrivileges"].ToString() != "")
                {
                    if ((row["IsPrivileges"].ToString() == "1") || (row["IsPrivileges"].ToString().ToLower() == "true"))
                    {
                        model.IsPrivileges = true;
                    }
                    else
                    {
                        model.IsPrivileges = false;
                    }
                }
                if (row["IsSend"] != null && row["IsSend"].ToString() != "")
                {
                    model.IsSend = int.Parse(row["IsSend"].ToString());
                }
                if (row["ShareCount"] != null && row["ShareCount"].ToString() != "")
                {
                    model.ShareCount = int.Parse(row["ShareCount"].ToString());
                }
                if (row["CollectionCount"] != null && row["CollectionCount"].ToString() != "")
                {
                    model.CollectionCount = int.Parse(row["CollectionCount"].ToString());
                }
                if (row["ComCount"] != null && row["ComCount"].ToString() != "")
                {
                    model.ComCount = int.Parse(row["ComCount"].ToString());
                }
                if (row["FoodCount"] != null && row["FoodCount"].ToString() != "")
                {
                    model.FoodCount = int.Parse(row["FoodCount"].ToString());
                }
                if (row["IsGroup"] != null && row["IsGroup"].ToString() != "")
                {
                    if ((row["IsGroup"].ToString() == "1") || (row["IsGroup"].ToString().ToLower() == "true"))
                    {
                        model.IsGroup = true;
                    }
                    else
                    {
                        model.IsGroup = false;
                    }
                }
                if (row["QRcodeUrl"] != null)
                {
                    model.QRcodeUrl = row["QRcodeUrl"].ToString();
                }
                if (row["Bus"] != null)
                {
                    model.Bus = row["Bus"].ToString();
                }
                if (row["MinPrice"] != null && row["MinPrice"].ToString() != "")
                {
                    model.MinPrice = decimal.Parse(row["MinPrice"].ToString());
                }
                if (row["MaxPrice"] != null && row["MaxPrice"].ToString() != "")
                {
                    model.MaxPrice = decimal.Parse(row["MaxPrice"].ToString());
                }
                if (row["CarPark"] != null && row["CarPark"].ToString() != "")
                {
                    if ((row["CarPark"].ToString() == "1") || (row["CarPark"].ToString().ToLower() == "true"))
                    {
                        model.CarPark = true;
                    }
                    else
                    {
                        model.CarPark = false;
                    }
                }
                if (row["Box"] != null && row["Box"].ToString() != "")
                {
                    if ((row["Box"].ToString() == "1") || (row["Box"].ToString().ToLower() == "true"))
                    {
                        model.Box = true;
                    }
                    else
                    {
                        model.Box = false;
                    }
                }
                if (row["PayCar"] != null && row["PayCar"].ToString() != "")
                {
                    if ((row["PayCar"].ToString() == "1") || (row["PayCar"].ToString().ToLower() == "true"))
                    {
                        model.PayCar = true;
                    }
                    else
                    {
                        model.PayCar = false;
                    }
                }
                if (row["WIFI"] != null && row["WIFI"].ToString() != "")
                {
                    if ((row["WIFI"].ToString() == "1") || (row["WIFI"].ToString().ToLower() == "true"))
                    {
                        model.WIFI = true;
                    }
                    else
                    {
                        model.WIFI = false;
                    }
                }
                if (row["NoSmoke"] != null && row["NoSmoke"].ToString() != "")
                {
                    if ((row["NoSmoke"].ToString() == "1") || (row["NoSmoke"].ToString().ToLower() == "true"))
                    {
                        model.NoSmoke = true;
                    }
                    else
                    {
                        model.NoSmoke = false;
                    }
                }
                if (row["ChildrenChair"] != null && row["ChildrenChair"].ToString() != "")
                {
                    if ((row["ChildrenChair"].ToString() == "1") || (row["ChildrenChair"].ToString().ToLower() == "true"))
                    {
                        model.ChildrenChair = true;
                    }
                    else
                    {
                        model.ChildrenChair = false;
                    }
                }
                if (row["SendDesc"] != null)
                {
                    model.SendDesc = row["SendDesc"].ToString();
                }
                if (row["TakeRange"] != null && row["TakeRange"].ToString() != "")
                {
                    model.TakeRange = decimal.Parse(row["TakeRange"].ToString());
                }
                if (row["KCVIP"] != null && row["KCVIP"].ToString() != "")
                {
                    if ((row["KCVIP"].ToString() == "1") || (row["KCVIP"].ToString().ToLower() == "true"))
                    {
                        model.KCVIP = true;
                    }
                    else
                    {
                        model.KCVIP = false;
                    }
                }
                if (row["Onlineorder"] != null && row["Onlineorder"].ToString() != "")
                {
                    model.Onlineorder = int.Parse(row["Onlineorder"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BizID,StoreName,BranchName,StoreAddress,BusinessTypeID,BusinessAddTime,ChainStoreID,CityID,DistrictID,BusinessState,ShortID,StorePhone,StorePhoto,StoreHours,BasicIntroduction,TelPhone,Cod,OnlinePay,TakeAwayType,VideoAddress,TakeOrderNum,CreateUserName,UpdateUserName,LastUpdateDate,BizSLD,BizBannerUrl,BizWeiBoUrl,BizNotice,GLat,GLng,BLat,BLng,IsQueue,IsPointMenu,IsTakeAway,IsReservation,IsCheck,LikeCount,OrderCount,SortID,IsCitySend,IsCoupon,IsPrivileges,IsSend,ShareCount,CollectionCount,ComCount,FoodCount,IsGroup,QRcodeUrl,Bus,MinPrice,MaxPrice,CarPark,Box,PayCar,WIFI,NoSmoke,ChildrenChair,SendDesc,TakeRange,KCVIP,Onlineorder ");
            strSql.Append(" FROM StoreInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return ServerDbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" BizID,StoreName,BranchName,StoreAddress,BusinessTypeID,BusinessAddTime,ChainStoreID,CityID,DistrictID,BusinessState,ShortID,StorePhone,StorePhoto,StoreHours,BasicIntroduction,TelPhone,Cod,OnlinePay,TakeAwayType,VideoAddress,TakeOrderNum,CreateUserName,UpdateUserName,LastUpdateDate,BizSLD,BizBannerUrl,BizWeiBoUrl,BizNotice,GLat,GLng,BLat,BLng,IsQueue,IsPointMenu,IsTakeAway,IsReservation,IsCheck,LikeCount,OrderCount,SortID,IsCitySend,IsCoupon,IsPrivileges,IsSend,ShareCount,CollectionCount,ComCount,FoodCount,IsGroup,QRcodeUrl,Bus,MinPrice,MaxPrice,CarPark,Box,PayCar,WIFI,NoSmoke,ChildrenChair,SendDesc,TakeRange,KCVIP,Onlineorder ");
            strSql.Append(" FROM StoreInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return ServerDbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM StoreInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.BizID desc");
            }
            strSql.Append(")AS Row, T.*  from StoreInfo T ");
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
            parameters[0].Value = "StoreInfo";
            parameters[1].Value = "BizID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return ServerDbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        public string GetMaxShortID()
        {
            return ServerDbHelperSQL.GetMaxID("ShortID", "StoreInfo").ToString();
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

