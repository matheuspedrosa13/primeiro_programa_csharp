using System;

public class Venda
{
    public Venda(int id, int clienteID, int produtoID, int quantidade, decimal preco, FormaPagamento formaPagamento)
    {
        ID = id;
        Data = DateTime.Now;
        ClienteID = clienteID;
        ProdutoID = produtoID;
        Quantidade = quantidade;
        Preco = preco; 
        FormaPagamento = formaPagamento;
    }

    public int ID { get; set; }
    public DateTime Data { get; set; }
    public int ClienteID { get; set; }
    public int ProdutoID { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; } 
    public FormaPagamento FormaPagamento { get; set; }
}
