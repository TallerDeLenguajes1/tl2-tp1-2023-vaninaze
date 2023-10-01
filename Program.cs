using System.Diagnostics;
using EspacioPedido;
using EspacioDatos;
Console.WriteLine("SELECCIONE UN TIPO DE ACCESO A DATOS: ");
Console.WriteLine(" 1- CSV");
Console.WriteLine(" 2- JSON");
int opcion;
Cadeteria cadeteria = new Cadeteria();
if(int.TryParse(Console.ReadLine(), out opcion)){
    switch (opcion)
    {
        case 1:
            AccesoCSV csv = new();
            cadeteria = csv.cargarCadeteriaCSV();
            break;
        case 2:
            AccesoJSON json = new();
            cadeteria = json.cargarCadeteriaJSON();
            break;
    }
}
cadeteria.crearPedido(1, "sin cebolla", "Mar", "Junin 231", "32413", "porton verde");
cadeteria.crearPedido(2, "sin aji", "Luz", "Cordoba 829", "324849", "casa rosa");

cadeteria.crearPedido(3, "sin tomate", "Isa", "Cordoba 829", "324849", "casa roja");
cadeteria.crearPedido(4, "con mayonesa", "Lau", "Cordoba 829", "324849", "depto 3");

opcion = Menu();
switch (opcion)
{
    case 1:
        AsignarCadeteAPedido(cadeteria);
        break;
    case 2:
        ReasignarPedido(cadeteria);
        break;
    case 3:
        Console.WriteLine("-- CADETERIA: ");
        Console.WriteLine("Nombre: "+ cadeteria.getNombre());
        Console.WriteLine("Telefono: "+ cadeteria.getTelefono());
        Console.WriteLine("_______Seleccione un cadete: ");
        int idCad;
        if (int.TryParse(Console.ReadLine(), out idCad))
        {
            float monto = cadeteria.JornalACobrar(idCad);
            Console.WriteLine("ID Cadete: " + idCad);
            Console.WriteLine("Jornal a cobrar: " + monto);
        }
        break;
}



//FUNCIONES
static int Menu()
{
    Console.WriteLine("-- OPERACIONES: --");
    Console.WriteLine("1- Asignar Cadete a Pedido");
    Console.WriteLine("2- Reasignar Pedido");
    Console.WriteLine("3- Jornal a cobrar del cadete");
    Console.WriteLine("_____ Seleccione una: ");
    int opcion;
    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        return opcion;
    }
    else
    {
        Console.WriteLine("ERROR");
        return 0;
    }
}
void AsignarCadeteAPedido(Cadeteria cadeteria)
{
    int cantPed = cadeteria.getCantPedidos(); //mostrar pedidos
    for(int i=0; i < cantPed; i++){
        Pedido pedido = cadeteria.MostrarPedido(i);
        pedido.MostrarPedido();
    }
    Console.WriteLine("_______Seleccione un pedido para asignar a un cadete: ");
    int idPed;
    if (int.TryParse(Console.ReadLine(), out idPed))
    {
        int cantCad = cadeteria.getCantCadetes(); //mostrar cadetes
        for(int i=0; i < cantCad; i++ ){ 
            Cadete cadete = cadeteria.MostrarCadete(i);
            cadete.MostrarCadete();
        }
        Console.WriteLine("_______Seleccione un cadete: ");
        int idCad;
        if (int.TryParse(Console.ReadLine(), out idCad))
        {
            cadeteria.AsignarCadeteAPedido(idCad, idPed);
        }
    };
}
static void ReasignarPedido(Cadeteria cadeteria)
{
    int cantPed = cadeteria.getCantPedidos();
    for(int i=0; i < cantPed; i++){
        Pedido pedido = cadeteria.MostrarPedido(i);
        pedido.MostrarPedido();
    }
    Console.WriteLine("_______Seleccione un pedido para REasignar a un cadete: ");
    int idPed;
    if (int.TryParse(Console.ReadLine(), out idPed))
    {
        int cantCad = cadeteria.getCantCadetes(); //mostrar cadetes
        for(int i=0; i < cantCad; i++ ){ 
            Cadete cadete = cadeteria.MostrarCadete(i);
            cadete.MostrarCadete();
        }
        Console.WriteLine("_______Seleccione un cadete: ");
        int idCad;
        if (int.TryParse(Console.ReadLine(), out idCad))
        {
            cadeteria.AsignarCadeteAPedido(idCad, idPed);
        }
    };
}
