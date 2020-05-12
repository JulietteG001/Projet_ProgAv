using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    public class Livrable
    {
        public string Nature { get; set; }
        public Livrable() //Constructeur par défaut
        {
            Nature = "";
        }
        public Livrable(string nature) //Constructeur surchargé
        {
            Nature = nature;
        }
        public override string ToString()
        {
            string chRes = "Nature : " + Nature;
            return chRes;
        }
    }
}
