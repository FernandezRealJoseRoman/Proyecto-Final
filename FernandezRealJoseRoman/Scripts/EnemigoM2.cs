/*
 Desarrollador: Fernandez Real Jose Roman
 Materia: Programacion orientada a objetos
 Grupo: DAA07A
 Profesor: Josue Israel Rivas Diaz
 Funcionamiento de codigo:
 Esta clase se encargara de calcular el moviento del enemgio dentro de la escena, la manera de moverse sera atraves de un patrullaje,
 donde a base de un array seguira un grupo de puntos determinados para de esta manera crear un camino. Esta clase se asegura de seguir
 el array en orden y de manera repetitiva.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemigoM2 : MonoBehaviour
{
    //Un array publico de tipo transform que guardara la ubicacion de los puntos que usara como camino.
    public Transform[] puntoMovimiento;
    // Variable con la cual instanciare la velocidad con la que se mueve el enemigo
    public float velocidad;
    // Variable en la cual guardare el numero de punto dentro del array en el cual esta de manera actual el enemigo
    public int puntoActual;
    //Varible tipo bool de patrullage
    public bool patrullage = true;
    //Varibale donde guardare el punto al cual se esta moviendo el enemigo
    public Vector3 blanco;
    //Variable donde se estara moviendo de manera activa
    public Vector3 MoverDireccion;
    //variable para guardar rapidez o velocity
    public Vector3 rapidez;

    //Dentro del sistema de actualizacion.
    void Update()
    {
        // el punto actual tiene un valor menor al numero de datos guardado dentro del array
        if (puntoActual < puntoMovimiento.Length)
        {
            //blanco guarda el valor de posicion del array punto de movimiento numero punto actual, el cual sera 0
            blanco = puntoMovimiento[puntoActual].position;
            //mover direccion ahora sera igual a blanco menos la posicion del transform
            MoverDireccion = blanco - transform.position;
            // rapidez guarda la rapidez del riggidbody que tenga este script
            rapidez = GetComponent<Rigidbody>().velocity;
            //Si la magnitud de mover direccion es menor a 1
            if (MoverDireccion.magnitude < 1)
            {
                //se aumentara en 1 valor de punto actual
                puntoActual++;
            }
            else
            {
                //de otra manera rapidez sera igual a mover direccion por la velocidad
                rapidez = MoverDireccion.normalized * velocidad;
            }
        }
        else
        {
            //si patrullage es igual a true
            if (patrullage)
            {
                //el punto actual sera igual a cero
                puntoActual = 0;
            }
            else
            {
                //rapidez sera igual a zero, tipo vector 3
                rapidez = Vector3.zero;
            }
        }
        //Se instancia dentro del script el componente de rigidbody, toma la rapidez y se guarda en la variable del mismo nombre.
        GetComponent<Rigidbody>().velocity = rapidez;
    }
}
