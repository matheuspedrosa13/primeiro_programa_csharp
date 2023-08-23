using System;
using System.Collections.Generic;

public class VendaService
{
    private VendaRepository vendaRepository;

    public VendaService(VendaRepository repository)
    {
        vendaRepository = repository;
    }

    public void RealizarNovaVenda(int clienteID, int produtoID, int quantidade, FormaPagamento formaPagamento)
    {
        Cliente cliente = ClienteService.MostrarCliente(clienteID);
        Produto produto = ProdutoService.MostrarProduto(produtoID);

        if (cliente == null || produto == null)
        {
            Console.WriteLine("Cliente ou produto inválido(s).");
            return;
        }

        if (quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida.");
            return;
        }

        if (quantidade > produto.QuantidadeEstoque)
        {
            Console.WriteLine("Quantidade indisponível em estoque.");
            return;
        }

        if (produto.QuantidadeEstoque == 0)
        {
            Console.WriteLine("Não tem estoque o suficiente");
            return;
        }

        if (produto.Status == false)
        {
            Console.WriteLine("Produto indisponível!");
            return;
        }
        
        vendaRepository.AdicionarVenda(clienteID, produtoID, quantidade, formaPagamento);


        Console.WriteLine("Venda realizada com sucesso!");
    }


    public List<Venda> ObterTodasVendas()
    {
        return vendaRepository.ObterTodasVendas();
    }

    public List<Venda> BuscarVendasPorClientes(int clienteID)
    {
        return vendaRepository.BuscarPorCliente(clienteID);
    }

    public List<Venda> BuscarVendasProProduto(int produtoID)
    {
        return vendaRepository.BuscarPorProduto(produtoID);
    }
}
