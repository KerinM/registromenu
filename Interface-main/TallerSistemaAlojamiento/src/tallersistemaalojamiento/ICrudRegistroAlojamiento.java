/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package tallersistemaalojamiento;

import java.util.ArrayList;

/**
 *
 * @author ESTUDIANTES
 */
public interface ICrudRegistroAlojamiento {
    
    boolean agregarAlojamiento(Alojamiento a);
     
    Alojamiento buscar(int codigo);
      
    boolean eliminar(Alojamiento a);
      
     ArrayList<Alojamiento> obtenerAlojamientos();  
}
