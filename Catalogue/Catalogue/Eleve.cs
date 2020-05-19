using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    public class Eleve : Intervenant
    {
        public string Promotion { get; set; }

        public Eleve() : base()
        //Constructeur par défaut
        {
            Promotion = "";
        }

        public Eleve(string _promotion) : base()
        //constructeur surchargé
        {
            Promotion = _promotion;
        }

        public override string ToString()
        {
            string chRes = base.ToString() + "\n       Promotion : " + Promotion;
            return chRes;
        }
    }
}
