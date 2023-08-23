using System.Text.RegularExpressions;

public class ClienteService{
    private static ClientesDatabase database = new ClientesDatabase();
    private static ClienteRepository clienteRepository = new ClienteRepository();


    public bool addCliente(Cliente cliente)
    {
        if (!TemSobrenome(cliente.Nome))
        {
            Console.Write("O nome deve ter um sobrenome!");
            return false;
        }
        else if (!NaoContemNumeros(cliente.Nome))
        {
            Console.WriteLine("O nome não pode conter números!");
            return false;
        }
        if (!ValidarCPF(cliente.CPF))
        {
            Console.Write("CPF inválido!");
            return false;
        }
        if (cliente.Id == 0 || !VerificarVazio(cliente.Nome) || !VerificarVazio(cliente.CPF) || !VerificarVazio(cliente.Sexo) || !VerificarVazio(cliente.Telefone) || !VerificarVazio(cliente.Email))
        {
            Console.Write("O valor não pode ser nulo e nem vazio\n");
            return false;
        }
        if(!ValidarTelefone(cliente.Telefone)){
            Console.Write("Telefone deve seguir o padrão: (XX)XXXXX-XXXX\n");
            return false;
        }

        if(!ValidarEmail(cliente.Email)){
            Console.Write("Email não está no formato correto\n");
            return false;
        }

        if(ClienteRepository.ExisteID(cliente.Id) == true){
            Console.Write("O Id passado já está sendo usado, ele deve ser único!\n");
            return false;
        }
        
        if(ClienteRepository.ExisteCPF(cliente.CPF) == true){
            Console.Write("O CPF passado já está sendo usado\n");
            return false;
        }

        if(ClienteRepository.ExisteTelefone(cliente.Telefone) == true){
            Console.Write("O telefone passado já está sendo usado\n");
            return false;
        }

        if(ClienteRepository.ExisteEmail(cliente.Email) == true){
            Console.Write("O email passado já está sendo usado\n");
            return false;
        }

        bool adicionadoComSucesso = ClienteRepository.AddCliente(cliente);

        if (adicionadoComSucesso)
        {
            Console.WriteLine("Cliente adicionado com sucesso!");
            return true;
        }
        else
        {
            Console.WriteLine("Não foi possível adicionar o cliente.");
            return false;
        }
    }
    
    public void BuscarPorId(int id)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Id == id)
            {
                ClienteRepository.MostrarInformacoes(cliente);
                break;
            }
        }
    }

    public static bool ExisteCliente(int id)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    public static Cliente MostrarCliente(int id)
    {
        return ClienteRepository.ObterClientePorId(id);
    }
    
    public void BuscarPorCPF(string cpf)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.CPF == cpf)
            {
                ClienteRepository.MostrarInformacoes(cliente);
                break;
            }
        }
    }

    public void BuscarPorNome(string nome)
    {
        foreach (Cliente cliente in database.clientes)
        {
            if (cliente.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                ClienteRepository.MostrarInformacoes(cliente);
                break;
            }
        }
    }


    public bool ValidarSexoOpcao(string opcao)
    {
        string opcaoFormatada = opcao.ToLower();
        if(opcaoFormatada == "m" || opcaoFormatada == "f" || opcaoFormatada == "p"){
            return true;
        }
        return false;
    }


    public bool ValidarTelefone(string telefone)
    {
        Regex Rgx = new Regex(@"^\d{11}$");

        if (!Rgx.IsMatch(telefone))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool ValidarEmail(string email)
    {
        Regex emailRegex = new Regex(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.\w+$");
        if (!emailRegex.IsMatch(email))
        {
            return false;
        }

        return true;
    }


    public static bool TemSobrenome(string nome){
        string[] partesNome = nome.Split(' ');
        return partesNome.Length >= 2;
    }

    public static bool NaoContemNumeros(string texto){
        foreach (char c in texto){
            if (char.IsDigit(c)){
                return false;
            }
        }
        return true;
    }

    public static bool VerificarVazio(object valor) 
    {
        if (valor == null) 
        {
            return false;
        }

        if (valor is string str) 
        {
            return !string.IsNullOrEmpty(str); 
        }

        return true;
    }

    static bool ValidarCPF(string cpf)
    {
        cpf = Regex.Replace(cpf, @"[^\d]", ""); 
        if (cpf.Length != 11)
            return false;

        int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        tempCpf = cpf.Substring(0, 9);
        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }
}