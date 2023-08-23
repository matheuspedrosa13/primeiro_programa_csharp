using System;
using System.Collections.Generic;

public class VendasDatabase
{
    public List<Venda> vendas = new List<Venda>
    {
        new Venda(101, 201, 3, FormaPagamento.CartaoDeCredito){
            ID = 1,
            Data = DateTime.Now.AddDays(-10)
        },
        new Venda(231, 322, 100, FormaPagamento.Dinheiro){
            ID = 1,
            Data = DateTime.Now.AddDays(-10)
        },
    };
}
