using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanQieKuaiDianSite.Model
{
    public class DishFullData
    {
        public DishFullData()
        {
            B = new List<GeneralEntity>();
            C = new List<DishTypeTable>();
        }

        public List<GeneralEntity> B;
        public List<DishTypeTable> C;
        public string D;
        public string E;
        public string F;
        public string G;
        public string H;
        public string I;

        protected bool _isNull;

        public bool IsNull
        {
            get { return _isNull; }
        }
    }

    public class NullDishFullData : DishFullData
    {
        public NullDishFullData()
        {
            _isNull = true;
        }
    }
}
