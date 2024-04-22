/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package tallersistemaalojamiento;

import java.time.LocalDate;
import java.time.Month;
import java.util.Scanner;

/**
 *
 * @author Jairo F
 */
public class Ppal {
static Scanner scanner=new Scanner(System.in);

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ICrudRegistroAlojamiento registro = new ImpArrayListRegistroAlojamiento();
        // TODO code application logic here
//        Alojamiento hab = new Habitacion(2, 0, "Hotel sicarare", "Vpar", "Colombia");
//        Alojamiento cab = new Cabaña(4, 1, "Casa e campo", "Vpar", "Colombia");
//
//        System.out.println("\nEjemplo de registro de alojamiento");
//        ICrudRegistroAlojamiento registro = new ImpArrayListRegistroAlojamiento();
//        registro.agregarAlojamiento(hab);
//        System.out.println(hab + " registrado");
//        registro.agregarAlojamiento(cab);
//        System.out.println(cab + " registrado");
//
//        System.out.println("\nEjemplo de busqueda y cotizacion de alojamiento");
//        Alojamiento buscado = registro.buscar(0);
//        if (buscado != null) {
//            Cotizacion cothab = new Cotizacion(LocalDate.now(), LocalDate.of(2024, Month.APRIL, 20), buscado);
//            System.out.println(cothab);
//        } else {
//            System.out.println("El alojamiento no esta registrado");
//        }
//
//        System.out.println("\nEjemplo de eliminacion y cotizacion de alojamiento");
//        Alojamiento eliminar = registro.buscar(1);
//        registro.eliminar(eliminar);
//        buscado = registro.buscar(1);
//        if (buscado != null) {
//            Cotizacion cothab = new Cotizacion(LocalDate.now(), LocalDate.of(2024, Month.APRIL, 20), buscado);
//            System.out.println(cothab);
//        } else {
//            System.out.println("El alojamiento no esta registrado");
//        }
//
//        System.out.println("\nCotizacion de todos los alojamientos");
//        for (Alojamiento a : registro.obtenerAlojamientos()) {
//            Cotizacion cotizacion = new Cotizacion(LocalDate.now(), LocalDate.of(2024, Month.APRIL, 22), a);
//            System.out.println(cotizacion);
//        }
    int op=0;
    do{
    
        System.out.println("1- Agregar habitacion");
        System.out.println("2- Agregar cabaña");
        System.out.println("3- Cotizar alojamiento");
        System.out.println("4- Eliminar alojamiento");
        System.out.println("5- Listar");
        System.out.println("6- Salir");
        System.out.println("Escoja una opcion");
        op =scanner.nextInt();
        switch(op){
            case 1 : 
                System.out.println("ingrese el codigo de la habitacion");
                int cod=scanner.nextInt();
                scanner.nextLine();
                System.out.println("ingrese la direccion");
                String dire=scanner.nextLine();
                System.out.println("ingrese la ciudad");
                String ciu=scanner.nextLine();
                System.out.println("ingrese el pais");
                String pais=scanner.nextLine();
                System.out.println("ingrese el numero de personas");
                int person=scanner.nextInt();
                Alojamiento hab= new Habitacion(person, cod, dire, ciu, pais);                
                registro.agregarAlojamiento(hab);
                System.out.println(hab + " registrado");
                break;
            case 2 :
                System.out.println("ingrese el codigo de la habitacion");
                cod=scanner.nextInt();
                scanner.nextLine();
                System.out.println("ingrese la direccion");
                dire=scanner.nextLine();
                System.out.println("ingrese la ciudad");
                ciu=scanner.nextLine();
                System.out.println("ingrese el pais");
                pais=scanner.nextLine();
                System.out.println("ingrese el numero de cuartos");
                int cuartos=scanner.nextInt();
                Alojamiento cab= new Cabaña(cuartos, cod, dire, ciu, pais);
                registro.agregarAlojamiento(cab);
                System.out.println(cab + " registrado");
                break;
            case 3 :
                System.out.println("ingrese el codigo que desea buscar");
                int codi=scanner.nextInt();
                Alojamiento buscado = registro.buscar(codi);
                 if (buscado != null) {
                    Cotizacion cothab = new Cotizacion(LocalDate.now(), LocalDate.of(2024, Month.APRIL, 22), buscado);
                    System.out.println(cothab);
                } else {
                System.out.println("El alojamiento no esta registrado");
                }
                break;
            case 4 :
                System.out.println("ingrese el codigo a buscar");
                int co=scanner.nextInt();
                Alojamiento eliminado = registro.buscar(co);
                if (eliminado != null) {
                    registro.eliminar(eliminado);
                    System.out.println("eliminado");
                } else {
                System.out.println("El alojamiento no esta registrado");
                }
                break;
            case 5 :                
                for (Alojamiento a : registro.obtenerAlojamientos()) {
                    Cotizacion cotizacion = new Cotizacion(LocalDate.now(), LocalDate.of(2024, Month.APRIL, 22), a);
                    System.out.println(cotizacion);
                }
                break;
            case 6 :
                
                break;
        }
    }while(op!=6);
    }

}
