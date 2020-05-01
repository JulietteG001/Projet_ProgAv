using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    class Projet : Consultation.ITrouvable
    {
        private string NomProjet { get; set; }
        private int NbEleves { get; set; }
        private int Duree { get; set; } //Durée du projet en jours
        private string Semestres { get; set; }
        private string Consigne { get; set; }
        private List<Livrable> Livrables { get; set; } 
        private Matiere MatièreProjet { get; set; }
        private List<Intervenant> Intervenants { get; set; } 

        public Projet() //Constructeur par défaut
        {
            NomProjet = "";
            NbEleves = 0;
            Duree = 0;
            Semestres = "";
            Consigne = "";
            Livrables = new List<Livrable>();
            Intervenants = new List<Intervenant>();
        }
        public Projet(string nomprojet, int nbEleves, int duree, string semestres, string consigne, List<Livrable> livrables, List<Intervenant> intervenants) 
        //Constructeur surchargé
        {
            NomProjet = nomprojet;
            NbEleves = nbEleves;
            Duree = duree;
            Semestres = semestres;
            Consigne = consigne;
            Livrables = livrables;
            Intervenants = intervenants;
        }

        //implémentation de l'interface
        public override Projet Critere(string attrrech, string critrech)
        //recherche dans les projets si le critère de recherche entré fait partie des attributs du projet
        {
            if(attrrech == "Livrables")
            //on cherche dans la liste de livrables si on trouve le nom du livrable
            //si on l'a, on retourne le projet
            //si on l'a pas, message d'erreur
            {
                for(int i = 0; i<Livrables.Count; i++)
                {
                    if (Livrables.Contains(critrech))
                    {

                    }
                }
                
            }
            if (attrrech == "MatièreProjet")
            //on cherche dans la liste des matières si on trouve le nom de la matière
            //si on l'a, on retourne le projet
            //si on l'a pas, message d'erreur
            { }
            if (attrrech == "Intervenants")
            //on cherche dans la liste des intervenants si on trouve le nom de l'intervenant
            //si on l'a, on retourne le projet
            //si on l'a pas, message d'erreur
            { }

        }
    }
}
