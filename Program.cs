int mainChoice = 0;

List<Pizza> CardapioPizzas = new List<Pizza>{
    new Pizza {Sabor = "Mussarela", Preco = 30},
    new Pizza {Sabor = "Frango com catupiry", Preco = 40},
    new Pizza {Sabor = "Costela desfiada", Preco = 45}
};

List<Pedido> ListaPedidos = new List<Pedido>();

bool exit = false;

while (!exit){
    Console.WriteLine("\nBem-vindo ao projeto Pizzaria!");
    Console.WriteLine("ESCOLHA UMA OPÇÃO:");
    Console.WriteLine("1 - Adicionar Pizza");
    Console.WriteLine("2 - Listar Pizzas");
    Console.WriteLine("3 - Criar Novo Pedido");
    Console.WriteLine("4 - Listar Pedidos");
    Console.WriteLine("5 - Sair");
    
    mainChoice = int.Parse(Console.ReadLine());
           
    switch (mainChoice){
        case 1:
            Console.WriteLine("\nAdicionar uma pizza!");
            Console.WriteLine("Digite o sabor da pizza:");
            string sabor = Console.ReadLine();
            Console.WriteLine("Digite o preco da pizza (XX,XX):");
            double preco = double.Parse(Console.ReadLine());
            CardapioPizzas.Add(new Pizza {Sabor = sabor, Preco = preco});
            break;
        
        case 2:
            Console.WriteLine("\nListar pizzas");
            foreach (Pizza pizza in CardapioPizzas){
                Console.WriteLine($"{pizza.Sabor} - R${(pizza.Preco).ToString("N2")}");
            }
            break;
        
        case 3:
            Console.WriteLine("\nQual o nome do cliente?");
            string nome = Console.ReadLine();
            Console.WriteLine("Qual o telefone do cliente?");
            string telefone = Console.ReadLine();
            
            bool addPizza = false;

            List<Pizza> ListaPizzas = new List<Pizza>();
            while(!addPizza){
                Console.WriteLine("Escolha uma pizza para adicionar:");
                int i = 1;
                foreach (Pizza pizza in CardapioPizzas){
                    Console.WriteLine($"{i} - {pizza.Sabor} - R${(pizza.Preco).ToString("N2")}");
                    i++;
                }
                int escolha = int.Parse(Console.ReadLine());

                ListaPizzas.Add(new Pizza {Sabor = CardapioPizzas[escolha-1].Sabor, Preco = CardapioPizzas[escolha-1].Preco});

                Console.WriteLine("\nDeseja escolher outra pizza?\n1 - Sim | 2 - Não");
                int maisPizza = int.Parse(Console.ReadLine());

                switch (maisPizza){
                    case 1:
                        break;
                    
                    case 2:
                        addPizza = true;
                    break;
                    
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
            
            double totalPreco = 0;
            foreach (var pizza in ListaPizzas){
                totalPreco += pizza.Preco;
            }

            Console.WriteLine("PEDIDO CRIADO");
            Console.WriteLine($"Total: R${totalPreco}");

            ListaPedidos.Add(new Pedido {Nome = nome, Telefone = telefone, PizzasPedido = ListaPizzas, Total = totalPreco});

            break;
        
        case 4:
            foreach (var pedido in ListaPedidos){
                Console.WriteLine($"\nCliente: {pedido.Nome} - {pedido.Telefone}");
                Console.WriteLine($"Pizzas do Pedido:");
                foreach (var pizza in pedido.PizzasPedido){
                    Console.WriteLine($"{pizza.Sabor} - R${(pizza.Preco).ToString("N2")}");
                }
                Console.WriteLine($"Total: R${(pedido.Total).ToString("N2")}");
            }
            break;

        case 5:
            exit = true;
            break;

        default:
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
    }
}