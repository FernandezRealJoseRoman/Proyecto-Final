/*
 Desarrollador: Fernandez Real Jose Roman
 Materia: Programacion orientada a objetos
 Grupo: DAA07A
 Profesor: Josue Israel Rivas Diaz
 Funcionamiento de codigo:
 Esta clase se encargara de calcular el moviento del enemgio dentro de la escena, la manera de moverse sera atraves de un patrullaje,
 donde a base de un array seguira un grupo de puntos determinados para de esta manera crear un ciclo de camino. Esta clase se asegurara que
 tome un puto al azar para moverse, haciendo asi que su movimiento se erradico, pero dentro de unas posibilidades deseadas.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemigoM1 : MonoBehaviour
{
    //Variable que uso para establecer la velocidad con la cual se movera en su patrullage
    public float velocidad;
    //tiempo que debera pasar en cada punto antes de moverse hacia el siguiente
    private float tiempoEspera;
    //tiempo de espera inical
    public float tiempoEsperaInical;
    //Array en el cual guardaremos los valores tipo transfrom de los puntos que debera seguir
    public Transform[] puntoMovimiento;
    //el punto al que se movera ahora escojido al azar
    private int puntoAlAzar;
    

    void Start()
    {
        //primero se establece que el tiempo de espera es igual el tiempo de espera inicial
        tiempoEspera = tiempoEsperaInical;
        //se calcula el primer punto al azar, que se logra con un random cuyo alcanze sera el largo del array
        puntoAlAzar = Random.Range(0, puntoMovimiento.Length);
    }

    void Update()
    {
        //Se movera el enemigo hacia la posicion del punto al azar con un velocidad que nosotros establecimos.
        transform.position = Vector3.MoveTowards(transform.position, puntoMovimiento[puntoAlAzar].position, velocidad * Time.deltaTime);
        //Si la distancia de vector 3 es menor a 0.2 entonces
        if (Vector3.Distance(transform.position, puntoMovimiento[puntoAlAzar].position) < 0.2f)
        {
            //si tiempo espera es menor o igual a cero entonces
            if (tiempoEspera <= 0)
            {
                //punto al azar sera igual a un nuevo punto al azar del array
                puntoAlAzar = Random.Range(0, puntoMovimiento.Length);
                //se resetea tiempo de espera
                tiempoEspera = tiempoEsperaInical;
            }
            else
            {
                //se reduce el tiempo de espera
                tiempoEspera -= Time.deltaTime;
            }

        }
    }
}

