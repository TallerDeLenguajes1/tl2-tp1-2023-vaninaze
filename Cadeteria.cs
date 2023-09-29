namespace EspacioPedido;
using EspacioInforme;
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> ListaCadete = new List<Cadete>();

    private List<Pedido> ListaPedidos = new List<Pedido>();

    public Cadeteria(){
        
    }
    public Cadeteria(string nomb = "", string tel = "")
    {
        this.nombre = nomb;
        this.telefono = tel;
    }
    public void crearPedido(int num, string obs, string nomb, string dir, string telef, string datosRef){
        Pedido ped = new Pedido(num, obs, nomb, dir, telef, datosRef);
        ListaPedidos.Add(ped);
    }
    public void crearCadete(int id, string nombre, string dir, string telef){
        Cadete cad = new Cadete(id, nombre, dir, telef);
        ListaCadete.Add(cad);
    }
    public void agregarCadete(Cadete cad){
        ListaCadete.Add(cad);
    }
    public void MostrarCadeteria(){
        Console.WriteLine("Nombre: "+ this.nombre);
        Console.WriteLine("Telefono: "+ this.telefono);
    }
    public void MostrarCadetes()
    {
        Console.WriteLine("-- CADETES --");
        foreach (Cadete cad in ListaCadete)
        {
            cad.MostrarCadete();
        }
    }
    public void MostrarPedidos(){
        Console.WriteLine("--- PEDIDOS --- ");
        foreach (var ped in ListaPedidos)
        {
            ped.MostrarPedido();
        }
    }
    public float JornalACobrar(int idCad){
        float monto;
        int cont=0;
        foreach(Pedido ped in ListaPedidos){
            if(ped.IDcad != 0 && ped.IDcad == idCad){
                cont++;
            }
        }
        monto = 500*cont;
        return monto;
    }
    public void AsignarCadeteAPedido(int idCad, int idPed){
        Cadete? cadBuscado = ListaCadete.FirstOrDefault(cad => cad.Id == idCad);
        if(cadBuscado != null){
            ListaPedidos[idPed].GuardarCadete(cadBuscado);
        } else {
            Console.WriteLine("Error! Cadete no encontrado");
        }
    }
    public void ReasignarPedido(int idPed, int idCad)
    {
        Pedido? ped = ListaPedidos.FirstOrDefault(ped => ped.Numero == idPed);
        if(ped != null){
            foreach (Cadete cad in ListaCadete)
            {
                if (cad.Id == idCad && ped.IDcad != idCad)
                {
                    ped.GuardarCadete(cad);
                }
                else
                {
                    Console.WriteLine("Cadete no existe");
                }
            }
        }
    }
}