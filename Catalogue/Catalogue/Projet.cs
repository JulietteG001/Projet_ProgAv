using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Catalogue
{
    class Projet //: Consultation.ITrouvable 
    {
        private string NomProjet { get; set; }
        private int NbEleves { get; set; }
        private int Duree { get; set; } //Durée du projet en jours
        private string Semestres { get; set; }
        private string Consigne { get; set; }
        private List<Livrable> Livrables { get; set; } 
        private Matiere MatiereProjet { get; set; }
        private List<Intervenant> Intervenants { get; set; } 

        public Projet() //Constructeur par défaut
        {
            NomProjet = "";
            NbEleves = 0;
            Duree = 0;
            Semestres = "";
            Consigne = "";
            Livrables = new List<Livrable>();
            MatiereProjet = null;
            Intervenants = new List<Intervenant>();
        }
        
        public Projet(string nomprojet, int nbEleves, int duree, string semestres, string consigne, List<Livrable> livrables, Matiere matiereProjet, List<Intervenant> intervenants) 
        //Constructeur surchargé
        {
            NomProjet = nomprojet;
            NbEleves = nbEleves;
            Duree = duree;
            Semestres = semestres;
            Consigne = consigne;
            Livrables = livrables;
            MatiereProjet = matiereProjet;
            Intervenants = intervenants;
        }
        public override string ToString()
        {
            string chRes = "Nom : " + NomProjet + " Nombre d'élèves: " + NbEleves + " Durée : " + Duree + " Semestres : " + Semestres + " Consigne : " + Consigne + " Livrables : " + Livrables + " Matière associée : " + MatiereProjet + " Intervenants : " + Intervenants;
            return chRes;
        }

        //public override Projet CritLivrable(object critlivr)
        ////implémentation de l'interface pour trouver un type de livrable
        //{
        //    string livr = critlivr as string;
        //    for (int i = 0; i < this.Livrables.Count; i++)
        //    {
        //        if (this.Livrables[i] == critlivr)
        //        {
        //            return this;
        //        }

        //        else
        //        {
        //            Console.WriteLine("Il n'existe pas de projet contenant ce type de livrable !");
        //        }
        //    }
        //}
        public Projet CritMatiere(object critmat)
        //implémentation de l'interface pour trouver une matière
        {
            XmlTextReader reader = new XmlTextReader("Catalogue_projets.xml");
            
            reader.ReadToFollowing("MatiereProjet");

            string matiere = critmat as string;

            string mot = reader.ReadElementContentAsString();
            int i = 0;
            //Je cherche si un projet correspond à la matière cherchée
            while (mot != matiere) 
            {
                reader.ReadToFollowing("MatiereProjet"); //On passe à la balise "matiere" suivante, càd on inspecte le projet suivant
                mot = reader.ReadElementContentAsString();
                i++; // ce i va nous aider à retrouver le projet plus tard
            }
            //Je ne vois pas comment gérer l'erreur si il n'y a pas de projet pour la matière sélectionnée

            //Si un projet contient la matière recherchée, alors il faut créer un objet Matiere 
            //(pour le placer dans les attributs du projet qu'on va renvoyer) -> problème à voir plus tard et qui ne va pas se poser si on réussit la désérialisation (cf la suite)

            //Ci dessous plusieurs méthodes pour récupérer le projet à renvoyer

            //Création d'un second reader qui ne contient que le projet étudié
            //for (int j = 0; j < i; j++)
            //{
            //    reader.ReadToFollowing("Projet"); //on se déplace jusqu'au ième projet, càd celui qu'on cherche
            //}

            ////reader.MoveToContent();
            //XmlReader inner = reader.ReadSubtree();

            //inner.ReadToDescendant("nom");
            //string nom = inner.Name;

            //Essai d'une autre méthode : ReadInnerXml pour lire tout le contenu du noeud actuel et ainsi pouvoir créer le projet à renvoyer
            //reader.MoveToContent(); //on revient au noeud
            //reader.ReadToFollowing("Projet");
            //string test = reader.ReadInnerXml();
            //Console.WriteLine("Résultat : " + test);

            //Autre essai : désérialisation
            List<Projet> Catalogue_projets = new List<Projet>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); //ne marche pas car la classe projet doit être public, mais non ça nous arrange pas
            StreamReader sr = new StreamReader("Catalogue_projets.xml");

            Catalogue_projets = (List<Projet>)serializer.Deserialize(sr);
            sr.Close();

            Projet p = Catalogue_projets[i];
            Console.WriteLine(p);

            return p;
        }

        //public override Projet CritInterv(object critinterv)
        ////implémentation de l'interface pour trouver un intervenant
        //{
        //    string mat = critinterv as string;
        //    for (int i = 0; i < this.Intervenants.Count; i++)
        //    {
        //        if (this.Intervenants[i] == critinterv)
        //        {
        //            return this;
        //        }

        //        else
        //        {
        //            Console.WriteLine("Il n'existe pas de projet pour lequel cet intervenant est impliqué !");
        //        }
        //    }
        //}

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
