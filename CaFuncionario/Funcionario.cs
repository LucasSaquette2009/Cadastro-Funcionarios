using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CaFuncionario
{
    /// <summary>
    /// Representa um funcionário de uma empresa, com informações pessoais e de contato.
    /// </summary>
    class Funcionario
    {
        // Campos privados
        private int matricula;
        private string nome;
        private string endereço;
        private string cidade;
        private string uf;
        private string cep;
        private string cpf;
        private string telefone;
        private string email;
        private DateTime datanasc;

        /// <summary>
        /// Matrícula do funcionário.
        /// </summary>
        public int Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        /// <summary>
        /// Nome do funcionário.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Endereço do funcionário.
        /// </summary>
        public string Endereço
        {
            get { return endereço; }
            set { endereço = value; }
        }

        /// <summary>
        /// Cidade do funcionário.
        /// </summary>
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        /// <summary>
        /// Unidade Federativa (UF) do funcionário.
        /// </summary>
        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }

        /// <summary>
        /// CEP do funcionário.
        /// </summary>
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        /// <summary>
        /// CPF do funcionário.
        /// </summary>
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        /// <summary>
        /// Telefone do funcionário.
        /// </summary>
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        /// <summary>
        /// E-mail do funcionário.
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Data de nascimento do funcionário.
        /// </summary>
        public DateTime Datanasc
        {
            get { return datanasc; }
            set { datanasc = value; }
        }

        /// <summary>
        /// Construtor padrão que inicializa os campos com valores padrão.
        /// </summary>
        public Funcionario()
        {
            Matricula = 0;
            Nome = "";
            Endereço = "";
            Cidade = "";
            Uf = "";
            Cep = "";
            Cpf = "";
            Telefone = "";
            Email = "";
            Datanasc = DateTime.Now;
        }

        /// <summary>
        /// Calcula a idade do funcionário com base na data de nascimento.
        /// </summary>
        /// <returns>Idade em anos.</returns>
        public int Idade()
        {
            int idade = DateTime.Now.Year - datanasc.Year;
            int mes = datanasc.Month;
            int dia = datanasc.Day;

            // Ajusta a idade se ainda não chegou o aniversário deste ano
            if (DateTime.Now.Month < mes || (DateTime.Now.Month == mes && DateTime.Now.Day < dia))
            {
                idade--;
            }

            return idade;
        }

        /// <summary>
        /// Retorna uma string com todas as informações do funcionário.
        /// </summary>
        /// <returns>Informações completas do funcionário.</returns>
        public override string ToString()
        {
            return "Funcionário:" +
                $"\nMatricula: " + Matricula +
                "\nNome: " + Nome +
                "\nEndereço: " + Endereço +
                "\nCidade: " + Cidade +
                "\nUf: " + Uf +
                "\nCep: " + Cep +
                "\nCpf: " + Cpf +
                "\nTelefone: " + Telefone +
                "\nEmail: " + Email +
                "\nData nasc: " + Datanasc.ToString("dd/MM/yyyy") +
                "\nIdade: " + Idade();
        }
    }
}