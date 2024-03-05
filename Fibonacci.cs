using System.Text.Json;


public static class Fibonacci
{


    public static void Execute()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Sequência de Fibonacci");

        var targetValues = new uint[] { 0, 52, 144, 150, 4000, 701408733, 4294967291 };

        foreach (var target in targetValues)
        {
            var fibonacci = FibonacciSequence(target, out var isOverflow);

            Console.WriteLine("\nSequência completa: " + JsonSerializer.Serialize(fibonacci));

            if (fibonacci.Last() == target)
                Console.WriteLine($"{target} pertence à sequência de Fibonacci");
            else 
                Console.WriteLine($"{target} não pertence à sequência de Fibonacci." + (isOverflow ? $" {fibonacci.Last()} é o maior número calculável com uint " : ""));


        }


    }

    /// <summary>
    /// Gera uma sequência de Fibonacci de números menores de <paramref name="limit"/>
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="overflow">Será <see langword="true"/> caso aconteça o overflow</param>
    /// <returns></returns>
    public static List<uint> FibonacciSequence(uint limit, out bool overflow)
    {

        overflow = false;

        if (limit == 0)
            return [0];


        var sequence = new List<uint> { 0, 1 };

        uint last, preLast;
        while (true)
        {
            last = sequence.Last();
            preLast = sequence[sequence.Count - 2];
            var newValue = last + preLast;


            if (newValue < last)
            { //Soma atingiu Overflow de inteiros, retornando o que tem
                overflow = true;
                return sequence;
            }
            else if (newValue > limit) //Soma ultrapassou o limite, retornando o que tem
                return sequence;

            sequence.Add(newValue);

            if (newValue == limit)
                return sequence;

        }

    }
}