﻿using BowlingClasses.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BowlingClasses.Core
{
    /// <summary>
    /// Représentation d'une partie de bowling.
    /// </summary>
    public class Partie : IPartie
    {
        /// <summary>
        /// Service de calcul.
        /// </summary>
        private readonly IServiceCalculScore _serviceCalculScore;

        /// <summary>
        /// Constructeur par injection.
        /// </summary>
        /// <param name="serviceCalculScore">Calculateur de score.</param>
        public Partie(IServiceCalculScore serviceCalculScore)
        {
            _serviceCalculScore = serviceCalculScore;
        }

        /// <summary>
        /// Cases du jeu.
        /// </summary>
        public ICase[][] Cases { get; set; }

        /// <summary>
        /// Équipe.
        /// </summary>
        public IEquipe Equipe { get; set; }

        /// <summary>
        /// Index de la case à jouer.
        /// </summary>
        public int IndexCase { get; private set; }

        /// <summary>
        /// Index du joueur.
        /// </summary>
        public int IndexJoueur { get; private set; }

        /// <summary>
        /// Ajout d'un lancer.
        /// </summary>
        /// <param name="lancer">Nombre de quilles abattues.</param>
        /// <returns>Vrai si l'opération est une réussite.</returns>
        public bool AjouterLancer(int lancer, int? ixJoueur = null, int? ixCase = null)
        {
            // Variables de travail.
            var indexJoueur = (ixJoueur ?? IndexJoueur);
            var indexCase = (ixCase ?? IndexCase);

            if (indexJoueur < Equipe.Joueurs.Length && indexCase < 10)
            {
                // Récupération de la case de jeu.
                var caseJeu = Cases[indexJoueur][indexCase];

                // Ajout du score.
                caseJeu.AjouterEssai(lancer);

                // Si la case est terminée, passer au suivant !
                if (caseJeu.EstTerminee)
                {
                    // Recalculer les scores.
                    CalculerScores(Cases[indexJoueur].Take(indexCase + 1).ToList());

                    // Passe au joueur suivant.
                    Suivant();
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculer les scores rétrospectivement.
        /// </summary>
        /// <param name="cases">Cases.</param>
        private void CalculerScores(List<ICase> cases)
        {
            cases
                .ForEach(caseJeu => 
                    caseJeu.Score = _serviceCalculScore
                        .Calculer(
                            cases.SelectMany(k => k.Essais.Where(p => p.HasValue).Select(p => p.Value)).ToArray(),
                            cases.IndexOf(caseJeu) + 1));
        }

        /// <summary>
        /// Passe au suivant. Si les joueurs ont tous joué, on va au prochain carreau.
        /// </summary>
        private void Suivant()
        {
            // Si tous les joueurs ont joué.
            if (++IndexJoueur >= Equipe.Joueurs.Length)
            {
                IndexJoueur = 0;
                IndexCase++;
            }
        }
    }
}
