using UnityEngine;

public class MovimientoTorreta : MonoBehaviour 
{
    public Camera camara;

	void Update () 
	{
        Vector3 posicionMouse = Input.mousePosition;
        posicionMouse.z = 5.23f;

        Vector3 posicionObjeto = Camera.main.WorldToScreenPoint(transform.position);
        posicionMouse.x = posicionMouse.x - posicionObjeto.x;
        posicionMouse.y = posicionMouse.y - posicionObjeto.y;

        float angulo = Mathf.Atan2(posicionMouse.y, posicionMouse.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo));
    }
}
