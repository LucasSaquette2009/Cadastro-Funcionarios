using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CaFuncionario
{
    /// <summary>
    /// Classe pra funcoes extras do menu que eu achei melhor colocar.
    /// </summary>
    public static class Funcoes
    {

        public static string SoLetras(string mensagem)
        {
            string entrada;
            Console.Write(mensagem);
            while (string.IsNullOrWhiteSpace(entrada = Console.ReadLine()!) || entrada.Any(char.IsDigit))
            {
                ApagarAviso();
                Console.Write("Caractér incorreto!! " + mensagem);
            }
            return entrada;
        }


        public static int SoNumeros(string mensagem)
        {
            int valor;
            Console.Write(mensagem);
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                ApagarAviso();
                Console.Write("Caractér incorreto!! " + mensagem);
            }
            return valor;
        }

        public static string Soespecifico(string mensagem, string padraoRegex)
        {
            string especifico;
            Console.Write(mensagem);
            especifico = Console.ReadLine()!;
            while (!Regex.IsMatch(especifico, padraoRegex))
            {
                ApagarAviso();
                Console.Write("Caractér incorreto!! " + mensagem);
                especifico = Console.ReadLine()!;
            }
            return especifico;
        }

        public static DateTime Sodata(string mensagem)
        {
            DateTime data;
            Console.Write(mensagem);
            while (!DateTime.TryParse(Console.ReadLine(), out data) || data > DateTime.Now || data < DateTime.Now.AddYears(-150))
            {
                ApagarAviso();
                Console.Write("Caractér incorreto!! " + mensagem);
            }
            return data;
        }

        public static bool QuerRepetir()
        {
            int resposta;
            Console.WriteLine("\nQuer Repetir? ");
            Console.WriteLine("[1]- Sim");
            Console.WriteLine("[2]- Não\n");
            Console.Write("Opção: ");
            while (!int.TryParse(Console.ReadLine(), out resposta) || resposta < 1 || resposta > 2)
            {
                int linha = Console.CursorTop;
                Console.SetCursorPosition(0, linha - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, linha - 1);
                Console.Write("Opção inválida, Opção: ");
            }
            return resposta == 1;
        }


        public static bool QuerVoltar()
        {
            int resposta;
            Console.WriteLine("Voltar ao menu");
            Console.WriteLine("[1]- Voltar");
            Console.Write("Opção: ");
            while (!int.TryParse(Console.ReadLine(), out resposta) || resposta < 1 || resposta > 1)
            {
                int linha = Console.CursorTop;
                Console.SetCursorPosition(0, linha - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, linha - 1);
                Console.Write("Opção inválida, Opção: ");
            }
            return resposta == 2;
        }

        public static void ApagarAviso()//sistema apagar linha, apaga pra linha unica
        {
            int linha = Console.CursorTop;
            Console.SetCursorPosition(0, linha - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, linha - 1);

        }

        public static void ApagarAviso2()//sistema apagar linha dobrado
        {
            int linha = Console.CursorTop;
            Console.SetCursorPosition(0, linha - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, linha - 2);
            Console.SetCursorPosition(0, linha - 2);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, linha - 2);
        }
    }
}
