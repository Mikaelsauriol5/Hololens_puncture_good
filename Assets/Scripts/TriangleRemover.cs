using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleRemover : MonoBehaviour
{
    public GameObject currentObjectSelected;
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;

    void deleteTriangle(int index)
    {
        if (!currentObjectSelected)
            return;

        Destroy(currentObjectSelected.GetComponent<MeshCollider>());
        Mesh mesh = currentObjectSelected.transform.GetComponent<MeshFilter>().mesh;
        int[] oldTriangles = mesh.triangles;
        int[] newTriangles = new int[mesh.triangles.Length - 3];

        int i = 0;
        int j = 0;

        while(j < mesh.triangles.Length)
        {
            if(j != index * 3)
            {
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
            }
            else
            {
                j += 3;
            }
        }
        currentObjectSelected.transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
        currentObjectSelected.AddComponent<MeshCollider>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        float distance = currentObjectSelected ? currentHitDistance : maxDistance;
        Gizmos.DrawWireSphere(origin + direction * distance, sphereRadius);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;

        if(Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentObjectSelected = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            deleteTriangle(hit.triangleIndex);
        }
        else
        {
            currentObjectSelected = null;
            currentHitDistance = 0;
        }   
    }
}
