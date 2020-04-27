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
            Console.ReadLine();
        }
    }
}
