using KineticEnergy.Server.Interfaces;

namespace KineticEnergy.Server.Services;

public class EnergyCalculationService : IEnergyCalculationService
{
    public double CalculateEnergy(double mass, double speed)
    {
        return 0.5 * mass * speed * speed;
    }

    public async Task<string> CalculateImpact(double energy)
    {
        return await Task.Run(() => Impacts(energy));
    }

    private string Impacts(double energy)
    {
        if (energy < 0)
            return "Negative energy does not exist";
        else if (energy == 0)
            return "No energy, no impact";
        else if (energy < 1e6)
            return "Impact at this level would not do much to Earth";
        else if (energy < 1e12)
            return "Impact might leave a dent in Earths crust";
        else if (energy < 1e24)
            return "Impact might create big hole in Earth";
        else if (energy < 1e28)
            return "Impact might destroy part of life and get us to nuclear winter";
        else if (energy < 1e32)
            return "Impact would get Earth really hot and shatter at least part of it";
        else
            return "Impact of this magnitude qould destroy Earth";
    }
}

