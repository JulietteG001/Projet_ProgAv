using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    class Eleve : Intervenant
    {
        public string Promotion { get; set; }
        public string Annee { get; set; }

        public Eleve(string _promotion, string _annee) : base()
        {
            Promotion = _promotion;
            Annee = _annee;
        }

        public override string ToString()
        {
            string chRes = base.ToString() + "Promotion : " + Promotion + " Année : " + Annee;
            return chRes;
        }
    }
}
