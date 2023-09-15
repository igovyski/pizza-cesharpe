class Cardapio {
    public List<Pizza> CardapioPizzas = new List<Pizza>{
        new Pizza {Sabor = "Mussarela", Preco = 30},
        new Pizza {Sabor = "Frango com catupiry", Preco = 40},
        new Pizza {Sabor = "Costela desfiada", Preco = 45}
    };

    public void AdicionarPizza(string sabor, double preco){
        CardapioPizzas.Add(new Pizza{Sabor = sabor, Preco = preco});
    }

    public void ListarPizzas(){
        int i = 1;

        if (CardapioPizzas.Count > 1){
            foreach (Pizza pizza in CardapioPizzas){
                Console.WriteLine($"{i} - {pizza.Sabor} - R${(pizza.Preco).ToString("N2")}");
                i++;
            }
        } 
        else {
            Console.WriteLine("\nNão há pizzas no cardápio");
        }
    }

}