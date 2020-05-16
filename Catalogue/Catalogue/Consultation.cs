using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; //Pour utiliser XmlReader

namespace Catalogue
{
    class Consultation
    {
        public void AffinerLaRecherche()
        {
            Console.Clear();
            Console.WriteLine("Entrez le numéro correspondant à votre critère de recherche : \n" +
                "1. Par projet\n" + //OK INTERFACE
                "2. Par matière\n" + //OK INTERFACE
                "3. Par intervenant\n" + 
                "4. Par type de livrable\n" +
                "5. Par année\n"); //OK INTERFACE
            int num = int.Parse(Console.ReadLine());
            Console.Clear();

            XmlReader reader = XmlReader.Create("Catalogue_projets.xml"); //déclaration du XmlReader
            List<string> listeAffichage = new List<string>();

            Projet p = new Projet(); //Pour pouvoir utiliser CompteNoeuds(), à voir si on laisse comme ça

            if (num == 1) //Si la recherche se fait par projet
            {
                int j = 0;

                //Recherche de tous les noms de projets possibles
                while (j < p.CompteNoeuds("Projet")) 
                {
                    bool dejaAffiche = false;
                    reader.ReadToFollowing("NomProjet"); 
                    string nom = reader.ReadElementContentAsString();
                    foreach(string element in listeAffichage) 
                        //on vérifie si le nom rencontré n'a pas déjà été rencontré
                        //j'ai donc fait l'hypothèse que 2 projets peuvent avoir le même nom, c'est peut-être débile x)
                    {
                        if(element == nom)
                        {
                            dejaAffiche = true; //le nom a déjà été entré dans la liste de choses à afficher 
                        }
                    }
                    if (!dejaAffiche) //si le nom n'a jamais été rencontré
                    {
                        listeAffichage.Add(nom); //on l'ajoute dans la liste des choses à afficher
                    }
                    j++;
                }

                //Affichage de tous les noms de projets
                Console.WriteLine("=========== Recherche par projet ===========\n");
                Console.WriteLine("Entrez le nom du projet recherché pour obtenir plus de détails : \n");
                int i = 1;
                foreach (string element in listeAffichage)
                {
                    Console.WriteLine(i + ". " + element);
                    i++;
                }
                Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit le projet dont il veut plus de détails
                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else Console.WriteLine(listeAffichage[num2 - 1]); //pour les tests, je laisse le return en commentaire
                //return listeAffichage[num2 - 1]; //Retourne donc un string -> les méthodes Crit prennent donc un string en entrée ?

            // PREVOIR DES MESSAGES D'ERRREUR SI ON ENTRE PAS LE BON TRUC 
            }

            if (num == 2)
            {
                //afficher l'ensemble des matières pour lesquelles on a des projets (+ 1 ou on en a pas pour les messages d'erreur)
                //l'utilisateur devra à nouveau taper un chiffre pour sélectionner la matière
                //C'est l'interface qui prend le reste en main avec une méthode pour sortir les projets par matière
                int j = 0;

                //Recherche de toutes les matières possibles
                while (j < p.CompteNoeuds("NomMat")) 
                {
                    bool dejaAffiche = false;
                    reader.ReadToFollowing("NomMat");
                    string mat = reader.ReadElementContentAsString();
                    foreach (string element in listeAffichage)
                    //on vérifie si la matière rencontrée n'a pas déjà été rencontrée
                    {
                        if (element == mat)
                        {
                            dejaAffiche = true; //la matière a déjà été entrée dans la liste de choses à afficher 
                        }
                    }
                    if (!dejaAffiche) //si l'année n'a jamais été rencontrée
                    {
                        listeAffichage.Add(mat); //on l'ajoute dans la liste des choses à afficher
                    }
                    j++;
                }

                //Affichage de toutes les matières
                Console.WriteLine("=========== Recherche par matière ===========\n");
                Console.WriteLine("Entrez le numéro de la matière recherchée pour obtenir les projets associés : \n");
                int i = 1;
                foreach (string element in listeAffichage)
                {
                    Console.WriteLine(i + ". " + element);
                    i++;
                }
                Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit le projet dont il veut plus de détails
                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else Console.WriteLine(listeAffichage[num2 - 1]); //pour les tests, je laisse le return en commentaire
                //return listeAffichage[num2 - 1];
            }

            if (num == 3)
            {
                //afficher l'ensemble des intervenants pour lesquels on a des projets (+ 1 ou on en a pas pour les messages d'erreur)
                //l'utilisateur devra à nouveau taper un chiffre pour sélectionner l'intervenant
                //C'est l'interface qui prend le reste en main avec une méthode pour sortir les projets par intervenant
                int j = 0;

                //Recherche de toutes les années possibles
                while (j < p.CompteNoeuds("NomInterv")) 
                {
                    bool dejaAffiche = false;
                    reader.ReadToFollowing("NomInterv");
                    string nom = reader.ReadElementContentAsString();
                    reader.ReadToFollowing("Prenom");
                    string prenom = reader.ReadElementContentAsString();

                    foreach (string element in listeAffichage)
                    //on vérifie si l'intervenant rencontré n'a pas déjà été ajouté à la liste d'affichage
                    {
                        if (element == nom)
                        {
                            dejaAffiche = true; //l'intervenant a déjà été entré dans la liste de choses à afficher 
                        }
                    }
                    if (!dejaAffiche) //si l'intervenant n'a jamais été rencontré
                    {
                        listeAffichage.Add(prenom); //on l'ajoute dans la liste des choses à afficher
                        listeAffichage.Add(nom);
                    }
                    j++;
                }
                //Affichage de tous les intervenants
                Console.WriteLine("=========== Recherche par intervenants ===========\n");
                Console.WriteLine("Entrez le numéro de l'intervenant recherché pour obtenir les projets associés : \n");
                int i = 1;
                for (int k=0 ; k < listeAffichage.Count ; k+=2)
                {
                    Console.WriteLine(i + ". " + listeAffichage[k] + " " + listeAffichage[k+1]); //affichage du prénom et du nom
                    i++;
                }
                Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit le projet dont il veut plus de détails
                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else Console.WriteLine(listeAffichage[num2 - 1]); //pour les tests, je laisse le return en commentaire
                //return listeAffichage[num2 - 1];
            }

            if (num == 4)
            {
                //afficher l'ensemble des livrables pour lesquels on a des projets (+ 1 ou on en a pas pour les messages d'erreur)
                //l'utilisateur devra à nouveau taper un chiffre pour sélectionner le livrable
                //C'est l'interface qui prend le reste en main avec une méthode pour sortir les projets par livrable
                int j = 0;

                //Recherche de toutes les années possibles
                while (j < p.CompteNoeuds("Nature")) 
                {
                    bool dejaAffiche = false;
                    reader.ReadToFollowing("Nature");
                    string livrable = reader.ReadElementContentAsString();
                    foreach (string element in listeAffichage)
                    //on vérifie si le livrable rencontré n'a pas déjà été ajouté à la liste d'affichage
                    {
                        if (element == livrable)
                        {
                            dejaAffiche = true; //le livrable a déjà été entré dans la liste de choses à afficher 
                        }
                    }
                    if (!dejaAffiche) //si le livrable n'a jamais été rencontré
                    {
                        listeAffichage.Add(livrable); //on l'ajoute dans la liste des choses à afficher
                    }
                    j++;
                }

                //Affichage de toutes les années
                Console.WriteLine("=========== Recherche par type de livrable ===========\n");
                Console.WriteLine("Entrez le numéro de du type de livrable recherché pour obtenir les projets associés : \n");
                int i = 1;
                foreach (string element in listeAffichage)
                {
                    Console.WriteLine(i + ". " + element);
                    i++;
                }
                Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit le projet dont il veut plus de détails
                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else Console.WriteLine(listeAffichage[num2 - 1]); //pour les tests, je laisse le return en commentaire
                //return listeAffichage[num2 - 1];
            }

            if (num == 5)
            {
                int j = 0;

                //Recherche de toutes les années possibles
                while (j < p.CompteNoeuds("AnneeProjet")) 
                {
                    bool dejaAffiche = false;
                    reader.ReadToFollowing("AnneeProjet");
                    string annee = reader.ReadElementContentAsString();
                    foreach (string element in listeAffichage)
                    //on vérifie si l'année rencontrée n'a pas déjà été ajoutée à la liste d'affichage
                    {
                        if (element == annee)
                        {
                            dejaAffiche = true; //l'année a déjà été entrée dans la liste de choses à afficher 
                        }
                    }
                    if (!dejaAffiche) //si l'année n'a jamais été rencontrée
                    {
                        listeAffichage.Add(annee); //on l'ajoute dans la liste des choses à afficher
                    }
                    j++;
                }

                //Affichage de toutes les années
                Console.WriteLine("=========== Recherche par année ===========\n");
                Console.WriteLine("Entrez le numéro de l'année recherchée pour obtenir les projets associés : \n");
                int i = 1;
                foreach (string element in listeAffichage)
                {
                    Console.WriteLine(i + ". " + element);
                    i++;
                }
                Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit le projet dont il veut plus de détails
                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else Console.WriteLine(listeAffichage[num2 - 1]); //pour les tests, je laisse le return en commentaire
                //return listeAffichage[num2 - 1];
            }
        }
        public void AfficherResultat(List<Projet> projets)
        {
            Console.WriteLine("======================== Résultats de la recherche ========================\n");
            foreach(Projet p in projets)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("\n------------------------\n");
            }
        }
        public interface ITrouvable
        {
            //déclaration des méthodes de base
            Projet CritLivrable(Object critlivr);
            Projet CritMatiere(Object critmat);
            Projet CritInterv(Object critinterv);
            Projet CritAnnee(Object critannee);
        }
    }
}
