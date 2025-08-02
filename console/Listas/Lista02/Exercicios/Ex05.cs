using System;

public class Ex05
{
	public Ex05()
	{
	}

	public static void CalcularImposto()
	{
		char opcao;
		double preco, imposto = 0, valorImposto;

		char[] opcoesValidas = { 'A', 'a', 'B', 'b', 'C', 'c' }; 

        Console.WriteLine("Escolha uma opção");
		Console.WriteLine("\ta - Alimento");
		Console.WriteLine("\tb - Eletrônico");
        Console.WriteLine("\tc - Roupa");
        Console.Write("Opção: ");
		opcao = Convert.ToChar(Console.Read());
		Console.ReadLine();

		switch (opcao) {
			case 'A':
			case 'a':
				imposto = 0.05;
				break;
			case 'B':
			case 'b':
				imposto = 0.15;
                break;
            case 'C':
            case 'c':
                imposto = 0.1;
                break;
            default:
				Console.WriteLine("Tipo do produto inválido.");
				break;
		}

		if (opcoesValidas.Contains(opcao))
		{
            Console.Write("Preço: ");
            preco = Convert.ToDouble(Console.ReadLine());
            valorImposto = preco * imposto;
            Console.WriteLine($"Imposto: R${valorImposto:F2}");
        }
    }
}
