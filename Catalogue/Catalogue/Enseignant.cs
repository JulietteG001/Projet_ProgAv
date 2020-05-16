using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    public class Enseignant : Intervenant
    {
        public List<Matiere> Matieres { get; set; }

        public Enseignant() : base() 
        //Constructeur par défaut
        {
            Matieres = new List<Matiere>();
        }

        public Enseignant(List<Matiere> matieres_enseignees) : base()
        //constructeur surchargé
        {
            Matieres = matieres_enseignees;
        }

        public override string ToString()
        {
            string chRes = base.ToString() + "Matière(s) enseignée(s) : " + Matieres;
            return chRes;
        }
    }
}
