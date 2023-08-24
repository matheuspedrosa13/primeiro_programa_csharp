public class MenusFuncionamento{
    private ClienteService clienteService = new ClienteService();

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
}