using EspacioPedido;
//Carga todas las cadeterias, selecciono una y cargo sus cadetes
//CADETERIA CSV
public class CargarCSV{
    public void cargarCadeteriaCSV()
    {
        string nombreArch = @"C:\tl2-tp2-2023-vaninaze\Cadeteria.csv";
        StreamReader archivo = new(nombreArch);
        string? linea;
        List<Cadeteria> listaCadeterias = new();
        while ((linea = archivo.ReadLine()) != null)
        {
            string[] fila = linea.Split(",").ToArray();
            string nomb = fila[0];
            string tel = fila[1];
            Cadeteria cad = new Cadeteria(nomb, tel);
            listaCadeterias.Add(cad);
        }

        //muestro las cadeterias
        Console.WriteLine("-- Cadeterias --");
        int i = 1;
        foreach (Cadeteria cad in listaCadeterias)
        {
            Console.WriteLine("-- CADETERIA: "+ i);
            cad.MostrarCadeteria();
            i++;
        }
        Console.WriteLine("Seleccione una Cadeteria");
        int opcion;
        int.TryParse(Console.ReadLine(), out opcion);

        //Guardo la cedeteria seleccionada
        /*Cadeteria cadeteriaSelec = new Cadeteria();
        cadeteriaSelec = listaCadeterias[opcion];*/
        Cadeteria cadeteria = listaCadeterias[opcion];
        Console.WriteLine("Cadeteria seleccionada: " + opcion);
        cadeteria.MostrarCadeteria();
        string archCadetes = @"C:\tl2-tp2-2023-vaninaze\Cadetes.csv";
        StreamReader archivo2 = new(archCadetes);
        archivo2.ReadLine(); // Leo la primera línea y la descarto porque es el encabezado
        while ((linea = archivo2.ReadLine()) != null)
        {
            string[] fila = linea.Split(",").ToArray();
            int id = Convert.ToInt16(fila[0]);
            string nombre = fila[1];
            string dir = fila[2];
            string tel = fila[3];
            cadeteria.crearCadete(id, nombre, dir, tel);
        }
    }
}
