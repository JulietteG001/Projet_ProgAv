using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    class Projet
    {
        private int NbEleves { get; set; }
        private int Duree { get; set; } //Durée du projet en jours
        private string Semestres { get; set; }
        private string Consigne { get; set; }
        private List<Livrable> Livrables { get; set; } 
        private Matiere MatièreProjet { get; set; }
        private List<Intervenant> Intervenants { get; set; } 

        public Projet() //Constructeur par défaut
        {
            NbEleves = 0;
            Duree = 0;
            Semestres = "";
            Consigne = "";
            Livrables = new List<Livrable>();
            Intervenants = new List<Intervenant>();
        }
        public Projet(int nbEleves, int duree, string semestres, string consigne, List<Livrable> livrables, List<Intervenant> intervenants) //Constructeur surchargé
        {
            NbEleves = nbEleves;
            Duree = duree;
            Semestres = semestres;
            Consigne = consigne;
            Livrables = livrables;
            Intervenants = intervenants;
        }
    }
}
