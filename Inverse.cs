using System.Text;

public static class Inverse{
    public static void Execute(){
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Inversor de texto");

        var strings = new string[] {
            "algum", "1234", "   15 7 278 df dfgh", "Sit ullamco anim cupidatat magna non.", "&%¨$¨%%%&¨#$dflgkdfjghkl"
        };

        foreach (var text in strings)
        {
            var inverted = Invert(text);

            //Convertendo array de char em string. A função string.Join("", inverted) faria o mesmo.
            var output = new StringBuilder();
            for (int i = 0; i < inverted.Count(); i++)
                output.Append(inverted.ElementAt(i));

            Console.WriteLine($"{text} -> {output.ToString()}");
        }
    }


    public static IEnumerable<T> Invert<T>(IEnumerable<T> elements){
        var inverted = new T[elements.Count()];

        //Percorrendo normal, mas decrementando um contador que começa com o tamanho - 1
        for (int r = inverted.Length-1, i = 0; i < inverted.Length; i++, r--)
            inverted[i] = elements.ElementAt(r);
        return inverted;
    }

    
}
