/*
 Desarrollador: Fernandez Real Jose Roman
 Materia: Programacion orientada a objetos
 Grupo: DAA07A
 Profesor: Josue Israel Rivas Diaz
 Funcionamiento de codigo:
 Esta clase se encargara del control de movimiento sobre el jugador, ademas de esto se encargara del disparo.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlJugador : Movimiento
{
    //Variable tipo objeto del juego que guardara la informacion del jugador
    public GameObject Jugador;
    //Variable que guardara el prefab proyectil el cual sera disparado por el jugador.
    public GameObject proyectil;
    //Variable tipo transform que guardara la ubicacion del empty que funcionara como punto de instanciacion de las balas
    public Transform EngendrarBalas;
    //Velocidad que sera agregada a un contador, que servira para saber cuanto tiempo debe de pasar antes de ser dispara la siguiente bala
    public float VelocidadDisparo = 0.01f;
    //variable al cual servira par ahacer la comparacion del ritmo de disparo
    public float SiguienteDisparo = 0.0f;

    void Start()
    {
        //acceso a los componentes, este es un comportamiento de la clase de movimiento
        AccesoComponentes();
    }

    void FixedUpdate()
    {
        //ejecucion continua del comportamiento dentro de la clase movimiento que se encargara de calcular aceleracion y avienta un valor
        Aceleracion(velocidad);

        //si lelgara a presionar la tecla de espacio o el tiempo fuera mas grande que la varialble siguiente disparo se ejecutara
        if (Input.GetKey(KeyCode.Space) && Time.time > SiguienteDisparo)
        {
            //comportamiento llamado disparo
            Disparo();
        }
    }

    //aqui se instancia el disparo y se estable un tiempo antes del suguiente disparo
    void Disparo()
    {
        //Agrega tiempo antes del siguiente disparo
        SiguienteDisparo = Time.time + VelocidadDisparo;
        //Instancia un clone del prefab reconocido aqui con el nombre de proyectil, con la posicion y rotacion del punto llamado engendrar balas; esto lo hace como un objeto dentro del juego.
        GameObject clone = Instantiate(proyectil, EngendrarBalas.position, EngendrarBalas.rotation) as GameObject;
    }
}
