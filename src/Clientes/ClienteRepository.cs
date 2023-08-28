public class ClienteRepository
{
    private static ClienteService service = new ClienteService();
    public static ClientesDatabase clientesDatabase = new ClientesDatabase();


    public static bool AddCliente(Cliente cliente)
    {
        clientesDatabase.Clientes().Add(cliente);

        return true;
    }

    public static bool AtualizarPorId(int id, string novoNome = null, string novoEmail = null, string novoTelefone = null)
    {
        Cliente clienteParaAtualizar = clientesDatabase.Clientes().FirstOrDefault(client => client.Id == id);

        if (clienteParaAtualizar == null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return false;
        }

        if (!string.IsNullOrEmpty(novoNome))
        {
            if (!ClienteService.TemSobrenome(novoNome) || !ClienteService.NaoContemNumeros(novoNome))
            {
                Console.WriteLine("O nome deve ter pelo menos duas palavras, sem números!");
                return false;
            }
            clienteParaAtualizar.Nome = novoNome;
        }

        if (!string.IsNullOrEmpty(novoEmail))
        {
            clienteParaAtualizar.Email = novoEmail;
        }

        if (!string.IsNullOrEmpty(novoTelefone))
        {
            clienteParaAtualizar.Telefone = novoTelefone;
        }

        return true;
    }



    public static bool AlterarStatusPorId(int id, bool novoStatus){
        foreach (Cliente cliente in clientesDatabase.Clientes())
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
        string telefoneFormatado = FormatarTelefone(cliente.Telefone);
        
        string status = cliente.Status ? "Sim" : "Não";
        
        Console.WriteLine("\nInformações do Cliente:\n");
        Console.WriteLine($"Id: {cliente.Id}\nAtivo: {status}\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {telefoneFormatado}\nEmail: {cliente.Email}");
    }

    public static string FormatarTelefone(string telefone)
    {
        string telefoneLimpo = new string(telefone.Where(char.IsDigit).ToArray());

        if (telefoneLimpo.Length == 10)
        {
            return $"({telefoneLimpo.Substring(0, 2)}) {telefoneLimpo.Substring(2, 4)}-{telefoneLimpo.Substring(6)}";
        }
        else if (telefoneLimpo.Length == 11)
        {
            return $"({telefoneLimpo.Substring(0, 2)}) {telefoneLimpo.Substring(2, 5)}-{telefoneLimpo.Substring(7)}";
        }
        else
        {
            return telefoneLimpo;
        }
    }


    public static void MostrarTodosClientes()
    {
        foreach (Cliente cliente in clientesDatabase.Clientes())
        {
            MostrarInformacoes(cliente);
            Console.WriteLine();
        }
    }

    public static Cliente ObterClientePorId(int id)
    {
        foreach (Cliente cliente in clientesDatabase.Clientes())
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
        MostrarInformacoes(clientesDatabase.Clientes().Where(client => client.Id == id).ToList()[0]);
    }

    public void BuscarPorNome(string nome)
    {
        List<Cliente> clientesEncontrados = clientesDatabase.Clientes()
            .Where(cliente => cliente.Nome.ToLower().Contains(nome.ToLower()))
            .ToList();

        service.contarClientes(clientesEncontrados);

        Console.WriteLine("Clientes encontrados com esse nome:\n");

        foreach (var cliente in clientesEncontrados)
        {
            MostrarInformacoes(cliente);
        }
    }


    public Cliente BuscarPorCPF(string cpf)
    {
        return clientesDatabase.Clientes().Where(client => client.CPF == cpf).ToList()[0];
    }

    public static bool ExisteID(int id)
    {
        foreach (Cliente cliente in clientesDatabase.Clientes())
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
        foreach (Cliente cliente in clientesDatabase.Clientes()){
            if (cliente.Email.Equals(email, StringComparison.OrdinalIgnoreCase)){
                return true;
            }
        }
        return false;
    }
    public static bool ExisteTelefone(string telefone)
    {
        foreach (Cliente cliente in clientesDatabase.Clientes()){
            if (cliente.Telefone.Equals(telefone, StringComparison.OrdinalIgnoreCase)){
                return true;
            }
        }
        return false;
    }
    public static bool ExisteCPF(string cpf)
    {
        foreach (Cliente cliente in clientesDatabase.Clientes()){
            if (cliente.CPF.Equals(cpf, StringComparison.OrdinalIgnoreCase)){
                return true;
            }
        }
        return false;
    }
}
