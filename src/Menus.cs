using System;
using ClasseCliente; 

namespace ClasseMenu
{
    class Menus
    {   
        public void ExibirMenu(){
            Console.Write("Por onde você deseja começar?\n\n1. Clientes\n2. Produtos\n3. Vendas\n\nDigite aqui a escolha: ");
            string? valor = Console.ReadLine();
            if (int.TryParse(valor, out int valor2)){
                if(valor2 == 1){
                    ExibirMenuClientes();
                }
            }
        }
        public void Continuar(){
            Console.Write("\nDeseja voltar ao menu?\n\n1. Voltar\n2. Encerrar programa\n\n");
            string? valor = Console.ReadLine();
            if (int.TryParse(valor, out int valor2)){
                if (valor2 == 1){
                    ExibirMenu();
                }else if(valor2 == 2){
                    Console.Write("Obrigado por usar o meu sistema, até logo!");
                }else{
                    Console.WriteLine("\nOpção inválida");
                    ExibirMenu();
                }
            }
        }
        public void ExibirMenuClientes(){
            Console.Write("\n\n----Clientes----\n\nO que você deseja fazer?\n\n1. Listar todos os clientes\n\n2. Mostrar por id\n\n3. Mostrar por nome\n\n4. Mostrar por CPF\n\nDigite aqui a escolha: ");
            string? valor = Console.ReadLine();
            
            if (int.TryParse(valor, out int valor2)){
                if (valor2 == 1){
                    MenuClientelistar();
                }
                else if (valor2 == 2){
                    MenuClientelistarId();
                }
                else{
                    Console.WriteLine("\nOpção inválida");
                    ExibirMenuClientes();
                }
            }
            else{
                Console.WriteLine("\nDeve ser um número inteiro");
                ExibirMenuClientes();
            }
        }

        public void MenuClientelistar(){
            List<Cliente> listaClientes = new List<Cliente>();
            Cliente cliente1 = new Cliente(12, true, "João Silva", "123.456.789-00", "Masculino", "(11) 1234-5678", "joao@example.com");
            listaClientes.Add(cliente1);

            Cliente cliente2 = new Cliente(13, true, "Maria Souza", "987.654.321-00", "Feminino", "(21) 9876-5432", "maria@example.com");
            listaClientes.Add(cliente2);

            foreach (Cliente cliente in listaClientes)
            {
                cliente.MostrarInformacoes();
                Console.WriteLine();
                Continuar();
            }
        }

        public void MenuClientelistarId(){
            List<Cliente> listaClientes = new List<Cliente>();
            Cliente cliente1 = new Cliente(12, true, "João Silva", "123.456.789-00", "Masculino", "(11) 1234-5678", "joao@example.com");
            listaClientes.Add(cliente1);

            Cliente cliente2 = new Cliente(13, true, "Maria Souza", "987.654.321-00", "Feminino", "(21) 9876-5432", "maria@example.com");
            listaClientes.Add(cliente2);

            Console.Write("Qual o id do cliente? ");
            string? valor = Console.ReadLine();
            if(int.TryParse(valor, out int valor2)){
                foreach(Cliente cliente in listaClientes){
                    if(cliente.Id == valor2){
                        Cliente.BuscarPorId(listaClientes, valor2);
                        Continuar();
                        break;
                    }else{
                        Console.Write("Não existe cliente com esse id");
                    }
                }
            }else{
                Console.Write("\nO id deve ser um número inteiro");
                Continuar();
            }
        }
    }
}
