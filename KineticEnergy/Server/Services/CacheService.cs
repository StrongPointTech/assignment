using KineticEnergy.Server.Interfaces;

namespace KineticEnergy.Server.Services;

public class CacheService : ICacheService
{
    private readonly Dictionary<double, string> _impactCache = new();

    public void CacheImpact(double energy, string impact)
    {
        if (!_impactCache.ContainsKey(energy))
            _impactCache.Add(energy, impact);
    }

    public bool TryGetImpact(double energy, out string impact) => _impactCache.TryGetValue(energy, out impact);
}

