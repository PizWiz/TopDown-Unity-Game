using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Camera cam;
    public GameObject bullet;
    private Vector3 bulletSpawn;
    private float reloadTimer = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //POINT TO LOOK AT MOUSE
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(pointToLook);
            
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
        }
    }

    void FixedUpdate()
    {
        //SHOOT A BULLET
        if(reloadTimer<=0)
        {
            if(Input.GetMouseButton(0))
            {
                bulletSpawn= new Vector3(Random.Range(-0.3f,0.3f),0,Random.Range(-0.3f,0.3f));
                reloadTimer = GameScript.playerReloadSpeed;
                Instantiate(bullet,transform.position + bulletSpawn + (transform.forward * 2f),transform.rotation);
            }
        }
        else
        {
            reloadTimer-=1;
        }
    }
}
