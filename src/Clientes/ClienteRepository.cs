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
        Console.WriteLine("Informações do Cliente:");
        Console.WriteLine($"Id: {cliente.Id}\nStatus: {cliente.Status}\nNome: {cliente.Nome}\nCPF: {cliente.CPF}\nSexo: {cliente.Sexo}\nTelefone: {cliente.Telefone}\nEmail: {cliente.Email}");
    }

    public static void MostrarTodosClientes()
    {
        foreach (Cliente cliente in database.clientes)
        {
            MostrarInformacoes(cliente);
            Console.WriteLine();
        }
    }

    public static void BuscarPorId(int termoBusca)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Id == termoBusca)
            {
                MostrarInformacoes(cliente);
                return;
            }
        }
        Console.WriteLine("Cliente não encontrado");
    }
}