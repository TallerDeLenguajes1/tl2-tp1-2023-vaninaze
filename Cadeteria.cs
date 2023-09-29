namespace EspacioPedido;
using EspacioInforme;
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> ListaCadete = new List<Cadete>();

    public Cadeteria()
    {

    }
    public Cadeteria(string nomb = "", string tel = "")
    {
        this.nombre = nomb;
        this.telefono = tel;
    }
    public void AltaPedido(int idcad, int num, string obs, string nomb, string dir, string telef, string datosDir)
    {
        foreach (var cadete in ListaCadete)
        {
            if (cadete.Id == idcad)
            {//reemplazar con metodos linq
                Pedido pedido = new Pedido(num, obs, nomb, dir, telef, datosDir);
                pedido.CambiarEstado();
                cadete.AgregarPedido(pedido);
            }
        }
    }
    public void Mostrar()
    {
        Console.WriteLine("-- CADETES --");
        foreach (var cad in ListaCadete)
        {
            cad.MostrarCadete();
        }
    }
    public void CrearCadete(int id, string nomb, string dir, string telef)
    {
        Cadete cad = new Cadete(id, nomb, dir, telef);
        ListaCadete.Add(cad);
    }

    public void ReasignarPedido(Pedido pedido, int id)
    {
        foreach (Cadete cad in ListaCadete)
        {
            if (cad.Id == id && cad.buscarPedido(pedido) != 1)
            {
                cad.AgregarPedido(pedido);
            }
            else
            {
                Console.WriteLine("Cadete no existe");
            }
        }
    }
    //Carga todas las cadeterias, selecciono una y cargo sus cadetes
    public void cargarCadeteria()
    {
        string nombreArch = @"C:\tl2-tp1-2023-vaninaze\Cadeteria.csv";
        StreamReader archivo = new(nombreArch);
        string? linea;
        List<Cadeteria> listaCadeterias = new();
        while ((linea = archivo.ReadLine()) != null)
        {
            string[] fila = linea.Split(",").ToArray();
            string nomb = fila[0];
            string tel = fila[1];
            Cadeteria cadeteria = new Cadeteria(nomb, tel);
            listaCadeterias.Add(cadeteria);
        }

        //muestro las cadeterias
        Console.WriteLine("-- Cadeterias --");
        int i = 0;
        foreach (Cadeteria cad in listaCadeterias)
        {
            Console.WriteLine(i + "- " + "Cadeteria: " + cad.nombre);
            i++;
        }
        Console.WriteLine("Seleccione una Cadeteria");
        int opcion;
        int.TryParse(Console.ReadLine(), out opcion);

        //Guardo la cedeteria seleccionada
        /*Cadeteria cadeteriaSelec = new Cadeteria();
        cadeteriaSelec = listaCadeterias[opcion];*/
        this.nombre = listaCadeterias[opcion].nombre;
        this.telefono = listaCadeterias[opcion].telefono;
        Console.WriteLine("Cadeteria seleccionada: " + opcion);
        string archCadetes = @"C:\tl2-tp1-2023-vaninaze\Cadetes.csv";
        StreamReader archivo2 = new(archCadetes);
        archivo2.ReadLine(); // Leo la primera línea y la descarto porque es el encabezado
        while ((linea = archivo2.ReadLine()) != null)
        {
            string[] fila = linea.Split(",").ToArray();
            int id = Convert.ToInt16(fila[0]);
            string nombre = fila[1];
            string dir = fila[2];
            string tel = fila[3];
            CrearCadete(id, nombre, dir, tel);
        }
    }

    public void InformeCad()
    {
        Informe informe = new();
        foreach (Cadete cad in ListaCadete)
        {
            float monto = cad.JornalACobrar();
            int envios = cad.CantEnvios();
            informe.CargarInforme(cad.Id, monto, envios);
        }
        informe.mostrarInforme();
    }
}