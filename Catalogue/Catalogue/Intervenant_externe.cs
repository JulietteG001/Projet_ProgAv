using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    public class Intervenant_externe : Intervenant
    {
        private string Descr_intervenant { get; set; }

        public Intervenant_externe() : base()
        //Constructeur par défaut
        {
            Descr_intervenant = "";
        }

        public Intervenant_externe(string _descr_inter) : base()
        //constructeur surchargé
        {
            Descr_intervenant = _descr_inter;
        }

        public override string ToString()
        {
            string chRes = base.ToString() + "\n       Description : " + Descr_intervenant;
            chRes += "\n";
            return chRes;
        }
    }
}
