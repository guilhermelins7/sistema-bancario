using Sistema_Bancario;

var conta = Conta.Criar("1234", 90);

Console.WriteLine(conta.ChecarSaldo());

conta.Depositar(0);

Console.WriteLine(conta.ChecarSaldo());

conta.Sacar(200);

Console.WriteLine(conta.ChecarSaldo());