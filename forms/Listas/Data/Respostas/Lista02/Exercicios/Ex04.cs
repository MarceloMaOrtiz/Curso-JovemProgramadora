using System;

public class Ex04
{
	public Ex04()
	{
	}

	public static void ConverteTempo()
	{
		char opcao;
		double horas, minutos;

        Console.WriteLine("Escolha uma opção");
		Console.WriteLine("\tH - Horas para Minutos");
		Console.WriteLine("\tM - Minutos para Horas");
		Console.Write("Opção: ");
		opcao = Convert.ToChar(Console.Read());
		Console.ReadLine();

		switch (opcao) {
			case 'H': case 'h':
				Console.Write("Horas: ");
				horas = Convert.ToDouble(Console.ReadLine());
				minutos = horas * 60;
				Console.WriteLine($"{horas.ToString("0.##")}h = {minutos.ToString("0.##")}m");
				break;
			case 'M': case 'm':
                Console.Write("Minutos: ");
                minutos = Convert.ToDouble(Console.ReadLine());
				horas = minutos / 60;
                Console.WriteLine($"{minutos.ToString("0.##")}m = {horas.ToString("0.##")}h");
                break;
			default:
				Console.WriteLine("Opção inválida.");
				break;
		} 

    }
}
