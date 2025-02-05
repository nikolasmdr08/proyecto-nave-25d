using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSC : MonoBehaviour
{
    public Transform SpaceShip;
    private Vector3 Pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pos = new Vector3(SpaceShip.position.x, SpaceShip.position.y, this.transform.position.z);
        this.transform.position = Pos;
    }
}
