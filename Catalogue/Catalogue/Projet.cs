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
    public class Projet //: Consultation.ITrouvable //erreur ici normale tant qu'on a pas déclaré toutes les méthodes crées dans l'interface
    {
        public string NomProjet { get; set; } //Nom du projet
        public int NbEleves { get; set; } //Nombre d'élèves impliqués dans le projet
        public int Duree { get; set; } //Durée du projet en jours
        public string AnneeProjet { get; set; } //Année où s'est déroulé le projet (de la forme 20XX-20XX)
        public string Semestres { get; set; } //Numéro des semestres où s'est déroulé le projet
        public string Consigne { get; set; } //Consigne brève de ce que demande le projet
        public List<Livrable> Livrables { get; set; } //Liste des livrables à fournir à terme du projet
        public Matiere MatiereProjet { get; set; } //Matière concernée par le projet
        private List<Intervenant> Intervenants { get; set; }  //Liste des intervenants au sein du projet (profs, externes, élèves)

        public Projet() //Constructeur par défaut
        {
            NomProjet = "";
            NbEleves = 0;
            Duree = 0;
            AnneeProjet = "";
            Semestres = "";
            Consigne = "";
            Livrables = new List<Livrable>();
            MatiereProjet = null; //ATTENTION VARIABLE DECLAREE NULL C PAS OUF
            Intervenants = new List<Intervenant>();
        }
        
        public Projet(string nomprojet, int nbEleves, int duree, string _anneeprojet, string semestres, string consigne, List<Livrable> livrables, Matiere matiereProjet, List<Intervenant> intervenants) 
        //Constructeur surchargé
        {
            NomProjet = nomprojet;
            NbEleves = nbEleves;
            Duree = duree;
            AnneeProjet = _anneeprojet;
            Semestres = semestres;
            Consigne = consigne;
            Livrables = livrables;
            MatiereProjet = matiereProjet;
            Intervenants = intervenants;
        }
        public override string ToString()
        {
            string chRes = "Nom : " + NomProjet + "\nNombre d'élèves: " + NbEleves + "\nDurée : " + Duree + "\nAnnée du projet : " + AnneeProjet +  "\nSemestres : " + Semestres + "\nConsigne : " + Consigne + "\nLivrables : " + Livrables + "\nMatière associée : " + MatiereProjet + "\nIntervenants : " + Intervenants;
            return chRes;
        }
        public List<Projet> Deserialiser()
        {
            List<Projet> Catalogue_projets = new List<Projet>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>));
            StreamReader sr = new StreamReader("Catalogue_projets.xml");

            Catalogue_projets = (List<Projet>)serializer.Deserialize(sr);
            sr.Close();
            return Catalogue_projets;
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

        public List<Projet> CritMatiere(object critmat)
        //implémentation de l'interface pour trouver une matière
        {
            List<Projet> Catalogue_projets = this.Deserialiser();//Désérialisation de notre fichier xml contenant les projets

            XmlReader reader = XmlReader.Create("Catalogue_projets.xml"); //déclaration du xmlReader

            string matiere = critmat as string;
            int i = 0; //compteur 
            List<Projet> projetsTrouves = new List<Projet>(); //liste qui contiendra nos résultats
            
            //Recherche du ou des projets concerné(s) par le critère
            while (i<3) //tant qu'on a pas regardé tous les projets, ça serait bien de rajouter une variable NbProjets (nombre de projets dans notre fichier xml)
            {
                reader.ReadToFollowing("MatiereProjet"); //On passe à la balise "matiere" suivante, càd on inspecte le projet suivant
                string mot = reader.ReadElementContentAsString();//on dit que la valeur dans la balise MatiereProjet est un string

                //pour chaque projet, on regarde si dans la liste des matières, matiere == mot
                if (mot == matiere)
                {
                    //si oui, on récupère le projet et on range tous ses attributs dans un objet de la classe Projet
                    //on fait une liste pour y ranger les projets
                    projetsTrouves.Add(Catalogue_projets[i]);
                }
                i++;
                //retourner quelque chose si jamais il trouve pas
                //ou alors ne proposerque des matières pour lesquelles on trouve un projet en fait, c'est plus intelligent mdr
            }
            return projetsTrouves;
        }

    
        //Ci dessous plusieurs méthodes pour récupérer le projet à renvoyer (je les laisse au cas où)

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


        ////Autre essai : désérialisation
        //List<Projet> Catalogue_projets = new List<Projet>();
        //XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>)); //ne marche pas car la classe projet doit être public, mais non ça nous arrange pas
        //StreamReader sr = new StreamReader("Catalogue_projets.xml");

        //Catalogue_projets = (List<Projet>)serializer.Deserialize(sr);
        //sr.Close();

        //Projet p = Catalogue_projets[i];
        //Console.WriteLine(p);

        //return p;



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


        //public override Projet CritAnnee(object critannee)
        ////implémentation de l'interface pour trouver une année
        //{
        //    string annee = critannee as string;
        //    if (AnneeProjet == critannee as string) //on double le cast avec as, parce que sinon on fait ue comparaison de références et pas de types
        //    {
        //        return this;
        //    }
        //    //trouver comment retourner un message d'erreur
        //}


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
