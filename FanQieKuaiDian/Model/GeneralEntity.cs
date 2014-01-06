using System.Collections.Generic;
using FanQieKuaiDianSite.Model;
using ISite;

namespace FanQieKuaiDianSite
{
    public class GeneralEntity : IDishSiteModel
    {
        public GeneralEntity()
        {
            Z = new List<PictureEntity>();
        }

        public int A;
        public string B;
        public string C;
        public string CC;
        public string D;
        public string E;
        public string F;
        public string G;
        public string K;
        public string L;
        public string LL;
        public string M;
        public string N;
        public string P;
        public int Q;
        public string R;
        public string S;
        public string W;
        public List<PictureEntity> Z;

        public int DishID
        {
            get
            {
                return A;
            }
            set
            {
                A = value;
            }
        }

        public string DishName
        {
            get
            {
                return B;
            }
            set
            {
                B = value;
            }
        }

        public string DishesMoney
        {
            get
            {
                return C;
            }
            set
            {
                C = value;
            }
        }

        public string DishesUnit
        {
            get
            {
                return E;
            }
            set
            {
                E = value;
            }
        }


        public string DishesBrief
        {
            get
            {
                return CC;
            }
            set
            {
                CC = value;
            }
        }

        public bool IsNull
        {
            get { return _isNull; }
            set { _isNull = value; }
        }

        protected bool _isNull;


        public int Popularity
        {
            get
            {
                return Q;
            }
            set
            {
                Q = value;
            }
        }


        public string PictureName
        {
            get
            {
                return G;
            }
            set
            {
                G = value;
            }
        }
        public string DishTypeID { get; set; }
    }

    public class NullGeneralEntity : GeneralEntity
    {
        public NullGeneralEntity()
        {
            _isNull = true;
        }
    }
}