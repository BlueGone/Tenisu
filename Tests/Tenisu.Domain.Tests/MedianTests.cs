using Tenisu.Domain.Extensions;

namespace Tenisu.Domain.Tests;

public class MedianTests
{
    [Theory]
    [MemberData(nameof(Median_OddCountCollection_ReturnsMedian_TestData))]
    public void Median_OddCountCollection_ReturnsMedian(
        IReadOnlyCollection<double> collection,
        double expected
    )
    {
        var actual = collection.Median(x => x);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(Median_EvenCountCollection_ReturnsMedian_TestData))]
    public void Median_EvenCountCollection_ReturnsMedian(
        IReadOnlyCollection<double> collection,
        double expected
    )
    {
        var actual = collection.Median(x => x);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Median_EmptyCollection_ThrowsArgumentOutOfRangeException()
    {
        double[] collection = [];

        Assert.Throws<InvalidOperationException>(() => collection.Median(x => x));
    }

    public static TheoryData<
        IReadOnlyCollection<double>,
        double
    > Median_OddCountCollection_ReturnsMedian_TestData() =>
        new()
        {
            { [1], 1.0 },
            { [1, 3, 2], 2.0 },
            { [4, 3, 6, 1, 1], 3.0 },
            { [5, 4, 3, 2, 1], 3.0 },
        };

    public static TheoryData<
        IReadOnlyCollection<double>,
        double
    > Median_EvenCountCollection_ReturnsMedian_TestData() =>
        new()
        {
            { [1, 2], 1.5 },
            { [1, 2, 3, 4], 2.5 },
            { [3, 2, 4, 5, 6, 1], 3.5 },
            { [6, 5, 4, 3, 2, 1], 3.5 },
            { [-5, 5], 0 },
        };
}
