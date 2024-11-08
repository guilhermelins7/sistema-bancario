using Sistema_Bancario;

var conta = Conta.Criar("1234", 900);

Console.WriteLine(conta.ChecarSaldo());

conta.Depositar(900);

Console.WriteLine(conta.ChecarSaldo());

conta.Sacar(90);

Console.WriteLine(conta.ChecarSaldo());