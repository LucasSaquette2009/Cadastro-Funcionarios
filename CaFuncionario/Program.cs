using CaFuncionario;
using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
Console.Title = "Cadastro de Funcionários\n";
Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;
List<Funcionario> funcionarios = new List<Funcionario>();
funcionarios.Add(new Funcionario() { Matricula = 1, Nome = "João Silva", Endereço = "Rua A, 123", Cidade = "São Paulo", Uf = "SP", Cep = "12345678", Cpf = "12345678901", Telefone = "11987654321", Email = "Joao@gmail.com", Datanasc = new DateTime(1990, 5, 15) });
funcionarios.Add(new Funcionario() { Matricula = 2, Nome = "Mariazinha machado", Endereço = "Rua B, 123", Cidade = "São Paulo", Uf = "SP", Cep = "98765432", Cpf = "98765432123", Telefone = "15400289223", Email = "Maria@gmail.com", Datanasc = new DateTime(2010, 2, 20) });
int opcao;
bool voltar = true;
while (voltar)
{
    //opcoes
    Console.Clear();
    Console.WriteLine(Console.Title);
    Console.WriteLine("Escolha uma das opções abaixo:\n" +
        "\n1. Cadastrar um Funcionário" +
        "\n2. Listar os Funcionários" +
        "\n3. Editar um Funcionário" +
        "\n4. Consultar um Funcionário" +
        "\n5. Excluir um Funcionário" +
        "\n6. Sair");
    Console.Write("\nOpção: ");
    while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 && opcao > 7)
    {
        Funcoes.ApagarAviso2();
        Console.Write("Opção invalida!\nDigite novamente: ");
    }
    switch (opcao)
    {
        case 1: //cadastrar
            Funcionario f = new Funcionario();//objeto de funcionario
            int mat;

            //matricula
            Console.Clear();
           f.Matricula = Funcoes.SoNumeros("Informe a matrícula: ");

            //Nome
            f.Nome = Funcoes.SoLetras("Informe o Nome: ");

            //endereço
            f.Endereço = Funcoes.SoLetras("Informe o endereço: ");

            //cidade
            f.Cidade = Funcoes.SoLetras("Informe a cidade: ");

            //estado
            f.Uf = Funcoes.SoLetras("Informe o Estado: ");

            //CEP
            f.Cep = Funcoes.Soespecifico("CEP (8 DIGITOS): ", @"^\d{8}$");

            //CPF
            f.Cpf = Funcoes.Soespecifico("CPF (11 DIGITOS): ", @"^\d{11}$");

            //Telefone, eu ajustei pro fixo e telefone movel só
            f.Telefone = Funcoes.Soespecifico("Telefone (11 DIGITOS): ", @"^\d{11}$");

            //email
            f.Email = Funcoes.Soespecifico("Informe o email: ", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            //data de nascimento
            f.Datanasc = Funcoes.Sodata("Informe a data de nascimento: ");

            //Jogar as informações pra classe e mostrar que está cadastrado
            funcionarios.Add(f);
            Console.Clear();
            Console.WriteLine("***** Cadastrado com sucesso *****");
            Thread.Sleep(1300);
            break;

        case 2: //listando
            do
            {
                Console.Clear();
                Console.WriteLine("Listagem dos Funcionários\n");
                if (funcionarios.Count == 0)
                {
                    Console.WriteLine("Nenhum funcionário cadastrado!");//Sisteminha que fiz pra ver se tem funcionario cadastrado
                }
                else
                {
                    foreach (var item in funcionarios)
                    {
                        Console.WriteLine(item.ToString() + "\n");
                    }
                }
            } while (Funcoes.QuerVoltar());
            break;

        case 3: //editar funcionario
            do
            {
                Console.Clear();
                Console.WriteLine("Alterando funcionários\n");
                if (funcionarios.Count == 0)
                {
                    Console.WriteLine("Nenhum funcionário cadastrado!");//Sisteminha que fiz pra ver se tem funcionario cadastrado
                    if (!Funcoes.QuerVoltar())
                        break;
                }
                else
                {
                    mat = Funcoes.SoNumeros("Informe a matrícula do funcionário que deseja editar: ");
                    bool NaoAchou = true;
                    foreach (var func in funcionarios)
                    {
                        if (func.Matricula == mat) //Verificar um funcionario já matriculado
                        {
                            Console.Clear();
                            NaoAchou = false;

                            //nome
                            func.Nome = Funcoes.SoLetras("Informe o Nome: ");
                            //endereço
                            func.Endereço = Funcoes.SoLetras("Informe o endereço: ");

                            //cidade
                            func.Cidade = Funcoes.SoLetras("Informe a cidade: ");

                            //estado
                            func.Uf = Funcoes.SoLetras("Informe o Estado: ");

                            //CEP
                            func.Cep = Funcoes.Soespecifico("CEP (8 DIGITOS): ", @"^\d{8}$");

                            //CPF
                            func.Cpf = Funcoes.Soespecifico("CPF (11 DIGITOS): ", @"^\d{11}$");

                            //Telefone, eu ajustei pro fixo e telefone movel só
                            func.Telefone = Funcoes.Soespecifico("Telefone (11 DIGITOS): ", @"^\d{11}$");

                            //email
                            func.Email = Funcoes.Soespecifico("Informe o email: ", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

                            //data de nascimento
                            func.Datanasc = Funcoes.Sodata("Informe a data de nascimento: ");
                        }
                    }
                    if (NaoAchou)
                    {
                        Console.Clear();
                        Console.WriteLine("Funcionario não encontrado!");
                    }
                }
            } while (Funcoes.QuerRepetir());
            break;

        case 4: //consultar
            do
            {
                bool achou = false;
                Console.Clear();
                Console.WriteLine("Consulta de funcionário\n");
                if (funcionarios.Count == 0)
                {
                    Console.WriteLine("Nenhum funcionário cadastrado!");//Sisteminha que fiz pra ver se tem funcionario cadastrado
                    if (!Funcoes.QuerVoltar())
                        break;
                }
                else
                {
                    Console.WriteLine("Qual matricula quer consultar?");
                    Console.Write("Matrícula: ");
                    while (!int.TryParse(Console.ReadLine(), out mat) || mat < 1)
                    {
                        Funcoes.ApagarAviso();
                        Console.Write("Matrícula está incorreta! Informe a matrícula: ");
                    }
                    foreach (var funcionario in funcionarios)
                    {
                        if (funcionario.Matricula == mat)
                        {
                            Console.Clear();
                            Console.WriteLine("Funcionário encontrado!\n");
                            Console.WriteLine(funcionario);
                            achou = true;
                        }
                    }
                    if (!achou)
                    {
                        Console.Clear();
                        Console.WriteLine("Funcionário não encontrado!");
                    }
                }
            } while (Funcoes.QuerRepetir());
            break;

        case 5: //excluir
            do
            {
                Console.Clear();
                Console.WriteLine("Excluir Funcionário");
                Console.Write("\nInforme a matrícula: ");
                if (funcionarios.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Nenhum funcionário cadastrado!");
                    if (!Funcoes.QuerVoltar())
                        break;
                }
                while (!int.TryParse(Console.ReadLine(), out mat) || mat < 1)
                {
                    Funcoes.ApagarAviso();
                    Console.Write("Matrícula invalida! Informe a matrícula: ");
                }
                int removidos = funcionarios.RemoveAll(f => f.Matricula == mat);

                if (removidos > 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nFuncionário excluido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Matrícula não existente!");
                }
            } while (Funcoes.QuerRepetir());
            break;

        case 6:
            Console.Clear();
            Console.Write("Saindo...");
            Thread.Sleep(1000);
            voltar = false;
            break;
    }
}