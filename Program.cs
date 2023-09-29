using System.Diagnostics;
using EspacioPedido;

Console.WriteLine("SELECCIONE UN TIPO DE ACCESO A DATOS: ");
Console.WriteLine(" 1- CSV");
Console.WriteLine(" 2- JSON");
int opcion;
Cadeteria cadeteria = new Cadeteria();
if(int.TryParse(Console.ReadLine(), out opcion)){
    switch (opcion)
    {
        case 1:
            CargarCSV csv = new();
            csv.cargarCadeteriaCSV();
            break;
       /* case 2:
            cadeteria.cargarCadeteriaJSON();
            break;*/
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
        cadeteria.MostrarCadetes();
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
    cadeteria.MostrarPedidos();
    Console.WriteLine("_______Seleccione un pedido para asignar a un cadete: ");
    int idPed;
    if (int.TryParse(Console.ReadLine(), out idPed))
    {
        cadeteria.MostrarCadetes();
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
    cadeteria.MostrarPedidos();
    Console.WriteLine("_______Seleccione un pedido para REasignar a un cadete: ");
    int idPed;
    if (int.TryParse(Console.ReadLine(), out idPed))
    {
        cadeteria.MostrarCadetes();
        Console.WriteLine("_______Seleccione un cadete: ");
        int idCad;
        if (int.TryParse(Console.ReadLine(), out idCad))
        {
            cadeteria.AsignarCadeteAPedido(idCad, idPed);
        }
    };
}
