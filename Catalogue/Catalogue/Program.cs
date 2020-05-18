using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lancement de la consultation du catalogue
            //Consultation consultation = new Consultation();
            //consultation.AffinerLaRecherche();


            Projet p = new Projet();
            List<Projet> ps = new List<Projet>();

            //ps = p.CritIntervenant("Favier");
            //ps = p.CritMatiere("Introduction à la programmation");
            //ps = p.CritMatiere("Intelligence Artificielle");
            //ps = p.CritAnnee("2019-2020");
            ps = p.CritLivrable("Code source");
            //consultation.AfficherResultat(ps);

            //ps = p.CritProjet("Projet Blackout");
            //ps = p.CritLivrable("Rapport");

            foreach (Projet s in ps) //Pour vérifier ce que contient la liste renvoyée pendant les tests
            {
                Console.WriteLine(s);
            }

            //Console.WriteLine(p.CompteNoeuds("Projet"));

            //AFFICHAGE DES INTERVENANTS

            //foreach (Projet s in ps) //Pour vérifier ce que contient la liste renvoyée pendant les tests
            //{
            //    foreach (Intervenant i in s.Intervenants) //Pour regarder ce que contient la liste d'intervenants de chaque projet
            //    {
            //        Console.WriteLine("Nom : " + i.NomInterv.ToString());
            //    }
            //}
            Console.ReadLine();
        }
    }
}
