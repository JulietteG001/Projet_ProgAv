using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; //Pour utiliser XmlReader
using System.Xml.Serialization; //Pour utiliser XmlSerializer
using System.IO; //Pour utiliser StreamReader

namespace Catalogue
{
    public class Projet : Consultation.ITrouvable //erreur ici normale tant qu'on a pas déclaré toutes les méthodes crées dans l'interface
    {
        public string NomProjet { get; set; } //Nom du projet
        public int NbEleves { get; set; } //Nombre d'élèves impliqués dans le projet
        public int Duree { get; set; } //Durée du projet en jours
        public string AnneeProjet { get; set; } //Année où s'est déroulé le projet (20XX-20XX)
        public string Semestres { get; set; } //Semestres où s'est déroulé le projet
        public string Consigne { get; set; } //Consigne brève de ce que demande le projet
        public List<Livrable> Livrables { get; set; } //Liste des livrables à fournir au terme du projet
        public Matiere MatiereProjet { get; set; } //Matière concernée par le projet

        [XmlArrayItem("Enseignant", typeof(Enseignant))] 
        [XmlArrayItem("Eleve", typeof(Eleve))]           
        [XmlArrayItem("Intervenant_externe", typeof(Intervenant_externe))]
        //Ce code signifie que le Serializer peut rencontrer ces types dérivés, qui font partie de la classe Intervenant
        public List<Intervenant> Intervenants { get; set; }  //Liste des intervenants au sein du projet (profs, externes, élèves)

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
            string chRes = "Nom : " + NomProjet + "\nNombre d'élèves: " + NbEleves + "\nDurée (en jours) : " + Duree + "\nAnnée du projet : " + AnneeProjet + "\nSemestres : " + Semestres + "\nConsigne : " + Consigne + "\n\nLivrables : ";
            foreach (Livrable l in this.Livrables) //On ajoute la liste des livrables à la chaîne
            {
                chRes += l.Nature + " | ";
            }
            chRes += "\nMatière associée : " + MatiereProjet.ToString() + "\n\nIntervenants : ";
            foreach (Intervenant i in this.Intervenants) //On ajoute la liste des intervenants à la chaîne
            {
                chRes += i.ToString() + " | ";
            }
            chRes += "\n _______________________________________________________________ \n";
            return chRes;
        }

        public int CompteNoeuds(string nomNoeud)
        //compte le nb de noeuds du même nom contenus dans le dossier XML
        {
            int nbNoeuds = 0; //stocke le nombre de noeuds trouvés

            XmlDocument docRef = new XmlDocument(); //on crée un objet XmlDocument
            docRef.Load("Catalogue_projets.xml"); //on lui attribue notre document XML

            XmlElement nomCherche = docRef.DocumentElement; //L'élément nomCherche fait partie de Catalogue_projet.xml
            XmlNodeList noeud = nomCherche.GetElementsByTagName(nomNoeud); //On compte les noeuds dont le nom correspond à celui du noeud pris en entrée
            nbNoeuds = noeud.Count;
            return nbNoeuds;
        }

        public List<Projet> Deserialiser()
        //Désérialise le contenu du fichier XML contenant les projets
        {
            //création d'une liste de projets
            List<Projet> Catalogue_projets = new List<Projet>();
            //création du serializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Projet>));
            //création du streamreader
            StreamReader sr = new StreamReader("Catalogue_projets.xml");

            //on désérialise le contenu du XML dans la liste des projets
            Catalogue_projets = (List<Projet>)serializer.Deserialize(sr);
            sr.Close();
            //on retourne tous les projets extraits
            return Catalogue_projets;
        }

        public List<Projet> CritProjet(object critProj)
        //implémentation de l'interface pour trouver tous les projets
        {
            List<Projet> Catalogue_projets = this.Deserialiser();//Désérialisation de notre fichier xml contenant les projets
            XmlReader reader = XmlReader.Create("Catalogue_projets.xml"); //déclaration du xmlReader

            string nomProjet = critProj as string;
            int i = 0; //compteur 
            List<Projet> projetsTrouvesProj = new List<Projet>(); //liste qui contiendra nos résultats

            //Recherche du ou des projets concerné(s) par le critère
            while (i < CompteNoeuds("Projet")) //tant qu'on a pas regardé tous les projets
            {
                reader.ReadToFollowing("NomProjet"); //On passe à la balise "NomProjet" suivante, càd on inspecte le projet suivant
                string mot = reader.ReadElementContentAsString();//on dit que la valeur dans la balise NomProjet est un string

                if (mot == nomProjet)
                {
                    //si oui, on récupère le projet et on range tous ses attributs dans un objet de la classe Projet
                    projetsTrouvesProj.Add(Catalogue_projets[i]);
                }
                i++;
            }
            return projetsTrouvesProj;
        }

