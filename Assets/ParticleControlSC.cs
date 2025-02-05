using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControlSC : MonoBehaviour
{
    //public Transform propulsorIzquierdo;
    //public Transform propulsorDerecho;
    public ParticleSystem LeftPropeller;
    public ParticleSystem RigthPropeller;
    public ParticleSystem LeftCenterPropeller;
    public ParticleSystem RigthCenterPropeller;
    public float OriginLeftPropellerSize;
    public float OriginRigthPropellerSize;
    public float OriginLeftCenterPropellerSize;
    public float OriginRigthCenterPropellerSize;
    // Start is called before the first frame update
    void Start()
    {
        OriginLeftPropellerSize = LeftPropeller.startSize;
        OriginRigthPropellerSize = RigthPropeller.startSize;
        OriginLeftCenterPropellerSize = LeftCenterPropeller.startSize;
        OriginRigthCenterPropellerSize = RigthCenterPropeller.startSize;
    }

    // Update is called once per frame
    void Update()
    {
        ParticleBehaviour();
    }

    void ParticleBehaviour()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
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
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
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
}
