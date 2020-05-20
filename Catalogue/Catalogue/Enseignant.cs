using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    public class Enseignant : Intervenant
    {

        public Enseignant() : base() { }

        public override string ToString()
        {
            string chRes = base.ToString();
            chRes += "\n";
            return chRes;
        }
    }
}
