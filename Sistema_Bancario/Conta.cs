using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario
{
    internal class Conta
    {
        public int Numero { get; set; }
        private decimal Saldo { get; set; }
        private string Senha { get; set; }
        private List<Transacao> _historicoTransacao = new List<Transacao>();
        // Implementar método de cripotografia desenvolvido na disciplina de Arq. comp.
        public Cliente Titular { get; private set; }

        private Conta(Cliente titular, string senha, decimal depositoInicial)
        {
            Titular = titular;
            Senha = senha;
            Saldo = depositoInicial;
        }

        public decimal ChecarSaldo()
        {
            return Saldo;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor do depósito deve ser positivo");

            Saldo += valor;

            _historicoTransacao.Add(new Transacao("deposito", valor));
        }

        public void Sacar(decimal valor)
        {
            if (valor > Saldo) throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= valor;

            _historicoTransacao.Add(new Transacao("saque", valor));
        }

        public void Historico()
        {
            Console.WriteLine("Histórico de transações:");
            foreach (var transacao in _historicoTransacao)
            {
                Console.WriteLine(transacao);
            }
        }

        public bool ValidarSenha(string senha)
        {
            return Senha == senha;
        }
    }
}
