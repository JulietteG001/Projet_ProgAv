using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    public class Matiere
    {
        public string NomMat { get; set; }
        public string Coefficient { get; set; }
        private List<Intervenant> Encadrants { get; set; } 

        public Matiere() //Constructeur par défaut
        {
            NomMat = "";
            Coefficient = "0";
            List<Intervenant> Encadrants = new List<Intervenant>();
        }
        public Matiere(string nom, string coefficient, List<Intervenant> encadrants) //Constructeur surchargé
        {
            NomMat = nom;
            Coefficient = coefficient;
            List<Intervenant> Encadrants = encadrants;
        }
        public override string ToString()
        {
            string chRes = "Nom : " + NomMat + " Coefficient : " + Coefficient + " Encadrants : " + Encadrants;
            return chRes;
        }
    }
}
