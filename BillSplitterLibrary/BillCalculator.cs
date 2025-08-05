namespace BillSplitterLibrary;

public static class BillCalculator
{
    public static decimal SplitAmount(decimal totalAmount, int people)
    {
        if (people <= 0)
            throw new ArgumentException("Number of people must be greater than 0");

        return totalAmount / people;
    }

    public static Dictionary<string, decimal> CalculateTipSplit(Dictionary<string, decimal> meals, float tipPercentage)
    {
        if (meals == null || meals.Count == 0)
            throw new ArgumentException("Meals dictionary must not be empty");

        decimal total = meals.Values.Sum();
        var tips = new Dictionary<string, decimal>();

        foreach (var meal in meals)
        {
            decimal weight = meal.Value / total;
            decimal tip = Math.Round((decimal)(tipPercentage / 100) * total * weight, 2);
            tips[meal.Key] = tip;
        }

        return tips;
    }

    public static decimal TipPerPerson(decimal price, int patrons, float tipPercentage)
    {
        if (patrons <= 0)
            throw new ArgumentException("Number of patrons must be greater than 0");

        return Math.Round(price * (decimal)(tipPercentage / 100) / patrons, 2);
    }
}

