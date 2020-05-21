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
            Consultation consultation = new Consultation();
            int retourMenu = 0;
            do
            {
                Console.Clear();
                consultation.AfficherResultat(consultation.AffinerLaRecherche());
                Console.WriteLine("1. Retour au menu principal");
                retourMenu = int.Parse(Console.ReadLine());
            }
            while (retourMenu==1);
            Console.ReadLine();
        }
    }
}
