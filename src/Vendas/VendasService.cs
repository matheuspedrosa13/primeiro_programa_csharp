using System;
using System.Collections.Generic;

public class VendaService
{
    private VendaRepository vendaRepository = new VendaRepository();

    public bool RealizarNovaVenda(int clienteID, int produtoID, int quantidade, FormaPagamento formaPagamento)
    {
        Cliente cliente = ClienteService.MostrarCliente(clienteID);
        Produto produto = ProdutoService.MostrarProduto(produtoID);
        bool clienteExiste = ClienteService.ClienteExiste(clienteID);
        bool produtoExiste = ProdutoService.ProdutoExiste(produtoID);

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

        if (quantidade > produto.QuantidadeEstoque)
        {
            Console.WriteLine("Quantidade indisponível em estoque.");
            return false;
        }

        if (produto.QuantidadeEstoque == 0)
        {
            Console.WriteLine("Não tem estoque o suficiente");
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
