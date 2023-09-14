class PizzariaApp {
    private Menu menu;

    public PizzariaApp() {
        menu = new Menu();
    }

    public void Run() {
        bool exit = false;

        while (!exit) {
            menu.MenuInicial();

            int mainChoice = int.Parse(Console.ReadLine());

            switch (mainChoice) {
                case 1:
                    menu.MenuAdicionarPizza();
                    break;

                case 2:
                    menu.MenuListarPizza();
                    break;

                case 3:
                    menu.MenuNovoPedido();
                    break;

                case 4:
                    menu.MenuListarPedidos();
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
    }
}
