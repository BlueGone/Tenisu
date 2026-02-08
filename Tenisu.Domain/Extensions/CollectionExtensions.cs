namespace Tenisu.Domain.Extensions;

public static class CollectionExtensions
{
    public static double Median<TSource>(
        this IReadOnlyCollection<TSource> source,
        Func<TSource, double> selector
    )
    {
        if (source.Count == 0)
        {
            throw new InvalidOperationException("Sequence contains no elements");
        }

        var orderedSelectedSource = source.Select(selector).Order();

        return source.Count % 2 == 0
            ? orderedSelectedSource.Skip(source.Count / 2 - 1).Take(2).Average()
            : orderedSelectedSource.Skip(source.Count / 2).First();
    }
}
