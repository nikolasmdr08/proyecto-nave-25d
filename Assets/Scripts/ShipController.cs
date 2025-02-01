using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float Force;
    public float TurnForce;
    public float NormalangularDrag;
    public Transform propulsorIzquierdo;
    public Transform propulsorDerecho;
    public Transform propulsorCentral;
    public ParticleSystem LeftPropeller;
    public ParticleSystem RigthPropeller;
    public ParticleSystem LeftCenterPropeller;
    public ParticleSystem RigthCenterPropeller;
    public float OriginLeftPropellerSize;
    public float OriginRigthPropellerSize;
    public float OriginLeftCenterPropellerSize;
    public float OriginRigthCenterPropellerSize;



    Rigidbody2D rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        NormalangularDrag = rb.angularDrag;

        OriginLeftPropellerSize          = LeftPropeller.startSize;
        OriginRigthPropellerSize         = RigthPropeller.startSize;
        OriginLeftCenterPropellerSize    = LeftCenterPropeller.startSize;
        OriginRigthCenterPropellerSize   = RigthCenterPropeller.startSize;


    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            LeftPropeller.loop = true;
            LeftCenterPropeller.loop = true;
            if (!LeftPropeller.isPlaying)
            {
                LeftPropeller.Play();
            }
            if (!LeftCenterPropeller.isPlaying)
            {
                LeftCenterPropeller.Play();
            }
            

            
            LeftPropeller.startSpeed = 4;
            LeftCenterPropeller.startSpeed = 1;


            RigthPropeller.startSpeed = 0;
            RigthCenterPropeller.startSpeed = 0;
            RigthPropeller.loop = false;
            RigthCenterPropeller.loop = false;

        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            RigthPropeller.loop = true;
            RigthCenterPropeller.loop = true;
            if (!RigthPropeller.isPlaying)
            {
                RigthPropeller.Play();
            }
            if (!RigthCenterPropeller.isPlaying)
            {
                RigthCenterPropeller.Play();
            }

            RigthPropeller.startSpeed = 4;
            RigthCenterPropeller.startSpeed = 1;

            LeftPropeller.startSpeed = 0;
            LeftCenterPropeller.startSpeed = 0;
            LeftPropeller.loop = false;
            LeftCenterPropeller.loop = false;
        }    
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            LeftPropeller.loop = false;
            LeftCenterPropeller.loop = true;
            RigthPropeller.loop = false;
            RigthCenterPropeller.loop = true;
            if (!LeftCenterPropeller.isPlaying)
            {
                LeftCenterPropeller.Play();
            }
            if (!RigthCenterPropeller.isPlaying)
            {
                RigthCenterPropeller.Play();
            }

            LeftPropeller.startSpeed = 0;
            LeftCenterPropeller.startSpeed = 3;
            RigthPropeller.startSpeed = 0;
            RigthCenterPropeller.startSpeed = 3;

        }
        else
        {
            LeftPropeller.startSpeed = 0;
            LeftCenterPropeller.startSpeed = 0;
            RigthPropeller.startSpeed = 0;
            RigthCenterPropeller.startSpeed = 0;

            LeftPropeller.loop = false;
            RigthPropeller.loop = false;
            LeftCenterPropeller.loop = false;
            RigthCenterPropeller.loop = false;
        }
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