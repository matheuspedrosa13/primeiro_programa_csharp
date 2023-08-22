public class ProdutoService
{   
    ProdutoRepository produtoRepo = new ProdutoRepository();    
    public void AtualizarProduto(int id, string coluna, object novoValor)
    {
        if (coluna == "Preco")
        {
            decimal precoNovo = Convert.ToDecimal(novoValor);
            if (precoNovo <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero.");
            }
        }
        else if (coluna == "quantidadeEstoque"){
            int quantidadeNova = Convert.ToInt32(novoValor);
            if (quantidadeNova < 0 || quantidadeNova < produtoRepo.ObterQuantidadeEstoque(id))
            {
                throw new ArgumentException("A quantidade em estoque não pode ser negativa ou diminuída.");
            }
        }

        produtoRepo.AtualizarProduto(id, coluna, novoValor);
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
