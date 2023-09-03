using System.Globalization;
public class Menu
{
    private ClienteService clienteService = new ClienteService();
    private ProdutoService produtoService = new ProdutoService();
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

    public string ObterCPF(string opcao){
        while (!clienteService.ValidarCPF(opcao!))
        {
            Console.WriteLine("CPF inválido, o CPF não pode ter traços ou pontos. Digite-o novamente:");
            opcao = Console.ReadLine()!;
        }
        return opcao;
    }

    public string ObterTelefone(string opcao){
        while (!clienteService.ValidarTelefone(opcao!))
        {
            Console.WriteLine("Telefone inválido, o telefone deve ser uma sequência de 10 ou 11 digitos sem traços ou ponto. Digite-o novamente:");
            opcao = Console.ReadLine()!;
        }
        return opcao;
    }

    public string ObterEmail(string opcao){
        while (!clienteService.ValidarEmail(opcao!))
        {
            Console.WriteLine("Email inválido, o email deve seguir esse padrão: xxxxxx@xxx.xxx. Digite-o novamente:");
            opcao = Console.ReadLine()!;
        }
        return opcao;
    }

    public string ObterNome(string opcao){
        while (!clienteService.TemSobrenome(opcao!))
        {
            Console.WriteLine("Nome inválido, o nome deve ter sobrenome. Digite-o novamente:");
            opcao = Console.ReadLine()!;
        }
        return opcao;
    }

    public string ObterNomesProduto(bool nome, string nomeProduto)
    {
        if(nome == true){
            while (produtoService.ContemNumeros(nomeProduto))
            {
                Console.WriteLine("O nome do produto não pode conter números. Tente novamente.");
                Console.Write("Digite o nome do produto: ");
                nomeProduto = Console.ReadLine()!;
            }
        }else{
            while (produtoService.ContemNumeros(nomeProduto))
            {
                Console.WriteLine("O nome do fabricante não pode conter números. Tente novamente.");
                Console.Write("Digite o nome do fabricante: ");
                nomeProduto = Console.ReadLine()!;
            }
        }
        return nomeProduto;
    }

    public decimal ObterPrecoProduto(string precoInput)
    {
        decimal precoDecimal;
        while (!decimal.TryParse(precoInput, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out precoDecimal))
        {
            Console.WriteLine("Escolha inválida! O preço deve ser inteiro ou decimal!");
            Console.Write("Digite o preço: ");
            precoInput = Console.ReadLine()!;
        }
        return precoDecimal;
    }

    public int ObterQuantidadeEstoque(string quantidade){  
        int estoqueReal;

        while (!int.TryParse(quantidade, out estoqueReal) || estoqueReal < 0)
        {
            Console.WriteLine("A quantidade deve ser inteiro e maior ou igual a 0!");
            Console.Write("Digite um número inteiro: ");
            quantidade = Console.ReadLine()!;
        }
        return estoqueReal;
    }

    public string ObterDescricao(string descricao){
        while(!produtoService.IsTextOnly(descricao)){
            Console.WriteLine("A descrição não pode ter número, nem caracteres especiais");
            Console.Write("Digite um texto: ");
            descricao = Console.ReadLine()!;
        }
        return descricao;
    }

