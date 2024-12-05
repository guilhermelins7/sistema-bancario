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
        public Cliente Titular { get; private set; }
        private List<Transacao> _historicoTransacao = new List<Transacao>();
        // Implementar método de cripotografia desenvolvido na disciplina de Arq. comp.

        public Conta(Cliente titular, string senha, decimal depositoInicial)
        {
            Titular = titular;
            Senha = CriptografarSenha(senha);
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

        // Algoritmo utilizado em Arq. de Comp.
        private string CriptografarSenha(string senha)
        {
            senha = Reverter(senha);
            senha = CifraDeCesar(senha);
            senha = Criptografar(senha);

            static string Reverter(string senha)
            {
                string resultado = "";

                for (int index = senha.Length - 1; index >= 0; index--)
                {
                    resultado += senha[index];
                }

                return resultado;
            }

            static string CifraDeCesar(string senha)
            {
                string resultado = "";

                for (int index = 0; index < senha.Length; index++) // Aplicação cifra de cesar
                {
                    int aux = (int)senha[index] + 3; // convertando para valor ASCII inteiro e adicionando + 3;
                    resultado += (char)aux; // retornando para char e adicionando à string.
                }

                return resultado;
            }

            static string Criptografar(string senha)
            {
                string criptografia = "";
                int aux;
                int valor = 0;

                for (int index = 0; index < senha.Length; index++)
                {
                    aux = (int)(senha[index] + (Math.Pow(2, valor) + 1)); // Aplicando função do TP.
                    criptografia += (char)aux;
                    valor++;

                    if (valor == 3)
                    {
                        valor = 0;
                    }
                }

                return criptografia;
            }

            return senha;
        }

        public bool ValidarSenha(string senha)
        {
            return Senha == senha;
        }
    }
}
