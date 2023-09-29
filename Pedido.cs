namespace EspacioPedido;
using EspacioPedido;
public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;
    private int estado;

    private int idCad;
    Cadete cadete;
    public int IDcad { get => idCad; }
    public int Estado { get => estado; }
    public int Numero { get => numero; }

    public void MostrarPedido()
    {
        Console.WriteLine(" Pedido numero: "+Numero);
        Console.WriteLine(" Observacion: "+observacion);
        Console.WriteLine(" Estado: "+estado);
        Console.WriteLine(" ID Cadete: "+idCad);
        Console.WriteLine(" ---------- ");
    }
    public Pedido(int num, string obs, string nomb, string dir, string telef, string datos)
    {
        cliente = new Cliente(nomb, dir, telef, datos);
        numero = num;
        observacion = obs;
        estado = 0; //Pendiente
        idCad = 0;
    }
    public void GuardarCadete(Cadete cad){
        cadete = cad;
        Console.WriteLine("Pedido ID: "+Numero);
        Console.WriteLine("Nuevo Cadete: "+cad.Id);
    }
    public void CambiarEstado()
    {
        if (estado == 0)
        {
            estado = 1; //aceptado
        }
        else
        {
            estado = 2; //entregado
        }
    }
    public void verDireccionCliente()
    {
        Console.WriteLine(cliente.Direccion);
    }
    public void verDatosCliente()
    {
        Console.WriteLine(cliente.Nombre);
        Console.WriteLine(cliente.Direccion);
        Console.WriteLine(cliente.Telefono);
        Console.WriteLine(cliente.DatosReferencia);
    }
}