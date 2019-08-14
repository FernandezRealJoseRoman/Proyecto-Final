/*
 Desarrollador: Fernandez Real Jose Roman
 Materia: Programacion orientada a objetos
 Grupo: DAA07A
 Profesor: Josue Israel Rivas Diaz
 Funcionamiento de codigo:
 Esta clase se encargara de asignar un comportamiento basico a las balas dentro del juego, este comportamiento sencillamente es
 moverse hacia el frente y ser destruidas en caso de salirse del area de juego.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //Variable tipo objeto de juego que guardara al prefab bala
    public GameObject bala;
    //Variable que guardara riggidbody del prefab
    public Rigidbody rb;
    /*Velocidad  a la que se movera la bala, de tipo publico para ser cambiado en caso de ser nesesario y ser mas facil crear objetos
    tipo bala que tengan diferentes velocidades.*/
    public float velocidadBala;

    //cuando se instancia el objeto
    private void Start()
    {
        //guarda la informacion de rigidgody dentro de la varialble llamada rb.
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Grega fuerza al riggidbody para moverse hacia el frente, esta fuerza la determina la variable velocidad, multiplicada por time para que sea constante no importa a cuantos cudadros corra el juego
        rb.AddForce(transform.forward * velocidadBala * Time.deltaTime);
        //Si la posicion del objeto bala, llegara a ser mayor a estos numeros, que actuaran como los limites
        if (bala.transform.position.z <=-20 || bala.transform.position.z >=20 || bala.transform.position.x <= -16 || bala.transform.position.x >= 16)
        {
            //destruye el objeto
            Destroy(gameObject);
        }
    }
}
