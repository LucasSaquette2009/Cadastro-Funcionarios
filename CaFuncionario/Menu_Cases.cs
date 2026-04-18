using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CaFuncionario
{
    internal class Menu_Cases
    {
        /// <summary>
        /// Define as cores padrão do console para o menu, garantindo uma aparência consistente e legível.
        /// </summary>
        public static void Corpadrao()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        /// <summary>
        /// Menu principal do sistema de cadastro de funcionários, 
        /// onde o usuário pode escolher entre as opções disponíveis para gerenciar os registros dos funcionários.
        /// </summary>
        /// <returns>Retornar a variavel opcao para o main</returns>
        public static int Menu()
        {
            Corpadrao();
            //opcoes
            Console.Clear();
            Console.WriteLine(Console.Title);
            Console.WriteLine("Escolha uma das opções abaixo:\n" +
                "\n1. Cadastrar um Funcionário" +
                "\n2. Listar os Funcionários" +
                "\n3. Editar um Funcionário" +
                "\n4. Consultar um Funcionário" +
                "\n5. Excluir um Funcionário" +
                "\n6. Sair\n");
            int opcao = Funcoes.Soespecificoint("Opção: ", @"^[1-6]$");
            return opcao;
        }

        /// <summary>
        /// Cadastro de um novo funcionário,
        /// onde o usuário é solicitado a inserir as informações necessárias para criar um registro completo do funcionário.
        /// </summary>
        /// <param name="funcionarios">Lista onde os funcionarios vai ser armazenados</param>
        public static void Cadastro(List<Funcionario> funcionarios)
        {
            Corpadrao();
            Funcionario f = new Funcionario();//objeto de funcionario
            Console.Clear();
            int mat = Funcoes.SoNumeros("Informe a matrícula: ");
            if (funcionarios.Any(func => func.Matricula == mat))//verificar se a matricula já existe
            {
                //exibe que ja existe um funcionario com a matricula informada
                Console.Write("Matrícula já cadastrada!\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                return;
            }
            else
            {
                //exibe as informações de cadastro.
                f.Matricula = mat;
                f.Nome = Funcoes.SoLetras("Informe o Nome: ");
                f.Endereço = Funcoes.Soespecifico("Informe o endereço: ", @"^[a-zA-Z0-9\s,.-]+$");
                f.Cidade = Funcoes.SoLetras("Informe a cidade: ");
                f.Uf = Funcoes.SoLetras("Informe o Estado: ");
                f.Cep = Funcoes.Soespecifico("CEP (8 DIGITOS): ", @"^\d{8}$");
                f.Cpf = Funcoes.Soespecifico("CPF (11 DIGITOS): ", @"^\d{11}$");
                f.Telefone = Funcoes.Soespecifico("Telefone (11 DIGITOS): ", @"^\d{11}$");
                f.Email = Funcoes.Soespecifico("Informe o email: ", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                f.Datanasc = Funcoes.Sodata("Informe a data de nascimento: ")!.Value;
                Console.Write("Funcionário cadastrado!\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                funcionarios.Add(f); //Jogar as informações pra classe
            }
        }

        /// <summary>
        /// Listar os funcionários cadastrados, exibindo suas informações de forma clara e organizada.
        /// </summary>
        /// <param name="funcionarios">Lista onde os funcionarios vai ser armazenados</param>
        public static void Listar(List<Funcionario> funcionarios)
        {
            Corpadrao();
            Console.Clear();
            Console.WriteLine("Listagem dos Funcionários\n");
            if (Funcoes.Contarfuncionario(funcionarios)) return;
            else
            {
                //Exibe as informações de cada funcionário cadastrado, permitindo ao usuário visualizar os detalhes de cada registro de forma clara e organizada.
                foreach (var item in funcionarios)
                {
                    Console.WriteLine(item.ToString() + "\n");
                }
            }
            Console.Write("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Editar as informações de um funcionário existente, permitindo ao usuário atualizar os dados conforme necessário.
        /// </summary>
        /// <param name="funcionarios">Lista onde os funcionarios vai ser armazenados</param>
        public static void Editar(List<Funcionario> funcionarios)
        {
            do
            {
                Corpadrao();
                Console.Clear();
                Console.WriteLine("Editar funcionários [Enter pra manter]\n");
                if (Funcoes.Contarfuncionario(funcionarios)) return;

                int mat = Funcoes.SoNumeros("Informe a matrícula do funcionário que deseja editar: ");
                var func = funcionarios.Find(f => f.Matricula == mat);

                if (func != null)
                {
                    //se não for nulo, exibe as informações atuais do funcionário e solicita as novas informações,
                    //permitindo ao usuário manter os valores atuais pressionando Enter.
                    Console.Clear();
                    Console.WriteLine($"Editar o funcionário [Matrícula: {func.Matricula}]\n");
                    func.Nome = Funcoes.SoLetras($"Atual: [{func.Nome}] Novo Nome: ", true) ?? func.Nome;
                    func.Endereço = Funcoes.Soespecifico($"Atual: [{func.Endereço}] Novo Endereço: ", @"^[a-zA-Z0-9\s,.-]+$", true) ?? func.Endereço;
                    func.Cidade = Funcoes.SoLetras($"Atual: [{func.Cidade}] Nova Cidade: ", true) ?? func.Cidade;
                    func.Uf = Funcoes.SoLetras($"Atual: [{func.Uf}] Novo Estado: ", true) ?? func.Uf;
                    func.Cep = Funcoes.Soespecifico($"Atual: [{func.Cep}] Novo CEP: ", @"^\d{8}$", true) ?? func.Cep;
                    func.Cpf = Funcoes.Soespecifico($"Atual: [{func.Cpf}] Novo CPF: ", @"^\d{11}$", true) ?? func.Cpf;
                    func.Telefone = Funcoes.Soespecifico($"Atual: [{func.Telefone}] Novo Telefone: ", @"^\d{11}$", true) ?? func.Telefone;
                    func.Email = Funcoes.Soespecifico($"Atual: [{func.Email}] Novo Email: ", @"^[^@\s]+@[^@\s]+\.[^@\s]+$", true) ?? func.Email;
                    func.Datanasc = Funcoes.Sodata($"Atual: [{func.Datanasc:dd/MM/yyyy}] Nova Data: ", true) ?? func.Datanasc;
                }
                else
                {
                    //se for nulo, exibe uma mensagem de erro indicando que o funcionário não foi encontrado.
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Funcionario não encontrado!");
                    Console.ResetColor();
                }
            } while (Funcoes.QuerRepetir());
        }

        /// <summary>
        /// Consultar as informações de um funcionário específico,
        /// permitindo ao usuário visualizar os detalhes do registro do funcionário com base na matrícula fornecida.
        /// </summary>
        /// <param name="funcionarios">Lista onde os funcionarios vai ser armazenados</param>
        public static void Consultar(List<Funcionario> funcionarios)
        {
            do
            {
                Corpadrao();
                Console.Clear();
                Console.WriteLine("Consulta de funcionário\n");
                if (Funcoes.Contarfuncionario(funcionarios)) return;

                int mat = Funcoes.SoNumeros("Informe a matrícula: ");
                var funcionario = funcionarios.Find(f => f.Matricula == mat);

                if (funcionario != null)
                {
                    //se encontrado, exibe as informações do funcionário de forma clara e organizada.
                    Console.Clear();
                    Console.WriteLine("Funcionário encontrado!\n");
                    Console.WriteLine(funcionario);
                }
                else
                {
                    //se não encontrado, exibe uma mensagem de erro indicando que o funcionário não foi encontrado.
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Funcionário não encontrado!");
                    Console.ResetColor();
                }

            } while (Funcoes.QuerRepetir());
        }

        /// <summary>
        /// Excluir um funcionário do sistema, removendo o registro do funcionário com base na matrícula fornecida pelo usuário.
        /// </summary>
        /// <param name="funcionarios">Lista onde os funcionarios vai ser armazenados</param>
        public static void Excluir(List<Funcionario> funcionarios)
        {
            do
            {
                Corpadrao();
                Console.Clear();
                Console.WriteLine("Excluir Funcionário\n");
                if (Funcoes.Contarfuncionario(funcionarios)) return;

                int mat = Funcoes.SoNumeros("Informe a matrícula: ");

                int removidos = funcionarios.RemoveAll(f => f.Matricula == mat);
                if (removidos > 0)
                {
                    //se removidos for maior que 0, exibe uma mensagem de sucesso indicando que o funcionário foi excluído com sucesso.
                    Console.WriteLine("Funcionário excluido com sucesso!");
                }
                else
                {
                    //se removidos for igual a 0, exibe uma mensagem de erro indicando que o funcionário não foi encontrado.
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Matrícula não existente!");
                    Console.ResetColor();
                }
            } while (Funcoes.QuerRepetir());
        }
    }
}
