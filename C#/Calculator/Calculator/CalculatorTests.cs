namespace CalculatorTest;
using Domain;
public class CalculatorTests
{
    // Sum of 2 and 2 should return 4
    [Fact]
    public void Sum_of_2_and_2_should_be_4() =>
        Assert.Equal(4, new Calculator().Sum(2, 2));
}