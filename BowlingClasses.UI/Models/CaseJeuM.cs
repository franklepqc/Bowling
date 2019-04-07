namespace BowlingClasses.UI.Models
{
    public class CaseJeuM
    {
        /// <summary>
        /// Essais du joueur.
        /// </summary>
        public int?[] Essais { get; set; }

        /// <summary>
        /// Score à afficher.
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="estDixiemeCarreau">Indicateur de 10ième carreau.</param>
        public CaseJeuM(bool estDixiemeCarreau = false)
        {
            if (estDixiemeCarreau) Essais = new int?[3];
            else Essais = new int?[2];
        }
    }
}
