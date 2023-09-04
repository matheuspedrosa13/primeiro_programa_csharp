using System;
using System.Collections.Generic;

public class VendaService
{
    private VendaRepository vendaRepository = new VendaRepository();
    private static ProdutoService produtoService = new ProdutoService();

    public bool RealizarNovaVenda(int clienteID, int produtoID, int quantidade, FormaPagamento formaPagamento)
    {
        Produto produto = produtoService.MostrarProduto(produtoID);
        bool clienteExiste = ClienteService.ClienteExiste(clienteID);
        bool produtoExiste = produtoService.ProdutoExiste(produtoID);

        if (!clienteExiste)
        {
            Console.WriteLine("O cliente não existe.");
            return false;
        }

        if (!produtoExiste)
        {
            Console.WriteLine("O produto não existe.");
            return false;
        }

        if (quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida.");
            return false;
        }

        if (produto.Status == false)
        {
            Console.WriteLine("Produto indisponível!");
            return false;
        }
        
        return true;
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
