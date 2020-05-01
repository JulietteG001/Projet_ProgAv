using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    class Enseignant : Intervenant
    {
        public List<Matiere> Matieres { get; set; }

        public Enseignant(List<Matiere> matieres_enseignees) : base()
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
