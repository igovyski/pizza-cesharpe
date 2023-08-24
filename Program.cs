int i = 1;
List<Pizza> pizzas = new List<Pizza>();


while (i!=0){
    Console.WriteLine("\nBem-vindo ao projeto Pizzaria!");
    Console.WriteLine("ESCOLHA UMA OPÇÃO:");
    Console.WriteLine("1 - Adicionar Pizza");
    Console.WriteLine("2 - Listar Pizzas");
    Console.WriteLine("3 - Sair");
    i = Convert.ToInt16(Console.ReadLine());
    
    if (i == 1){
        Console.WriteLine("\nAdicionar uma pizza!");
        Console.WriteLine("Digite o nome da pizza:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o sabor da pizza:");
        string sabor = Console.ReadLine();
        Console.WriteLine("Digite o preco da pizza (XX,XX):");
        string preco = Console.ReadLine();
        pizzas.Add(new Pizza { Nome = nome, Sabor = sabor, Preco = preco});

    }else if (i == 2){
        Console.WriteLine("\nListar pizza");
        foreach (Pizza pizza in pizzas)
        {
            Console.WriteLine($"Nome = {pizza.Nome}, Sabor = {pizza.Sabor}, Preco = {pizza.Preco}");
        }
    } else if (i == 3){
        i = 0;
    }
}
