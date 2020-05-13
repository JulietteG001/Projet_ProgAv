using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
   public  abstract class Intervenant
    //abstraite car un intervenant tout seul n'existe pas en lui-même.
    //on lui applique donc l'étiquette élève, enseignant, ou intervenant extérieur via des classes héritières.
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; }

        //Constructeur par défaut
        public Intervenant()
        {
            Nom = " ";
            Prenom = " ";
            Role = " ";
        }

        //Constructeur surchargé 
        public Intervenant(string _nom, string _prenom, string _role)
        {
            Nom = _nom;
            Prenom = _prenom;
            Role = _role;
        }

        public override string ToString()
        {
            string chRes = "Nom : " + Nom + " Prénom : " + Prenom + " Rôle : " + Role;
            return chRes;
        }
    }
}
