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
        public List<Projet> AffinerLaRecherche()
        //permet à l'utilisateur de chercher un projet selon différents critères
        {
            Console.Clear(); //permet de vider l'interface
            Console.WriteLine("##################### Catalogue des projets menés à l'ENSC #####################\n\n");
            Console.WriteLine("Entrez le numéro correspondant à votre critère de recherche : \n" +
                "1. Par projet\n" +
                "2. Par matière\n" +
                "3. Par intervenant\n" + 
                "4. Par type de livrable\n" +
                "5. Par année\n");
            int num = int.Parse(Console.ReadLine());

            while(num<1 || num>5) //Car 5 critères de recherche possibles
            //tant que l'utilisateur n'entre pas une valeur correcte, on réitère la demande
            {
                Console.Clear();
                Console.WriteLine("Veuillez entrer une valeur correspondant à un critère de recherche !");
                Console.WriteLine("Entrez le numéro correspondant à votre critère de recherche : \n" +
               "1. Par projet\n" +
               "2. Par matière\n" +
               "3. Par intervenant\n" +
               "4. Par type de livrable\n" +
               "5. Par année\n");
                num = int.Parse(Console.ReadLine());
            }
            Console.Clear();

            XmlReader reader = XmlReader.Create("Catalogue_projets.xml"); //déclaration du XmlReader
            List<string> listeAffichage = new List<string>();

            Projet p = new Projet(); //Pour pouvoir utiliser CompteNoeuds(), à voir si on laisse comme ça
            List<Projet> resultat = new List<Projet>();
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
                    //Hypothèse : 2 projets peuvent avoir le même nom
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
                Console.WriteLine("Entrez le numéro du projet recherché pour obtenir plus de détails : \n");
                int i = 1;
                foreach (string element in listeAffichage)
                {
                    Console.WriteLine(i + ". " + element);
                    i++;
                }
                Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit le projet dont il veut plus de détails

                while (num2 < 1 || num2 > listeAffichage.Count + 1)//on ajoute 1 pour tenir compte de l'option de retour
                //tant que l'utilisateur n'entre pas une valeur correcte, on réitère la demande
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer une valeur correspondant à un projet !");
                    Console.WriteLine("=========== Recherche par projet ===========\n");
                    Console.WriteLine("Entrez le numéro du projet recherché pour obtenir plus de détails : \n");
                    i = 1;
                    foreach (string element in listeAffichage)
                    {
                        Console.WriteLine(i + ". " + element);
                        i++;
                    }
                    Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                    num2 = int.Parse(Console.ReadLine());
                }

                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else resultat = p.CritProjet(listeAffichage[num2 - 1]);
                
            }

            if (num == 2) //Recherche par matière
            {
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
                    if (!dejaAffiche) //si la matière n'a jamais été rencontrée
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
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit la matière

                while (num2 < 1 || num2 > listeAffichage.Count + 1)
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer une valeur correspondant à une matière !");
                    Console.WriteLine("=========== Recherche par matière ===========\n");
                    Console.WriteLine("Entrez le numéro de la matière recherchée pour obtenir les projets associés : \n");
                    i = 1;
                    foreach (string element in listeAffichage)
                    {
                        Console.WriteLine(i + ". " + element);
                        i++;
                    }
                    Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                    num2 = int.Parse(Console.ReadLine());
                }

                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else resultat = p.CritMatiere(listeAffichage[num2 - 1]);
            }

            if (num == 3) //Recherche par intervenant
            {
                int j = 0;

                //Recherche de tous les intervenants
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
                    if (!dejaAffiche && nom!="") //si l'intervenant n'a jamais été rencontré
                    {
                        listeAffichage.Add(prenom); //on l'ajoute dans la liste des choses à afficher
                        listeAffichage.Add(nom);
                    }
                    j++;
                }
                //Affichage de tous les intervenants
                Console.WriteLine("=========== Recherche par intervenant ===========\n");
                Console.WriteLine("Entrez le numéro de l'intervenant recherché pour obtenir les projets associés : \n");
                int i = 1;
                for (int k=0 ; k < listeAffichage.Count ; k+=2)
                {
                    Console.WriteLine(i + ". " + listeAffichage[k] + " " + listeAffichage[k+1]); //affichage du prénom et du nom
                    i++;
                }
                Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit l'intervenant

                while (num2 < 1 || num2 > listeAffichage.Count +2)
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer une valeur correspondant à un intervenant !");
                    Console.WriteLine("=========== Recherche par intervenant ===========\n");
                    Console.WriteLine("Entrez le numéro de l'intervenant recherché pour obtenir les projets associés : \n");
                    i = 1;
                    for (int k = 0; k < listeAffichage.Count; k += 2)
                    {
                        Console.WriteLine(i + ". " + listeAffichage[k] + " " + listeAffichage[k + 1]); //affichage du prénom et du nom
                        i++;
                    }
                    Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                    num2 = int.Parse(Console.ReadLine());
                }

                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else resultat = p.CritIntervenant(listeAffichage[num2*2 - 1]);
            }

            if (num == 4) //Recherche par livrable
            {            
                int j = 0;

                //Recherche de tous les livrables possibles
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
                    if (!dejaAffiche && livrable!="") //si le livrable n'a jamais été rencontré
                    {
                        listeAffichage.Add(livrable); //on l'ajoute dans la liste des livrables à afficher
                    }
                    j++;
                }

                //Affichage de tous les livrables
                Console.WriteLine("=========== Recherche par type de livrable ===========\n");
                Console.WriteLine("Entrez le numéro de du type de livrable recherché pour obtenir les projets associés : \n");
                int i = 1;
                foreach (string element in listeAffichage)
                {
                    Console.WriteLine(i + ". " + element);
                    i++;
                }
                Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit le livrable

                while (num2 < 1 || num2 > listeAffichage.Count + 1)
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer une valeur correspondant à un livrable !");
                    Console.WriteLine("=========== Recherche par livrable ===========\n");
                    Console.WriteLine("Entrez le numéro du livrable recherché pour obtenir les projets associés : \n");
                    i = 1;
                    foreach (string element in listeAffichage)
                    {
                        Console.WriteLine(i + ". " + element);
                        i++;
                    }
                    Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                    num2 = int.Parse(Console.ReadLine());
                }

                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else resultat = p.CritLivrable(listeAffichage[num2 - 1]);
            }

            if (num == 5) //Recherche par année
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
                int num2 = int.Parse(Console.ReadLine()); //l'utilisateur choisit l'année

                while (num2 < 1 || num2 > listeAffichage.Count + 1)
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer une valeur correspondant à une année !");
                    Console.WriteLine("=========== Recherche par année ===========\n");
                    Console.WriteLine("Entrez le numéro de l'année recherchée pour obtenir plus de détails : \n");
                    i = 1;
                    foreach (string element in listeAffichage)
                    {
                        Console.WriteLine(i + ". " + element);
                        i++;
                    }
                    Console.WriteLine("\n" + i + ". Retour à l'écran d'accueil");
                    num2 = int.Parse(Console.ReadLine());
                }

                if (num2 == i)
                {
                    AffinerLaRecherche();
                }
                else resultat = p.CritAnnee(listeAffichage[num2 - 1]);
            }
            return resultat;
        }
        public void AfficherResultat(List<Projet> projets)
        {
            Console.Clear();
            Console.WriteLine("======================== Résultats de la recherche ========================\n");
            foreach(Projet p in projets)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("\n _______________________________________________________________ \n");
            }
        }
        public interface ITrouvable
        {
            //déclaration des méthodes de base
            List<Projet> CritProjet(Object critProj);
            List<Projet> CritLivrable(Object critlivr);
            List<Projet> CritMatiere(Object critmat);
            List<Projet> CritIntervenant(Object critinterv);
            List<Projet> CritAnnee(Object critannee);
        }
    }
}
