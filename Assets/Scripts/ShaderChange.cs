using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderChange : MonoBehaviour
{
    public GameObject heart;
    public GameObject needleExtremity;

    private Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        renderer = heart.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = needleExtremity.transform.position;
        renderer.material.SetVector("_Position", position);
    }
}
