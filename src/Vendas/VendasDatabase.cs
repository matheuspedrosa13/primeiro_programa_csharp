using System;
using System.Collections.Generic;

public class VendasDatabase
{
    public List<Venda> vendas = new()
    {
        new Venda(1, 101, 201, 3, FormaPagamento.CartaoDeCredito){
            Data = DateTime.Now.AddDays(-10)
        },
        new Venda(2, 231, 322, 100, FormaPagamento.Dinheiro){
            Data = DateTime.Now.AddDays(-10)
        }
    };

    public List<Venda> Vendas()
    {
        return vendas;
    }
}
