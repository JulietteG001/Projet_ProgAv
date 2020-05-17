using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    public class Intervenant_externe : Intervenant
    {
        public List<Matiere> Matiere_intervention { get; set; }
        private string Descr_intervenant { get; set; }

        public Intervenant_externe() : base()
        //Constructeur par défaut
        {
            Matiere_intervention = new List<Matiere>();
            Descr_intervenant = "";
        }

        public Intervenant_externe(List<Matiere> liste_matieres, string _descr_inter) : base()
        //constructeur surchargé
        {
            Matiere_intervention = liste_matieres;
            Descr_intervenant = _descr_inter;
        }

        public override string ToString()
        {
            string chRes = base.ToString() + "\n       Matière(s) d'intervention : " + Matiere_intervention;
            return chRes;
        }
    }
}
