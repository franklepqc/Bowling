using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BowlingClasses.Core.Interfaces;

namespace BowlingClasses.Core
{
    /// <summary>
    /// Implémentation du service pour une partie jouée d'avance.
    /// </summary>
    public class ServicePreJoue : IServicePreJoue
    {
        /// <summary>
        /// Lecteur.
        /// </summary>
        private readonly ILecteur _lecteur;

        /// <summary>
        /// Constructeur par injection.
        /// </summary>
        /// <param name="lecteur">Lecteur d'un fichier / des données.</param>
        public ServicePreJoue(ILecteur lecteur)
        {
            _lecteur = lecteur;
        }

        /// <summary>
        /// Entrer le score à la partie.
        /// </summary>
        /// <param name="lecture">Lecture du fichier.</param>
        /// <param name="partie">Partie en cours.</param>
        /// <param name="indexJoueur">N° du joueur.</param>
        /// <returns>Vrai si l'opération est une réussite.</returns>
        public bool EntrerScore(Stream lecture, IPartie partie, int indexJoueur)
        {
            // Variables.
            var donnees = _lecteur.Lire(lecture);

            foreach (var lancer in donnees)
            {
                if (!partie.AjouterLancer(lancer, indexJoueur))
                {
                    // Revert.
                    var casesJoueur = partie.Cases[indexJoueur];
                    for (int noCase = 0; noCase < casesJoueur.Length; noCase++)
                    {
                        var essais = casesJoueur[noCase].Essais;
                        for (int noEssai = 0; noEssai < essais.Length; noEssai++)
                        {
                            essais[noEssai] = new int?();
                        }
                    }

                    return false;
                }
            }

            return true;
        }
    }
}
