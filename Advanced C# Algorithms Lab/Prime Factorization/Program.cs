using System;
using System.Collections.Generic;


class PrimeFactorization
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int divisor = 2;
        int currentResult = N;
        List<int> primeMultiple = new List<int>();
        while (currentResult != divisor)
        {
            if (currentResult % divisor == 0)
            {
                primeMultiple.Add(divisor);
                currentResult = currentResult / divisor;
            }
            else
            {
                divisor++;
            }
        }

        primeMultiple.Add(currentResult);

        Console.WriteLine("{0} = {1}", N, string.Join(" * ", primeMultiple));

    }
}