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

        [XmlArrayItem("Enseignant", typeof(Enseignant))] //Ce code signifie que le Serializer peut rencontrer ces types 
        [XmlArrayItem("Eleve", typeof(Eleve))]           //dérivés, qui font quand même partie de la classe Intervenant
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
            string chRes = "\n       Nom : " + NomMat + "\n       Coefficient : " + Coefficient + "\n       Encadrants : ";
            //foreach (Intervenant e in this.Encadrants) //On ajoute la liste des encadrants à la chaîne
            //{
            //    chRes += e.Prenom + " " + e.NomInterv + " | ";
            //}
            return chRes;
        }
    }
}
