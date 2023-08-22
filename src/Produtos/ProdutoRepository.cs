using System.Reflection;
public class ProdutoRepository{

    private static ProdutoDatabase database = new ProdutoDatabase();
    private static ProdutoService service = new ProdutoService();


    public int ObterQuantidadeEstoque(int id){
        return BuscarPorId(id).QuantidadeEstoque;
    }   
    public bool CadastrarProduto(Produto produto){
        List<Produto> produtos = ListarProdutos();
        foreach (Produto produtosID in produtos)
        {
            if(produtosID.Id == produto.Id){
                Console.WriteLine("O id passado já está em uso!");
                return false;
            }
        }
        database.produto.Add(produto);
        return true;
    }
    public bool AlterarStatusPorId(int id, bool novoStatus){
        foreach (Produto produto in database.produto)
        {
            if (produto.Id == id){
                produto.Status = novoStatus;
                return true;
            }
        }
        return false;
    }
    public List<Produto> ListarProdutos()
    {
        return database.produto;
    }

    public Produto BuscarPorId(int id)
    {
        return database.produto.Find(produto => produto.Id == id);
    }

    public bool AtualizarProduto(int id, string coluna, object novoValor)
    {
        Produto produtoExistente = database.produto.Find(p => p.Id == id);
        if (produtoExistente != null)
        {
            PropertyInfo propertyInfo = typeof(Produto).GetProperty(coluna);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(produtoExistente, novoValor);
                return true;
            }
            else
            {
                throw new ArgumentException("Coluna inválida.");
            }
        }
        else{
            throw new ArgumentException("Produto não encontrado.");
        }
    }

    public List<Produto> BuscarPorNome(string nome)
    {
        return database.produto.FindAll(produto => produto.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }
}