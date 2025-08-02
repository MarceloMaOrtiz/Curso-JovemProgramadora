using System;

public class Ex03
{
	public Ex03()
	{
	}

	public static void ClassificarTemperatura()
	{
		double celsius;
		Console.Write("Temperatura (Cº): ");
		celsius = Convert.ToDouble(Console.ReadLine());
		if (celsius >= 30)
		{
			Console.WriteLine($"{celsius}Cº está quente.");
		}
		else if(celsius >= 15)
		{
            Console.WriteLine($"{celsius}Cº está moderado.");
		}
		else
		{
            Console.WriteLine($"{celsius}Cº está frio.");
        }

    }
}
