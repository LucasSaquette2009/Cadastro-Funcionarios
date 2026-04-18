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

        /// <summary>
        /// Função para validar se a entrada do usuário contém apenas letras, com opção de ser um campo opcional (permitindo entrada vazia).
        /// </summary>
        /// <param name="mensagem">Mensagem Atribuída pra cada variavel, está no menu_cases</param>
        /// <param name="opcional">Se a opção "opcional" for verdadeira, o usuário pode deixar a entrada em branco, retornando null nesse caso. Caso contrário, a função retorna a string válida inserida pelo usuário.</param>
        /// <returns>Retorna somente letras, ou null caso usuario deixe em branco</returns>
        public static string SoLetras(string mensagem, bool opcional = false)
        {
            string entrada;
            Console.Write(mensagem);
            while (true)
            {
                entrada = Console.ReadLine()!;
                if (opcional && string.IsNullOrWhiteSpace(entrada))
                {
                    //se a opção for opcional e o usuário deixar em branco, retorna null.
                    return null!;
                }
                if (!string.IsNullOrWhiteSpace(entrada) && !entrada.Any(char.IsDigit))
                {
                    //se a entrada não for vazia e não contiver dígitos, retorna a entrada válida.
                    return entrada;
                }
                ApagarAviso();
                Console.Write("Caractér incorreto!! " + mensagem);
            }
        }

        /// <summary>
        /// Solicita ao usuário que insira um número inteiro positivo, validando a entrada para garantir que seja um número válido e não negativo.
        /// A função continua solicitando até que uma entrada válida seja fornecida. O valor é retornado como um inteiro.
        /// </summary>
        /// <param name="mensagem">Mensagem Atribuída pra cada variavel, está no menu_cases</param>
        /// <returns>Retorna somente numero inteiro</returns>
        public static int SoNumeros(string mensagem)
        {
            int valor;
            Console.Write(mensagem);
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                //se a entrada não for um número inteiro válido ou for negativa, exibe uma mensagem de erro e solicita novamente.
                ApagarAviso();
                Console.Write("Caractér incorreto!! " + mensagem);
            }
            return valor;
        }

        /// <summary>
        /// Solicita ao usuário que insira uma string que corresponda a um padrão específico definido por uma expressão regular (regex).
        /// A função continua solicitando até que a entrada do usuário corresponda ao padrão fornecido.
        /// </summary>
        /// <param name="mensagem">Mensagem Atribuída pra cada variavel, está no menu_cases</param>
        /// <param name="padraoRegex">Variavel pra guardar o padrão, colocada em cada func</param>
        /// <param name="opcional">Se a opção "opcional" for verdadeira, o usuário pode deixar a entrada em branco, retornando null nesse caso. Caso contrário, a função retorna a string válida inserida pelo usuário.</param>
        /// <returns>Retorna somente o que está dentro do padrão, ou null caso deixe em branco</returns>
        public static string Soespecifico(string mensagem, string padraoRegex, bool opcional = false)
        {
            string especifico;
            Console.Write(mensagem);
            while (true)
            {
                especifico = Console.ReadLine()!;
                if (opcional && string.IsNullOrWhiteSpace(especifico))
                {
                    //se a opção for opcional e o usuário deixar em branco, retorna null.
                    return null!;
                }

                if (Regex.IsMatch(especifico, padraoRegex))
                {
                    //se a entrada corresponder ao padrão regex fornecido, retorna a entrada válida.
                    return especifico;
                }

                ApagarAviso();
                Console.Write("Caractér incorreto!! " + mensagem);
            }
        }

        /// <summary>
        /// Solicita ao usuário que insira um número inteiro que corresponda a um padrão específico definido por uma expressão regular (regex).
        /// </summary>
        /// <param name="mensagem">Mensagem Atribuída pra cada variavel, está no menu_cases</param>
        /// <param name="padrao">Variavel pra guardar o padrão, colocada em cada func</param>
        /// <returns>Retorna o padrão, mas em tipo int</returns>
        public static int Soespecificoint(string mensagem, string padraoRegex)
        {
            //Puxa o resultado da função Soespecifico e depois converte o resultado para um inteiro usando int.Parse.
            string resultado = Soespecifico(mensagem, padraoRegex);
            return int.Parse(resultado);
        }

        /// <summary>
        /// Solicita ao usuário que insira uma data, validando a entrada para garantir que
        /// seja uma data válida e que esteja dentro de um intervalo razoável (entre 150 anos atrás e a data atual).
        /// </summary>
        /// <param name="mensagem">Mensagem Atribuída pra cada variavel, está no menu_cases</param>
        /// <param name="opcional">Se a opção "opcional" for verdadeira, o usuário pode deixar a entrada em branco, retornando null nesse caso. Caso contrário, a função retorna a string válida inserida pelo usuário.</param>
        /// <returns>Retorna somente uma data, ou null caso deixe em branco</returns>
        public static DateTime? Sodata(string mensagem, bool opcional = false)
        {
            DateTime data;
            Console.Write(mensagem);
            while (true)
            {
                string entrada = Console.ReadLine()!;

                if (opcional && string.IsNullOrWhiteSpace(entrada))
                {
                    //se a opção for opcional e o usuário deixar em branco, retorna null.
                    return null;
                }

                if (DateTime.TryParse(entrada, out data) && data <= DateTime.Now && data >= DateTime.Now.AddYears(-150))
                {
                    //se a entrada for uma data válida e estiver dentro do intervalo permitido, retorna a data válida.
                    return data;
                }
                ApagarAviso();
                Console.Write("Caractér incorreto!! " + mensagem);
            }
        }

        /// <summary>
        /// Solicita ao usuário que escolha se deseja repetir uma ação, apresentando opções para "Sim" ou "Não".
        /// A função valida a entrada do usuário para garantir que seja uma opção válida (1 para Sim e 2 para Não).
        /// </summary>
        /// <returns>retorna um valor booleano indicando a escolha do usuário (true para Sim e false para Não).</returns>
        public static bool QuerRepetir()
        {
            int resposta;
            Console.WriteLine("\nQuer Repetir? ");
            Console.WriteLine("[1]- Sim");
            Console.WriteLine("[2]- Não\n");
            Console.Write("Opção: ");
            while (!int.TryParse(Console.ReadLine(), out resposta) || resposta < 1 || resposta > 2)
            {
                //se a entrada não for um número inteiro válido ou não for 1 ou 2, exibe uma mensagem de erro e solicita novamente.
                ApagarAviso();
                Console.Write("Opção inválida, Opção: ");
            }
            return resposta == 1;
        }

        /// <summary>
        /// Apaga a última linha exibida no console, limpando o conteúdo e reposicionando o cursor para a posição correta.
        /// </summary>
        public static void ApagarAviso()//sistema apagar linha, apaga pra linha unica
        {
            //Apaga a última linha exibida no console, limpando o conteúdo e reposicionando o cursor para a posição correta.
            Console.Beep();
            int linha = Console.CursorTop;
            Console.SetCursorPosition(0, linha - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, linha - 1);
        }

        public static bool Contarfuncionario(List<Funcionario> funcionarios)
        {
            if (funcionarios.Count == 0)
            {
                //Se funcionarios for igual a 0, mostra a mensagem de que não tem funcionario cadastrado, e volta pro menu ao pressionar qualquer tecla.
                Console.WriteLine("Nenhum funcionário cadastrado!");//Sisteminha que fiz pra ver se tem funcionario cadastrado
                Console.Write("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return true;
            }
            return false;
        }
    }
}
