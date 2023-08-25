public class ClienteRepository
{
    private static ClientesDatabase database = new ClientesDatabase();
    private static ClienteService service = new ClienteService();


    public static bool AddCliente(Cliente cliente)
    {
        database.clientes.Add(cliente);
        return true;
    }

    public static bool AtualizarPorId(int id, string novoNome, string novoEmail, string novoTelefone)
    {
        for (int i = 0; i < database.clientes.Count; i++)
        {
            if (database.clientes[i].Id == id)
            {
                if (!ClienteService.TemSobrenome(novoNome) || !ClienteService.NaoContemNumeros(novoNome))
                {
                    Console.WriteLine("O nome deve ter pelo menos duas palavras, sem números!");
                    return false;
                }

                Cliente clienteAtualizado = database.clientes[i];
                clienteAtualizado.Nome = novoNome;
                clienteAtualizado.Email = novoEmail;
                clienteAtualizado.Telefone = novoTelefone;

                return true;
            }
        }
        return false;
    }


    public static bool AlterarStatusPorId(int id, bool novoStatus){
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Id == id){
                cliente.Status = novoStatus;
                return true;
            }
        }
        return false;
    }
    public static void MostrarInformacoes(Cliente cliente)
    {
        if(cliente.Status == true){
            Console.WriteLine("\nInformações do Cliente:\n");
            Console.WriteLine($"Id: {cliente.Id}\nAtivo: Sim\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {cliente.Telefone}\nEmail: {cliente.Email}");
        }else{
            Console.WriteLine("\nInformações do Cliente:\n");
            Console.WriteLine($"Id: {cliente.Id}\nAtivo: Não\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {cliente.Telefone}\nEmail: {cliente.Email}");
        }
      
    }

    public static void MostrarTodosClientes()
    {
        foreach (Cliente cliente in database.clientes)
        {
            MostrarInformacoes(cliente);
            Console.WriteLine();
        }
    }

    public static Cliente ObterClientePorId(int id)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Id == id)
            {
                return cliente;
            }
        }
        return null!;
    }


    public void BuscarPorId(int id)
    {
        service.BuscarPorId(id);
    }

    public Cliente BuscarPorCPF(string cpf)
    {
        return service.BuscarPorCPF(cpf); // Chama o método no repositório
    }
    public void BuscarPorNome(string nome)
    {
        service.BuscarPorNome(nome);
        
    }

    public static bool ExisteID(int id)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Id == id)
            {
                return true;
            }
        }
        return false;
    }


    public static bool ExisteEmail(string email)
    {
        foreach (Cliente cliente in database.clientes){
            if (cliente.Email.Equals(email, StringComparison.OrdinalIgnoreCase)){
                return true;
            }
        }
        return false;
    }
    public static bool ExisteTelefone(string telefone)
    {
        foreach (Cliente cliente in database.clientes){
            if (cliente.Telefone.Equals(telefone, StringComparison.OrdinalIgnoreCase)){
                return true;
            }
        }
        return false;
    }
    public static bool ExisteCPF(string cpf)
    {
        foreach (Cliente cliente in database.clientes){
            if (cliente.CPF.Equals(cpf, StringComparison.OrdinalIgnoreCase)){
                return true;
            }
        }
        return false;
    }
}
