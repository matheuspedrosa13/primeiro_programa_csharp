using System;
using System.Collections.Generic;

public class Produto{
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
                throw new ArgumentException("O preço deve ser maior que zero.");
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
                throw new ArgumentException("A quantidade em estoque não pode ser negativa.");
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