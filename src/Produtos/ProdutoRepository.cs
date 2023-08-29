using System.Reflection;
public class ProdutoRepository{

    private static ProdutoDatabase database = new ProdutoDatabase();


    public int ObterQuantidadeEstoque(int id){
        var produtoQuantidade = database.Produto().Find(produto => produto.Id == id);
        return produtoQuantidade!.QuantidadeEstoque;
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
        database.Produto().Add(produto);
        return true;
    }
    public bool AlterarStatusPorId(int id, bool novoStatus){
        foreach (Produto produto in database.Produto())
        {
            if (produto.Id == id){
                produto.Status = novoStatus;
                return true;
            }
        }
        return false;
    }

     public int ObterId(){
        return database.Produto().Count + 1;
    }


    public List<Produto> ListarProdutos()
    {
        return database.Produto();
    }

    public void BuscarPorId(int id)
    {
        var produtoEncontrado = database.Produto().Find(produto => produto.Id == id);
        if(produtoEncontrado!.Status == true){
            Console.WriteLine("\nInformações do Produto:\n");
            Console.WriteLine($"Id: {produtoEncontrado.Id}\nAtivo: Sim\nNome: {produtoEncontrado.Nome}\nPreço: {produtoEncontrado.Preco}\nEstoque: {produtoEncontrado.QuantidadeEstoque}\nFabricante: {produtoEncontrado.Fabricante}\nDescrição Técnica: {produtoEncontrado.DescricaoTecnica}");
        }else{
                  Console.WriteLine("\nInformações do Produto:\n");
            Console.WriteLine($"Id: {produtoEncontrado.Id}\nAtivo: Não\nNome: {produtoEncontrado.Nome}\nPreço: {produtoEncontrado.Preco}\nEstoque: {produtoEncontrado.QuantidadeEstoque}\nFabricante: {produtoEncontrado.Fabricante}\nDescrição Técnica: {produtoEncontrado.DescricaoTecnica}");
        }   
    }



    public bool AtualizarProduto(int id, string? coluna, object novoValor)
    {
        var produtoExistente = database.Produto().Find(p => p.Id == id);
        if (produtoExistente != null)
        {
            var propertyInfo = typeof(Produto).GetProperty(coluna!);
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

    public List<Produto> BuscarPorNome(string? nome)
    {
        return database.Produto().FindAll(produto => produto.Nome!.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public static Produto ObterProdutoPorId(int id)
    {
        foreach (Produto produto in database.Produto())
        {
            if (produto.Id == id)
            {
                return produto;
            }
        }
        return null!;
    }
}