/*
 Desarrollador: Fernandez Real Jose Roman
 Materia: Programacion orientada a objetos
 Grupo: DAA07A
 Profesor: Josue Israel Rivas Diaz
 Funcionamiento de codigo:
 Esta clase se encargara de registrar la colision de los proyectiles con el enemigo, a lo que al pasar,
 se encargara de calcular la vida del enemigo despues del impacto. Y si es nesesario desplegarlo dentro del juego.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    //Salud inical servira para poder cambiar la cantidad de vida desde unity y se asegurara de establecer el valor inical de vida actual.
    public int saludIncial = 400;
    //Una variable publica para poder cambiar desde unity, se encarga de darle un valor al impacto de la bala.
    public int ataqueCantidad = 15;
    //esta es la variable que se encargara de llevar cuenta de la cantidad de vida de la instancia dentro del juego.
    public int saludActual;
    //Esta variable tipo slider lo usaremos para desplegar la vida del enemigo dentro del juego a manera de un slider en el UI.
    public Slider controlSalud;

    public ManejoEscena Eliminado;

    //empesaremos estableciendo la cantidad de HP actual como completa
    private void Start()
    {
        saludActual = saludIncial;
    }

    //esta comportamiento se encarga de reconocer cuando un trigger entre en contacto con el box colider del enemigo
    private void OnTriggerEnter(Collider other)
    {
        //si el objeto dentro del juego, que entra en contacto tiene el tag de "balas" 
        if (other.gameObject.tag.Equals("Balas"))
        {
            //Se calcula el comportamiento publico llamado recibir atque
            RecibirAtaque();
            //destruye al objeto del juego con el tag balas
            Destroy(other.gameObject);

        }
    }
    
    //calculara el ataque recibido
    public void RecibirAtaque()
    {
        //calculara que la salud actual ahora sea igual a saludactual menos la cantidad de ataque
        saludActual = saludActual - ataqueCantidad;
        //toma el valor de salud actual y se lo manda al slider para ser desplegado
        controlSalud.value = saludActual;
        //En caso de que la cantidad de salud actual sea menor o igual a 0
        if (saludActual <= 0)
        {
            FindObjectOfType<ManejoEscena>().EliminarEnemigo();
            //destruye el componente dentro del juego que tenga este script, destruye al enemigo
            Destroy(gameObject);
        }
    }
}
