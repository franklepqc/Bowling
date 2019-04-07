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
            PartieJoueurs.Add(new PartieJoueurM { Nom = "Joueur1" });
            PartieJoueurs.Add(new PartieJoueurM { Nom = "Joueur2" });
            PartieJoueurs.Add(new PartieJoueurM { Nom = "Joueur3" });
            PartieJoueurs.Add(new PartieJoueurM { Nom = "Joueur4" });
            PartieJoueurs.Add(new PartieJoueurM { Nom = "Joueur5" });
            PartieJoueurs.Add(new PartieJoueurM { Nom = "Joueur6" });
        });
    }
}
