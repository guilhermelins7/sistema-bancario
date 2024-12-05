using SistemaBancario;

Cliente cliente = new Cliente("João", "845.514.210-30");


var conta = new Conta(cliente, "123", 90.1m);

Console.WriteLine(conta.Senha);