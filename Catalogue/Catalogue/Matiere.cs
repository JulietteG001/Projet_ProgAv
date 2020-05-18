using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catalogue
{
    public class Matiere
    {
        public string NomMat { get; set; }
        public string Coefficient { get; set; }

        public Matiere() //Constructeur par défaut
        {
            NomMat = "";
            Coefficient = "0";
        }
        public Matiere(string nom, string coefficient) //Constructeur surchargé
        {
            NomMat = nom;
            Coefficient = coefficient;
        }
        public override string ToString()
        {
            string chRes = "\n       Nom : " + NomMat + "\n       Coefficient : " + Coefficient;
            return chRes;
        }
    }
}