    //Menus de exibição
    public void ExibirMenu(){
        while (true)
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

            switch (escolha)
            {
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
                    Console.WriteLine("Obrigado por usar o meu sistema! Volte sempre!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Escolha inválida! Tente novamente.");
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
            Console.WriteLine("7. Voltar ao menu principal");

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
                    string nome = Console.ReadLine()!;
                    string nomeVerificado = ObterNomesProduto(true, nome);
                    string nomeFormatado = produtoService.PascalCase(nomeVerificado);

                    Console.WriteLine("Digite o preço do produto: (0.00)");
                    string precoInput = Console.ReadLine()!;
                    precoInput = precoInput.Replace(",", ".");
                    decimal precoVerificado = ObterPrecoProduto(precoInput);


                    Console.WriteLine("Digite a quantidade em estoque:");
                    string estoqueStr = Console.ReadLine()!;
                    int estoqueReal = ObterQuantidadeEstoque(estoqueStr);

                    Console.WriteLine("Digite o nome do fabricante:");
                    string fabricante = Console.ReadLine()!;
                    string fabricanteVerificado = ObterNomesProduto(false, fabricante);
                    string fabricanteFormatado = produtoService.PascalCase(fabricanteVerificado);

                    Console.WriteLine("Digite a descrição do produto:");
                    string descricao = Console.ReadLine()!;
                    string descricaoReal = ObterDescricao(descricao);

                    int obterId = produtoRepo.ObterId();

                    Produto novoProduto = new Produto(obterId, true, nomeFormatado, precoVerificado, estoqueReal, fabricanteFormatado, descricaoReal);

                    produtoRepo.CadastrarProduto(novoProduto);
                    Console.WriteLine("Produto adicionado com sucesso!");
                    ContinueProduto();
                    break;

                case 2:
                    Console.WriteLine("Lista de todos os produtos:");

                    CultureInfo currentCulture = CultureInfo.CurrentCulture;
                    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

                    List<Produto> produtos = produtoRepo.ListarProdutos();
                    foreach (Produto produto3 in produtos)
                    {
                        if (produto3.Status)
                        {
                            Console.WriteLine($"ID: {produto3.Id}, Ativo: Sim, Nome: {produto3.Nome}, Preço: {produto3.Preco.ToString("0.00")}, Quantidade em Estoque: {produto3.QuantidadeEstoque}, Fabricante: {produto3.Fabricante}, Descrição: {produto3.DescricaoTecnica}");
                        }
                        else
                        {
                            Console.WriteLine($"ID: {produto3.Id}, Ativo: Não, Nome: {produto3.Nome}, Preço: {produto3.Preco.ToString("0.00")}, Quantidade em Estoque: {produto3.QuantidadeEstoque}, Fabricante: {produto3.Fabricante}, Descrição: {produto3.DescricaoTecnica}");
                        }
                    }

                    CultureInfo.CurrentCulture = currentCulture;

                    ContinueProduto();
                    break;

                case 3:
                    Console.WriteLine("Digite o id do produto:");
                    var idProd = Console.ReadLine();
                    bool idEncontrado = false;
                    int idReal = 0;

                    while (!idEncontrado)
                    {
                        if (!int.TryParse(idProd, out idReal))
                        {
                            Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                            Console.WriteLine("Digite o ID novamente:");
                            idProd = Console.ReadLine();
                        }
                        else
                        {
                            idEncontrado = produtoRepo.BuscarPorId(idReal);
                            if (!idEncontrado)
                            {
                                Console.WriteLine("O id não encontrado!");
                                Console.WriteLine("Digite o ID novamente:");
                                idProd = Console.ReadLine();
                            }
                        }
                    }

                    if (idEncontrado)
                    {
                        var produtoEncontrado = produtoRepo.ObterProdutoPorId(idReal);
                        Console.WriteLine("\nInformações do Produto:\n");
                        Console.WriteLine($"Id: {produtoEncontrado.Id}\nAtivo: {(produtoEncontrado.Status ? "Sim" : "Não")}\nNome: {produtoEncontrado.Nome}\nPreço: {produtoEncontrado.Preco}\nEstoque: {produtoEncontrado.QuantidadeEstoque}\nFabricante: {produtoEncontrado.Fabricante}\nDescrição Técnica: {produtoEncontrado.DescricaoTecnica}");
                    }

                    ContinueProduto();
                    break;


                case 4:
                    Console.WriteLine("Digite o nome do produto:");
                    var nome2 = Console.ReadLine();

                    List<Produto> produtosPorNome = produtoRepo.BuscarPorNome(nome2);
                    
                    foreach (Produto produto2 in produtosPorNome)
                    {
                        if(produto2.Status == true){
                            Console.WriteLine($"ID: {produto2.Id}, Ativo: Sim, Nome: {produto2.Nome}, Preço: {produto2.Preco}, Quantidade em Estoque: {produto2.QuantidadeEstoque}");
                        }else{
                            Console.WriteLine($"ID: {produto2.Id}, Ativo: Não, Nome: {produto2.Nome}, Preço: {produto2.Preco}, Quantidade em Estoque: {produto2.QuantidadeEstoque}");
                        }
                    }
                    ContinueProduto();
                    break;

                case 5:
                    Console.WriteLine("Digite o ID do produto para atualizar as informações:");
                    var idAtualizarStr = Console.ReadLine();

                    bool idEncontrado2 = false;
                    int idReal2 = 0;

                    while (!idEncontrado2)
                    {
                        if (!int.TryParse(idAtualizarStr, out idReal2))
                        {
                            Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                            Console.WriteLine("Digite o ID novamente:");
                            idAtualizarStr = Console.ReadLine();
                        }
                        else
                        {
                            idEncontrado2 = produtoRepo.BuscarPorId(idReal2);
                            if (!idEncontrado2)
                            {
                                Console.WriteLine("O id não encontrado!");
                                Console.WriteLine("Digite o ID novamente:");
                                idAtualizarStr = Console.ReadLine();
                            }
                        }
                    }

                    if (int.TryParse(idAtualizarStr, out int idAtualizarProduto))
                    {
                        Console.WriteLine("Escolha o que deseja atualizar:");
                        Console.WriteLine("1. Nome");
                        Console.WriteLine("2. Preço");
                        Console.WriteLine("3. Fabricante");
                        Console.WriteLine("4. Descrição");
                        var escolha1 = Console.ReadLine();

                        switch (escolha1)
                        {
                            case "1":
                                Console.WriteLine("Digite o novo nome do produto:");
                                var novoNome = Console.ReadLine();
                                bool produtoAtualizadoNome = produtoRepo.AtualizarPorId(idAtualizarProduto, novoNome: novoNome!);
                                
                                if (produtoAtualizadoNome)
                                {
                                    Console.WriteLine("Nome do produto atualizado com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível atualizar o nome do produto.");
                                }
                                break;

                            case "2":
                                Console.WriteLine("Digite o novo preço do produto:");
                                var novoPrecoStr = Console.ReadLine();
                                if (decimal.TryParse(novoPrecoStr, out decimal novoPreco))
                                {
                                    bool produtoAtualizadoPreco = produtoRepo.AtualizarPorId(idAtualizarProduto, preco: novoPreco);
                                    if (produtoAtualizadoPreco)
                                    {
                                        Console.WriteLine("Preço do produto atualizado com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não foi possível atualizar o preço do produto.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Preço inválido! Digite um número decimal válido.");
                                }
                                break;

                            case "3":
                                Console.WriteLine("Digite o novo fabricante do produto:");
                                var novoFabricante = Console.ReadLine();
                                bool produtoAtualizadoFabricante = produtoRepo.AtualizarPorId(idAtualizarProduto, fabricante: novoFabricante!);
                                if (produtoAtualizadoFabricante)
                                {
                                    Console.WriteLine("Fabricante do produto atualizado com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível atualizar o fabricante do produto.");
                                }
                                break;

                            case "4":
                                Console.WriteLine("Digite a nova descrição do produto:");
                                var novaDescricao = Console.ReadLine();
                                bool produtoAtualizadoDescricao = produtoRepo.AtualizarPorId(idAtualizarProduto, descricao: novaDescricao!);
                                if (produtoAtualizadoDescricao)
                                {
                                    Console.WriteLine("Descrição do produto atualizada com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível atualizar a descrição do produto.");
                                }
                                break;

                            default:
                                Console.WriteLine("Escolha inválida.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                    }
                    ContinueProduto();
                    break;

                case 6:
                    int idStatus;
                    Produto produto = null!; // Declare a variável fora do loop e inicialize como null

                    while (true)
                    {
                        Console.WriteLine("Digite o id do produto para alterar o status:");
                        var idStatusStr = Console.ReadLine();

                        if (int.TryParse(idStatusStr, out idStatus))
                        {
                            produto = produtoRepo.ObterProdutoPorId(idStatus);

                            if (produto != null)
                            {
                                break; // ID válido, saia do loop
                            }
                            else
                            {
                                Console.WriteLine($"Produto com ID {idStatus} não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        }
                    }

                    if (produto != null)
                    {
                        Console.WriteLine($"Status atual do produto com ID {idStatus}: {(produto.Status ? "Ativo" : "Inativo")}");
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
                                ContinueProduto();
                                break;
                            }

                            if (novoStatus == produto.Status)
                            {
                                Console.WriteLine($"O produto já está {(novoStatus ? "ativo" : "inativo")}.");
                            }
                            else
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
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida! Digite 1 para Ativo ou 2 para Inativo.");
                        }
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
            Console.WriteLine("8. Voltar ao menu principal");

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
                    var nomeReal = ObterNome(nome!);

                    Console.WriteLine("Digite o CPF do cliente (sem pontos ou traços):");
                    string cpf = Console.ReadLine()!;
                    var cpfReal = ObterCPF(cpf);

                    Console.WriteLine("Digite o sexo (M para Masculino, F para Feminino, P para Prefiro Não Comentar):");
                    var sexo = Console.ReadLine();
                    var sexoReal = ObterSexoDoUsuario(sexo!);

                    Console.WriteLine("Digite o telefone do cliente: (uma sequência de 11 ou 10 (telefone fixo) números, contando o DDD do estado)");
                    var telefone = Console.ReadLine();
                    var telefoneReal = ObterTelefone(telefone!);

                    Console.WriteLine("Digite o email do cliente:");
                    var email = Console.ReadLine();
                    var emailReal = ObterEmail(email!);

                    int obterId = clienteRepo.ObterId();
                    
                    string nomeFormatado = clienteService.ParaPascalCase(nomeReal);
                    Cliente novoCliente = new Cliente(obterId, true, nomeFormatado!, cpfReal, sexoReal, telefoneReal!, emailReal!);

                    bool clienteAdicionado = clienteService.addCliente(novoCliente);
                

                    if (!clienteAdicionado){
                        Console.WriteLine("Não foi possível adicionar o cliente.");
                    }   
                    ContinueCliente();
                    break;

                case 2:
                    Console.WriteLine("Lista de todos os clientes:\n");
                    clienteRepo.MostrarTodosClientes();
                    ContinueCliente();
                    break;

                case 3:
                    Console.WriteLine("Digite o id do cliente:");
                    string idvar = Console.ReadLine()!;
                    int id2;

                    if (int.TryParse(idvar, out id2))
                    {
                        Cliente clienteAchado = clienteRepo.BuscarPorId(id2);
                        if (clienteAchado != null)
                        {
                            string telefoneFormatado = clienteRepo.FormatarTelefone(clienteAchado.Telefone);
                            string status = clienteAchado.Status ? "Sim" : "Não";
                            Console.WriteLine($"Id: {clienteAchado.Id}\nAtivo: {status}\nNome: {clienteAchado.Nome}\nCPF: {clienteAchado.CPF}\nSexo: {clienteAchado.Sexo}\nTelefone: {telefoneFormatado}\nEmail: {clienteAchado.Email}\n");
                            ContinueCliente();
                        }
                        else
                        {
                            Console.WriteLine($"Nenhum cliente encontrado com o ID {id2}.\n");
                            ContinueCliente();

                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.\n");
                        ContinueCliente();
                    }
                    break;


                case 4:
                    Console.WriteLine("Digite o nome do cliente (sem acento):");
                    var nome2 = Console.ReadLine();
                    clienteRepo.BuscarPorNome(nome2!);
                    ContinueCliente();
                    break;
                
                case 5:
                    Console.WriteLine("Digite o CPF do cliente:");
                    string cpf2 = Console.ReadLine()!;

                    var clienteEncontrado = clienteRepo.BuscarPorCPF(cpf2);

                    if (clienteEncontrado != null)
                    {
                        Cliente clienteAchado = ClienteRepository.MostrarInformacoes(clienteEncontrado);
                        string telefoneFormatado = clienteRepo.FormatarTelefone(clienteAchado.Telefone);
                        string status = clienteAchado.Status ? "Sim" : "Não";
                        Console.WriteLine($"Id: {clienteAchado.Id}\nAtivo: {status}\nNome: {clienteAchado.Nome}\nCPF: {clienteAchado.CPF}\nSexo: {clienteAchado.Sexo}\nTelefone: {telefoneFormatado}\nEmail: {clienteAchado.Email}");

                    }
                    else
                    {
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

                                if (!clienteService.TemSobrenome(novoNome!))
                                {
                                    Console.WriteLine("O nome deve ter pelo menos duas palavras!");
                                    break;
                                }

                                bool clienteAtualizadoNome = ClienteRepository.AtualizarPorId(idAtualizar, novoNome!);
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
                                if(clienteRepo.ExisteEmail(novoEmail!) == true){
                                    Console.WriteLine("Email já cadastrado no banco de dados");
                                    break;
                                }else if(clienteRepo.ValidarEmail(novoEmail!) == false){
                                    Console.WriteLine("Email deve estar no padrão. Ex: xxxxx@xxxx.xxx");
                                    break;
                                }else{
                                    bool clienteAtualizadoEmail = ClienteRepository.AtualizarPorId(idAtualizar, null!, novoEmail!);
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
                                
                                bool clienteAtualizadoTelefone = ClienteRepository.AtualizarPorId(idAtualizar, null!, null!, novoTelefone!);
                                if(clienteRepo.ValidarTelefone(novoTelefone!) == true){
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
                        Cliente clienteAchado = clienteRepo.BuscarPorId(idStatus);
                        if (int.TryParse(novoStatusStr, out int novoStatusOpcao))
                        {
                            bool novoStatus;
                            
                            if (novoStatusOpcao == 1)
                            {
                                if(clienteAchado.Status == true){
                                    Console.WriteLine("Cliente já está ativo");
                                    ContinueCliente();
                                }
                                novoStatus = true;

                            }
                            else if (novoStatusOpcao == 2)
                            {
                                if(clienteAchado.Status == false){
                                    Console.WriteLine("Cliente já está desativado");
                                    ContinueCliente();
                                }
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
            Console.WriteLine("5. Buscar Venda por Id");
            Console.WriteLine("6. Voltar ao menu principal");

            var escolhaStr = Console.ReadLine();

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    int clienteID, produtoID, quantidade, formaPagamentoInt;
                    FormaPagamento formaPagamento;

                    while (true)
                    {
                        Console.WriteLine("Digite o ID do cliente:");
                        if (int.TryParse(Console.ReadLine(), out clienteID))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ID de cliente inválido. Tente novamente.");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Digite o ID do produto:");
                        if (int.TryParse(Console.ReadLine(), out produtoID))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ID de produto inválido. Tente novamente.");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Digite a quantidade:");
                        if (int.TryParse(Console.ReadLine(), out quantidade) && quantidade > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida. Deve ser um número positivo. Tente novamente.");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Escolha a forma de pagamento (0 - Dinheiro, 1 - CartaoDeDebito, 2 - CartaoDeCredito, 3 - PIX):");
                        if (int.TryParse(Console.ReadLine(), out formaPagamentoInt) && formaPagamentoInt >= 0 && formaPagamentoInt <= 3)
                        {
                            formaPagamento = (FormaPagamento)formaPagamentoInt;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Forma de pagamento inválida. Tente novamente.");
                        }
                    }

                    vendaRepository.AdicionarVenda(clienteID, produtoID, quantidade, formaPagamento);
                    break;
                    
                case 2:
                    Console.WriteLine("Lista de todas as vendas:");
                    vendaRepository.MostrarVendas(vendaRepository.ObterTodasVendas());
                    ContinueVendas();
                    break;

                case 3:
                    int clienteIDFiltro;

                    while (true)
                    {
                        Console.WriteLine("Digite o ID do cliente:");
                        if (int.TryParse(Console.ReadLine(), out clienteIDFiltro))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ID de cliente inválido. Tente novamente.");
                        }
                    }

                    List<Venda> vendasCliente = vendaRepository.BuscarPorCliente(clienteIDFiltro);
                    if (vendasCliente.Count == 0)
                    {
                        Console.WriteLine("Cliente não encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Vendas do cliente:");
                        vendaRepository.MostrarVendas(vendasCliente);
                    }
                    ContinueVendas();
                    break;

                case 4:
                    int produtoIDFiltro;

                    while (true)
                    {
                        Console.WriteLine("Digite o ID do produto:");
                        if (int.TryParse(Console.ReadLine(), out produtoIDFiltro))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ID de produto inválido. Tente novamente.");
                        }
                    }

                    List<Venda> vendasProduto = vendaRepository.BuscarPorProduto(produtoIDFiltro);
                    if (vendasProduto.Count == 0)
                    {
                        Console.WriteLine("Produto não encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Vendas do produto:");
                        vendaRepository.MostrarVendas(vendasProduto);
                    }
                    ContinueVendas();
                    break;

                case 5:
                    int vendaID;

                    while (true)
                    {
                        Console.WriteLine("Digite o ID da venda:");
                        var vendaIDStr = Console.ReadLine();
                        if (int.TryParse(vendaIDStr, out vendaID))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ID de venda inválido. Tente novamente.");
                        }
                    }

                    Venda venda = vendaRepository.BuscarPorID(vendaID);
                    if (venda != null)
                    {
                        Console.WriteLine("Venda encontrada:");
                        vendaRepository.MostrarVendaPorID(vendaID);
                    }
                    else
                    {
                        Console.WriteLine("Venda não encontrada.");
                    }
                    break;

                case 6:
                    sair = true;
                    ExibirMenu();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
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
                ExibirMenuCliente();
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
            ExibirMenuProduto();
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
                ExibirMenuProduto();
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
            ExibirMenuVendas();
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
                ExibirMenuVendas();
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