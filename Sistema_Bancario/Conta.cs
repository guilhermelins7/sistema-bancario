using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bancario
{
    internal class Conta
    {
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        private string Senha { get; set; }
        // Implementar método de cripotografia desenvolvido na disciplina de Arq. comp.
        //public Cliente Titular { get; private set; }

        private Conta() { } // Garantir que a instanciação de nova classe seja feita através do método CriarConta.

        public static Conta Criar(string senha, decimal depositoInicial)
        {
            // Adicionar método para criar novo número de conta do cliente e deposito inicial
            return new Conta
            {
                // Implementar Criação automatica de numeração de conta.
                Senha = senha,
                Saldo = depositoInicial
            };
        }

        public decimal ChecarSaldo()
        {
            return Saldo;
        }

        public void Depositar(decimal valor)
        {
            try
            {
                if (valor <= 0) throw new ArgumentException(); ;

                Saldo += valor;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("O valor do depósito deve ser positivo");
            }
        }

        public void Sacar(decimal valor)
        {
            try
            {
                if (valor > Saldo) throw new InvalidOperationException();
                Saldo -= valor;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Saldo insuficiente.");
            }
        }

        public bool ValidarSenha(string senha)
        {
            return Senha == senha;
        }
    }
}
