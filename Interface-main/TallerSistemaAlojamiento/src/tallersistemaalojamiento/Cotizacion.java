/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package tallersistemaalojamiento;

import java.time.LocalDate;
import java.time.Period;

/**
 *
 * @author Jairo F
 */
public class Cotizacion {
    private LocalDate fechaI;
    private LocalDate fechaF;
    private Alojamiento alojamiento;
    private int noDias;
    private double tarifaPlenaPorDia;
    private double subtotal;
    private double descuento;
    private double total;

    public Cotizacion() {
    }

    public Cotizacion(LocalDate fechaI, LocalDate fechaF, Alojamiento alojamiento) {
        this.fechaI = fechaI;
        this.fechaF = fechaF;
        this.alojamiento = alojamiento;
        this.noDias = this.calcularNoDias(fechaI, fechaF);
        this.tarifaPlenaPorDia = this.alojamiento.calcularPrecioDia();
        this.subtotal = this.tarifaPlenaPorDia * this.noDias;
        this.descuento = this.subtotal*this.alojamiento.calcularDescuento(this.noDias);
        this.total = this.subtotal - descuento;
    }

    public LocalDate getFechaI() {
        return fechaI;
    }

    public void setFechaI(LocalDate fechaI) {
        this.fechaI = fechaI;
    }

    public LocalDate getFechaF() {
        return fechaF;
    }

    public void setFechaF(LocalDate fechaF) {
        this.fechaF = fechaF;
    }

    public Alojamiento getAlojamiento() {
        return alojamiento;
    }

    public void setAlojamiento(Alojamiento alojamiento) {
        this.alojamiento = alojamiento;
    }

    public int getNoDias() {
        return noDias;
    }

    public void setNoDias(int noDias) {
        this.noDias = noDias;
    }

    public double getTarifaPlenaPorDia() {
        return tarifaPlenaPorDia;
    }

    public void setTarifaPlenaPorDia(double tarifaPlenaPorDia) {
        this.tarifaPlenaPorDia = tarifaPlenaPorDia;
    }

    public double getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(double subtotal) {
        this.subtotal = subtotal;
    }

    public double getDescuento() {
        return descuento;
    }

    public void setDescuento(double descuento) {
        this.descuento = descuento;
    }

    public double getTotal() {
        return total;
    }

    public void setTotal(double total) {
        this.total = total;
    }
    
    public int calcularNoDias(LocalDate fechaInicio, LocalDate FechaFin){
        Period duracion = Period.between(fechaInicio, FechaFin);
        return duracion.getDays();
    }

    @Override
    public String toString() {
        return "Cotizacion{" +"\n"+"\n"+   
                    "\tfechaI=" + fechaI +"\n"+ 
                    "\tfechaF=" + fechaF +"\n"+  
                    "\talojamiento=" + alojamiento +"\n"+  
                    "\tnoDias=" + noDias +"\n"+  
                    "\ttarifaPlenaPorDia=" + tarifaPlenaPorDia +"\n"+  
                    "\tsubtotal=" + subtotal +"\n"+  
                    "\tdescuento=" + descuento +"\n"+  
                    "\ttotal=" + total +"\n"+ 
                '}';
    }
    
    
    
}
