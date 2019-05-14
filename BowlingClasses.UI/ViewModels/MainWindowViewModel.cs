using BowlingClasses.Core.Interfaces;
using BowlingClasses.UI.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BowlingClasses.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Fields

        /// <summary>
        /// Services à injecter.
        /// </summary>
        private readonly IServiceCreationPartie _serviceCreationPartie;
        private readonly IServicePreJoue _servicePreJoue;

        /// <summary>
        /// Partie en cours.
        /// </summary>
        private IPartie _partie;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="serviceCreationPartie">Service de création d'une partie.</param>
        /// <param name="servicePreJoue">Service pour les parties pré-jouées.</param>
        public MainWindowViewModel(IServiceCreationPartie serviceCreationPartie, IServicePreJoue servicePreJoue)
        {
            // Assignation des objets injectés.
            _serviceCreationPartie = serviceCreationPartie;
            _servicePreJoue = servicePreJoue;

            // Assignation des commandes.
            CommandeAjouterLancer = new DelegateCommand<string>(
                AjouterLancer);
            CommandePreJoue = new DelegateCommand<int?>(PreJoue);

            InitialiserAsync();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Commande pour ajouter un lancer.
        /// </summary>
        public DelegateCommandBase CommandeAjouterLancer { get; private set; }

        /// <summary>
        /// Commande pour le service du pré-joué.
        /// </summary>
        public ICommand CommandePreJoue { get; private set; }

        /// <summary>
        /// Liste des cases de jeu.
        /// </summary>
        public ObservableCollection<PartieJoueurM> PartieJoueurs { get; private set; } = new ObservableCollection<PartieJoueurM>();

        #endregion Properties

        #region Methods

        /// <summary>
        /// Ajoute le lancer.
        /// </summary>
        private void AjouterLancer(string lancerStr)
        {
            // Variables de travail.
            var lancer = System.Convert.ToInt32(lancerStr);
            var noCase = _partie.IndexCaseParJoueur[_partie.IndexJoueur];
            var partieJoueur = PartieJoueurs[_partie.IndexJoueur];

            if (_partie.AjouterLancer(lancer))
            {
                partieJoueur.CasesJeu
                    .Take(noCase + 1)
                    .ToList()
                    .ForEach((caseJeu) =>
                    {
                        // Signaler à l'interface que les valeurs ont changé.
                        caseJeu.SignalerChangement();
                    });
            }
        }

        /// <summary>
        /// Initialiser les cases.
        /// </summary>
        /// <returns>Cases.</returns>
        private void InitialiserAsync()
        {
            // Réinitialiser.
            _partie = null;
            _partie = _serviceCreationPartie.Creer(6);

            // Réinitialiser.
            PartieJoueurs.Clear();

            // Ajouter.
            for (int iCptJoueurs = 0; iCptJoueurs < _partie.Equipe.Joueurs.Length; iCptJoueurs++)
            {
                PartieJoueurs.Add(new PartieJoueurM(iCptJoueurs, _partie.Equipe.Joueurs[iCptJoueurs], _partie.Cases[iCptJoueurs]));
            }
        }

        /// <summary>
        /// Activer la partie pré-jouée.
        /// </summary>
        /// <param name="indexJoueur">Index du joueur.</param>
        private void PreJoue(int? indexJoueur)
        {
            if (indexJoueur.HasValue &&
                indexJoueur.Value >= 0 &&
                indexJoueur.Value < PartieJoueurs.Count)
            {
                var ixJoueur = indexJoueur.Value;

                // Ouverture du dialogue.
                var dialogue = new Microsoft.Win32.OpenFileDialog();
                dialogue.Filter = "Fichiers texte|*.txt";
                dialogue.Multiselect = false;

                // Si un fichier est choisi.
                if (true == dialogue.ShowDialog())
                {
                    // Si le score est bel et bien lu et entré.
                    if (_servicePreJoue.EntrerScore(dialogue.OpenFile(), _partie, ixJoueur))
                    {
                        // Indique le joueur est absent.
                        _partie.Equipe.Joueurs[ixJoueur].EstAbsent = true;

                        // Rafraîchir l'affichage.
                        PartieJoueurs[ixJoueur].CasesJeu
                            .ToList()
                            .ForEach((caseJeu) =>
                            {
                                // Signaler à l'interface que les valeurs ont changé.
                                caseJeu.SignalerChangement();
                            });
                    }
                }
            }
        }

        #endregion Methods
    }
}