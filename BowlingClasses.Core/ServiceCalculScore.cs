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
        public int? Calculer(ICase[] cases, int noCaseCourante = 10)
        {
            // Vérification des cases.
            // Si le tout n'est pas valide, retourner zéro.
            if (!_serviceValidation.Valider(cases)) return 0;

            // Variables.
            int resultat = 0;
            int indexLancer = 0;
            int premierLancer = 0,
                deuxiemeLancer = 0,
                troisiemeLancer = 0;
            var lancers = cases.SelectMany(
                    caseJeu => caseJeu.Essais.Where(essai => essai.HasValue).Select(essai => essai.Value))
                .ToArray();

            // Constantes.
            const int NOMBRE_QUILLES_TOTAL = 10;

            // Itération en cours.
            for (int noCase = 1; noCase <= noCaseCourante; noCase++)
            {
                // Premier lancer.
                if (!ObtenirLancer(lancers, indexLancer, out premierLancer)) return null;

                // Cas d'un abat.
                if (premierLancer == NOMBRE_QUILLES_TOTAL)
                {
                    // Obtenir les lancers 2 et 3.
                    if (!ObtenirLancer(lancers, indexLancer + 1, out deuxiemeLancer)) return null;
                    if (!ObtenirLancer(lancers, indexLancer + 2, out troisiemeLancer)) return null;

                    resultat += premierLancer +
                        deuxiemeLancer +
                        troisiemeLancer;

                    indexLancer++;
                }
                // L'abat est écarté, on doit procéder avec l'autre essai.
                else
                {
                    // Deuxième lancer.
                    if (!ObtenirLancer(lancers, indexLancer + 1, out deuxiemeLancer)) return null;

                    // Vérification d'une réserve.
                    if (premierLancer + deuxiemeLancer == NOMBRE_QUILLES_TOTAL)
                    {
                        if (!ObtenirLancer(lancers, indexLancer + 2, out troisiemeLancer)) return null;
                        resultat += premierLancer + deuxiemeLancer + troisiemeLancer;
                    }
                    // Aucun abat, aucune réserve. On ne fait qu'additionner le nombre
                    // de quilles abattues.
                    else
                    {
                        resultat += premierLancer + deuxiemeLancer;
                    }

                    indexLancer += 2;
                }
            }

            return resultat;
        }

        /// <summary>
        /// Obtenir le lancer tout en vérifiant qu'on ne sorte pas du tableau.
        /// </summary>
        /// <param name="lancers">Tous les lancers.</param>
        /// <param name="index">Position visée.</param>
        /// <param name="lancer">Sortie. Résultat du "TryGet".</param>
        /// <returns>Vrai si la valeur a pu être retrouvée.</returns>
        private bool ObtenirLancer(int[] lancers, int index, out int lancer)
        {
            // Variables de travail.
            lancer = 0;

            // Index en dehors des limites.
            if (index < 0 || index >= lancers.Length)
            {
                return false;
            }

            // Assignation.
            lancer = lancers[index];
            return true;
        }
    }
}