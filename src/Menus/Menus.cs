public class Menu
{
    private MenusExibir menusExibir = new MenusExibir();


    public void ExibirMenu(){
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\nSelecione uma opção:");
            Console.WriteLine("1. Aba Cliente");
            Console.WriteLine("2. Aba Produto");
            Console.WriteLine("3. Aba Vendas");

            string escolhaStr = Console.ReadLine()!;

            if (!int.TryParse(escolhaStr, out int escolha))
            {
                Console.WriteLine("Escolha inválida! Digite um número correspondente à opção desejada.");
                continue;
            }

            switch(escolha){
                case 1:
                    menusExibir.ExibirMenuCliente();
                    break;
                case 2: 
                    menusExibir.ExibirMenuProduto();
                    break;
                case 3: 
                    menusExibir.ExibirMenuVendas();
                    break;
            }
        }
    }
}