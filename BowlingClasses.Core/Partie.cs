using BowlingClasses.Core.Interfaces;
using System;

namespace BowlingClasses.Core
{
    public class Partie : IPartie
    {
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
        public int NoCaseCourante => throw new NotImplementedException();

        /// <summary>
        /// Ajout d'un lancer.
        /// </summary>
        /// <param name="lancer">Nombre de quilles abattues.</param>
        /// <returns>Vrai si l'opération est une réussite.</returns>
        public bool AjouterLancer(int lancer)
        {
            throw new NotImplementedException();
        }
    }
}
