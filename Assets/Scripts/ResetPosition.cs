using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetPosition : MonoBehaviour
{
    public GameObject heart;
    public Vector3 initPosition;
    public Quaternion initRotation;

    public bool isTrigger;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = heart.transform.position;
        initRotation = heart.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            ResetPositionHeart();
            isTrigger = false;
        }
    }

    public void ResetPositionHeart()
    {
        heart.transform.position = initPosition;
        heart.transform.rotation = initRotation;
    }
}
