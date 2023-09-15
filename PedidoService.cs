using Microsoft.VisualBasic;

class PedidoService {
    private Cardapio classeCardapio;
    public List<Pedido> ListaPedidos = new List<Pedido>();

    public PedidoService(Cardapio classeCardapio) {
        this.classeCardapio = classeCardapio;
    }

    public void AddPizzasPedido(List<Pizza> ListaPizzas){

        bool addPizza = true;

        while(addPizza){
            Console.WriteLine("Escolha uma pizza para adicionar:");
            classeCardapio.ListarPizzas();
            int escolha = int.Parse(Console.ReadLine()) -1;

            if (escolha >= 0 && escolha <= classeCardapio.CardapioPizzas.Count){
                ListaPizzas.Add(new Pizza {Sabor = classeCardapio.CardapioPizzas[escolha].Sabor, Preco = classeCardapio.CardapioPizzas[escolha].Preco});
            } 
            else {
                Console.WriteLine("Opção inválida");
            }

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
        int i = 1;
        if (ListaPedidos.Count > 0){
            foreach (var pedido in ListaPedidos){
                Console.WriteLine($"\nPEDIDO {i}");
                Console.WriteLine($"Cliente: {pedido.Nome} - {pedido.Telefone}");
                Console.WriteLine($"Pizzas do Pedido:");
                foreach (var pizza in pedido.PizzasPedido){
                    Console.WriteLine($"{pizza.Sabor} - R${(pizza.Preco).ToString("N2")}");
                }
                Console.WriteLine($"Total: R${(pedido.Total).ToString("N2")}");
                Console.WriteLine($"Quanto falta para pagar: R${(pedido.FaltaPagar).ToString("N2")}");
                Console.WriteLine($"Pago: {pedido.StatusPagamento}");
                i++;
            }
        }
        else {
            Console.WriteLine("\nNão há pedidos");
        }
    }

    public void PagarPedido(Pedido pedidoParaPagar){
        Console.WriteLine("ESCOLHA A FORMA DE PAGAMENTO:");
        Console.WriteLine("1 - Dinheiro");
        Console.WriteLine("2 - Cartão de Débito");
        Console.WriteLine("3 - Vale-Refeição");
        
        int escolha = int.Parse(Console.ReadLine());
        string formaPagamento = "";
        switch(escolha){
            case 1:
                formaPagamento = "DINHEIRO";
                break;
            case 2:
                formaPagamento = "CARTÃO DE DÉBITO";
                break;
            case 3:
                formaPagamento = "VALE-REFEIÇÃO";
                break;
            default:
                Console.WriteLine("Digite uma forma de pagamento válida");
                break;
        }
        Console.WriteLine("Qual o valor:");
        double valorPago = double.Parse(Console.ReadLine());
        if (valorPago <= pedidoParaPagar.FaltaPagar && formaPagamento != "DINHEIRO"){
            pedidoParaPagar.EfetuarPagamento(valorPago, formaPagamento);
            Console.WriteLine($"IF {formaPagamento}");
        } 
        else if (formaPagamento == "DINHEIRO") {
            Console.WriteLine($"ELSE IF {formaPagamento}");
            pedidoParaPagar.EfetuarPagamento(valorPago, formaPagamento);
        }
        else {
            Console.WriteLine($"ELSE {formaPagamento}");
            Console.WriteLine($"Com o {formaPagamento} você só pode pagar um valor menor ou igual do que falta ser pago.");
        }
        
    }

}