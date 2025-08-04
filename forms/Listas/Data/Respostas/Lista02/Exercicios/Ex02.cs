using System;

public class Ex02
{
	public Ex02()
	{
	}

	public static void ProcurarNumeroIntervalo()
	{
		int numero;
		Console.Write("Número: ");
		numero = Convert.ToInt32(Console.ReadLine());
		if (numero > 0 && numero <= 100)
		{
			Console.WriteLine("Número válido.");
		}
		else
		{
            Console.WriteLine("Número inválido.");
        }

    }
}
