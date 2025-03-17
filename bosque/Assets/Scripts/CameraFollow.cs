using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Asignaremos al protagonista en la caja de Component
    public Vector3 offset = new Vector3(0, 3, -5);
    public float smoothSpeed = 5f;
    void LateUpdate()
    {
        if (target == null) return; // Si no hay target, no hacer nada

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}