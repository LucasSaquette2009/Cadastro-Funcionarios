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
while(voltar)
{
Funcionario f = new Funcionario();//objeto de funcionario
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
            int mat; //variaveis do case
            string nome1, endereco1, cidade1, estado1, cep1, cpf1, tel1, email1;
            DateTime data1 = DateTime.Now;

            //matricula
            Console.Clear();
            Console.WriteLine("Cadastrar um Funcionário\n");
            Console.Write("Informe a matrícula: ");
            while (!int.TryParse(Console.ReadLine(), out mat) || mat < 1)//Verificar se é inteiro ou menor que 0
            {
                Funcoes.ApagarAviso();
                Console.Write("Matrícula está incorreta! Informe a matrícula: ");
            }
            f.Matricula = mat;//variavel temporaria que criei pra a variavel original nao guardar o valor errado

            //Nome
            Console.Write("Informe o nome: ");
            while (string.IsNullOrWhiteSpace(nome1 = Console.ReadLine()!) || !Funcoes.SoLetras(nome1))
            {
                Funcoes.ApagarAviso();
                Console.Write("Nome está incorreto! Informe o Nome: ");
            }
            f.Nome = nome1;

            //endereço
            Console.Write("Informe o endereço: ");
            while (string.IsNullOrWhiteSpace(endereco1 = Console.ReadLine()!))
            {
                Funcoes.ApagarAviso();
                Console.Write("Endereço está incorreto! Informe o endereço: ");
            }
            f.Endereço = endereco1;

            //cidade
            Console.Write("Informe a cidade: ");
            while (string.IsNullOrWhiteSpace(cidade1 = Console.ReadLine()!) || !Funcoes.SoLetras(cidade1))
            {

                Funcoes.ApagarAviso();
                Console.Write("Cidade está incorreta! Informe a Cidade: ");
            }
            f.Cidade = cidade1;

            //estado
            Console.Write("Informe o Estado: ");
            while (string.IsNullOrWhiteSpace(estado1 = Console.ReadLine()!) || !Funcoes.SoLetras(estado1))
            {
                Funcoes.ApagarAviso();
                Console.Write("Estado está incorreto! Informe o Estado: ");
            }
            f.Uf = estado1;

            //CEP
            Console.Write("Informe o CEP: ");
            while (String.IsNullOrWhiteSpace(cep1 = Console.ReadLine()!)
                || !Funcoes.SoNumeros(cep1)
                || cep1.Length != 8) //verifica se é só numero e limita o caracter do cep
            {
                Funcoes.ApagarAviso();
                Console.Write("CEP está incorreto! Informe o CEP: ");
            }
            f.Cep = cep1;

            //CPF
            Console.Write("Informe o CPF: ");
            while (String.IsNullOrWhiteSpace(cpf1 = Console.ReadLine()!)
               || !Funcoes.SoNumeros(cpf1)
               || cpf1.Length != 11)
            {
                Funcoes.ApagarAviso();
                Console.Write("CPF está incorreto! Informe o CPF: ");
            }
            f.Cpf = cpf1;

            //Telefone, eu ajustei pro fixo e telefone movel só
            Console.Write("Informe o telefone (Com DDD): ");
            while (String.IsNullOrWhiteSpace(tel1 = Console.ReadLine()!)
               || !Funcoes.SoNumeros(tel1)
               || tel1.Length < 11 | tel1.Length > 11)
            {
                Funcoes.ApagarAviso();
                Console.Write("Telefone está incorreto! Informe o Telefone: ");
            }
            f.Telefone = tel1;

            //email
            Console.Write("Informe o email: ");
            while (string.IsNullOrWhiteSpace(email1 = Console.ReadLine()!))
            {
                Funcoes.ApagarAviso();
                Console.Write("Email está incorreto! Informe o Email: ");
            }
            f.Email = email1;

            //data de nascimento
            Console.Write("Informe a data de nascimento: ");
            while (!DateTime.TryParse(Console.ReadLine(), out data1) || data1 > DateTime.Now || data1 < DateTime.Now.AddYears(-150))
            {
                Funcoes.ApagarAviso();
                Console.Write("Data está incorreta! Informe a data: ");
            }
            f.Datanasc = data1;

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
                    //matricula
                    Console.Write("Informe a matrícula desejada: ");
                    while (!int.TryParse(Console.ReadLine(), out mat) || mat < 1)
                    {
                        Funcoes.ApagarAviso();
                        Console.Write("Matrícula está incorreta! Informe a matrícula: ");
                    }
                    bool NaoAchou = true; //Variavel bool pra verificar se não achou o func matriculado
                    foreach (var func in funcionarios)
                    {
                        if (func.Matricula == mat) //Verificar um funcionario já matriculado
                        {
                            Console.Clear();
                            NaoAchou = false;

                            //nome
                            Console.Write("Informe o nome: ");
                            while (string.IsNullOrWhiteSpace(nome1 = Console.ReadLine()!) || !Funcoes.SoLetras(nome1))
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("Nome está incorreto! Informe o Nome: ");
                            }
                            func.Nome = nome1;
                            //endereço
                            Console.Write("Informe o endereço: ");
                            while (string.IsNullOrWhiteSpace(endereco1 = Console.ReadLine()!))
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("Endereço está incorreto! Informe o endereço: ");
                            }
                            func.Endereço = endereco1;

                            //cidade
                            Console.Write("Informe a cidade: ");
                            while (string.IsNullOrWhiteSpace(cidade1 = Console.ReadLine()!) || !Funcoes.SoLetras(cidade1))
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("Cidade está incorreta! Informe a Cidade: ");
                                func.Cidade = cidade1;
                            }

                            //estado
                            Console.Write("Informe o Estado: ");
                            while (string.IsNullOrWhiteSpace(estado1 = Console.ReadLine()!) || !Funcoes.SoLetras(estado1))
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("Estado está incorreto! Informe o Estado: ");
                            }
                            func.Uf = estado1;

                            //CEP
                            Console.Write("Informe o CEP: ");
                            while (String.IsNullOrWhiteSpace(cep1 = Console.ReadLine()!)
                                || !Funcoes.SoNumeros(cep1)
                                || cep1.Length != 8) //verifica se é só numero e limita o caracter do cep
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("CEP está incorreto! Informe o CEP: ");
                            }
                            func.Cep = cep1;

                            //CPF
                            Console.Write("Informe o CPF: ");
                            while (String.IsNullOrWhiteSpace(cpf1 = Console.ReadLine()!)
                               || !Funcoes.SoNumeros(cpf1)
                               || cpf1.Length != 11)
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("CPF está incorreto! Informe o CPF: ");
                            }
                            func.Cpf = cpf1;

                            //Telefone, eu ajustei pro fixo e telefone movel só
                            Console.Write("Informe o telefone: ");
                            while (String.IsNullOrWhiteSpace(tel1 = Console.ReadLine()!)
                               || !Funcoes.SoNumeros(tel1)
                               || tel1.Length < 11 || tel1.Length > 11)
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("Telefone está incorreto! Informe o Telefone: ");
                            }
                            func.Telefone = tel1;

                            //email
                            Console.Write("Informe o email: ");
                            while (string.IsNullOrWhiteSpace(email1 = Console.ReadLine()!))
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("Email está incorreto! Informe o Email: ");
                            }
                            func.Email = email1;

                            //data de nascimento
                            Console.Write("Informe a data de nascimento: ");
                            while (!DateTime.TryParse(Console.ReadLine(), out data1) || data1 > DateTime.Now || data1 < DateTime.Now.AddYears(-150))
                            {
                                Funcoes.ApagarAviso();
                                Console.Write("Data está incorreta! Informe a data: ");
                            }
                            func.Datanasc = data1;
                            Console.WriteLine("\nAlterado com sucesso!");
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