using BowlingClasses.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BowlingClasses.Core
{
    public class LecteurFichierJson : ILecteur
    {
        /// <summary>
        /// Lire les informations du fichier.
        /// </summary>
        /// <returns>Lancers.</returns>
        public int[] Lire(Stream stream)
        {
            // Variables de travail.
            var retour = Enumerable.Empty<int>();

            if (null != stream)
            {
                // Lecture dans le fichier.
                using (var reader = new StreamReader(stream))
                {
                    var texte = reader.ReadToEnd();

                    if (!string.IsNullOrEmpty(texte) && !string.IsNullOrWhiteSpace(texte))
                    {
                        retour = JsonConvert.DeserializeObject<IEnumerable<CaseJson>>(texte).SelectMany(caseJeuJson => caseJeuJson.essais);
                    }
                }
            }

            return retour.ToArray();
        }

        internal class CaseJson
        {
            public int id { get; set; }
            public int[] essais { get; set; }
        }
    }
}
