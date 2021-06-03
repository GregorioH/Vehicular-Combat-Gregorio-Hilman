using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
        }
    }
}
