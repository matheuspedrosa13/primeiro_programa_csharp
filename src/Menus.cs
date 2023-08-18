public class Menus
{
    private ClienteService clienteService = new ClienteService();
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
    public void ExibirMenu()
    
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

            Console.WriteLine("6. Sair");


            string escolhaStr = Console.ReadLine();

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch (escolha)
            {
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
                    break;

                case 2:
                    Console.WriteLine("Lista de todos os clientes:");
                    
                    ClasseRepository.MostrarTodosClientes();
                    
                    break;

                case 3:
                    Console.WriteLine("Digite o id do cliente:");
                    string idString = Console.ReadLine();
                    
                    if (int.TryParse(idString, out int id2))
                    {
                        
                        ClasseRepository.BuscarPorId(id2);
                    }else{
                        Console.WriteLine("ID inválido! Certifique-se de digitar um número inteiro.");
                        break;
                    }
                    
                    break;

                case 4:
                    Console.WriteLine("Digite o nome do cliente:");
                    string nome2 = Console.ReadLine();
                    ClasseRepository.BuscarPorNome(nome2);
                    break;
                
                case 5:
                    Console.WriteLine("Digite o CPF do cliente:");
                    string cpf2 = Console.ReadLine();
                    ClasseRepository.BuscarPorCPF(cpf2);
                    break;

                case 6:
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    // Métodos para as outras opções do menu...

}

