using BowlingClasses.Core.Interfaces;
using System.Linq;

namespace BowlingClasses.Core
{
    /// <summary>
    /// Service de validation des cases.
    /// </summary>
    public class ServiceValidation : IServiceValidation
    {
        /// <summary>
        /// Validation.
        /// </summary>
        /// <param name="cases">Cases de jeu.</param>
        /// <returns>Vrai si les valeurs et les cases sont valides, faux sinon.</returns>
        public bool Valider(ICase[] cases)
        {
            // Validations de base.
            // On a des cases!
            if (null == cases) return false;

            // Entre 1 et 10.
            if (!(cases.Count() >= 0 && cases.Count() <= 10)) return false;

            // Toutes les cases possèdent un nombre de quilles abattues valide.
            return cases
                .All(caseJeu => 
                    ((caseJeu.Essais?.Any() == true) &&
                    (!caseJeu.Essais.All(essai => !essai.HasValue)) &&
                    (caseJeu.EstDixiemeCarreau ? 
                        (caseJeu.Essais.Sum() <= 30 && caseJeu.Essais.Sum() >= 0) :     // 10ième carreau.
                        (caseJeu.Essais.Sum() <= 10 && caseJeu.Essais.Sum() >= 0))));   // Autres carreaux.
        }
    }
}
