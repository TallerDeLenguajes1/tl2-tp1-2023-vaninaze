using EspacioPedido;
namespace EspacioInforme;
public class Informe{
    float montoCadete;
    int cantEnviosCadete;
    float montoTotalPedidos;
    int cantEnviosPromedio;
    List<Informe> listaInforme = new();
    public Informe(){
        montoTotalPedidos = 0;
        cantEnviosPromedio = 0;
    }
    public void CargarInforme(float monto, int envios){
        montoCadete = monto;
        cantEnviosCadete = envios;
        montoTotalPedidos = +monto;
        cantEnviosPromedio = +envios;
    
    }
    public void MostrarInforme(){

    }
}