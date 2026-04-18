# 🚀 SISTEMA DE GESTÃO DE FUNCIONÁRIOS (CAFUNCIONARIO)
## 🛠️ FUNCIONALIDADES PRINCIPAIS
🆕 Cadastro Completo: Registro de funcionários com campos protegidos e organizados.

🔍 Busca Inteligente: Localização rápida de colaboradores através do número de matrícula utilizando LINQ.

📝 Edição Flexível: Permite atualizar dados específicos sem necessidade de reescrever tudo. Se pressionar Enter em um campo vazio, o sistema mantém o valor original.

✅ Validações com Regex: Verificação rigorosa de formatos para CPF, CEP, E-mail e Telefone.

🛡️ Filtros de Entrada: Métodos que impedem a inserção de letras em campos numéricos e vice-versa.

## 🧠 CONCEITOS TÉCNICOS APLICADOS
Encapsulamento: Campos private com propriedades public para total segurança.

LINQ & Lambda: Uso de .Any() e .Find() para manipular a lista.

Operador ?? (Null Coalescing): Lógica para manter o dado anterior na edição.

Interpolação de Strings: Uso de $"" para um código mais limpo.
