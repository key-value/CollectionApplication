using System.Reflection;

namespace SiteFactory
{
    public class CollectionFactory
    {
        private static string _assemblyPath = "";

        public CollectionFactory(string assemblyPath)
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

        public T CreateInterface<T>(string className)
        {
            if (string.IsNullOrEmpty(_assemblyPath))
            {
                return default(T);
            }
            string classNamespace = string.Format("{0}.{1}", _assemblyPath, className);
            object objType = CreateObject(_assemblyPath, classNamespace);
            if (objType == null)
            {
                return default(T);
            }
            return (T)objType;
        }
        #endregion

        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public ISite.IStore CreateStoreSecretary()
        {
            return CreateInterface<ISite.IStore>("StoreSecretary");
        }
        #endregion

        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public ISite.IPicture CreatePictureSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            return CreateInterface<ISite.IPicture>("PictureSecretary");
        }
        #endregion
        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public ISite.IDishType CreateDishTypeSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            return CreateInterface<ISite.IDishType>("DishTypeSecretary");
        }
        #endregion
        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public ISite.IDishes CreateDishesSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            return CreateInterface<ISite.IDishes>("DishesSecretary");
        }
        #endregion
        #region
        /// <summary>
        /// 创建BusPhotoAlbumTable数据层接口。商家相册
        /// </summary>
        public ISite.ICatalogue CreateCatalogueSecretary()
        {
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");
            return CreateInterface<ISite.ICatalogue>("CatalogueSecretary");
        }
        #endregion
    }
}
