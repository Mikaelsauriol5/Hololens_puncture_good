using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinHeart : MonoBehaviour
{
    public Transform sceneContent;
    public Transform parentTransform;
    public Vector3 leftHeartPosition;
    public float separationDistance;

    GameObject rightHeart;
    bool isJoined;

    private void OnTriggerEnter(Collider other)
    {
        if (!isJoined && other.gameObject.tag == "Heart")
        {
            parentTransform.GetComponentInChildren<MeshRenderer>().enabled = true;
            GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<MeshRenderer>().enabled = false;

            parentTransform.position = other.gameObject.transform.position;
            other.gameObject.transform.parent = parentTransform;
            transform.parent = parentTransform;
            transform.localPosition = leftHeartPosition;

            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<SphereCollider>().enabled = false;
            other.GetComponent<ObjectManipulator>().ForceEndManipulation();
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<ObjectManipulator>().ForceEndManipulation();
            parentTransform.GetComponent<SphereCollider>().enabled = true;

            rightHeart = other.gameObject;
            isJoined = true;
        }
    }

    public void SeparateHeart()
    {
        if (isJoined)
        {
            transform.parent = sceneContent;
            rightHeart.transform.parent = sceneContent;

            parentTransform.GetComponentInChildren<MeshRenderer>().enabled = false;
            GetComponent<MeshRenderer>().enabled = true;
            rightHeart.GetComponent<MeshRenderer>().enabled = true;

            rightHeart.GetComponent<SphereCollider>().enabled = true;
            rightHeart.GetComponent<ObjectManipulator>().enabled = true;
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<ObjectManipulator>().enabled = true;
            parentTransform.GetComponent<SphereCollider>().enabled = false;

            transform.Translate(Vector3.right * separationDistance/2);
            rightHeart.transform.Translate(Vector3.left * separationDistance/2);

            isJoined = false;
        }
    }
}
