using System;

public class Ex06
{
	public Ex06()
	{
	}

	public static void Estacao()
	{
		int dia, mes, ano;
		string estacao = "";

		Console.Write("Dia: ");
		dia = Convert.ToInt32(Console.ReadLine());
        Console.Write("Mês: ");
        mes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ano: ");
        ano = Convert.ToInt32(Console.ReadLine());

		switch (mes) {
			case 1:
			case 2:
				estacao = "verão";
				break;
			case 3:
				if (dia <= 19) estacao = "verão";
				else estacao = "outono";
				break;
			case 4:
			case 5:
				estacao = "outono";
				break;
			case 6:
				if (dia <= 20) estacao = "outono";
				else estacao = "inveno";
				break;
			case 7:
			case 8:
				estacao = "inverno";
				break;
			case 9:
				if (dia <= 22) estacao = "inverno";
				else estacao = "primavera";
				break;
			case 10:
			case 11:
				estacao = "primavera";
				break;
			case 12:
				if (dia <= 20) estacao = "primavera";
				else estacao = "verão";
				break;
			default:
				Console.WriteLine("Mês inválido.");
				break;
			}

		if (mes >= 1 && mes <= 12)
		{
            Console.WriteLine($"Estamos na(o) {estacao}, a data é {dia}/{mes}/{ano}");
        }
    }
}
