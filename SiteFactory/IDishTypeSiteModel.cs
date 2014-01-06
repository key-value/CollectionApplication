using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ISite
{
    public interface IDishSiteModel
    {
        int DishID { get; set; }

        string DishName { get; set; }

        string DishesMoney { get; set; }

        string DishesUnit { get; set; }

        string DishesBrief { get; set; }

        bool IsNull { get; set; }

        int Popularity { get; set; }

        string PictureName { get; set; }

        string DishTypeID { get; set; }
    }
}
