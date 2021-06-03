using UnityEngine;

public class InputAuto : MonoBehaviour
{
    MovimientoAuto movimientoAuto;

    void Awake()
    {
        movimientoAuto = GetComponent<MovimientoAuto>();
    }

    // Update is called once per frame 
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        movimientoAuto.SetInputVector(inputVector);
    }
}
