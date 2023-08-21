public class ProdutoService
{
    public void Atualizar(Produto produto, int novoId, string novoNome, decimal novoPreco, int novaQuantidadeEstoque, string novoFabricante, string novaDescricaoTecnica)
    {
        produto.Id = novoId;
        produto.Nome = novoNome;
        produto.Preco = novoPreco;

        if (novaQuantidadeEstoque >= produto.QuantidadeEstoque)
        {
            produto.QuantidadeEstoque = novaQuantidadeEstoque;
        }
        else
        {
            throw new ArgumentException("A quantidade em estoque não pode ser reduzida.");
        }

        produto.Fabricante = novoFabricante;
        produto.DescricaoTecnica = novaDescricaoTecnica;
    }

    public void ExcluirProduto(List<Produto> produtos, int id)
    {
        Produto produtoExistente = produtos.Find(p => p.Id == id);

        if (produtoExistente != null)
        {
            produtos.Remove(produtoExistente);
        }
        else
        {
            throw new ArgumentException("Produto não encontrado.");
        }
    }
}
