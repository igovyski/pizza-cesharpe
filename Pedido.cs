class Pedido {
    public string Nome {get; set;}
    public string Telefone {get; set;}
    public IEnumerable<Pizza> PizzasPedido {get; set;}
    public double Total {get; set;}
}