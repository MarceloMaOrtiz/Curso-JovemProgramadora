using System;

public class Ex02
{
	public Ex02()
	{
	}
	public static void RepetirAteCondicao()
	{
		int num = 0;
		do
		{
			Console.Write("Número: ");
			num = Convert.ToInt32(Console.ReadLine());

			if (num < 100) Console.WriteLine($"Número {num} menor que 100.");
			else Console.WriteLine($"Fim. Número {num} maior ou igual que 100");
		}while(num < 100);
	}
}
