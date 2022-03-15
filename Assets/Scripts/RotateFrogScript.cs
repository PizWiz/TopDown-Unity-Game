using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFrogScript : MonoBehaviour
{
    public int rotationSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,rotationSpeed,0),Space.World);
    }
}
