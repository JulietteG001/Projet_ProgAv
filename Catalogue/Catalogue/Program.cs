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
            Consultation consultation = new Consultation();
            consultation.AffinerLaRecherche();

            Projet p = new Projet();
            
            List<Projet> ps = new List<Projet>();


            //ps = p.CritLivrable("Code source");
            //ps = p.CritAnnee("2019-2020");
            //consultation.AfficherResultat(ps);

            //ps = p.CritProjet("Projet Blackout");
            //ps = p.CritLivrable("Rapport");

            //AFFICHAGE DES LIVRABLES

            foreach (Projet s in ps) //Pour vérifier ce que contient la liste renvoyée par CritMatiere pendant les tests
            {
                foreach (Livrable l in s.Livrables) //Pour regarder ce que contient la liste de livrables de chaque projet
                {
                    //Console.WriteLine(l.Nature.ToString());
                }
               //Console.WriteLine(s);
            }

            Console.ReadLine();
        }
    }
}
