using SistemaBancario;

Console.WriteLine("Bem-vindo ao Sistema Bancário!\n");

Console.WriteLine("Para inicar, Informe seu nome e cpf para criar uma conta.");

// Necessário declarar como nulo para tratar exceção no try-catch
Cliente cliente = null;

bool clienteValido = true;

while (clienteValido)
{
    try
    {
        // Criar cliente
        Console.Write("Digite o nome do cliente: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o CPF do cliente: ");
        string cpf = Console.ReadLine();

        cliente = new Cliente(nome, cpf);

        clienteValido = false;
    }
    catch(ArgumentNullException)
    {
        Console.WriteLine("\nNome não pode ser vazio, tente novamente.");
    }
    catch (Exception)
    {
        Console.WriteLine("\nCPF Inválido, tente novamente.");
    }
}

Console.WriteLine("Cliente criado com sucesso!\n");

Console.WriteLine("Agora,vamos criar uma conta.");

// Criar conta
Console.Write("Crie uma senha para a conta: ");
string senha = Console.ReadLine();

Conta conta = null;

do
{
    Console.WriteLine("Deseja fazer um depósito inicial?");
    string resp = Console.ReadLine();
    if (resp == "S")
    {
       Console.Write("Informe o valor do depósito inicial: ");

        decimal depositoInicial;

        while (!decimal.TryParse(Console.ReadLine(), out depositoInicial) || depositoInicial < 0)
        {
            Console.Write("Valor inválido. Tente novamente: ");
        }

        conta = new Conta(cliente, senha, depositoInicial);
    }
    else if (resp == "N")
    {
        conta = new Conta(cliente, senha);
    }
    else Console.WriteLine("Resposta inválida. use \"S\" ou \"N\"");
} while (conta != null);

Conta conta = new Conta(cliente, senha, depositoInicial);

Console.WriteLine("Conta criada com sucesso!");

bool sair = false;

while (!sair)
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine("1 - Consultar Saldo");
    Console.WriteLine("2 - Depositar");
    Console.WriteLine("3 - Sacar");
    Console.WriteLine("4 - Ver Histórico de Transações");
    Console.WriteLine("5 - Sair");
    Console.Write("Opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine($"Saldo atual: R$ {conta.ChecarSaldo():F2}");
            break;

        case "2":
            Console.Write("Digite o valor para depósito: ");
            decimal valorDeposito;
            while (!decimal.TryParse(Console.ReadLine(), out valorDeposito) || valorDeposito <= 0)
            {
                Console.Write("Valor inválido. Tente novamente: ");
            }
            conta.Depositar(valorDeposito);
            Console.WriteLine("Depósito realizado com sucesso!");
            break;

        case "3":
            Console.Write("Digite o valor para saque: ");
            decimal valorSaque;
            while (!decimal.TryParse(Console.ReadLine(), out valorSaque) || valorSaque <= 0)
            {
                Console.Write("Valor inválido. Tente novamente: ");
            }
            try
            {
                conta.Sacar(valorSaque);
                Console.WriteLine("Saque realizado com sucesso!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;

        case "4":
            conta.Historico();
            break;

        case "5":
            sair = true;
            Console.WriteLine("Obrigado por usar o Sistema Bancário!");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}