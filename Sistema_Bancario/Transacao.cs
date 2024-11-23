using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario
{
    internal class Transacao
    {
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }

        public Transacao(string tipo, decimal valor)
        {
            Data = DateTime.Now;
            Valor = valor;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"{Data}: {Tipo} de R$ {Valor:F2}.";
        }
    }
}
