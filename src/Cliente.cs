using System;

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
        
    }
}
