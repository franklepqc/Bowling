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
        public int? Score
        {
            get => _caseJeu.Score;
            set
            {
                _caseJeu.Score = value.Value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Détermine si c'est le dixième carreau.
        /// </summary>
        public bool EstDixiemeCarreau { get; private set; }

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="caseJeu">Case de jeu.</param>
        public CaseJeuM(ICase caseJeu)
        {
            // Case de jeu.
            _caseJeu = caseJeu;

            // Initialiser le nombre de carreaux.
            EstDixiemeCarreau = _caseJeu.Essais.Count() == 3;
        }

        /// <summary>
        /// Signaler à l'interface que les essais ont changé.
        /// </summary>
        public void SignalerChangement()
        {
            RaisePropertyChanged(nameof(Essais));
        }
    }
}
