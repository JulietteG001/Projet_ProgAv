using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    [System.Xml.Serialization.XmlInclude(typeof(Enseignant))]
    [System.Xml.Serialization.XmlInclude(typeof(Eleve))]
    [System.Xml.Serialization.XmlInclude(typeof(Intervenant_externe))]
    //Ce code signifie que le Serializer peut rencontrer ces types dérivés, qui font quand même partie de la classe Intervenant

    public abstract class Intervenant
    //abstraite car un intervenant tout seul n'existe pas en lui-même.
    //on lui applique donc l'étiquette élève, enseignant, ou intervenant extérieur via des classes héritières.
    {
        public string NomInterv { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; }

        //Constructeur par défaut
        public Intervenant()
        {
            NomInterv = " ";
            Prenom = " ";
            Role = " ";
        }

        //Constructeur surchargé 
        public Intervenant(string _nom, string _prenom, string _role)
        {
            NomInterv = _nom;
            Prenom = _prenom;
            Role = _role;
        }

        public override string ToString()
        {
            string chRes = "\n       Nom : " + NomInterv + "\n       Prénom : " + Prenom + "\n       Rôle : " + Role;
            return chRes;
        }
    }
}
