using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using BowlingClasses.UI.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BowlingClasses.UI.ViewModels
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// Liste des cases de jeu.
        /// </summary>
        public ObservableCollection<PartieJoueurM> PartieJoueurs { get; private set; } = new ObservableCollection<PartieJoueurM>();

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public MainWindowViewModel()
        {
            InitialiserAsync();
        }

        /// <summary>
        /// Initialiser les cases.
        /// </summary>
        /// <returns>Cases.</returns>
        private Task InitialiserAsync() => Task.Run(() =>
        {
            // Réinitialiser.
            PartieJoueurs.Clear();

            // Ajouter.
            PartieJoueurs.Add(new PartieJoueurM(new Joueur("Joueur 1"), new CasesJeu()));
            PartieJoueurs.Add(new PartieJoueurM(new Joueur("Joueur 2"), new CasesJeu()));
            PartieJoueurs.Add(new PartieJoueurM(new Joueur("Joueur 3"), new CasesJeu()));
            PartieJoueurs.Add(new PartieJoueurM(new Joueur("Joueur 4"), new CasesJeu()));
            PartieJoueurs.Add(new PartieJoueurM(new Joueur("Joueur 5"), new CasesJeu()));
            PartieJoueurs.Add(new PartieJoueurM(new Joueur("Joueur 6"), new CasesJeu()));
        });
    }

    public class CasesJeu : Collection<ICase>
    {
        public CasesJeu()
        {
            for (int i = 0; i < 9; i++) Add(new CaseJeu(2));
            Add(new CaseJeu(3));
        }
    }
}
