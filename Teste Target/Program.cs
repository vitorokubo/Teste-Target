using System.Text.Json;

class Program
{
    //Função exercicio 1
    static int CalcularSoma(int indice)
    {
        int soma = 0, k = 0;

        while (k < indice)
        {
            k = k + 1;
            soma = soma + k;
        }

        return soma;
    }
    //Função exercicio 2
    static bool PertenceFibonacci(int numero)
    {
        int a = 0, b = 1, temp;

        while (a <= numero)
        {
            if (a == numero)
                return true;

            temp = a + b;
            a = b;
            b = temp;
        }

        return false;
    }

    static string InverterString(string input)
    {
        char[] caracteres = new char[input.Length];
        int j = 0;

        for (int i = input.Length - 1; i >= 0; i--)
        {
            caracteres[j] = input[i];
            j++;
        }

        return new string(caracteres);
    }

    static void Main()
    {
        Console.WriteLine("Desenvolvedor Candidato - Vitor Sabatin");

        //Exercicio 1
        Console.WriteLine("\nExercício 1");

        int resultado = CalcularSoma(13);
        Console.WriteLine("O valor final de SOMA é: " + resultado);

        //Exercicio 2
        Console.WriteLine("\nExercício 2");

        Console.Write("Digite um número: ");
        try
        {
            int numero = int.Parse(Console.ReadLine());
            if (PertenceFibonacci(numero))
                Console.WriteLine($"{numero} pertence à sequência de Fibonacci.");
            else
                Console.WriteLine($"{numero} NÃO pertence à sequência de Fibonacci.");
        } catch {
            Console.WriteLine("número invalido");
        }
       

        //Exercicio 3
        Console.WriteLine("\nExercício 3");
        string filePath = "./dados.json"; // Caminho do arquivo JSON
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            var lista = JsonSerializer.Deserialize<List<Dados>>(jsonContent);

            if (lista != null)
            {
                lista = lista.OrderBy(x => x.valor).ToList();

                //menor Faturamento no mês
                var menorFaturamento = lista.FirstOrDefault();
                Console.WriteLine($"Menor valor de faturamento no mes :{menorFaturamento?.valor}, no dia: {menorFaturamento?.dia}");

                // maior Faturamento no mês
                var maiorFaturamento = lista.LastOrDefault();
                Console.WriteLine($"Maior valor de faturamento no mes :{maiorFaturamento?.valor}, no dia: {maiorFaturamento?.dia}");

                var mediaMensal = lista.Where(x => x.valor > 0).Average(f => f.valor);
                int diasAcimaDaMedia = lista.Count(f => f.valor > mediaMensal);

                Console.WriteLine($"Número de dias com faturamento superior à média mensal:{diasAcimaDaMedia}");

            }
            else
            {
                Console.WriteLine("Lista vazia");
            }
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado.");
        }
        //Exercicio 4
        Console.WriteLine("\nExercício 4");

        var faturamentoPorEstado = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double faturamentoTotal = 0;
        foreach (var faturamento in faturamentoPorEstado.Values)
        {
            faturamentoTotal += faturamento;
        }

        foreach (var estado in faturamentoPorEstado)
        {
            double percentual = (estado.Value / faturamentoTotal) * 100;
            Console.WriteLine($"Estado: {estado.Key}, Faturamento: R${estado.Value:F2}, Percentual: {percentual:F2}%");
        }

        //Exercicio 5
        Console.WriteLine("\nExercício 5");

        Console.Write("Digite uma string para inverter: ");
        string input = Console.ReadLine();

        string stringInvertida = InverterString(input);

        Console.WriteLine($"String invertida: {stringInvertida}");

    }

}

public class Dados
{
    public int dia { get; set; }
    public double valor { get; set; }

}


