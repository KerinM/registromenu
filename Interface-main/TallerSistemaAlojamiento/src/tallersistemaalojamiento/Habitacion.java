/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package tallersistemaalojamiento;


/**
 *
 * @author Jairo F
 */
public class Habitacion extends Alojamiento {
    private static final double PRECIO_POR_PERSONA = 25000;
    private static final double DESCUENTO_POR_PERSONA=0.05;
    private static final double DESCUENTO_POR_DIAS=0.03;
    private static final double LIMITE_DIAS_DESCUENTO=3;
    
    private int noMaxPersona;

    public Habitacion() {
    }

    public Habitacion(int noMaxPersona, int codigo, String direccion, String ciudad, String pais) {
        super(codigo, direccion, ciudad, pais);
        this.noMaxPersona = noMaxPersona;
    }
    
    public int getNoMaxPersona() {
        return noMaxPersona;
    }

    public void setNoMaxPersona(int noMaxPersona) {
        this.noMaxPersona = noMaxPersona;
    }
    
    @Override
    public double calcularPrecioDia() {
        double valor = this.noMaxPersona * Habitacion.PRECIO_POR_PERSONA;
        return valor;
        
    }
    
    @Override
    public double calcularDescuento(int noDias){
        double pDescuento = (this.noMaxPersona-1) * Habitacion.DESCUENTO_POR_PERSONA;
        if(noDias>Habitacion.LIMITE_DIAS_DESCUENTO)
            pDescuento+=Habitacion.DESCUENTO_POR_DIAS;
        return pDescuento;
    }

    @Override
    public String toString() {
        return "Habitacion{" + super.toString()+ ", noMaxPersona=" + noMaxPersona + '}';
    }

    
}
