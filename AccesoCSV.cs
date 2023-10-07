namespace EspacioDatos;
using EspacioPedido;
//Carga todas las cadeterias, selecciono una y cargo sus cadetes
//CADETERIA CSV
public class AccesoCSV: AccesoADatos{
    public override Cadeteria cargarCadeteria()
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
        mostrarCadeterias(listaCadeterias);
        Cadeteria cadeteria = elegirCadeteria(listaCadeterias);

        //cargo cadetes
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
        return cadeteria;
    }
}
