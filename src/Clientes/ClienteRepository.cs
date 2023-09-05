public class ClienteRepository
{
    private static ClienteService service = new ClienteService();
    public static ClientesDatabase clientesDatabase = new ClientesDatabase();


    public static bool AddCliente(Cliente cliente)
    {
        clientesDatabase.Clientes().Add(cliente);

        return true;
    }


    public int ObterId(){
        return clientesDatabase.Clientes().Count + 1;
    }
    public static bool AtualizarPorId(int id, string novoNome = null!, string novoEmail = null!, string novoTelefone = null!)
    {
        Cliente clienteParaAtualizar = clientesDatabase.Clientes().FirstOrDefault(client => client.Id == id)!;

        if (clienteParaAtualizar == null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return false;
        }

        if (!string.IsNullOrEmpty(novoNome))
        {
            if (!service.TemSobrenome(novoNome) || !service.NaoContemNumeros(novoNome))
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
    public static Cliente MostrarInformacoes(Cliente cliente)
    {
        return cliente;
    }

    public string FormatarTelefone(string telefone)
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


    public void MostrarTodosClientes()
    {
        foreach (Cliente cliente in clientesDatabase.Clientes())
        {
            string telefoneFormatado = FormatarTelefone(cliente.Telefone);
        
            string status = cliente.Status ? "Sim" : "Não";
            Console.WriteLine($"Cliente {cliente.Id}:\n");
            
            Console.WriteLine($"Id: {cliente.Id}\nAtivo: {status}\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {telefoneFormatado}\nEmail: {cliente.Email}\n\n");
    
        }
    }

    public Cliente ObterClientePorId(int id)
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


    public Cliente BuscarPorId(int id)
    {
        Cliente clienteEncontrado = clientesDatabase.Clientes().FirstOrDefault(cliente => cliente.Id == id)!;
        if (clienteEncontrado != null)
        {
            return MostrarInformacoes(clienteEncontrado);
        }
        else
        {
            return null!;
        }
    }

    public void BuscarPorNome(string nome)
    {
        List<Cliente> clientesEncontrados = clientesDatabase.Clientes()
            .Where(cliente => cliente.Nome.ToLower().Contains(nome.ToLower()))
            .ToList();

        bool contarClientes = service.contarClientes(clientesEncontrados);
        if(contarClientes == false){
            Console.WriteLine("Nenhum cliente encontrado.");
        }else{
            Console.WriteLine("Clientes encontrados com esse nome:\n");
            foreach (var cliente in clientesEncontrados)
            {
                string telefoneFormatado = FormatarTelefone(cliente.Telefone);
                string status = cliente.Status ? "Sim" : "Não";
                Console.WriteLine($"Id: {cliente.Id}\nAtivo: {status}\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {telefoneFormatado}\nEmail: {cliente.Email}");
            }
        }
    }


    public Cliente BuscarPorCPF(string cpf)
    {
        Cliente clienteEncontrado = clientesDatabase.Clientes().FirstOrDefault(cliente => cliente.CPF == cpf)!;
        return clienteEncontrado;
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


    public bool ExisteEmail(string email)
    {
        foreach (Cliente cliente in clientesDatabase.Clientes()){
            if (cliente.Email.Equals(email, StringComparison.OrdinalIgnoreCase)){
                return true;
            }
        }
        return false;
    }

    public bool ValidarEmail(string email){
        return service.ValidarEmail(email);
    }
    public bool ValidarTelefone(string telefone){
        return service.ValidarTelefone(telefone);
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
