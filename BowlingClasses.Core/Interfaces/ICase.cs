namespace BowlingClasses.Core.Interfaces
{
    public interface ICase
    {
        int?[] Essais { get; }

        bool EstTerminee { get; }

        bool EstDixiemeCarreau { get; }

        int? Score { get; set; }

        bool AjouterEssai(int lancer);
    }
}
