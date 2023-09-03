using System.Reflection;
public class ProdutoRepository{

    private static ProdutoDatabase database = new ProdutoDatabase();
    private static ProdutoService service = new ProdutoService();


    public int ObterQuantidadeEstoque(int id){
        var produtoQuantidade = database.Produto().Find(produto => produto.Id == id);
        return produtoQuantidade!.QuantidadeEstoque;
    }   

    // Função para verificar se a entrada contém apenas caracteres de texto

    public bool AtualizarPorId(int id, string novoNome = null!, decimal? preco = null, string fabricante = null!, string descricao = null!){
        Produto produtoParaAtualizar = database.Produto().FirstOrDefault(product => product.Id == id)!;

        if (produtoParaAtualizar == null)
        {
            Console.WriteLine("Produto não encontrado.");
            return false;
        }

        if (!string.IsNullOrEmpty(novoNome))
        {
            if (service.NaoContemNumeros(novoNome)){
                produtoParaAtualizar.Nome = novoNome;
            }
            else{
                Console.WriteLine("O nome deve ser sem números!");
                return false;
            }
        }

        if (preco.HasValue)
        {
            produtoParaAtualizar.Preco = preco.Value;
        }

        if (!string.IsNullOrEmpty(fabricante))
        {
            produtoParaAtualizar.Fabricante = fabricante;
        }
        
        if (!string.IsNullOrEmpty(descricao))
        {
            produtoParaAtualizar.DescricaoTecnica = descricao;
        }

        return true;
    }

    public bool IsTextOnly(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }


    public bool CadastrarProduto(Produto produto){
        List<Produto> produtos = ListarProdutos();
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

    public List<Produto> BuscarPorNome(string? parteDoNome)
        {
            if (parteDoNome == null)
            {
                return new List<Produto>(); 
            }

            parteDoNome = parteDoNome.ToLower();

            List<Produto> resultados = database.Produto().FindAll(produto => 
                produto.Nome != null && produto.Nome.ToLower().Contains(parteDoNome)
            );

            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum produto encontrado com a parte do nome especificada.");
            }

            return resultados;
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