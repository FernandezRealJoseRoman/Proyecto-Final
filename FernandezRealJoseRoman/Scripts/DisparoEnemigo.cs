/*
 Desarrollador: Fernandez Real Jose Roman
 Materia: Programacion orientada a objetos
 Grupo: DAA07A
 Profesor: Josue Israel Rivas Diaz
 Funcionamiento de codigo:
 Esta clase se encargara de detereminar el ritmo de disparo del enemigo
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    //variable de tipo publica que guardara el prefab del proyectil enemigo
    public GameObject proyectil;
    //variable donde guardaremos la ubicacion en un transform de un empty que es parte del enemigo, este sera el lugar en especifico en donde engendrara las balas.
    public Transform EngendrarBalas;
    //Ritmo con el cual sera instanciado el proyectil
    public float VelocidadDisparo = 0.01f;
    // contador de tiempo que se ocupara para comporar en contra de la velocidad de disparo.
    public float SiguienteDisparo = 0.0f;

    void FixedUpdate()
    {
        //cada vez que el tiempo dentro de la consola sea mas grande que siguiente disparo 
        if (Time.time > SiguienteDisparo)
        {
            //ejecuta el comportamieto llamado disparo
            Disparo();
        }
    }

    //Comportamiento de disparo
    void Disparo()
    {
        //el valor llamado siguiente disparo sera igual a time mas la velocidad haciendo asi que la cantidad que ponga dentro de velocidad sea en intervalo en que tardara time en alcanzar la cantidad
        SiguienteDisparo = Time.time + VelocidadDisparo;
        //Instancia una copia de proyectir, con la posicion del empty llamado engendrar balas, y tambien la rotacion del mismo, como un objeto dentro del juego.
        GameObject clone = Instantiate(proyectil, EngendrarBalas.position, EngendrarBalas.rotation) as GameObject;
    }
}
