public class ProdutoRepository{

    private static ProdutoDatabase database = new ProdutoDatabase();
    private static ProdutoService service = new ProdutoService();


    public bool CadastrarProduto(Produto produto){
        database.produto.Add(produto);
        return true;
    }
    public List<Produto> ListarProdutos()
    {
        return database.produto;
    }
    public Produto BuscarPorId(int id)
    {
        return database.produto.Find(produto => produto.Id == id);
    }

    public List<Produto> BuscarPorNome(string nome)
    {
        return database.produto.FindAll(produto => produto.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public void AtualizarProduto(Produto produto)
    {
        Produto produtoExistente = database.produto.Find(p => p.Id == produto.Id);

        if (produtoExistente != null)
        {
            service.Atualizar(
                produtoExistente,  // Passando a instância de Produto existente
                produto.Id,
                produto.Nome,
                produto.Preco,
                produto.QuantidadeEstoque,
                produto.Fabricante,
                produto.DescricaoTecnica
            );
        }
        else
        {
            throw new ArgumentException("Produto não encontrado.");
        }
    }


}