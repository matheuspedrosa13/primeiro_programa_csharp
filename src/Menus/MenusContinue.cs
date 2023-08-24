public class MenusContinuar{
    
    private MenusExibir menusExibir = new MenusExibir();
    private Menu menuPrincipal = new Menu();

    public void ContinueCliente()
    {
        Console.WriteLine("Deseja continuar no cliente?");
        Console.WriteLine("1. Sim");
        Console.WriteLine("2. Voltar para o menu principal");
        var escolhaStr = Console.ReadLine();

        if (!int.TryParse(escolhaStr, out int escolha))
        {
            Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
            menusExibir.ExibirMenuCliente();
        }
        
        switch (escolha)
        {
            case 1:
                menusExibir.ExibirMenuCliente();
                break;

            case 2:
                menuPrincipal.ExibirMenu();
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
        var escolhaStr = Console.ReadLine();

        if (!int.TryParse(escolhaStr, out int escolha))
        {
            Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
            menusExibir.ExibirMenuCliente();
        }
        
        switch (escolha)
        {
            case 1:
                menusExibir.ExibirMenuProduto();
                break;

            case 2:
                menuPrincipal.ExibirMenu();
                break; 

            default:
                Console.WriteLine("Opção inválida.");
                ContinueProduto(); 
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
            ContinueVendas();
        }

        switch (escolha)
        {
            case 1:
                menusExibir.ExibirMenuVendas();
                break;

            case 2:
                menuPrincipal.ExibirMenu();
                break;

            default:
                Console.WriteLine("Opção inválida.");
                ContinueVendas();
                break;
        }
    }
}