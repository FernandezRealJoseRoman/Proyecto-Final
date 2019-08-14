/*
 Desarrollador: Fernandez Real Jose Roman
 Materia: Programacion orientada a objetos
 Grupo: DAA07A
 Profesor: Josue Israel Rivas Diaz
 Funcionamiento de codigo:
 Esta el la clase de movimieto se encarga de guarda informacion del posicionamientod de un objeto. Ademas aqui se establecen los limites del juego
 evitando que el jugador se salga de la pantalla
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Una clase que se encarga de guardar los datos que cuales con los x y z minima y maxima.
[System.Serializable]
public class Limites
{
    public float xMin, xMax, zMin, zMax;
}

public class Movimiento : MonoBehaviour
{
    //Variable donde se guarda la informaciond de tipo riggidbody del jugador
    public Rigidbody rbJugador;
    //Un float para guardar informacion del eje x
    protected float hor;
    //Un floar para guarda informacion del eje z
    protected float vert;
    //tipo float que ayudara a poder cambiar la velocidad con la que se mueve el jugador
    public float velocidad;
    // Variable que pedira la imformacion de la clase de limites
    public Limites limite;

    
    protected void AccesoComponentes()
    {
        //relaciona el riggidbody con rb jugador
        rbJugador = GetComponent<Rigidbody>();
    }

    //Es de tipo sobre cargada, constantemente abienta una informacione en espefico en este caso v.
    protected void Aceleracion(float v)
    {
        //guarda la informacion de la ubicacion del objeto dentro de hor
        hor = Input.GetAxis("Horizontal") * v * Time.deltaTime;
        //guarda la informacion de la ubicacion del objeto dentro de hor
        vert = Input.GetAxis("Vertical") * v * Time.deltaTime;
        //Establece que la velocidad del riggidbody sera igual a un vecto 3 con la informacion de hor y vert
        rbJugador.velocity = new Vector3(hor, rbJugador.velocity.y, vert);

        //Limita la posicion de rbjugador atraves de la comparacion de x y z min y max
        rbJugador.position = new Vector3(
            Mathf.Clamp(rbJugador.position.x, limite.xMin, limite.xMax),
            0.0f,
            Mathf.Clamp(rbJugador.position.z, limite.zMin, limite.zMax)
            );
    }
}
