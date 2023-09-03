using System;
using System.Collections.Generic;

public class Produto{
    private Menu menu = new Menu();
    public int Id { get; set; }
    public bool Status {get; set;}
    public string? Nome { get; set; }
    private decimal preco;
    private int quantidadeEstoque;
    public string? Fabricante { get; set; }
    public string? DescricaoTecnica { get; set; }

    public decimal Preco{
        get { return preco; }
        set{
            if (value > 0){
                preco = Math.Round(value, 2);
            }
            else{
                Console.WriteLine("O preço deve ser maior que 0!");
                menu.ContinueProduto();
            }
        }
    }

    public int QuantidadeEstoque{
        get { return quantidadeEstoque; }
        set{
            if (value >= 0){
                quantidadeEstoque = value;
            }
            else{
                Console.WriteLine("Quantidade em estoque não pode ser negativa!");
                menu.ContinueProduto();
            }
        }
    }

    public Produto(int id, bool status, string? nome, decimal preco, int quantidadeEstoque, string? fabricante, string? descricaoTecnica){
        Id = id;
        Status = status;
        Nome = nome;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
        Fabricante = fabricante;
        DescricaoTecnica = descricaoTecnica;
    }
}