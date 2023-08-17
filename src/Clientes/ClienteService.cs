using System.Text.RegularExpressions;

public class ClienteService{

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
            Console.Write("O valor não pode ser nulo e nem vazio");
            return false;
        }
        if(!ValidarTelefone(cliente.Telefone)){
            Console.Write("Telefone deve seguir o padrão: (XX)XXXXX-XXXX");
        }
        bool adicionadoComSucesso = ClasseRepository.AddCliente(cliente);

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

    public bool ValidarTelefone(string telefone){
        Regex Rgx = new Regex(@"^\(\d{2}\)\d{5}-\d{4}$"); //formato (XX)XXXXX-XXXX

        if (!Rgx.IsMatch(telefone))
            return false;
        else
            return true;
    }  
    
                
    static bool TemSobrenome(string nome){
        string[] partesNome = nome.Split(' ');
        return partesNome.Length >= 2;
    }

    static bool NaoContemNumeros(string texto){
        foreach (char c in texto){
            if (char.IsDigit(c)){
                return false;
            }
        }
        return true;
    }
    static bool VerificarVazio(object valor) 
    {
        if (valor == null) 
        {
            return false;
        }

        if (valor is string str) 
        {
            return !string.IsNullOrEmpty(str); // Altere para !string.IsNullOrEmpty
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