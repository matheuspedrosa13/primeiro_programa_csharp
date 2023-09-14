public class ClientesDatabase
{   
    private List<Cliente> database = new List<Cliente> {
        new Cliente(1, true, "Joao Silva", "23952760811", "Masculino", "11945676569", "joao@example.com"),
        new Cliente(2, true, "Felipe Silva", "98765432100", "Masculino", "11987655432", "felipe@example.com")
    };
    public void AdicionarCliente(Cliente cliente)
    {
        database.Add(cliente);
    }


    public List<Cliente> Clientes()
    {
        return database;
    }
}
