using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanQieKuaiDianSite.Model
{
    public class DishTypeTable
    {
        public DishTypeTable()
        {
            E = new List<int>();
            D = new List<DishTypeInfo>();
        }
        public int A;
        public string B;
        public string C;
        public List<int> E;
        public List<DishTypeInfo> D;

        protected bool _isNull;

        public bool IsNull
        {
            get { return _isNull; }
        }
    }

    public class NullDishTypeTable : DishTypeTable
    {
        public NullDishTypeTable():base()
        {
            _isNull = true;
        }
    }
}
