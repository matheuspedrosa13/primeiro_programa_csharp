public class Menus
{
    private ClienteService clienteService = new ClienteService();
    public void ExibirMenu()
    
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1. Adicionar Cliente");
            Console.WriteLine("2. Mostrar Todos os Clientes");
            Console.WriteLine("3. Buscar Cliente por ID");
            Console.WriteLine("4. Sair");

            int escolha = int.Parse(Console.ReadLine());

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

                    Console.WriteLine("Digite o sexo do cliente:");
                    string sexo = Console.ReadLine();

                    Console.WriteLine("Digite o telefone do cliente:");
                    string telefone = Console.ReadLine();

                    Console.WriteLine("Digite o email do cliente:");
                    string email = Console.ReadLine();

                    Cliente novoCliente = new Cliente(id, true, nome, cpf, sexo, telefone, email);

                    bool clienteAdicionado = clienteService.addCliente(novoCliente);

                    if (clienteAdicionado)
                    {
                        Console.WriteLine("Cliente adicionado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível adicionar o cliente.");
                    }
                    break;





                case 2:
                    Console.WriteLine("Lista de todos os clientes:");
                    
                    ClasseRepository.MostrarTodosClientes();
                    
                    break;

                case 3:
                    // Lógica para buscar cliente por ID
                    break;
                case 4:
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

