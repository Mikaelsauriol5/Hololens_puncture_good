using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunctureCoordinates : MonoBehaviour
{
    public MeshCollider heartSurface;
    public GameObject axis;
    public TMPro.TextMeshPro punctureFeedbackText;
    public AudioSource punctureFeedbackAudio;

    bool hasCalculatedCoordinates = false;
    float punctureAngle = 0;
    Vector3 puncturePositon = Vector3.zero;
    CsvReadWrite csvWriteCoordinates;

    private void calculatePunctureCoordinates()
    {
        punctureAngle = Vector3.Angle(-axis.transform.up, gameObject.transform.right);
        puncturePositon = gameObject.transform.position;

        punctureFeedbackText.text = "Puncture coordinates calculated!";
        punctureFeedbackAudio.Play();

        csvWriteCoordinates.Write(punctureAngle, puncturePositon.x, puncturePositon.y, puncturePositon.z);

        hasCalculatedCoordinates = true;
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.Equals(heartSurface) && !hasCalculatedCoordinates)
        {
            calculatePunctureCoordinates();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        csvWriteCoordinates = new CsvReadWrite("PunctureCoordinates");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
