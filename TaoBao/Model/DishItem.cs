using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBao.Model
{
    public class DishItem
    {
        public cat cat { get; set; }
        public List<DishesTaoBao> item { get; set; }
    }
}
