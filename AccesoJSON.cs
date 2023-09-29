namespace EspacioDatos;
using EspacioPedido;
using System.Text.Json;
using System.Text.Json.Serialization;
public class AccesoJSON: AccesoADatos{
    public Cadeteria cargarCadeteriaJSON(){
        string archivo = @"C:\tl2-tp2-2023-vaninaze\Cadeteria.json";
        string jsonString = File.ReadAllText(archivo);
        List<Cadeteria>? listaCadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(jsonString);

        mostrarCadeterias(listaCadeterias);
        Cadeteria cadeteria = elegirCadeteria(listaCadeterias);
        
        string archivoCad = @"C:\tl2-tp2-2023-vaninaze\Cadetes.json";
        jsonString = File.ReadAllText(archivoCad);
        List<Cadete>? listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);

        int i=0, j= listaCadetes.Count();
        while(i < j){
            cadeteria.agregarCadete(listaCadetes[i]);
            i++;
        }
        return cadeteria;
    }
}