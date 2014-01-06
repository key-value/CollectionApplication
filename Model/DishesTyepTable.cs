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
namespace Maticsoft.Model
{
    /// <summary>
    /// 菜品类别
    /// </summary>
    [Serializable]
    public partial class DishesTyepTable
    {
        public DishesTyepTable()
        { }
        #region Model
        private string _dishestypeid;
        private string _dishestypename;
        private string _olddishestypeid;
        private string _businessid;
        private int? _sortid = 0;
        private DateTime? _createdate;
        private string _chainstoredishestypeid;
        private string _chainstoreid;
        private bool _isdeleted;
        private bool _issetmeal;
        /// <summary>
        /// 菜品类别表ID
        /// </summary>
        public string DishesTypeID
        {
            set { _dishestypeid = value; }
            get { return _dishestypeid; }
        }
        /// <summary>
        /// 菜品类别名称
        /// </summary>
        public string DishesTypeName
        {
            set { _dishestypename = value; }
            get { return _dishestypename; }
        }
        /// <summary>
        /// 子类别
        /// </summary>
        public string OldDishesTypeID
        {
            set { _olddishestypeid = value; }
            get { return _olddishestypeid; }
        }
        /// <summary>
        /// 商家登陆ID
        /// </summary>
        public string BusinessID
        {
            set { _businessid = value; }
            get { return _businessid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChainStoreDishesTypeID
        {
            set { _chainstoredishestypeid = value; }
            get { return _chainstoredishestypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChainStoreID
        {
            set { _chainstoreid = value; }
            get { return _chainstoreid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSetMeal
        {
            set { _issetmeal = value; }
            get { return _issetmeal; }
        }
        #endregion Model

    }
}

