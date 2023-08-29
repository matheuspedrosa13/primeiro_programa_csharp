public class Menu
{
    private ClienteService clienteService = new ClienteService();
    private ClienteRepository clienteRepo = new ClienteRepository();
    private ProdutoRepository produtoRepo = new ProdutoRepository();
    private VendaRepository vendaRepository = new VendaRepository();


    //Menu para obter sexo do usuario
    public string ObterSexoDoUsuario(string opcao){
        while (!clienteService.ValidarSexoOpcao(opcao!))
        {
            Console.WriteLine("Opção inválida! Escolha entre 'M', 'F' ou 'P':");
            opcao = Console.ReadLine()!;
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


    //Menus de exibição
    public void ExibirMenu(){
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\nSelecione uma opção:");
            Console.WriteLine("1. Aba Cliente");
            Console.WriteLine("2. Aba Produto");
            Console.WriteLine("3. Aba Vendas");
            Console.WriteLine("4. Sair do programa");

            string escolhaStr = Console.ReadLine()!;

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
                case 3: 
                    ExibirMenuVendas();
                    break;
                case 4: 
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

            var escolhaStr = Console.ReadLine();

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Digite o nome do produto:");
                    var nome = Console.ReadLine();

                    Console.WriteLine("Digite o preço do produto: (0.00)");
                    var escolhaPreco = Console.ReadLine();
                    if (!decimal.TryParse(escolhaPreco, out decimal precoDecimal)){
                        Console.WriteLine("Escolha inválida! Digite um número decimal!");
                        ContinueProduto();
                    }
                    Console.WriteLine("Digite a quantidade em estoque:");
                    var estoque  = Console.ReadLine();
                    if(!int.TryParse(estoque, out int estoqueReal)){
                        Console.WriteLine("Escolha inválida! Digite um número inteiro!");
                    }                 

                    Console.WriteLine("Digite o nome do fabricante:");
                    var fabricante = Console.ReadLine();

                    Console.WriteLine("Digite a descrição do produto:");
                    var descricao = Console.ReadLine();
                    int obterId = produtoRepo.ObterId();

                    Produto novoProduto = new Produto(obterId, true, nome, precoDecimal, estoqueReal, fabricante, descricao);

                    produtoRepo.CadastrarProduto(novoProduto);
                    Console.WriteLine();
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
                    var idProd = Console.ReadLine();
                    
                    if (!int.TryParse(idProd, out int idReal))
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        continue;
                    }
                    produtoRepo.BuscarPorId(idReal);

                    ContinueProduto();
                    break;

                case 4:
                    Console.WriteLine("Digite o nome do produto:");
                    var nome2 = Console.ReadLine();

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
                    var idAtualizar = Console.ReadLine();
                    
                    if (!int.TryParse(idAtualizar, out int idFinal))
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        break;
                    }

                    Console.WriteLine("O que você deseja atualizar(Nome, preco, quantidadeEstoque, Fabricante, DescicaoTecnica?");
                    var coluna = Console.ReadLine();

                    Console.WriteLine("Digite o novo valor:");
                    var novoValor = Console.ReadLine();
                    produtoRepo.AtualizarProduto(idFinal, coluna, novoValor!);
                    ContinueProduto();
                    break;

                case 6:
                    Console.WriteLine("Digite o id do produto para alterar o status:");
                    var idStatusStr = Console.ReadLine();

                    if (int.TryParse(idStatusStr, out int idStatus))
                    {
                        Console.WriteLine("Digite o novo status (true ou false):");
                        var novoStatusStr = Console.ReadLine();

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

            var escolhaStr = Console.ReadLine();

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch (escolha){
                case 1:
                    Console.WriteLine("Digite o nome do cliente (sem acento):");
                    var nome = Console.ReadLine();

                    Console.WriteLine("Digite o CPF do cliente (sem pontos ou traços):");
                    string cpf = Console.ReadLine();

                    Console.WriteLine("Digite o sexo (M para Masculino, F para Feminino, P para Prefiro Não Comentar):");
                    var sexo = Console.ReadLine();
                    var sexoReal = ObterSexoDoUsuario(sexo!);

                    Console.WriteLine("Digite o telefone do cliente: ((XX)XXXXX-XXXX)");
                    var telefone = Console.ReadLine();

                    Console.WriteLine("Digite o email do cliente:");
                    var email = Console.ReadLine();
                    int obterId = clienteRepo.ObterId();
                    Cliente novoCliente = new Cliente(obterId, true, nome!, cpf, sexoReal, telefone!, email!);

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
                    var idvar = Console.ReadLine();
                    
                    if (int.TryParse(idvar, out int id2))
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
                    Console.WriteLine("Digite o nome do cliente (sem acento):");
                    var nome2 = Console.ReadLine();
                    clienteRepo.BuscarPorNome(nome2!);
                    ContinueCliente();
                    break;
                
                case 5:
                    Console.WriteLine("Digite o CPF do cliente:");
                    string cpf2 = Console.ReadLine();
                    var clienteEncontrado = clienteRepo.BuscarPorCPF(cpf2);
                    Console.WriteLine(clienteEncontrado);

                    if (clienteEncontrado != null)
                    {
                        ClienteRepository.MostrarInformacoes(clienteEncontrado);
                    }
                    else
                    {
                        Console.WriteLine(clienteEncontrado);
                        Console.WriteLine("Cliente não encontrado.");
                    }

                    ContinueCliente();
                    break;



                case 6:
                    Console.WriteLine("Digite o id do cliente para atualizar as informações:");
                    var idAtualizarStr = Console.ReadLine();

                    if (int.TryParse(idAtualizarStr, out int idAtualizar))
                    {
                        Console.WriteLine("Escolha o que deseja atualizar:");
                        Console.WriteLine("1. Nome");
                        Console.WriteLine("2. Email");
                        Console.WriteLine("3. Telefone");
                        var escolha1 = Console.ReadLine();

                        switch (escolha1)
                        {
                            case "1":
                                Console.WriteLine("Digite o novo nome do cliente (com sobrenome):");
                                var novoNome = Console.ReadLine();

                                if (!ClienteService.TemSobrenome(novoNome))
                                {
                                    Console.WriteLine("O nome deve ter pelo menos duas palavras!");
                                    break;
                                }

                                bool clienteAtualizadoNome = ClienteRepository.AtualizarPorId(idAtualizar, novoNome);
                                if (clienteAtualizadoNome)
                                {
                                    Console.WriteLine("Nome do cliente atualizado com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível atualizar o nome do cliente.");
                                }
                                break;

                            case "2":
                                Console.WriteLine("Digite o novo email do cliente:");
                                var novoEmail = Console.ReadLine();
                                if(clienteRepo.ExisteEmail(novoEmail) == true){
                                    Console.WriteLine("Email já cadastrado no banco de dados");
                                    break;
                                }else if(clienteRepo.ValidarEmail(novoEmail) == false){
                                    Console.WriteLine("Email deve estar no padrão. Ex: xxxxx@xxxx.xxx");
                                    break;
                                }else{
                                    bool clienteAtualizadoEmail = ClienteRepository.AtualizarPorId(idAtualizar, null, novoEmail);
                                    if (clienteAtualizadoEmail)
                                    {
                                        Console.WriteLine("Email do cliente atualizado com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não foi possível atualizar o email do cliente.");
                                    }
                                    break;
                                }

                            case "3":
                                Console.WriteLine("Digite o novo telefone do cliente, deve seguir o padrão, 11 dígitos (se for número pessoal) ou 10 dígitos (se for número fixo) e ser um número");
                                var novoTelefone = Console.ReadLine();
                                
                                bool clienteAtualizadoTelefone = ClienteRepository.AtualizarPorId(idAtualizar, null, null, novoTelefone);
                                if(clienteRepo.ValidarTelefone(novoTelefone) == true){
                                    if (clienteAtualizadoTelefone)
                                    {
                                        Console.WriteLine("Telefone do cliente atualizado com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não foi possível atualizar o telefone do cliente.");
                                    }
                                    break;
                                }else{
                                        Console.Write("Telefone deve seguir o padrão, 11 dígitos (se for número pessoal) ou 10 dígitos (se for número fixo)\n");
                                    break;
                                }

                            default:
                                Console.WriteLine("Escolha inválida.");
                                break;
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
                    var idStatusStr = Console.ReadLine();

                    if (int.TryParse(idStatusStr, out int idStatus))
                    {
                        Console.WriteLine("Digite o novo status (1 para Ativo ou 2 para Inativo):");
                        var novoStatusStr = Console.ReadLine();

                        if (int.TryParse(novoStatusStr, out int novoStatusOpcao))
                        {
                            bool novoStatus;
                            
                            if (novoStatusOpcao == 1)
                            {
                                novoStatus = true;
                            }
                            else if (novoStatusOpcao == 2)
                            {
                                novoStatus = false;
                            }
                            else
                            {
                                Console.WriteLine("Opção de status inválida. Use 1 para Ativo ou 2 para Inativo.");
                                ContinueCliente();
                                break;
                            }

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
                            Console.WriteLine("Opção inválida! Digite 1 para Ativo ou 2 para Inativo.");
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
    public void ExibirMenuVendas()
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\nSelecione uma opção da aba VENDAS:");
            Console.WriteLine("1. Realizar Nova Venda");
            Console.WriteLine("2. Mostrar Todas as Vendas");
            Console.WriteLine("3. Filtrar Vendas por Cliente");
            Console.WriteLine("4. Filtrar Vendas por Produto");
            Console.WriteLine("5. Sair");

            var escolhaStr = Console.ReadLine();

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Digite o ID do cliente:");
                    int clienteID = int.Parse(Console.ReadLine()!);

                    Console.WriteLine("Digite o ID do produto:");
                    int produtoID = int.Parse(Console.ReadLine()!);

                    Console.WriteLine("Digite a quantidade:");
                    int quantidade = int.Parse(Console.ReadLine()!);

                    Console.WriteLine("Escolha a forma de pagamento (0 - Dinheiro, 1 - CartaoDeDebito, 2 - CartaoDeCredito, 3 - PIX):");
                    int formaPagamentoInt = int.Parse(Console.ReadLine()!);

                    if (formaPagamentoInt < 0 || formaPagamentoInt > 3)
                    {
                        Console.WriteLine("Forma de pagamento inválida.");
                        ContinueVendas();
                    }
                    else{
                        FormaPagamento formaPagamento = (FormaPagamento)formaPagamentoInt;
                        vendaRepository.AdicionarVenda(clienteID, produtoID, quantidade, formaPagamento);
                        ContinueVendas();
                    }
                    break;
                    
                case 2:
                    Console.WriteLine("Lista de todas as vendas:");
                    vendaRepository.MostrarVendas(vendaRepository.ObterTodasVendas());
                    ContinueVendas();
                    break;

                case 3:
                    Console.WriteLine("Digite o ID do cliente:");
                    int clienteIDFiltro = int.Parse(Console.ReadLine()!);

                    Console.WriteLine("Vendas do cliente:");
                    vendaRepository.MostrarVendas(vendaRepository.BuscarPorCliente(clienteIDFiltro));
                    ContinueVendas();
                    break;

                case 4:
                    Console.WriteLine("Digite o ID do produto:");
                    int produtoIDFiltro = int.Parse(Console.ReadLine()!);

                    Console.WriteLine("Vendas do produto:");
                    vendaRepository.MostrarVendas(vendaRepository.BuscarPorProduto(produtoIDFiltro));
                    ContinueVendas();
                    break;

                case 5:
                    sair = true;
                    ExibirMenu();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    ContinueVendas();
                    break;
            }
        }
    }

    //Menus de continuar
    public void ContinueCliente()
    {
        Console.WriteLine("Deseja continuar no cliente?");
        Console.WriteLine("1. Sim");
        Console.WriteLine("2. Voltar para o menu principal");
        var escolhaStr = Console.ReadLine();

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
                break; 
        }
    }
    public void ContinueProduto()
    {
        Console.WriteLine("Deseja continuar no produto?");
        Console.WriteLine("1. Sim");
        Console.WriteLine("2. Voltar para o menu principal");
        var escolhaStr = Console.ReadLine();

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
                break; 
        }
    }
    public void ContinueVendas()
    {
        Console.WriteLine("Deseja continuar na aba de VENDAS?");
        Console.WriteLine("1. Sim");
        Console.WriteLine("2. Voltar para o menu principal");
        var escolhaStr = Console.ReadLine();

        if (!int.TryParse(escolhaStr, out int escolha))
        {
            Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
            ExibirMenu();
        }

        switch (escolha)
        {
            case 1:
                ExibirMenuVendas();
                break;

            case 2:
                ExibirMenu();
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
}

// TODO: Adicionar opção de sair
	// Cliente
	// 	Dividir o DDD do telefone------------------
	// 	Mensagem de retorno caso o cliente nao seja localizado---------------
	// 	Buscar por nome esta exibindo oq eu digitei--------------
	// 	Adicionar busca por parte do nome----------------
	// 	Deixar buscas case insensitive----------------
	// 	Retirar inserção do ID, manter isso de forma automatica-----------------
	// 	Refatorar atualização de status do cliente-------------------
	// 	Na atualização, dar a opção do q é desejado atualizar----------------
	// 	Busca de clientes por nome não funciona------------------
	// 	Busca de clientes por ID nao funciona------------------
	// 	Busca de clientes por CPF nao funciona------------------