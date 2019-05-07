namespace BowlingClasses.Core.Interfaces
{
    public interface IServiceCalculScore
    {
        int Calculer(ICase[] cases, int noCaseCourante = 10);
    }
}
