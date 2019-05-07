using BowlingClasses.Core.Interfaces;
using System.Linq;

namespace BowlingClasses.Core
{
    /// <summary>
    /// Service pour calculer le score total.
    /// </summary>
    public class ServiceCalculScore : IServiceCalculScore
    {
        /// <summary>
        /// Service de validation.
        /// </summary>
        private readonly IServiceValidation _serviceValidation;

        /// <summary>
        /// Constructeur par injection.
        /// </summary>
        /// <param name="serviceValidation">Service de validation.</param>
        public ServiceCalculScore(IServiceValidation serviceValidation)
        {
            _serviceValidation = serviceValidation;
        }

        /// <summary>
        /// Permet de calculer le score final jusqu'à la case courante.
        /// </summary>
        /// <param name="cases">Cases avec toutes les quilles abattues.</param>
        /// <param name="noCaseCourante">N° de case. Par défaut 10, calculer le tout.</param>
        /// <returns>Score.</returns>
        public int Calculer(ICase[] cases, int noCaseCourante = 10)
        {
            // Vérification des cases.
            // Si le tout n'est pas valide, retourner zéro.
            if (!_serviceValidation.Valider(cases)) return 0;

            // Variables de travail.
            int indexLancer = 0;
            var lancers = cases.SelectMany(
                    caseJeu => caseJeu.Essais.Where(essai => essai.HasValue).Select(essai => essai.Value))
                .ToArray();

            // Sélection des cases.
            var tableau = cases
                .Take(noCaseCourante)       // Prendre le nombre demandé.
                                            // Calcul pour chaque case.
                .Select(nombre => TraiterCase(lancers, ref indexLancer))
                .ToArray();

            // Calculer la somme.
            return tableau.Sum();
        }

        /// <summary>
        /// Traiter seulement qu'une case.
        /// </summary>
        /// <param name="lancers">Lancers.</param>
        /// <param name="indexLancer">Index du lancer.</param>
        /// <returns>Score de la case.</returns>
        private int TraiterCase(int[] lancers, ref int indexLancer)
        {
            // Variables.
            int resultat = 0;

            // Constantes.
            const int NOMBRE_QUILLES_TOTAL = 10;

            // Premier lancer.
            int premierLancer = ObtenirLancer(lancers, indexLancer);

            // Cas d'un abat.
            if (premierLancer == NOMBRE_QUILLES_TOTAL)
            {
                resultat = premierLancer +
                    ObtenirLancer(lancers, indexLancer + 1) +
                    ObtenirLancer(lancers, indexLancer + 2);

                indexLancer++;
            }
            // L'abat est écarté, on doit procéder avec l'autre essai.
            else
            {
                // Deuxième lancer.
                int deuxiemeLancer = ObtenirLancer(lancers, indexLancer + 1);

                // Vérification d'une réserve.
                if (premierLancer + deuxiemeLancer == NOMBRE_QUILLES_TOTAL)
                {
                    resultat = premierLancer + deuxiemeLancer + ObtenirLancer(lancers, indexLancer + 2);
                }
                // Aucun abat, aucune réserve. On ne fait qu'additionner le nombre
                // de quilles abattues.
                else
                {
                    resultat = premierLancer + deuxiemeLancer;
                }

                indexLancer += 2;
            }

            return resultat;
        }

        /// <summary>
        /// Obtenir le lancer tout en vérifiant qu'on ne sorte pas du tableau.
        /// </summary>
        /// <param name="lancers">Tous les lancers.</param>
        /// <param name="index">Position visée.</param>
        /// <returns>Lancer, sinon 0.</returns>
        private int ObtenirLancer(int[] lancers, int index)
        {
            if (index >= lancers.Length) return 0;
            return lancers[index];
        }
    }
}