using BowlingClasses.Core.Interfaces;
using BowlingClasses.UI.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingClasses.UI.ViewModels
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// Service de création d'une partie.
        /// </summary>
        private readonly IServiceCreationPartie _serviceCreationPartie;

        /// <summary>
        /// Partie en cours.
        /// </summary>
        private IPartie _partie;

        /// <summary>
        /// Liste des cases de jeu.
        /// </summary>
        public ObservableCollection<PartieJoueurM> PartieJoueurs { get; private set; } = new ObservableCollection<PartieJoueurM>();

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="serviceCreationPartie">Service de création d'une partie.</param>
        public MainWindowViewModel(IServiceCreationPartie serviceCreationPartie)
        {
            // Assignation des objets injectés.
            _serviceCreationPartie = serviceCreationPartie;

            InitialiserAsync();
        }

        /// <summary>
        /// Initialiser les cases.
        /// </summary>
        /// <returns>Cases.</returns>
        private Task InitialiserAsync() => Task.Run(() =>
        {
            // Réinitialiser.
            _partie = null;
            _partie = _serviceCreationPartie.Creer(6);

            // Réinitialiser.
            PartieJoueurs.Clear();

            // Ajouter.
            _partie.Equipe.Joueurs
                .ToList()
                .ForEach(joueur =>
                {
                    PartieJoueurs.Add(new PartieJoueurM(joueur, _partie.Cases));
                });
        });
    }
}
