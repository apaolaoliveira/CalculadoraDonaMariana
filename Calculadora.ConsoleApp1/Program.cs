using System.ComponentModel;

namespace Calculadora.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();

                Console.WriteLine("Calculadora Dona Mariana");
                Console.WriteLine("Por Paola Oliveira");

                Console.WriteLine();

                Console.WriteLine("Digite 1 para Somar");
                Console.WriteLine("Digite 2 para Subtrair");
                Console.WriteLine("Digite 3 para Multiplicar");
                Console.WriteLine("Digite 4 para Dividir");
                Console.WriteLine("Digite 5 para a tabuada");

                Console.WriteLine("Digite S para sair");

                string operacao = Console.ReadLine();

                if (operacao == "S" || operacao == "s")
                {
                    break;
                }

                if(operacao == "5")
                {
                    Console.Write("Digite o número para gerar a tabuada: ");

                    int tabuada = Convert.ToInt32(Console.ReadLine());

                    for (int i = 1; i <= 10; i++)
                    {
                        int resultadoMultiplicacao = tabuada * i;

                        Console.WriteLine(tabuada + " x " + i + " = " + resultadoMultiplicacao);
                    } 
                    Console.ReadLine();
                    continue;
                }

                if (operacao != "1" && operacao != "2" && operacao != "3" && operacao != "4" && operacao != "5")
                {
                    Console.WriteLine("Operação Inválida, tente novamente!");
                    Console.ReadLine();
                    continue; //volta para o início do laço
                }

                Console.WriteLine();

                Console.Write("Digite o primeiro número: ");

                decimal primeiroNumero = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Digite o segundo número: ");

                decimal segundoNumero = Convert.ToDecimal(Console.ReadLine());

                decimal resultado = 0;

                switch (operacao)
                {
                    case "1": resultado = primeiroNumero + segundoNumero; break;

                    case "2": resultado = primeiroNumero - segundoNumero; break;  

                    case "3": resultado = primeiroNumero * segundoNumero; break;  

                    case "4":
                        { 
                            while (segundoNumero == 0)
                            {
                                Console.WriteLine("O segundo número não pode ser ZERO, tente novamente.");

                                Console.ReadLine();

                                Console.Write("Digite o segundo número: ");

                                segundoNumero = Convert.ToInt32(Console.ReadLine());
                            }
                                resultado = primeiroNumero / segundoNumero;
                                break;
                        }
                    
                    default:
                        break;
                }

                decimal resultadoFormatado = Math.Round(resultado, 2);

                Console.WriteLine("o resultado da sua operação é: " + resultadoFormatado);

                Console.ReadLine();

            } while (true);
        }
    }
}
