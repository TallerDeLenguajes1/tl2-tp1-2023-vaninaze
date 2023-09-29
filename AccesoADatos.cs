namespace EspacioDatos;
using EspacioPedido;
public abstract class AccesoADatos{
    public void mostrarCadeterias(List<Cadeteria> listaCad){
       //muestro las cadeterias
        Console.WriteLine("-- Cadeterias --");
        int i = 1;
        foreach (Cadeteria cad in listaCad)
        {
            Console.WriteLine("-- CADETERIA: "+ i);
            cad.MostrarCadeteria();
            i++;
        }
    }
    public Cadeteria elegirCadeteria(List<Cadeteria> listaCadeteria){
        Console.WriteLine("Seleccione una Cadeteria");
        int opcion;
        int.TryParse(Console.ReadLine(), out opcion);

        //Guardo la cedeteria seleccionada
        /*Cadeteria cadeteriaSelec = new Cadeteria();
        cadeteriaSelec = listaCadeterias[opcion];*/
        Cadeteria cadeteria = listaCadeteria[opcion];
        Console.WriteLine("Cadeteria seleccionada: " + opcion);
        cadeteria.MostrarCadeteria();
        return cadeteria;
    }
}