using System.Linq;

namespace BowlingClasses.Core
{
    /// <summary>
    /// Représentation d'une case de jeu dans la grille.
    /// </summary>
    public class CaseJeu : Interfaces.ICase
    {
        /// <summary>
        /// Nombre de quilles pour un abat.
        /// </summary>
        public static readonly int NOMBRE_QUILLES_ABAT = 10;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="nombreEssais">Nombre d'essai.</param>
        public CaseJeu(int nombreEssais)
        {
            Essais = new int?[nombreEssais];
        }

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="essais">Essais.</param>
        public CaseJeu(int?[] essais)
        {
            Essais = essais;
        }

        /// <summary>
        /// Essais.
        /// </summary>
        public int?[] Essais { get; private set; }

        /// <summary>
        /// Score de la case.
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        /// À savoir si la case est terminée.
        /// </summary>
        public bool EstTerminee => 
            (Essais.All(p => p.HasValue) ||
             (Essais.FirstOrDefault() == NOMBRE_QUILLES_ABAT && !EstDixiemeCarreau) ||
             (EstDixiemeCarreau && Essais[0].HasValue && Essais[1].HasValue && (Essais[0].Value + Essais[1].Value) < 10));

        /// <summary>
        /// À savoir si c'est le dixième carreau.
        /// </summary>
        public bool EstDixiemeCarreau => Essais.Count() == 3;

        /// <summary>
        /// Valide que l'ajout est possible.
        /// </summary>
        /// <param name="lancer">Nombre de quilles abattues.</param>
        /// <returns>Vrai si l'opération est une réussite.</returns>
        public void AjouterEssai(int lancer)
        {
            if (!Essais[0].HasValue)
            {
                Essais[0] = lancer;
            }
            else if (!Essais[1].HasValue)
            {
                // Réserve, calcul automatisé.
                if (!EstDixiemeCarreau)
                {
                    if (lancer == 10)
                    {
                        lancer -= Essais[0].Value;
                    }
                    // On a voulu jouer au fin fineau! On quitte.
                    else if ((lancer + Essais[0].Value) > 10)
                    {
                        return;
                    }
                }
                else
                {
                    if (lancer == 10 && Essais[0].Value > 0 && Essais[0].Value < 10)
                    {
                        lancer -= Essais[0].Value;
                    }
                }

                Essais[1] = lancer;
            }
            else if (EstDixiemeCarreau && !Essais[2].HasValue && (Essais[0].Value + Essais[1].Value) >= 10)
            {
                Essais[2] = lancer;
            }
        }
    }
}
