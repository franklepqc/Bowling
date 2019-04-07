using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingClasses.Tests
{
    [TestClass]
    public class ServiceCalculScoreTests
    {
        /// <summary>
        /// Conteneur.
        /// </summary>
        private static IServiceCalculScore _service;

        /// <summary>
        /// Initialisation du service.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _service = new ServiceCalculScore();
        }

        [TestMethod]
        public void CalculerScore_Succes100Points()
        {
            // Variables de travail.
            var lancers = new[]
            {
                0, 10,     // Case 1.
                0, 10,     // Case 2.
                0, 10,     // Case 3.
                0, 10,     // Case 4.
                0, 10,     // Case 5.
                0, 10,     // Case 6.
                0, 10,     // Case 7.
                0, 10,     // Case 8.
                0, 10,     // Case 9.
                0, 10, 0   // Case 10.
            };

            // Attendu.
            var attendu = 100;

            // Actuel.
            var actuel = _service.Calculer(lancers);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestMethod]
        public void CalculerScore_SuccesPartieParfaite()
        {
            // Variables de travail.
            var lancers = new[]
            {
                10, 10,     // Case 1.
                10, 10,     // Case 2.
                10, 10,     // Case 3.
                10, 10,     // Case 4.
                10, 10,     // Case 5.
                10, 10,     // Case 6.
                10, 10,     // Case 7.
                10, 10,     // Case 8.
                10, 10,     // Case 9.
                10, 10, 10  // Case 10.
            };

            // Attendu.
            var attendu = 300;

            // Actuel.
            var actuel = _service.Calculer(lancers);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
    }
}
