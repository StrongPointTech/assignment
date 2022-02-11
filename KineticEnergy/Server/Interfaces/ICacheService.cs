namespace KineticEnergy.Server.Interfaces;

public interface ICacheService
{
    public void CacheImpact(double energy, string impact);
    public bool TryGetImpact(double energy, out string impact);
}

