using BowlingClasses.Core.Interfaces;
using System;

namespace BowlingClasses.Core
{
    public class ServiceCreationPartie : IServiceCreationPartie
    {
        /// <summary>
        /// Créer la partie avec le nombre de joueurs.
        /// </summary>
        /// <param name="nombreJoueurs">Nombre de joueurs.</param>
        /// <returns>Partie.</returns>
        public IPartie Creer(int nombreJoueurs)
        {
            // Variable de retour.
            var partie = new Partie();

            // Assignation des joueurs.
            partie.Equipe = new Equipe(nombreJoueurs);
            for (int i = 1; i <= nombreJoueurs; i++)
            {
                partie.Equipe.Joueurs[i - 1] = new Joueur($"Joueur {i}");
            }

            // Création des cases.
            CreerCases(partie);

            return partie;
        }

        /// <summary>
        /// Créer les cases pour la partie.
        /// </summary>
        /// <param name="partie">Partie.</param>
        private void CreerCases(Partie partie)
        {
            partie.Cases = new ICase[10];
            for (int i = 0; i < 9; i++)
            {
                partie.Cases[i] = new CaseJeu(2);
            }
            partie.Cases[9] = new CaseJeu(3);
        }

        /// <summary>
        /// Créer la partie selon l'équipe.
        /// </summary>
        /// <param name="equipe">Équipe.</param>
        /// <returns>Partie.</returns>
        public IPartie Creer(IEquipe equipe)
        {
            // Variable de retour.
            var partie = new Partie();

            // Assignation des joueurs.
            partie.Equipe = equipe;

            // Création des cases.
            CreerCases(partie);

            return partie;
        }

        /// <summary>
        /// Créer la partie selon les noms des joueurs.
        /// </summary>
        /// <param name="nomsJoueurs">Noms des joueurs.</param>
        /// <returns>Partie.</returns>
        public IPartie Creer(params string[] nomsJoueurs)
        {
            // Variable de retour.
            var partie = new Partie();

            // Assignation des joueurs.
            partie.Equipe = new Equipe(nomsJoueurs.Length);
            for (int i = 0; i < nomsJoueurs.Length; i++)
            {
                partie.Equipe.Joueurs[i] = new Joueur(nomsJoueurs[i]);
            }

            // Création des cases.
            CreerCases(partie);

            return partie;
        }
    }
}
