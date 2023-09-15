namespace EspacioPedido;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    private List<Pedido> listaPedido = new List<Pedido>();


    public void MostrarCadete()
    {
        Console.WriteLine("Cadete: "+id);
        Console.WriteLine("  Nombre: "+nombre);
        Console.WriteLine("  Direccion: "+direccion);
        Console.WriteLine("  Telefono: "+telefono);

        Console.WriteLine("  --- Pedidos del Cadete: ");
        if(this.listaPedido == null){
            Console.WriteLine("  El cadete no tiene pedidos.");
        } else {
            foreach (var ped in listaPedido)
            {
                ped.MostrarPedido();
            }
        }
    }

    public Cadete(int id, string nom, string dir, string telef)
    {
        this.id = id;
        nombre = nom;
        direccion = dir;
        telefono = telef;
    }

    public int Id { get => id; }

    public void AgregarPedido(Pedido pedido)
    {
        listaPedido.Add(pedido);
    }

    public int buscarPedido(Pedido pedido)
    {
        foreach (Pedido ped in listaPedido)
        {
            if (ped == pedido)
            {
                return 1; //el pedido pertenece al cadete
            }
        }
        return 0;
    }
    public void EntregarPedido(Pedido pedido)
    {
        foreach (var ped in listaPedido)
        {
            if (ped == pedido)
            {
                ped.CambiarEstado();
            }
        }
    }
    public int CantEnvios(){
        int cont=0;
        foreach (var ped in listaPedido)
        {
            if (ped.Estado == 2) //entregado
            {
                cont++;
            }
        }
        return cont;
    }
    public float JornalACobrar()
    {
        int cobrar = 0;
        foreach (var pedido in listaPedido)
        {
            if (pedido.IDcad == id)
            {
                if (pedido.Estado == 2)
                {
                    cobrar++;
                }
            }
        }
        return cobrar * 500;
    }
}