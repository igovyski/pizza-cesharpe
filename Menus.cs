class Menu {

    private Cardapio cardapio;
    private PedidoService pedidoService;

    public Menu() {
        cardapio = new Cardapio(); 
        pedidoService = new PedidoService(cardapio);
    }

    public void MenuInicial(){
        Console.WriteLine("\nBem-vindo ao projeto Pizzaria!");
        Console.WriteLine("ESCOLHA UMA OPÇÃO:");
        Console.WriteLine("1 - Adicionar Pizza");
        Console.WriteLine("2 - Listar Pizzas");
        Console.WriteLine("3 - Criar Novo Pedido");
        Console.WriteLine("4 - Listar Pedidos");
        Console.WriteLine("5 - Sair");
    }

    public void MenuAdicionarPizza(){
        Console.WriteLine("\nAdicionar uma pizza!");
        Console.WriteLine("Digite o sabor da pizza:");
        string sabor = Console.ReadLine();
        Console.WriteLine("Digite o preco da pizza (XX,XX):");
        double preco = double.Parse(Console.ReadLine());
        cardapio.AdicionarPizza(sabor, preco);
    }

    public void MenuListarPizza(){
        Console.WriteLine("\nListar pizzas");
        cardapio.ListarPizzas();
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
        pedidoService.AddPizzasPedido(ListaPizzas);

        pedidoService.NovoPedido(nome, telefone, ListaPizzas);

    }

    public void MenuListarPedidos(){
        pedidoService.ListarTodosPedidos();
    }

}