using BowlingClasses.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingClasses.Core
{
    public class ServiceCalculScore : IServiceCalculScore
    {
        public int Calculer(int[] lancers, int noCaseCourante = 10)
        {
            // Variables de travail.
            int somme = 0;
            int noCase = 1;

            for (int index = 0; index < lancers.Length && noCase <= noCaseCourante; index++)
            {
                var lancer = ObtenirLancer(lancers, index);

                // Abat sauf 10ième carreau.
                if (10 == lancer)
                {
                    somme += lancer + ObtenirLancer(lancers, index + 1) + ObtenirLancer(lancers, index + 2);
                }
                else
                {
                    // Réserve.
                    lancer += ObtenirLancer(lancers, index + 1);

                    if (10 == lancer)
                    {
                        somme += lancer + ObtenirLancer(lancers, index + 2);
                    }
                    else
                    {
                        somme += lancer;
                    }

                    index++;
                }

                noCase++;
            }

            return somme;
        }

        private int ObtenirLancer(int[] lancers, int index) =>
            (lancers.Length <= index ? 0 : lancers[index]);
    }
}
