public class ClientesDatabase
{   
    private int nextId = 1;
    public List<Cliente> clientes = new(){
        new Cliente(12, true, "João Silva", "12345678900", "Masculino", "11945676569", "joao@example.com"),
        new Cliente(13, true, "Felipe Silva", "987654321-00", "Masculino", "11987655432", "felipe@example.com")
    };
    public int GetNextId()
    {
        return nextId++;
    }
}