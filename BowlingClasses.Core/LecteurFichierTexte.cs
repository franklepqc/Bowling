using BowlingClasses.Core.Interfaces;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BowlingClasses.Core
{
    public class LecteurFichierTexte : ILecteur
    {
        /// <summary>
        /// Lire les informations du fichier.
        /// </summary>
        /// <returns>Lancers.</returns>
        public int[] Lire(Stream stream)
        {
            // Variables de travail.
            string[] lancersStr;

            if (null == stream)
            {
                lancersStr = new string[0];
            }
            else
            {
                // Lecture dans le fichier.
                using (var reader = new StreamReader(stream))
                {
                    var texte = reader.ReadToEnd();
                    lancersStr = texte.Split(";");
                }
            }

            return lancersStr
                .Where(chaine => 
                    !string.IsNullOrEmpty(chaine) && 
                    !string.IsNullOrWhiteSpace(chaine) &&
                    Regex.IsMatch(chaine, @"^([0-9]*)$"))
                .Select(lancerStr => int.Parse(lancerStr))
                .ToArray();
        }
    }
}
