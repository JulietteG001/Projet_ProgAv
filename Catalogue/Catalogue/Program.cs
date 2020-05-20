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
            consultation.AfficherResultat(consultation.AffinerLaRecherche());
            Console.ReadLine();
        }
    }
}
