using UnityEngine;

public class Disparar : MonoBehaviour {

    public GameObject PrefabBala;
    public Transform SpawnBala;
    private float siguienteDisparo;
    public float tasaDisparo;

    public float velocidadBala = 20f;

	void Update ()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > siguienteDisparo)
        {
            siguienteDisparo = Time.time + tasaDisparo;
            Dispararo();
        }
	}

    void Dispararo()
    {
        GameObject bala = Instantiate(PrefabBala, SpawnBala.position, SpawnBala.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(SpawnBala.up * velocidadBala, ForceMode2D.Impulse);
    }
}
