using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    class Consultation
    {
        public void AffinerLaRecherche()
        {
            Console.WriteLine("Entrez le numéro correspondant à votre critère de recherche : \n" +
                "1. Par projet\n" +
                "2. Par matière\n" +
                "3. Par intervenant\n" + 
                "4. Par type de livrable\n" +
                "5. Par année\n");
            int num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                Console.WriteLine("Par matière");
            }
        }

        public interface ITrouvable
        {
            //l'interface se charge de regarder si, pour un des critères de recherche, 
            //il y a dans les projets créés un critère qui correspond. 
            //si c'est le cas, pour chaque projet, il faut que ce projet soit ciblé et
            //retenu pour être envoyé à la méthode AfficherResultat

            //déclaration de la classe de base
            Projet Critere(string attrrech, string critrech);
        }
    }
}
