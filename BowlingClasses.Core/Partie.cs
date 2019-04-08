using BowlingClasses.Core.Interfaces;

namespace BowlingClasses.Core
{
    public class Partie : IPartie
    {

        /// <summary>
        /// Cases du jeu.
        /// </summary>
        public ICase[][] Cases { get; set; }

        /// <summary>
        /// Équipe.
        /// </summary>
        public IEquipe Equipe { get; set; }

        /// <summary>
        /// Index de la case à jouer.
        /// </summary>
        public int IndexCase { get; private set; }

        /// <summary>
        /// Index du joueur.
        /// </summary>
        public int IndexJoueur { get; private set; }

        /// <summary>
        /// Ajout d'un lancer.
        /// </summary>
        /// <param name="lancer">Nombre de quilles abattues.</param>
        /// <returns>Vrai si l'opération est une réussite.</returns>
        public bool AjouterLancer(int lancer)
        {
            var essais = Cases[IndexJoueur][IndexCase].Essais;
            
            if (!essais[0].HasValue)
            {
                essais[0] = lancer;
                
                if (IndexCase < 9 && 10 == lancer)
                {
                    Suivant();
                }
            }
            else if (!essais[1].HasValue)
            {
                essais[1] = lancer;

                if (IndexCase < 9)
                {
                    Suivant();
                }
            }
            else if (IndexCase == 9 && essais.Length == 3 && !essais[2].HasValue)
            {
                essais[2] = lancer;
                Suivant();
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Passe au suivant. Si les joueurs ont tous joué, on va au prochain carreau.
        /// </summary>
        private void Suivant()
        {
            // Si tous les joueurs ont joué.
            if (++IndexJoueur >= Equipe.Joueurs.Length)
            {
                IndexJoueur = 0;
                IndexCase++;
            }
        }
    }
}
