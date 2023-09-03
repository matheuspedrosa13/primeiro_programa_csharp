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

    public bool NaoContemNumeros(string texto){
        foreach (char c in texto){
            if (char.IsDigit(c)){
                return false;
            }
        }
        return true;
    }

    public void DiminuirQuantidade(int id, int valoradiminuir){
        int quantidade = produtoRepo.ObterQuantidadeEstoque(id);
        produtoRepo.AtualizarProduto(id, "QuantidadeEstoque", quantidade - valoradiminuir);
    }

    public void ExcluirProduto(List<Produto> produtos, int id)
    {
        var produtoExistente = produtos.Find(p => p.Id == id);
        if (produtoExistente != null)
        {
            produtos.Remove(produtoExistente);
        }
        else
        {
            throw new ArgumentException("Produto não encontrado.");
        }
    }

    public bool ProdutoExiste(int produtoId)
    {
        Produto produto = produtoRepo.ObterProdutoPorId(produtoId);
        return produto != null;
    }
    public Produto MostrarProduto(int id)
    {
        return produtoRepo.ObterProdutoPorId(id);
    }
    public string PascalCase(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        char[] palavras = input.ToCharArray();

        palavras[0] = char.ToUpper(palavras[0]);
        for (int i = 1; i < palavras.Length; i++)
        {
            palavras[i] = char.ToLower(palavras[i]);
        }

        return new string(palavras);
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

    
    public bool ContemNumeros(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}
