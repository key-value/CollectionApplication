using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    public class DishType
    {
        public DishType()
        {
            DishesList = new List<int>();
        }
        public Guid PkID;

        public string DishName;

        public string hrefString;

        public string dishNum;

        public bool IsNull;

        public List<int> DishesList;
    }

    public class NullDishType : DishType
    {
        public NullDishType()
        {
            IsNull = true;
        }
    }
}
