namespace ArrayEFuncoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { -5, 3, 4, 5, 9, 6, 10, -2, 11, 1 };
            int maiorValor = int.MinValue, menorValor = int.MaxValue, valorMedio = 0, segundoMaior = 0, terceiroMaior = 0, x = 0, soma = 0;
            decimal media;
            int[] numerosNegativos = new int[9];
            int[] arrayReduzido = new int[numeros.Length];

            EncontrarValor_Maior_Menor_Impares_e_Soma(numeros, ref maiorValor, ref menorValor, segundoMaior, ref x, ref soma, numerosNegativos);

            segundoMaior = EncontrarValoresMaiores(numeros, maiorValor, segundoMaior);
            terceiroMaior = EncontrarValoresMaiores(numeros, segundoMaior, terceiroMaior);
            media = DeterminarMedia(numeros, soma);

            Exibição(numeros, maiorValor, menorValor, segundoMaior, terceiroMaior, x, soma, media, ref numerosNegativos, ref arrayReduzido);

        }

        private static decimal DeterminarMedia(int[] numeros, int soma)
        {
            return soma / numeros.Length;
        }

        private static void Exibição(int[] numeros, int maiorValor, int menorValor, int segundoMaior, int terceiroMaior, int x, int soma, decimal media, ref int[] numerosNegativos, ref int[] arrayReduzido)
        {
            Array.Copy(numeros, arrayReduzido, numeros.Length);
            Array.Sort(arrayReduzido);
            Array.Resize(ref arrayReduzido, 9);
            Array.Resize(ref numerosNegativos, x);
            Console.WriteLine($"O Menor valor é: {menorValor}");
            Console.WriteLine($"O Maior valor é: {maiorValor}");
            Console.WriteLine($"O 2° Maior valor é: {segundoMaior}");
            Console.WriteLine($"O 3° Maior valor é: {terceiroMaior}");
            Console.WriteLine($"Soma dos Valores é: {soma}");
            Console.WriteLine($"A media dos Valores é: {media}");
            Console.Write("Os numeros negativos são: ");
            exibirArray(numerosNegativos);
            Console.Write("A matriz de numeros total era: ");
            exibirArray(numeros);
            Console.Write("A matriz de numeros reduzida é: ");
            exibirArray(arrayReduzido);
        }

        private static void exibirArray(int[] arrayReferencia)
        {
            for (int i = 0; i < arrayReferencia.Length; i++)
            {
                if (i < arrayReferencia.Length - 1)
                    Console.Write($"{arrayReferencia[i]},");
                else
                    Console.Write($"{arrayReferencia[i]}.");
            }
            Console.WriteLine();
        }

        static int EncontrarValoresMaiores(int[] numeros, int valorLimiteParaComparacao, int valorDesejado)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] > valorDesejado && numeros[i] < valorLimiteParaComparacao)
                {
                    valorDesejado = numeros[i];
                }
            }

            return valorDesejado;
        }

        static void EncontrarValor_Maior_Menor_Impares_e_Soma(int[] numeros, ref int maiorValor, ref int menorValor, int segundoMaior, ref int x, ref int soma, int[] numerosNegativos)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] > maiorValor && numeros[i] > segundoMaior)
                {
                    maiorValor = numeros[i];
                }

                if (numeros[i] < menorValor)
                {
                    menorValor = numeros[i];
                }
                if (numeros[i] < 0)
                {
                    numerosNegativos[x] = numeros[i];
                    x++;
                }

                soma += numeros[i];
            }
        }
    }
}
