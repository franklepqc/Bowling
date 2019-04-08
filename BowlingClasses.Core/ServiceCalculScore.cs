using BowlingClasses.Core.Interfaces;

namespace BowlingClasses.Core
{
    /// <summary>
    /// Service pour calculer le score total.
    /// </summary>
    public class ServiceCalculScore : IServiceCalculScore
    {
        /// <summary>
        /// Permet de calculer le score final jusqu'à la case courante.
        /// </summary>
        /// <param name="lancers">Tableau de toutes les quilles abattues.</param>
        /// <param name="noCaseCourante">N° de case. Par défaut 10, calculer le tout.</param>
        /// <returns>Score.</returns>
        public int Calculer(int[] lancers, int noCaseCourante = 10)
        {
            return 0;
        }
    }
}
