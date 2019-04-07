using BowlingClasses.Core.Interfaces;

namespace BowlingClasses.Core
{
    public class Equipe : IEquipe
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="nombreJoueurs">Nombre de joueurs dans l'équipe.</param>
        public Equipe(int nombreJoueurs)
        {
            Joueurs = new IJoueur[nombreJoueurs];
        }

        /// <summary>
        /// Joueurs.
        /// </summary>
        public IJoueur[] Joueurs { get; private set; }
    }
}
