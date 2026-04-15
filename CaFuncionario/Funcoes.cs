using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaFuncionario
{
    /// <summary>
    /// Classe pra funcoes extras do menu que eu achei melhor colocar.
    /// </summary>
    public static class Funcoes
    {
        /// <summary>
        /// Verifica se a string contém apenas letras e espaços.
        /// </summary>
        /// <returns>True se só houver letras e espaços, false caso contrário.</returns>
        public static bool SoLetras(string texto)
        {
            foreach (char c in texto)
            {
                // Se o caractere não for letra e não for espaço, retorna false
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica se a string contém apenas números.
        /// </summary>
        /// <param name="texto">Texto a ser verificado.</param>
        /// <returns>True se só houver números, false caso contrário.</returns>
        public static bool SoNumeros(string texto)
        {
            foreach (char c in texto)
            {
                // Se o caractere não for dígito, retorna false
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Pergunta ao usuário se quer repetir
        /// </summary>
        /// <returns>True se o usuário digitar 1, false caso contrário.</returns>
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
        /// <summary>
        /// Pergunta ao usuário se quer tentar novamente
        /// </summary>
        /// <returns>True se o usuário digitar 1, false caso contrário.</returns>
        /// 
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
