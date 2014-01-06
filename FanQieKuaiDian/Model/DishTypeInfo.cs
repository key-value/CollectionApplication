using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanQieKuaiDianSite.Model
{
    public class DishTypeInfo
    {
        public DishTypeInfo()
        {
            D = new List<DishTypeEntity>();
        }
        public string B;
        public string C;
        public List<DishTypeEntity> D;

        protected bool _isNull;

        public bool IsNull
        {
            get { return _isNull; }
        }
    }

    public class NullDishTypeInfo : DishTypeInfo
    {
        public NullDishTypeInfo()
            : base()
        {
            _isNull = true;
        }
    }
}
