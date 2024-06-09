namespace Challenges;

public static class MathematicalFunctions
{
    // Existing LINQ equivalent: numbers.Sum()
    public static int Sum(int[] numbers) => numbers
        .Aggregate(0, (a, b) => a + b);
    
    // Existing LINQ equivalent: numbers.Max()
    public static int Max(int[] numbers) => numbers
        .Skip(1)
        .Aggregate(numbers[0], Math.Max);
    
    // Existing LINQ equivalent: numbers.Min()
    public static int Min(int[] numbers) => numbers
        .Skip(1)
        .Aggregate(numbers[0], Math.Min);

    public static int IndexOf(int[] numbers, int numberToFind) => numbers
        .Select((number, index) => (number, index))
        .Where(x => x.number == numberToFind)
        .Select(x => x.index)
        .FirstOrDefault();

    // Existing LINQ equivalent: numbers.Where(number => number == numberToFind).Any()
    // But LINQ has a Any overload that takes a predicate
    public static bool Contains(int[] numbers, int numberToFind) => numbers
        .Any(number => number == numberToFind);
    
    
    // Existing LINQ equivalent: numbers.Reverse()
    public static int[] Reverse(int[] numbers) => numbers
        .Select((number, index) => numbers[numbers.Length - 1 - index])
        .ToArray();
    
    public static int[] Copy(int[] numbers) => numbers.ToArray();

    // Existing LINQ equivalent: numbers.Where(number => number == numberToFind).Count()
    // But LINQ has a Count overload that takes a predicate
    public static int CountOccurrences(int[] numbers, int numberToFind) => numbers
        .Count(number => number == numberToFind);

    public static int Power(int number, int n) =>
        Enumerable
            .Repeat(number, n)
            .Aggregate(1, (a, b) => a * b);
    
    public static int GetAmountOfPrimes(int n)
    {
        Span<bool> primes = new bool[n / 2];
        
        primes.Fill(true);
        primes[0] = false; // 1 is not a prime number
    
        for(var i = 3; i * i <= n; i += 2)
        {
            if (IsPrime(primes, i))
            {
                for(var j = i * i; j <= n; j += (2*i))
                    SetNotPrime(primes, j);
            }
        }
    
        var count = 1; // Count 2 as a prime number
        for(var i = 1; i < primes.Length; i++)
        {
             if (primes[i])
               count++;
        }
    
        return count;
    }
    
    private static bool IsPrime(Span<bool> primes, int number)
    {
          var index = number / 2;
          
          return index < primes.Length && primes[index];
    }
    
    private static void SetNotPrime(Span<bool> primes, int num)
    {
        var index = num / 2;
        
        if (index >= primes.Length)
            return;
        
        primes[index] = false;
    }
}