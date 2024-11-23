using SistemaBancario;

Cliente cliente = new Cliente("João", "845.514.210-30");

Console.WriteLine(cliente.Nome);
Console.WriteLine(cliente.CPF);

var conta = Conta.Criar("123", 90.1m);

conta.Depositar(93.2m);
conta.Sacar(7.45m);

conta.Historico();