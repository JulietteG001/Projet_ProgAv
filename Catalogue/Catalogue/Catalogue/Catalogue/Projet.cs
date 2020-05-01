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

        public override Projet CritLivrable(object critlivr)
        //implémentation de l'interface pour trouver untype de livrable
        {
            string livr = critlivr as string;
            for (int i = 0; i < this.Livrables.Count; i++)
            {
                if (this.Livrables[i] == critlivr)
                {
                    return this;
                }

                else
                {
                    Console.WriteLine("Il n'existe pas de projet contenant ce type de livrable !");
                }
            }
        }
        public override Projet CritMatiere(object critmat)
        //implémentation de l'interface pour trouver une matière
        {
            string mat = critmat as string;
            if (MatièreProjet.Nom == critmat)
            {
                return this;
            }

            else
            {
                Console.WriteLine("Il n'existe pas de projet pour la matière sélectionnée !");
            }
        }

        public override Projet CritInterv(object critinterv)
        //implémentation de l'interface pour trouver une matière
        {
            string mat = critinterv as string;
            for (int i = 0; i < this.Intervenants.Count; i++)
            {
                if (this.Intervenants[i] == critinterv)
                {
                    return this;
                }

                else
                {
                    Console.WriteLine("Il n'existe pas de projet pour lequel cet intervenant est impliqué !");
                }
            }
        }

        ////implémentation de l'interface
        //public override bool Critere(object attrrech, object critrech)
        ////recherche dans les projets si le critère de recherche entré fait partie des attributs du projet
        //{
        //    Livrable 
        //    if(attrrech == "Livrables")
        //    //on cherche dans la liste de livrables si on trouve le nom du livrable
        //    //si on l'a, on retourne le projet
        //    //si on l'a pas, message d'erreur
        //    {
        //        for(int i = 0; i<Livrables.Count; i++)
        //        {
        //            if (Livrables.Contains(critrech))
        //            {

        //            }
        //        }

        //    }
        //    if (attrrech == "MatièreProjet")
        //    //on cherche dans la liste des matières si on trouve le nom de la matière
        //    //si on l'a, on retourne le projet
        //    //si on l'a pas, message d'erreur
        //    { }
        //    if (attrrech == "Intervenants")
        //    //on cherche dans la liste des intervenants si on trouve le nom de l'intervenant
        //    //si on l'a, on retourne le projet
        //    //si on l'a pas, message d'erreur
        //    { }

        //}
    }
}
