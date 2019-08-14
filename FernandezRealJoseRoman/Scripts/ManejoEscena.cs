using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoEscena : MonoBehaviour
{
    private int NumeroEnemigo = 2;
    private bool juegoTerminado = false;
    public float reinicioDelay = 1f;

    public void FinDelJuego()
    {
        if (juegoTerminado == false)
        {
            juegoTerminado = true;
            Debug.Log("Fin del juego");
            Invoke("Reiniciar", reinicioDelay);
        }
    }

    void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EliminarEnemigo()
    {
        NumeroEnemigo--;
        if (NumeroEnemigo <=0)
        {
            FinDelJuego();
        }
    }
}
