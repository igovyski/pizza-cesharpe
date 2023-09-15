class Menu {

    private Cardapio classeCardapio;
    private PedidoService classePedidoService;

    public Menu() {
        classeCardapio = new Cardapio(); 
        classePedidoService = new PedidoService(classeCardapio);
    }

    public void MenuInicial(){
        Console.WriteLine("\nBem-vindo ao projeto Pizzaria!");
        Console.WriteLine("ESCOLHA UMA OPÇÃO:");
        Console.WriteLine("1 - Adicionar Pizza");
        Console.WriteLine("2 - Listar Pizzas");
        Console.WriteLine("3 - Criar Novo Pedido");
        Console.WriteLine("4 - Listar Pedidos");
        Console.WriteLine("5 - Pagar Pedido");
        Console.WriteLine("6 - Sair");
    }

    public void MenuAdicionarPizza(){
        Console.WriteLine("\nAdicionar uma pizza!");
        Console.WriteLine("Digite o sabor da pizza:");
        string sabor = Console.ReadLine();
        Console.WriteLine("Digite o preco da pizza (XX,XX):");
        double preco = double.Parse(Console.ReadLine());
        classeCardapio.AdicionarPizza(sabor, preco);
    }

    public void MenuListarPizza(){
        Console.WriteLine("\nListar pizzas");
        classeCardapio.ListarPizzas();
    }

    public void MenuNovoPedido(){
        Console.WriteLine("\nQual o nome do cliente?");
        string nome = Console.ReadLine();
        Console.WriteLine("Qual o telefone do cliente?");
        string telefone = Console.ReadLine();

        /*
        List<Pizza> CardapioPizzas = new List<Pizza>{
            new Pizza {Sabor = "Mussarela", Preco = 30},
            new Pizza {Sabor = "Frango com catupiry", Preco = 40},
            new Pizza {Sabor = "Costela desfiada", Preco = 45}
        };
        */

        List<Pizza> ListaPizzas = new List<Pizza>();
        classePedidoService.AddPizzasPedido(ListaPizzas);

        if (ListaPizzas.Count > 0){
            classePedidoService.NovoPedido(nome, telefone, ListaPizzas);
        }
        else {
            Console.WriteLine("Pedido sem pizzas, faça um novo pedido.");
        }

    }

    public void MenuListarPedidos(){
        classePedidoService.ListarTodosPedidos();
    }

    public void MenuPagarPedido(){
        Console.WriteLine("Qual pedido deseja pagar?");
        int i = 1;
        foreach (var pedido in classePedidoService.ListaPedidos){
            Console.WriteLine($"#{i} - Cliente: {pedido.Nome} - Falta: R${(pedido.FaltaPagar).ToString("N2")}");
            i++;
        }

        int escolhaPedido = int.Parse(Console.ReadLine()) - 1;
        
        if (escolhaPedido >= 0 && escolhaPedido < classePedidoService.ListaPedidos.Count && classePedidoService.ListaPedidos[escolhaPedido].StatusPagamento == "NÃO") {
            Pedido pedidoParaPagar = classePedidoService.ListaPedidos[escolhaPedido];
            classePedidoService.PagarPedido(pedidoParaPagar);
        } 
        else {
            Console.WriteLine("Escolha outro pedido.");
        }
        

    }

}