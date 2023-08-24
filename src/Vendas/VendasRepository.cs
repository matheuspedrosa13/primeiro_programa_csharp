using System.Collections.Generic;

public class VendaRepository
{
    private static VendasDatabase database = new VendasDatabase();
    private static VendaService service = new VendaService();

    private int proximoID = 1;

    public void AdicionarVenda(int clienteID, int produtoID, int quantidade, FormaPagamento formaPagamento)
    {
        bool verificacao = service.RealizarNovaVenda(clienteID, produtoID, quantidade, formaPagamento);
        if(verificacao == true){
            Venda novaVenda = new Venda(clienteID, produtoID, quantidade, formaPagamento)
            {
                Data = DateTime.Now
            };
            clienteID = proximoID;
            database.vendas.Add(novaVenda);
            proximoID++;
            Console.WriteLine("Venda realizada com sucesso!");
        }else{
            Console.WriteLine("Venda não realizada!");
        }
    }

    public void MostrarVendas(List<Venda> vendas)
    {
        foreach (Venda venda in vendas)
        {
            Console.WriteLine($"ID: {venda.ID}");
            Console.WriteLine($"Data: {venda.Data}");
            Console.WriteLine($"Cliente ID: {venda.ClienteID}");
            Console.WriteLine($"Produto ID: {venda.ProdutoID}");
            Console.WriteLine($"Quantidade: {venda.Quantidade}");
            Console.WriteLine($"Forma de Pagamento: {venda.FormaPagamento}");
            Console.WriteLine("--------------");
        }
    }

    public void MostrarTodasVendas()
    {
        MostrarVendas(database.vendas);
    }

    public void MostrarVendasPorCliente(int clienteID)
    {
        List<Venda> vendasFiltradas = BuscarPorCliente(clienteID);
        MostrarVendas(vendasFiltradas);
    }

    public void MostrarVendasPorProduto(int produtoID)
    {
        List<Venda> vendasFiltradas = BuscarPorProduto(produtoID);
        MostrarVendas(vendasFiltradas);
    }

    public List<Venda> ObterTodasVendas()
    {
        return database.vendas;
    }

    public List<Venda> BuscarPorCliente(int clienteID)
    {
        List<Venda> vendasFiltradas = new List<Venda>();

        foreach (Venda venda in database.vendas)
        {
            if (venda.ClienteID == clienteID)
            {
                vendasFiltradas.Add(venda);
            }
        }

        return vendasFiltradas;
    }

    public List<Venda> BuscarPorProduto(int produtoID)
    {
        List<Venda> vendasFiltradas = new List<Venda>();

        foreach (Venda venda in database.vendas)
        {
            if (venda.ProdutoID == produtoID)
            {
                vendasFiltradas.Add(venda);
            }
        }

        return vendasFiltradas;
    }
}
