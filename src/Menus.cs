public class Menus
{
    private ClienteService clienteService = new ClienteService();
    private ClienteRepository clienteRepo = new ClienteRepository();
    private ProdutoService produtoService = new ProdutoService();
    private ProdutoRepository produtoRepo = new ProdutoRepository();
    public string ObterSexoDoUsuario(string opcao)
    {

        while (!clienteService.ValidarSexoOpcao(opcao))
        {
            Console.WriteLine("Opção inválida! Escolha entre 'M', 'F' ou 'P':");
            opcao = Console.ReadLine();
        }

        if (opcao.ToLower() == "m")
        {
            return "Masculino";
        }
        else if (opcao.ToLower() == "f")
        {
            return "Feminino";
        }
        else
        {
            return "Prefiro Não Comentar";
        }
    }

    public void ExibirMenu(){
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\nSelecione uma opção:");
            Console.WriteLine("1. Aba Cliente");
            Console.WriteLine("2. Aba Produto");

            string escolhaStr = Console.ReadLine();

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch(escolha){
                case 1:
                    ExibirMenuCliente();
                    break;
                case 2: 
                    ExibirMenuProduto();
                    break;
            }
        }
    }
    public void ExibirMenuProduto()
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\nSelecione uma opção da aba PRODUTO:");
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Buscar Produto por ID");
            Console.WriteLine("4. Buscar Produto por Nome");
            Console.WriteLine("5. Atualizar Produto por ID");
            Console.WriteLine("6. Excluir Produto por ID");
            Console.WriteLine("7. Sair");

            string escolhaStr = Console.ReadLine();

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Digite o id do produto:");
                    string idStr = Console.ReadLine();
                    
                    if (!int.TryParse(idStr, out int id))
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        break;
                    }

                    Console.WriteLine("Digite o nome do produto:");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Digite o preço do produto: (0.00)");
                    string escolhaPreco = Console.ReadLine();
                    if (!decimal.TryParse(escolhaPreco, out decimal precoDecimal)){
                        Console.WriteLine("Escolha inválida! Digite um número decimal!");
                        ContinueProduto();
                    }
                    Console.WriteLine("Digite a quantidade em estoque:");
                    string estoque  = Console.ReadLine();
                    if(!int.TryParse(estoque, out int estoqueReal)){
                        Console.WriteLine("Escolha inválida! Digite um número inteiro!");
                    }                 

                    Console.WriteLine("Digite o nome do fabricante:");
                    string fabricante = Console.ReadLine();

                    Console.WriteLine("Digite a descrição do produto:");
                    string descricao = Console.ReadLine();

                    Produto novoProduto = new Produto(id, true, nome, precoDecimal, estoqueReal, fabricante, descricao);

                    produtoRepo.CadastrarProduto(novoProduto);
                    ContinueProduto();
                    break;

                case 2:
                    Console.WriteLine("Lista de todos os produtos:");
                    List<Produto> produtos = produtoRepo.ListarProdutos();
                    foreach (Produto produto in produtos)
                    {
                        if(produto.Status == true){
                            Console.WriteLine($"ID: {produto.Id}, Ativo: Sim, Nome: {produto.Nome}, Preço: {produto.Preco}, Quantidade em Estoque: {produto.QuantidadeEstoque}");
                        }else{
                            Console.WriteLine($"ID: {produto.Id}, Ativo: Não, Nome: {produto.Nome}, Preço: {produto.Preco}, Quantidade em Estoque: {produto.QuantidadeEstoque}");
                        }
                    }
                    ContinueProduto();
                    break;

                case 3:
                    Console.WriteLine("Digite o id do produto:");
                    string idProd = Console.ReadLine();
                    
                    if (!int.TryParse(idProd, out int idReal))
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        continue;
                    }
                    Produto produtosPorId = produtoRepo.BuscarPorId(idReal);
                    if(produtosPorId.Status == true){
                        Console.WriteLine($"ID: {produtosPorId.Id}, Ativo: Sim, Nome: {produtosPorId.Nome}, Preço: {produtosPorId.Preco}, Quantidade em Estoque: {produtosPorId.QuantidadeEstoque}");
                    }else{
                        Console.WriteLine($"ID: {produtosPorId.Id}, Ativo: Não, Nome: {produtosPorId.Nome}, Preço: {produtosPorId.Preco}, Quantidade em Estoque: {produtosPorId.QuantidadeEstoque}");
                    }
                    ContinueProduto();
                    break;

                case 4:
                    Console.WriteLine("Digite o nome do produto:");
                    string nome2 = Console.ReadLine();

                    List<Produto> produtosPorNome = produtoRepo.BuscarPorNome(nome2);
                    
                    foreach (Produto produto in produtosPorNome)
                    {
                        if(produto.Status == true){
                            Console.WriteLine($"ID: {produto.Id}, Ativo: Sim, Nome: {produto.Nome}, Preço: {produto.Preco}, Quantidade em Estoque: {produto.QuantidadeEstoque}");
                        }else{
                            Console.WriteLine($"ID: {produto.Id}, Ativo: Não, Nome: {produto.Nome}, Preço: {produto.Preco}, Quantidade em Estoque: {produto.QuantidadeEstoque}");
                        }
                    }
                    ContinueProduto();
                    break;

                case 5:
                    Console.WriteLine("Digite o id do produto:");
                    string idAtualizar = Console.ReadLine();
                    
                    if (!int.TryParse(idAtualizar, out int idFinal))
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        break;
                    }

                    Console.WriteLine("O que você deseja atualizar(Nome, preco, quantidadeEstoque, Fabricante, DescicaoTecnica?");
                    string coluna = Console.ReadLine();

                    Console.WriteLine("Digite o novo valor:");
                    string novoValor = Console.ReadLine();
                    produtoRepo.AtualizarProduto(idFinal, coluna, novoValor);
                    ContinueProduto();
                    break;

                case 6:
                    Console.WriteLine("Digite o id do produto para alterar o status:");
                    string idStatusStr = Console.ReadLine();

                    if (int.TryParse(idStatusStr, out int idStatus))
                    {
                        Console.WriteLine("Digite o novo status (true ou false):");
                        string novoStatusStr = Console.ReadLine();

                        if (bool.TryParse(novoStatusStr, out bool novoStatus))
                        {
                            bool statusAlterado = produtoRepo.AlterarStatusPorId(idStatus, novoStatus);

                            if (statusAlterado)
                            {
                                Console.WriteLine("Status do produto alterado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível alterar o status do produto.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Status inválido! Digite 'true' para ativo ou 'false' para inativo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                    }
                    ContinueProduto();
                    break;

                case 7:
                    sair = true;
                    ExibirMenu();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
    public void ContinueCliente()
    {
        Console.WriteLine("Deseja continuar no cliente?");
        Console.WriteLine("1. Sim");
        Console.WriteLine("2. Voltar para o menu principal");
        string escolhaStr = Console.ReadLine();

        if (!int.TryParse(escolhaStr, out int escolha))
        {
            Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
            ExibirMenuCliente();
        }
        
        switch (escolha)
        {
            case 1:
                ExibirMenuCliente();
                break;

            case 2:
                ExibirMenu();
                break; 

            default:
                Console.WriteLine("Opção inválida.");
                ContinueCliente(); 
                break; 
        }
    }

    public void ContinueProduto()
    {
        Console.WriteLine("Deseja continuar no produto?");
        Console.WriteLine("1. Sim");
        Console.WriteLine("2. Voltar para o menu principal");
        string escolhaStr = Console.ReadLine();

        if (!int.TryParse(escolhaStr, out int escolha))
        {
            Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
            ExibirMenuCliente();
        }
        
        switch (escolha)
        {
            case 1:
                ExibirMenuProduto();
                break;

            case 2:
                ExibirMenu();
                break; 

            default:
                Console.WriteLine("Opção inválida.");
                ContinueProduto(); 
                break; 
        }
    }
    public void ExibirMenuCliente()
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\nSelecione uma opção da aba CLIENTE:");
            Console.WriteLine("1. Adicionar Cliente");
            Console.WriteLine("2. Mostrar Todos os Clientes");
            Console.WriteLine("3. Buscar Cliente por ID");
            Console.WriteLine("4. Buscar Cliente por Nome");
            Console.WriteLine("5. Buscar Cliente por CPF");
            Console.WriteLine("6. Atualizar Cliente por ID");
            Console.WriteLine("7. Alterar Status do Cliente por ID");
            Console.WriteLine("8. Sair");

            string escolhaStr = Console.ReadLine();

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch (escolha){
                case 1:
                    Console.WriteLine("Digite o id do cliente:");
                    string idStr = Console.ReadLine();
                    
                    if (!int.TryParse(idStr, out int id))
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        break;
                    }

                    Console.WriteLine("Digite o nome do cliente:");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Digite o CPF do cliente:");
                    string cpf = Console.ReadLine();

                    Console.WriteLine("Digite o sexo (M para Masculino, F para Feminino, P para Prefiro Não Comentar):");
                    string sexo = Console.ReadLine();
                    string sexoReal = ObterSexoDoUsuario(sexo);

                    Console.WriteLine("Digite o telefone do cliente: ((XX)XXXXX-XXXX)");
                    string telefone = Console.ReadLine();

                    Console.WriteLine("Digite o email do cliente:");
                    string email = Console.ReadLine();

                    Cliente novoCliente = new Cliente(id, true, nome, cpf, sexoReal, telefone, email);

                    bool clienteAdicionado = clienteService.addCliente(novoCliente);

                    if (!clienteAdicionado){
                        Console.WriteLine("Não foi possível adicionar o cliente.");
                    }
                    ContinueCliente();
                    break;

                case 2:
                    Console.WriteLine("Lista de todos os clientes:");
                    ClienteRepository.MostrarTodosClientes();
                    ContinueCliente();
                    break;

                case 3:
                    Console.WriteLine("Digite o id do cliente:");
                    string idString = Console.ReadLine();
                    
                    if (int.TryParse(idString, out int id2))
                    {
                        clienteRepo.BuscarPorId(id2);
                    }else{
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        ContinueCliente();
                        break;
                    }
                    ContinueCliente();
                    break;

                case 4:
                    Console.WriteLine("Digite o nome do cliente:");
                    string nome2 = Console.ReadLine();
                    clienteRepo.BuscarPorNome(nome2);
                    ContinueCliente();
                    break;
                
                case 5:
                    Console.WriteLine("Digite o CPF do cliente:");
                    string cpf2 = Console.ReadLine();
                    clienteRepo.BuscarPorCPF(cpf2);
                    ContinueCliente();
                    break;

                case 6:
                    Console.WriteLine("Digite o id do cliente para atualizar as informações:");
                    string idAtualizarStr = Console.ReadLine();

                    if (int.TryParse(idAtualizarStr, out int idAtualizar))
                    {
                        Console.WriteLine("Digite o novo nome do cliente (com sobrenome):");
                        string novoNome = Console.ReadLine();

                        if (!ClienteService.TemSobrenome(novoNome))
                        {
                            Console.WriteLine("O nome deve ter pelo menos duas palavras!");
                            break;
                        }

                        Console.WriteLine("Digite o novo email do cliente:");
                        string novoEmail = Console.ReadLine();

                        Console.WriteLine("Digite o novo telefone do cliente: ((XX)XXXXX-XXXX)");
                        string novoTelefone = Console.ReadLine();

                        bool clienteAtualizado = ClienteRepository.AtualizarPorId(idAtualizar, novoNome, novoEmail, novoTelefone);

                        if (clienteAtualizado)
                        {
                            Console.WriteLine("Informações do cliente atualizadas com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível atualizar as informações do cliente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                    }
                    ContinueCliente();
                    break;

                case 7:
                    Console.WriteLine("Digite o id do cliente para alterar o status:");
                    string idStatusStr = Console.ReadLine();

                    if (int.TryParse(idStatusStr, out int idStatus))
                    {
                        Console.WriteLine("Digite o novo status (true ou false):");
                        string novoStatusStr = Console.ReadLine();

                        if (bool.TryParse(novoStatusStr, out bool novoStatus))
                        {
                            bool statusAlterado = ClienteRepository.AlterarStatusPorId(idStatus, novoStatus);

                            if (statusAlterado)
                            {
                                Console.WriteLine("Status do cliente alterado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível alterar o status do cliente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Status inválido! Digite 'true' para ativo ou 'false' para inativo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                    }
                    ContinueCliente();
                    break;

                    case 8:
                        sair = true;
                        ExibirMenu();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        ContinueCliente();
                        break;
             }
         }
     }
}