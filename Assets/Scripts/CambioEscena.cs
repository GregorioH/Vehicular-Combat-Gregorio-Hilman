using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public static float puntos;

    void Start()
    {
        puntos = 0;
    }
    public void Reintentar()
    {
        SceneManager.LoadScene("Juego");
    }

    void Update()
    {
        if (puntos == 5)
        {
            SceneManager.LoadScene("Victoria");
        }
    }      
}