        public List<Projet> CritLivrable(object critlivr)
        //implémentation de l'interface pour trouver un type de livrable
        {
            List<Projet> Catalogue_projets = this.Deserialiser();
            XmlReader reader = XmlReader.Create("Catalogue_projets.xml");

            string livrable = critlivr as string;
            int i = 0; //compteur
            int j = 0; //compteur
            int numProj = 0;
            List<Projet> projetsTrouvesLivr = new List<Projet>(); //liste qui contiendra nos résultats
            
            //Recherche du ou des projets concerné(s) par le critère
            while (j < CompteNoeuds("Nature")) 
            {
                reader.ReadToFollowing("Nature"); //On passe à la balise "Nature" suivante ou on inspecte le projet suivant

                string mot = reader.ReadElementContentAsString(); Console.WriteLine(mot);Console.WriteLine("j" + j);
                //pour chaque projet, on regarde si dans la liste des livrables, livrable == mot
                if (mot == livrable)
                {
                    //si oui, on récupère le projet et on range tous ses attributs dans un objet de la classe Projet
                    //projetsTrouvesLivr.Add(Catalogue_projets[numProj]); //quand on a décommenté la boucle, remplacer par j ?
                Console.WriteLine(numProj); Console.WriteLine("Projet ajouté !"); //test de fonctionnement, à supprimer
                }
                i++;
                if (i > 4)
                {
                    numProj++;
                }
                j++;
            }
            return projetsTrouvesLivr;
        }

        public List<Projet> CritMatiere(object critmat)
        //implémentation de l'interface pour trouver une matière
        {
            List<Projet> Catalogue_projets = this.Deserialiser();
            XmlReader reader = XmlReader.Create("Catalogue_projets.xml");

            string matiere = critmat as string;
            int i = 0; //compteur 
            List<Projet> projetsTrouvesMat = new List<Projet>(); //liste qui contiendra nos résultats
            
            //Recherche du ou des projets concerné(s) par le critère
            while (i < CompteNoeuds("Projet"))
            {
                reader.ReadToFollowing("NomMat"); //On passe à la balise "matiere" suivante, càd on inspecte le projet suivant
                string mot = reader.ReadElementContentAsString();

                //pour chaque projet, on regarde si dans la liste des matières, matiere == mot
                if (mot == matiere)
                {
                    //si oui, on récupère le projet et on range tous ses attributs dans un objet de la classe Projet
                    projetsTrouvesMat.Add(Catalogue_projets[i]);
                }
                i++;
            }
            return projetsTrouvesMat;
        }

        public List<Projet> CritAnnee(object critannee)
        //implémentation de l'interface pour trouver une annee
        {
            List<Projet> Catalogue_projets = this.Deserialiser();
            XmlReader reader = XmlReader.Create("Catalogue_projets.xml");

            string annee = critannee as string;
            int i = 0; //compteur 
            List<Projet> projetsTrouvesAnnee = new List<Projet>(); //liste qui contiendra nos résultats

            //Recherche du ou des projets concerné(s) par le critère
            while (i < CompteNoeuds("Projet"))
            {
                reader.ReadToFollowing("AnneeProjet"); //On passe à la balise "AnneeProjet" suivante, càd on inspecte le projet suivant
                string mot = reader.ReadElementContentAsString();

                //pour chaque projet, on regarde si dans la liste des années, annee == mot
                if (mot == annee)
                {
                    //si oui, on récupère le projet et on range tous ses attributs dans un objet de la classe Projet
                    projetsTrouvesAnnee.Add(Catalogue_projets[i]);
                }
                i++;
            }
            return projetsTrouvesAnnee;
        }

        public List<Projet> CritIntervenant(object critInterv)
        //implémentation de l'interface pour trouver un type de livrable
        {
            List<Projet> Catalogue_projets = this.Deserialiser();
            XmlReader reader = XmlReader.Create("Catalogue_projets.xml");

            string intervenant = critInterv as string;
            int i = 0; //compteur
            List<Projet> projetsTrouvesInterv = new List<Projet>(); //liste qui contiendra nos résultats

            //Recherche du ou des projets concerné(s) par le critère
            while (i < CompteNoeuds("Projet"))
            {
                reader.ReadToFollowing("NomInterv"); //On passe à la balise "NomInterv" suivante ou on inspecte le projet suivant
                //reader.ReadToFollowing("Intervenant");

                string mot = reader.ReadElementContentAsString();
                //pour chaque projet, on regarde si dans la liste des intervenants, intervenant == mot
                if (mot == intervenant)
                {
                    //si oui, on récupère le projet et on range tous ses attributs dans un objet de la classe Projet
                    projetsTrouvesInterv.Add(Catalogue_projets[i]);
                    //Console.WriteLine(Catalogue_projets[i].Intervenants[0]);
                    Console.WriteLine("Projet ajouté !"); //test de fonctionnement, à supprimer
                }
                i++;
            }
            return projetsTrouvesInterv;
        }

        //public int CompteProjets()
        ////compte le nb de projets contenus dans le dossier XML via désérialisation
        //{
        //    int nbProjets = 0; 
        //    List<Projet> Catalogue_projets = this.Deserialiser();//Désérialisation de notre fichier xml contenant les projets
        //    nbProjets = Catalogue_projets.Count;
        //    return nbProjets;
        //}










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
