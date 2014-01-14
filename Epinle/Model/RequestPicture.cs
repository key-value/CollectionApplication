using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epinle.Model
{
    public class RequestPicture
    {
        public RequestPicture()
        { PictureModels = new List<PictureModel>(); }
        public List<PictureModel> PictureModels;
    }
}
