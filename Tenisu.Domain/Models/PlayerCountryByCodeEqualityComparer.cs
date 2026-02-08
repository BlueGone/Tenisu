namespace Tenisu.Domain.Models;

public class PlayerCountryByCodeEqualityComparer : IEqualityComparer<PlayerCountry>
{
    public bool Equals(PlayerCountry? x, PlayerCountry? y)
    {
        if (ReferenceEquals(x, y))
            return true;
        if (x is null)
            return false;
        if (y is null)
            return false;
        if (x.GetType() != y.GetType())
            return false;
        return x.Code == y.Code;
    }

    public int GetHashCode(PlayerCountry obj)
    {
        return obj.Code.GetHashCode();
    }
}
