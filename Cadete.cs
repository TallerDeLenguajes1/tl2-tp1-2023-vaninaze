namespace EspacioPedido;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    public int Id { get => id; }
    public Cadete(int id, string nom, string dir, string telef)
    {
        this.id = id;
        nombre = nom;
        direccion = dir;
        telefono = telef;
    } 
    public void MostrarCadete()
    {
        Console.WriteLine("Cadete: "+id);
        Console.WriteLine("  Nombre: "+nombre);
        Console.WriteLine("  Direccion: "+direccion);
        Console.WriteLine("  Telefono: "+telefono);
    }
}