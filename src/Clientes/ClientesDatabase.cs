public class ClientesDatabase
{   
    private List<Cliente> database = new List<Cliente> {
        new Cliente(12, true, "Joao Silva", "23952760811", "Masculino", "11945676569", "joao@example.com"),
        new Cliente(13, true, "Felipe Silva", "98765432100", "Masculino", "11987655432", "felipe@example.com")
    };

    public List<Cliente> Clientes()
    {
        return database;
    }
}
