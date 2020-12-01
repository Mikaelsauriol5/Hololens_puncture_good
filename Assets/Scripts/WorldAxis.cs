using UnityEngine;
using System.Collections;

public class WorldAxis : MonoBehaviour
{
    public GameObject axis;
    public float size = 0.2f;

    void OnDrawGizmos()
    {
        Vector3 initialPosition = axis.transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(initialPosition, initialPosition + axis.transform.right * -1.0f * size * axis.transform.localScale.x);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(initialPosition, initialPosition + axis.transform.up * -1.0f * size * axis.transform.localScale.x);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(initialPosition, initialPosition + axis.transform.forward * -1.0f * size * axis.transform.localScale.x);
        Gizmos.color = Color.white;
    }
}
