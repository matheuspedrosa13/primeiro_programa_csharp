public class Cliente
{   
    
    public int Id {get; set;}
    public bool Status {get; set;}
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Sexo { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    // Construtor que aceita parâmetros para todas as propriedades
    public Cliente(int id, bool status, string nome, string cpf, string sexo, string telefone, string email)
    {   
        Id = id;
        Status = status;
        Nome = nome;
        CPF = cpf;
        Sexo = sexo;
        Telefone = telefone;
        Email = email;
    }
}   