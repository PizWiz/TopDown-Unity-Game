using UnityEngine;

public class BulletScript : MonoBehaviour
{
    int timer = 0;
    private float speed;
    

    void Start()
    {
        //GRAB STATIC VARIABLES AT START
        speed=GameScript.playerBulletSpeed;

        //ROTATE BASED ON PLAYER POSITION AND APPLY BULLET SPREAD
        transform.Rotate(new Vector3(0,+Random.Range(-GameScript.playerBulletSpread,GameScript.playerBulletSpread),0));
    }


    void OnCollisionEnter(Collision other) 
    {
        //DESTROY IF COLLIDED WITH WALL
        if(other.collider.tag == "wall")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //GRAB STATIC VARIABLES
        speed=GameScript.playerBulletSpeed;
    }


    void FixedUpdate()
    {
        //MOVE BULLET
        Vector3 movementDirection = new Vector3 (0,0,1);
        movementDirection.Normalize();
        transform.Translate(movementDirection*speed);

        //DESTROY AFTER A CERTAIN AMOUNT OF TIME
        timer+=1;
        if(timer==100)
        {
            Destroy(gameObject);
        }
    }
}