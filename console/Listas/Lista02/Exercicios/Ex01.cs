using System;

public class Ex01
{
	public Ex01()
	{
	}

	public static void Desconto()
	{
		const int desconto = 10; // 10%
		double valor, valorFinal, valorDescontado = 0;
		Console.Write("Valor do produto: ");
		valor = Convert.ToDouble(Console.ReadLine());
		if (valor > 100)
		{
			valorDescontado = valor * desconto / 100;

            valorFinal = valor - valorDescontado;
		}
		else
		{
			valorFinal = valor;
		}
		Console.WriteLine($"Desconto: R${valorDescontado}");
		Console.WriteLine($"Valor Final: R${valorFinal}");

    }
}
