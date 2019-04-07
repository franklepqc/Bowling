using BowlingClasses.Core.Interfaces;
using System;
using System.Linq;

namespace BowlingClasses.Core
{
    public class Partie : IPartie
    {
        /// <summary>
        /// Index de case courante.
        /// </summary>
        private int _indexCaseCourante = 0;

        /// <summary>
        /// Cases du jeu.
        /// </summary>
        public ICase[] Cases { get; set; }

        /// <summary>
        /// Équipe.
        /// </summary>
        public IEquipe Equipe { get; set; }

        /// <summary>
        /// Numéro de la case courante.
        /// </summary>
        public int NoCaseCourante => _indexCaseCourante;

        /// <summary>
        /// Ajout d'un lancer.
        /// </summary>
        /// <param name="lancer">Nombre de quilles abattues.</param>
        /// <returns>Vrai si l'opération est une réussite.</returns>
        public bool AjouterLancer(int lancer)
        {
            var essais = Cases[NoCaseCourante].Essais;
            
            if (!essais[0].HasValue)
            {
                essais[0] = lancer;

                if (_indexCaseCourante < 9 && 10 == lancer)
                {
                    _indexCaseCourante++;
                }
            }
            else if (!essais[1].HasValue)
            {
                essais[1] = lancer;

                if (_indexCaseCourante < 9)
                    _indexCaseCourante++;
            }
            else if (_indexCaseCourante == 9 && essais.Length == 3 && !essais[2].HasValue)
            {
                essais[2] = lancer;
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
