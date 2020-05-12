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
                Console.WriteLine("Par projet");
            }
            if (num == 1)
            {
                //On liste tous les projets en prenant comme référence le nom de chaque projet
                //l'utilisateur devra à nouveau taper un chiffre pour sélectionner le projet
                //le projet s'affichera en entier (Méthode ToString ? Autre méthode ? Pas bsoin d'utiliser l'interface à mon avis)
            }

            if (num == 2)
            {
                Console.WriteLine("Par matière");
                //afficher l'ensemble des matières pour lesquelles on a des projets (+ 1 ou on en a pas pour les messages d'erreur)
                //l'utilisateur devra à nouveau taper un chiffre pour sélectionner la matière
                //C'est l'interface qui prend le reste en main avec une méthode pour sortir les projets par matière
            }

            if (num == 3)
            {
                //afficher l'ensemble des intervenants pour lesquels on a des projets (+ 1 ou on en a pas pour les messages d'erreur)
                //l'utilisateur devra à nouveau taper un chiffre pour sélectionner l'intervenant
                //C'est l'interface qui prend le reste en main avec une méthode pour sortir les projets par intervenant
            }

            if (num == 4)
            {
                //afficher l'ensemble des livrables pour lesquels on a des projets (+ 1 ou on en a pas pour les messages d'erreur)
                //l'utilisateur devra à nouveau taper un chiffre pour sélectionner le livrable
                //C'est l'interface qui prend le reste en main avec une méthode pour sortir les projets par livrable

            }

            if (num == 5)
            {
                //dans les projets, on a pas les années mais les semestres. Comment on fait ?
            }
        }

        public interface ITrouvable
        {
            //l'interface se charge de regarder si, pour un des critères de recherche, 
            //il y a dans les projets créés un critère qui correspond. 
            //si c'est le cas, pour chaque projet, il faut que ce projet soit ciblé et
            //retenu pour être envoyé à la méthode AfficherResultat

            //déclaration de la classe de base
            Projet CritLivrable(Object critlivr);
            Projet CritMatiere(Object critmat);
            Projet CritInterv(Object critinterv);
            Projet CritAnnee(Object critannee);
        }
    }
}
