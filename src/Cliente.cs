using System;
using System.Text.RegularExpressions;

namespace ClasseCliente
{
    class Cliente
    {   
        
        public int Id {get; set;}
        public bool Status {get; set;}
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Construtor que aceita parâmetros para todas as propriedades
        public Cliente(int id, bool status, string nome, string cpf, string sexo, string telefone, string email)
        {   
            Id = id;
            Status = status;
            Nome = nome;
            CPF = cpf;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
        }

        public void MostrarInformacoes()
        {
            Console.WriteLine("Informações do Cliente:");
            Console.WriteLine($"Id: {Id}\nStatus: {Status}\nNome: {Nome}\nCPF: {CPF}\nSexo: {Sexo}\nTelefone: {Telefone}\nEmail: {Email}");
        }
        public static void BuscarPorId(List<Cliente> clientes, int termoBusca)
        {
            foreach (Cliente cliente in clientes)
            {   
                if (cliente.Id == termoBusca)
                {
                    Console.WriteLine($"Informações do Cliente:\nId: {cliente.Id}\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {cliente.Telefone}\nEmail: {cliente.Email}");
                    return;
                }
            }
        }



        public static string BuscarPorNome(List<Cliente> clientes, string termoBusca)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Nome == termoBusca)
                {
                    return $"Informações do Cliente:\nId: {cliente.Id}\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {cliente.Telefone}\nEmail: {cliente.Email}";
                }
            }

            return "Cliente com esse nome não encontrado";
        }
        public static string BuscarPorCPF(List<Cliente> clientes, string termoBusca)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.CPF == termoBusca)
                {
                    return $"Informações do Cliente:\nId: {cliente.Id}\nStatus: {cliente.Status}\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {cliente.Telefone}\nEmail: {cliente.Email}";
                }
            }

            return "Cliente com esse CPF não encontrado";
        }

        public static bool CadastrarCliente(int id, string nome, string cpf, string sexo, string telefone, string email){
            if (!TemSobrenome(nome)){
                Console.Write("O nome deve ter um sobrenome!");
                return false;
            }else if(NaoContemNumeros(nome)){
                Console.WriteLine("O nome não pode conter números!");
                return false;
            }
            if(!ValidarCPF(cpf)){
                Console.Write("CPF inválido!");
                return false;
            }

            Cliente cliente1 = new Cliente(id, true, nome, cpf, sexo, telefone, email);
            return true;
        }

        static bool TemSobrenome(string nome){
            string[] partesNome = nome.Split(' ');
            return partesNome.Length >= 2;
        }

        static bool NaoContemNumeros(string texto){
            foreach (char c in texto){
                if (char.IsDigit(c)){
                    return false;
                }
            }
            return true;
        }
        static bool ValidarCPF(string cpf)
        {
            cpf = Regex.Replace(cpf, @"[^\d]", ""); 
            if (cpf.Length != 11)
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
