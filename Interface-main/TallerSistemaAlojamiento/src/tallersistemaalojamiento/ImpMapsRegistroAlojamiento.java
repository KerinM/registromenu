/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package tallersistemaalojamiento;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author ESTUDIANTES
 */
public class ImpMapsRegistroAlojamiento implements ICrudRegistroAlojamiento{
    
    private Map<Integer, Alojamiento> mapsAlojamiento;

    public ImpMapsRegistroAlojamiento() {
        this.mapsAlojamiento = new HashMap();
    }
    
    public Map<Integer, Alojamiento> getMapsAlojamiento() {
        return mapsAlojamiento;
    }

    public void setMapsAlojamiento(Map<Integer, Alojamiento> mapsAlojamiento) {
        this.mapsAlojamiento = mapsAlojamiento;
    }

    @Override
    public boolean agregarAlojamiento(Alojamiento a) {
       this.mapsAlojamiento.put(a.getCodigo(), a);
       return true;
    }

    @Override
    public Alojamiento buscar(int codigo) {
        return this.mapsAlojamiento.get(codigo);
    }

    @Override
    public boolean eliminar(Alojamiento a) {
        return false;
    }

    @Override
    public ArrayList<Alojamiento> obtenerAlojamientos() {
        return new ArrayList<Alojamiento>();
    }
    
}
