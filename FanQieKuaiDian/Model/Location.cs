using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanQieKuaiDianSite.Model
{
    public class Location
    {
        public Location()
        {
            RestaurantinfoList = new List<Restaurantinfo>();
        }
        public int PageNo;
        public int PageSize;
        public List<Restaurantinfo> RestaurantinfoList;
        public int TotalPage;
        public int IflastPage;
    }
}
