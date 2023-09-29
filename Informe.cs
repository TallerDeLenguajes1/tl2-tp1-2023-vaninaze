using EspacioPedido;
namespace EspacioInforme;
public class Informe
{
    float montoTotalPedidos;
    int cantEnviosPromedio;
    public Informe()
    {
        this.montoTotalPedidos = 0;
        this.cantEnviosPromedio = 0;
    }
    public void CargarInforme(int idCad, float jornalACobrar, int envios)
    {

        montoTotalPedidos = +jornalACobrar;
        cantEnviosPromedio = +envios;
        Console.Write("ID Cadete: " + idCad);
        Console.WriteLine("Monto a cobrar: " + jornalACobrar);
        Console.WriteLine("Cant de envios: " + envios);

    }
    public void mostrarInforme()
    {
        Console.WriteLine("Monto total de los pedidos: " + montoTotalPedidos);
        Console.WriteLine("Cantidad promedio de envios por cadete: " + cantEnviosPromedio);
    }
}