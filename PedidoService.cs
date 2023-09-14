class PedidoService {
    private Cardapio cardapio;
    private List<Pedido> ListaPedidos = new List<Pedido>();

    public PedidoService(Cardapio cardapio) {
        this.cardapio = cardapio;
    }

    public void AddPizzasPedido(List<Pizza> ListaPizzas){

        bool addPizza = true;

        while(addPizza){
            Console.WriteLine("Escolha uma pizza para adicionar:");
            cardapio.ListarPizzas();
            int escolha = int.Parse(Console.ReadLine());

            ListaPizzas.Add(new Pizza {Sabor = cardapio.CardapioPizzas[escolha-1].Sabor, Preco = cardapio.CardapioPizzas[escolha-1].Preco});

            Console.WriteLine("\nDeseja escolher outra pizza?\n1 - Sim | 2 - Não");
            int maisPizza = int.Parse(Console.ReadLine());

            switch (maisPizza){
                case 1:
                    break;
                
                case 2:
                    addPizza = false;
                break;
                
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

        }
    }

    public void NovoPedido(string nome, string telefone, List<Pizza> listaPizzas){
        double totalPedido = 0;
        
        foreach (var pizza in listaPizzas){
            totalPedido += pizza.Preco;
        }

        ListaPedidos.Add(new Pedido(nome, telefone, listaPizzas));

        Console.WriteLine("PEDIDO CRIADO");
        Console.WriteLine($"Total: R${(totalPedido).ToString("N2")}");
    }

    public void ListarTodosPedidos(){
        foreach (var pedido in ListaPedidos){
            Console.WriteLine($"\nCliente: {pedido.Nome} - {pedido.Telefone}");
            Console.WriteLine($"Pizzas do Pedido:");
            foreach (var pizza in pedido.PizzasPedido){
                Console.WriteLine($"{pizza.Sabor} - R${(pizza.Preco).ToString("N2")}");
            }
            Console.WriteLine($"Total: R${(pedido.Total).ToString("N2")}");
        }
    }

}