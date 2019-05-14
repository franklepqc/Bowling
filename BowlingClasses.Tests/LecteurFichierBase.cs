using System.IO;
using System.Text;

namespace BowlingClasses.Tests
{
    public abstract class LecteurFichierBase
    {
        /// <summary>
        /// Obtenir le stream selon le texte.
        /// </summary>
        /// <param name="texte">Texte du fichier.</param>
        /// <returns>Simule un fichier.</returns>
        protected Stream ObtenirStream(string texte) =>
            new MemoryStream(Encoding.UTF8.GetBytes(texte), false);
    }
}
