using BowlingClasses.Core.Interfaces;
using Prism.Mvvm;
using System.Linq;

namespace BowlingClasses.UI.Models
{
    public class CaseJeuM : BindableBase
    {
        /// <summary>
        /// Case de jeu (données).
        /// </summary>
        private ICase _caseJeu;

        /// <summary>
        /// Essais du joueur.
        /// </summary>
        public int?[] Essais => _caseJeu.Essais;

        /// <summary>
        /// Score à afficher.
        /// </summary>
        public int? Score => _caseJeu.Score;

        /// <summary>
        /// Détermine si c'est le dixième carreau.
        /// </summary>
        public bool EstDixiemeCarreau => _caseJeu.EstDixiemeCarreau;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="caseJeu">Case de jeu.</param>
        public CaseJeuM(ICase caseJeu)
        {
            // Case de jeu.
            _caseJeu = caseJeu;
        }

        /// <summary>
        /// Signaler à l'interface que les essais ont changé.
        /// </summary>
        public void SignalerChangement()
        {
            RaisePropertyChanged(nameof(Score));
            RaisePropertyChanged(nameof(Essais));
        }
    }
}
