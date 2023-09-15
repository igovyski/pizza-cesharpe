class Pedido {
    public string Nome {get; set;}
    public string Telefone {get; set;}
    public IEnumerable<Pizza> PizzasPedido {get; set;}
    public double Total {get; private set;}
    public double FaltaPagar {get; private set;}
    public string StatusPagamento {get; private set;}

    public Pedido(string nome, string telefone, IEnumerable<Pizza> pizzasPedido) {
        Nome = nome;
        Telefone = telefone;
        PizzasPedido = pizzasPedido;

        CalcularTotalPedido();
    }

    public void CalcularTotalPedido(){
        double totalPizzas = 0;
        foreach (var pizza in PizzasPedido) {
            totalPizzas += pizza.Preco;
        }
        
        Total = totalPizzas;
        FaltaPagar = totalPizzas;
        StatusPagamento = "NÃO";
    }

    public void EfetuarPagamento(double valor, string FormaPagamento){
        double aux = FaltaPagar;
        
        if (valor == FaltaPagar){
            StatusPagamento = "SIM";
            FaltaPagar -= valor;
        } 
        else if (valor > FaltaPagar && FormaPagamento == "DINHEIRO"){
            StatusPagamento = "SIM";
            FaltaPagar = 0;
        }
        else if (valor < FaltaPagar){
            FaltaPagar -= valor;
        }
        
        Console.WriteLine("VALOR RECEBIDO COM SUCESSO\n");
        Console.WriteLine($"TOTAL PAGO: R${(valor).ToString("N2")} ({FormaPagamento})");
        Console.WriteLine($"FALTA: R${(FaltaPagar).ToString("N2")}");
        if (FormaPagamento == "DINHEIRO"){
            Console.WriteLine($"TROCO: R${(valor - aux).ToString("N2")}");
        }
        else {
            Console.WriteLine($"TROCO: R${(0).ToString("N2")}");
        }
    }

}