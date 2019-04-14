using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingClasses.Tests
{
    [TestClass]
    public class ServiceValidationTests
    {
        /// <summary>
        /// Conteneur.
        /// </summary>
        private static IServiceValidation _service;

        /// <summary>
        /// Initialisation du service.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _service = new ServiceValidation();
        }

        [TestCategory(@"Service de validation des cases")]
        [TestMethod]
        public void Valider_Succes()
        {
            // Variables de travail.
            var cases = new[]
            {
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9, 0 }, true),
            };

            // Attendu.
            var attendu = true;

            // Actuel.
            var actuel = _service.Valider(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de validation des cases")]
        [TestMethod]
        public void Valider_EchecUneCaseVide()
        {
            // Variables de travail.
            var cases = new[]
            {
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[2]),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9, 0 }, true),
            };

            // Attendu.
            var attendu = false;

            // Actuel.
            var actuel = _service.Valider(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de validation des cases")]
        [TestMethod]
        public void Valider_EchecUneCaseNull()
        {
            // Variables de travail.
            var cases = new[]
            {
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(null),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9, 0 }, true),
            };

            // Attendu.
            var attendu = false;

            // Actuel.
            var actuel = _service.Valider(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de validation des cases")]
        [TestMethod]
        public void Valider_EchecAucuneCase()
        {
            // Variables de travail.
            ICase[] cases = null;

            // Attendu.
            var attendu = false;

            // Actuel.
            var actuel = _service.Valider(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
        
        [TestCategory(@"Service de validation des cases")]
        [TestMethod]
        public void Valider_EchecCasesVide()
        {
            // Variables de travail.
            ICase[] cases = new CaseJeu[0];

            // Attendu.
            var attendu = true;

            // Actuel.
            var actuel = _service.Valider(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de validation des cases")]
        [TestMethod]
        public void Valider_EchecTropDeCases()
        {
            // Variables de travail.
            ICase[] cases = new CaseJeu[20];

            // Attendu.
            var attendu = false;

            // Actuel.
            var actuel = _service.Valider(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de validation des cases")]
        [TestMethod]
        public void Valider_EchecNombreQuillesCaseInvalide()
        {
            // Variables de travail.
            var cases = new[]
            {
                new CaseJeu(new int?[] { 9, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9, 0 }, true),
            };

            // Attendu.
            var attendu = false;

            // Actuel.
            var actuel = _service.Valider(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Service de validation des cases")]
        [TestMethod]
        public void Valider_EchecNombreQuillesCaseInvalide2()
        {
            // Variables de travail.
            var cases = new[]
            {
                new CaseJeu(new int?[] { 9, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9 }),
                new CaseJeu(new int?[] { 0, 9, 11 }, true),
            };

            // Attendu.
            var attendu = false;

            // Actuel.
            var actuel = _service.Valider(cases);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
    }
}
