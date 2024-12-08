namespace SistemaBancario
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public Cliente(string nome, string cpf)
        {
            if (!ValidarCPF(cpf)) throw new Exception("CPF informado é inválido");

            Nome = nome;
            CPF = cpf;
        }

        private bool ValidarCPF(string cpf)
        {
            // Remove possíveis máscaras (pontos e traços)
            cpf = cpf.Replace(".", "").Replace("-", "");

            int[] multiplicadoresPrimeiro = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundo = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11 || !cpf.All(char.IsDigit) || /*verificar caracteres iquais*/ new string(cpf[0], 11) == cpf)
                return false;

            string cpfParcial = cpf.Substring(0, 9); // Extrair substring 0 à 9.
            int primeiroDigito = CalcularDigito(cpfParcial, multiplicadoresPrimeiro);
            int segundoDigito = CalcularDigito(cpfParcial + primeiroDigito, multiplicadoresSegundo);

            // Retorna se os dígitos calculados batem com os fornecidos
            /* obs de expressão vista em aula: em ASCII '0' = 48, '1' = 49...
            para obter o inteiro dentro do Array de string x - '0' = int */

            return cpf[9] - '0' == primeiroDigito && cpf[10] - '0' == segundoDigito;

            // Função para calcular o dígito verificador
            int CalcularDigito(string cpfParcial, int[] multiplicadores)
            {
                int soma = 0;

                for (int i = 0; i < multiplicadores.Length; i++)
                {
                    soma += (cpfParcial[i] - '0') * multiplicadores[i];
                }

                int resto = soma % 11;
                return resto < 2 ? 0 : 11 - resto;
            }
        }
    }
}
