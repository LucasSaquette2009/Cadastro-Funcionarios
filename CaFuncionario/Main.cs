using CaFuncionario;
using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
Console.Title = "Cadastro de Funcionários\n";
List<Funcionario> funcionarios = new List<Funcionario>();//Lista onde os funcionarios vai ser armazenados.
funcionarios.Add(new Funcionario() { Matricula = 1, Nome = "João Silva", Endereço = "Rua A, 123", Cidade = "São Paulo", Uf = "SP", Cep = "12345678", Cpf = "12345678901", Telefone = "11987654321", Email = "Joao@gmail.com", Datanasc = new DateTime(1990, 5, 15) });
funcionarios.Add(new Funcionario() { Matricula = 2, Nome = "Mariazinha machado", Endereço = "Rua B, 123", Cidade = "São Paulo", Uf = "SP", Cep = "98765432", Cpf = "98765432123", Telefone = "15400289223", Email = "Maria@gmail.com", Datanasc = new DateTime(2010, 2, 20) });
int opcao;
bool voltar = true;
while (voltar)
{
    opcao = Menu_Cases.Menu();
    switch (opcao)
    {
        case 1: //cadastrar
            Menu_Cases.Cadastro(funcionarios);
            break;

        case 2: //listando
            Menu_Cases.Listar(funcionarios);
            break;

        case 3: //editar funcionario
            Menu_Cases.Editar(funcionarios);
            break;

        case 4: //consultar
            Menu_Cases.Consultar(funcionarios);
            break;

        case 5: //excluir
            Menu_Cases.Excluir(funcionarios);
            break;

        case 6: //sair
            Console.Clear();
            Menu_Cases.Corpadrao();
            Console.Write("Saindo...");
            Thread.Sleep(1000);
            voltar = false;
            break;
    }
}