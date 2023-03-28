namespace Calculadora.ConsoleApp1
{
    internal class Program
    {

        static string[] descricoesOperacao = new string[100];
        static int quantidadeOperacoesRealizadas = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                string opcaoEscolhida = MostrarMenu();

                if (opcaoEscolhida == "S" || opcaoEscolhida == "s")
                    break;

                if (OpcaoInvalida(opcaoEscolhida))
                    Console.WriteLine("Operação Inválida, tente novamente!");
                    
                else if (opcaoEscolhida == "5")
                    GerarTabuada();

                else if (opcaoEscolhida == "6")
                    VisualizarHistorico();

                else
                    RealizarOperacao(opcaoEscolhida);
            }
        }

        static string MostrarMenu()
        {
            Console.Clear();

            Console.WriteLine("Calculadora Dona Mariana");
            Console.WriteLine("Por Paola Oliveira");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Somar [+]");
            Console.WriteLine("Digite 2 para Subtrair [-]");
            Console.WriteLine("Digite 3 para Multiplicar [*]");
            Console.WriteLine("Digite 4 para Dividir [/]");
            Console.WriteLine("Digite 5 para gerar tabuada.");
            Console.WriteLine("Digite 6 para visualizar seu histórico.");

            Console.WriteLine("Ou digite S para sair!");

            string operacao = Console.ReadLine();

            return operacao;
        }

        static bool OpcaoInvalida(string opcaoEscolhida)
        {
            bool opcaoInvalida =
            opcaoEscolhida != "1" &&
            opcaoEscolhida != "2" &&
            opcaoEscolhida != "3" &&
            opcaoEscolhida != "4" &&
            opcaoEscolhida != "5" &&
            opcaoEscolhida != "6" &&
            opcaoEscolhida != "s" &&
            opcaoEscolhida != "S";

            return opcaoInvalida;

        }

        static void GerarTabuada()
        {
            Console.Write("Digite o número para gerar a tabuada: ");

            int tabuada = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int resultadoMultiplicacao = tabuada * i;

                Console.WriteLine(tabuada + " x " + i + " = " + resultadoMultiplicacao);
            }
            Console.ReadLine();
        }

        static void VisualizarHistorico()
        {
            for (int i = 0; i < descricoesOperacao.Length; i++)
            {
                if (descricoesOperacao[i] != null)
                    Console.WriteLine(descricoesOperacao[i]);
            }

            Console.ReadLine();
        }

        static void RegistrarCalculo(decimal primeiroNumero, string sinalOperacao, decimal segundoNumero, decimal resultado)
        {
            descricoesOperacao[quantidadeOperacoesRealizadas] =
                primeiroNumero + " " + sinalOperacao + " " + segundoNumero + " = " + resultado;

            quantidadeOperacoesRealizadas++;
        }
       
        static decimal ObterValorDecimal(string mensagem)
        {
            Console.WriteLine();

            Console.Write(mensagem);

            decimal numero = Convert.ToDecimal(Console.ReadLine());

            return numero;
        }
        
        static void RealizarOperacao(string operacao)
        {
            decimal primeiroNumero = ObterValorDecimal("Digite o primeiro número: ");

            decimal segundoNumero = ObterValorDecimal("Digite o segundo número: ");

            decimal resultado = ObterResultado(operacao, primeiroNumero, ref segundoNumero);

            Console.WriteLine();

            Console.WriteLine($"O resultado dessa operação é: {resultado}");

            string sinalOperacao = ObterSinalOperacao(operacao);

            RegistrarCalculo(primeiroNumero, sinalOperacao, segundoNumero, resultado);

            Console.ReadLine();
        }

        static string ObterSinalOperacao(string operacao)
        {
            string sinalOperacao = "";

            switch (operacao)
            {
                case "1": sinalOperacao = "+"; break;

                case "2": sinalOperacao = "-"; break;

                case "3": sinalOperacao = "*"; break;

                case "4": sinalOperacao = "/"; break;

                default:
                    break;
            }

            return sinalOperacao;
        }

        static decimal ObterResultado(string operacao, decimal primeiroNumero, ref decimal segundoNumero)
        {
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

                            Console.WriteLine(); 

                            Console.Write("Digite o segundo número: ");

                            segundoNumero = Convert.ToInt32(Console.ReadLine());
                        }

                        resultado = primeiroNumero / segundoNumero;
                        break;
                    }

                default:
                    break;
            }

            return Math.Round(resultado, 2);
        }

    }

}
