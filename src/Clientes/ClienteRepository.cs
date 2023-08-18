public class ClasseRepository
{
    private static ClientesDatabase database = new ClientesDatabase();

    public static bool AddCliente(Cliente cliente)
    {
        database.clientes.Add(cliente);
        return true;
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
    public static void BuscarPorId(int id)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Id == id)
            {
                MostrarInformacoes(cliente);
                break;
            }
        }
    }

    public static void BuscarPorCPF(string cpf)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.CPF == cpf)
            {
                MostrarInformacoes(cliente);
                break;
            }
        }
    }

    public static void BuscarPorNome(string nome)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                MostrarInformacoes(cliente);
                break;
            }
        }
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
