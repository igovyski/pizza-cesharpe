class Pedido {
    public string Nome {get; set;}
    public string Telefone {get; set;}
    public IEnumerable<Pizza> PizzasPedido {get; set;}
    public double Total {get; private set;}

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
    }
}