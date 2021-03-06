﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    class Intervenant_externe : Intervenant
    {
        public List<Matiere> Matiere_intervention { get; set; }
        private string Descr_intervenant { get; set; }

        public Intervenant_externe(List<Matiere> liste_matieres, string _descr_inter) : base()
        {
            Matiere_intervention = liste_matieres;
            Descr_intervenant = _descr_inter;
        }

        public override string ToString()
        {
            string chRes = base.ToString() + "Matière(s) d'intervention : " + Matiere_intervention;
            return chRes;
        }
    }
}
