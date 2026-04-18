🚀 Sistema de Gestão de Funcionários (CaFuncionario)
Bem-vindo ao CaFuncionario! Este é um projeto desenvolvido em C# Console Application focado na gestão eficiente de registos de colaboradores, aplicando os pilares da Programação Orientada a Objetos (POO).

🛠️ Funcionalidades principais
🆕 Cadastro Completo: Registo de funcionários com campos protegidos e organizados.

🔍 Busca Inteligente: Localização rápida de colaboradores através do número de matrícula utilizando LINQ.

📝 Edição Flexível: Permite atualizar dados específicos sem necessidade de reescrever tudo. Se pressionar Enter num campo vazio, o sistema mantém o valor original.

✅ Validações com Regex: Verificação rigorosa de formatos para:

CPF (apenas números, 11 dígitos)

CEP (apenas números, 8 dígitos)

E-mail (validação de formato padrão)

Telefone e Datas.

🛡️ Filtros de Entrada: Métodos personalizados que impedem a inserção de letras em campos numéricos e vice-versa.

🧠 Conceitos Técnicos Aplicados
O projeto foi construído para demonstrar domínio em:

Encapsulamento: Uso de campos private com propriedades public (get/set) para total segurança dos dados.

LINQ & Lambda: Utilização de .Any() para verificar duplicados e .Find() para capturar objetos na lista.

Operador ?? (Null Coalescing): Lógica essencial para a funcionalidade de "manter dado anterior" durante a edição.

Interpolação de Strings: Uso de $"" para um código mais limpo e legível.

Tratamento de Nulidade: Garantia de que o programa não crasha ao lidar com valores vazios.

📁 Estrutura do Código
Menu/Program: Gere o fluxo principal e a interface com o utilizador.

Funcionario.cs: Classe de entidade com a lógica de negócio e encapsulamento.

Funcoes.cs: Biblioteca de utilitários para validações, tratamento de cores e entradas de dados.
