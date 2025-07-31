using System;

public class Ex04
{
	public Ex04()
	{
	}

	public static void EncontrandoNumero()
	{
		int numEscolhido, numSorteado, contTentativas = 0;

		Random rand = new Random();
		numSorteado = rand.Next(1, 101);
		do
		{
			Console.Write("Número: ");
			numEscolhido = Convert.ToInt32(Console.ReadLine());
			if (numEscolhido < numSorteado) Console.WriteLine("Número escolhido é menor que o sorteado.");
			else if (numEscolhido > numSorteado) Console.WriteLine("Número escolhido é maior que o sorteado.");
			else Console.WriteLine("Uhuuu !! Você acertou");
            contTentativas++;
		}while(numEscolhido != numSorteado);

		Console.WriteLine($"Precisou de {contTentativas} tentativas.");
	}
}
