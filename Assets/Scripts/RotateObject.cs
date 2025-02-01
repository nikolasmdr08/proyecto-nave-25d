using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public GameObject toRotate;
    public Vector3 rotation;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toRotate.transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
