/**  版本信息模板在安装目录下，可自行修改。
* Dishes.cs
*
* 功 能： N/A
* 类 名： Dishes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/15 11:09:22   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// Dishes:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Dishes
    {
        public Dishes()
        { }


        #region Model
        private string _dishesid;
        private string _dishesname;
        private string _dishesmoney;
        private string _popularity;
        private string _storeid;
        private string _picturename;
        private string _dishtypeid;
        private string _dishesunit;
        private string _dishesbrief;
        /// <summary>
        /// 
        /// </summary>
        public string DishesID
        {
            set { _dishesid = value; }
            get { return _dishesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DishesName
        {
            set { _dishesname = value; }
            get { return _dishesname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DishesMoney
        {
            set { _dishesmoney = value; }
            get { return _dishesmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string popularity
        {
            set { _popularity = value; }
            get { return _popularity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreId
        {
            set { _storeid = value; }
            get { return _storeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PictureName
        {
            set { _picturename = value; }
            get { return _picturename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dishTypeID
        {
            set { _dishtypeid = value; }
            get { return _dishtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DishesUnit
        {
            set { _dishesunit = value; }
            get { return _dishesunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DishesBrief
        {
            set { _dishesbrief = value; }
            get { return _dishesbrief; }
        }
        #endregion Model

        public bool IsCurrentPrice
        {
            get;
            set;
        }

        public bool IsNull
        {
            get { return _isNull; }
        }

        protected bool _isNull;
    }

    public class NullDishes : Dishes
    {
        public NullDishes()
        {
            _isNull = true;
        }
    }
}

