using BowlingClasses.Core.Interfaces;
using System.Linq;

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
        /// Constructeur.
        /// </summary>
        /// <param name="noms">Noms des joueurs.</param>
        public Equipe(params string[] noms)
        {
            Joueurs = noms
                .Select(nom => new Joueur(nom))
                .ToArray();
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="joueurs">Joueurs.</param>
        public Equipe(IJoueur[] joueurs)
        {
            Joueurs = joueurs;
        }

        /// <summary>
        /// Joueurs.
        /// </summary>
        public IJoueur[] Joueurs { get; private set; }
    }
}
