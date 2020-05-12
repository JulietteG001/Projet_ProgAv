using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    public class Matiere
    {
        public string Nom { get; set; }
        public string Coefficient { get; set; }
        private List<Intervenant> Encadrants { get; set; } 

        public Matiere() //Constructeur par défaut
        {
            Nom = "";
            Coefficient = "0";
            List<Intervenant> Encadrants = new List<Intervenant>();
        }
        public Matiere(string nom, string coefficient, List<Intervenant> encadrants) //Constructeur surchargé
        {
            Nom = nom;
            Coefficient = coefficient;
            List<Intervenant> Encadrants = encadrants;
        }
        public override string ToString()
        {
            string chRes = "Nom : " + Nom + " Coefficient : " + Coefficient + " Encadrants : " + Encadrants;
            return chRes;
        }
    }
}
