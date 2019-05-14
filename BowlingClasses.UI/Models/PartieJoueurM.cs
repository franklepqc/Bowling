using BowlingClasses.Core.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BowlingClasses.UI.Models
{
    public class PartieJoueurM
    {
        #region Fields

        /// <summary>
        /// Joueur.
        /// </summary>
        private readonly IJoueur _joueur;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public PartieJoueurM(int id, IJoueur joueur, IEnumerable<ICase> casesJeu)
        {
            // Initialisation.
            Id = id;
            _joueur = joueur;
            int indexCase = 0;
            casesJeu.ToList()
                .ForEach(caseJeu => CasesJeu.Add(new CaseJeuM(caseJeu, indexCase++)));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Cases du jeu.
        /// </summary>
        public ObservableCollection<CaseJeuM> CasesJeu { get; private set; } = new ObservableCollection<CaseJeuM>();

        /// <summary>
        /// Index.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nom du joueur.
        /// </summary>
        public string Nom => _joueur.Nom;

        #endregion Properties
    }
}