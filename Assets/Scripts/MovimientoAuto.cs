using UnityEngine;
using UnityEngine.SceneManagement;
public class MovimientoAuto : MonoBehaviour
{
    [Header("Configuracion Auto")]
    public float derrapeAuto = 0.95f;
    public float aceleracionAuto = 5;
    public float rotacionAuto = 3.5f;
    public float velocidadMaxima = 3;

    float inputAceleracion = 0;
    float inputDireccion = 0;

    float anguloRotacion = 0;

    float velocidadVsArriba = 0;

    Rigidbody2D rbAuto;
    void Awake()
    {
        rbAuto = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        if (inputAceleracion == 0)
            rbAuto.drag = Mathf.Lerp(rbAuto.drag, 3.0f, Time.fixedDeltaTime * 3);
        else rbAuto.drag = 0;

        velocidadVsArriba = Vector2.Dot(transform.up, rbAuto.velocity);

        if (velocidadVsArriba > velocidadMaxima && inputAceleracion > 0)
            return;

        if (velocidadVsArriba < -velocidadMaxima * 0.5f && inputAceleracion < 0)
            return;

        if (rbAuto.velocity.sqrMagnitude > velocidadMaxima * velocidadMaxima && inputAceleracion > 0)
            return;

        Vector2 fuerzaVector = transform.up * inputAceleracion * aceleracionAuto;

        rbAuto.AddForce(fuerzaVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float velocidadMinimaAntesDeRotar = (rbAuto.velocity.magnitude / 2);
        velocidadMinimaAntesDeRotar = Mathf.Clamp01(velocidadMinimaAntesDeRotar);

        anguloRotacion -= inputDireccion * rotacionAuto * velocidadMinimaAntesDeRotar;

        rbAuto.MoveRotation(anguloRotacion);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 velocidadAdelante = transform.up * Vector2.Dot(rbAuto.velocity, transform.up);
        Vector2 velocidadDerecha = transform.right * Vector2.Dot(rbAuto.velocity, transform.right);

        rbAuto.velocity = velocidadAdelante + velocidadDerecha * derrapeAuto;
    }

    float GetLateralVelocity()
    {
        return Vector2.Dot(transform.right, rbAuto.velocity);
    }

    public bool IsTireScreeching(out float velocidadLateral, out bool estaFrenado)
    {
        velocidadLateral = GetLateralVelocity();
        estaFrenado = false;

        if (inputAceleracion < 0 && velocidadVsArriba > 0)
        {
            estaFrenado = true;
            return true;
        }

        if (Mathf.Abs(GetLateralVelocity()) > 4.0f)
            return true;

        return false;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        inputDireccion = inputVector.x;
        inputAceleracion = inputVector.y;
    }

    public float GetVelocityMagnitude()
    {
        return rbAuto.velocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            SceneManager.LoadScene("Derrota");
        }
    }
}