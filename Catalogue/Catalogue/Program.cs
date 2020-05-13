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
            //consultation.AffinerLaRecherche();

            Projet p = new Projet();
            //Console.WriteLine(p.CritMatiere("test").ToString());
            List<Projet> ps = new List<Projet>();
            ps = p.CritLivrable("Code source");

            foreach (Projet s in ps) //Pour vérifier ce que contient la liste renvoyée par CriMatiere pendant les tests
            {
                //Console.WriteLine(s.ToString());
                foreach (Livrable l in s.Livrables) //Pour regarder ce que contient la liste de livrables de chaque projet
                {
                    Console.WriteLine(l.ToString());
                }
            }
            
            Console.ReadLine();
        }
    }
}
