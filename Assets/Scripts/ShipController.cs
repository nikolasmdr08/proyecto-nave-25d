using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float Force;
    public float TurnForce;
    public float NormalangularDrag;
    public Transform propulsorCentral;
    Rigidbody2D rb;

    void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        NormalangularDrag = rb.angularDrag;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.angularDrag = NormalangularDrag;
            //rb.AddForceAtPosition(new Vector2(-1, 1).normalized * fuerza, propulsorDerecho.position, ForceMode2D.Force);
            rb.AddForce(propulsorCentral.forward * Force/3 , ForceMode2D.Force);
            var impulse = (TurnForce * Mathf.Deg2Rad) * rb.inertia;
            rb.AddTorque(impulse, ForceMode2D.Force);
            //rb.AddRelativeForce(propulsorIzquierdo.forward * Force, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.angularDrag = NormalangularDrag;
            //rb.AddForceAtPosition(new Vector2(1, 1).normalized * fuerza, propulsorIzquierdo.position, ForceMode2D.Force);
            rb.AddForce(propulsorCentral.forward * Force/3 , ForceMode2D.Force);
            var impulse = (-TurnForce * Mathf.Deg2Rad) * rb.inertia;
            rb.AddTorque(impulse, ForceMode2D.Force);
            //rb.AddRelativeForce(propulsorDerecho.forward * Force, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            rb.angularDrag = Force;
            rb.AddForce(propulsorCentral.forward * Force, ForceMode2D.Force);  
        }
        
    }
}