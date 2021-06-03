using UnityEngine.SceneManagement;
using UnityEngine;

public class ColisionEnemigos : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Derrota");
        }

        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(gameObject);
            CambioEscena.puntos += 1;
        }

    }
}
