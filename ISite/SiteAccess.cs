using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SiteFactory
{
    public sealed class SiteAccess
    {
        private static string _assemblyPath = "FanQieKuaiDianSite";

        public SiteAccess(string assemblyPath)
        {
            _assemblyPath = assemblyPath;
        }

        #region
        private static object CreateObject(string assemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(assemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public static ISite.IStore CreateStoreSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            string classNamespace = _assemblyPath + ".StoreSecretary";
            object objType = CreateObject(_assemblyPath, classNamespace);
            return (ISite.IStore)objType;
        }
        #endregion

        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public static ISite.IPicture CreatePictureSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            string classNamespace = _assemblyPath + ".PictureSecretary";
            object objType = CreateObject(_assemblyPath, classNamespace);
            return (ISite.IPicture)objType;
        }
        #endregion
        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public static ISite.IDishType CreateDishTypeSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            string classNamespace = _assemblyPath + ".DishTypeSecretary";
            object objType = CreateObject(_assemblyPath, classNamespace);
            return (ISite.IDishType)objType;
        }
        #endregion
        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public static ISite.IDishes CreateDishesSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            string classNamespace = _assemblyPath + ".DishesSecretary";
            object objType = CreateObject(_assemblyPath, classNamespace);
            return (ISite.IDishes)objType;
        }
        #endregion
        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public static ISite.ICatalogue CreateCatalogueSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            string classNamespace = _assemblyPath + ".CatalogueSecretary";
            object objType = CreateObject(_assemblyPath, classNamespace);
            return (ISite.ICatalogue)objType;
        }
        #endregion
    }
}
