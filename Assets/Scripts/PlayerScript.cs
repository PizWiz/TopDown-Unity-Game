using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //INITIATE SOME VARS
    public float speed = 1f;
    public Camera cam;
    public float rotationSpeed;
    private Rigidbody rigid;
    private bool moved = false;
    Animator anim;


    void Start()
    {
        rigid = GetComponent<Rigidbody> ();
    }


    void OnCollisionEnter(Collision other) 
    {
        //COLLIDE WITH ENEMY
        if(other.collider.tag == "enemy")
        {
            EnemyScript temp = other.collider.gameObject.GetComponent<EnemyScript>();
            //GameScript.playerHealth-=temp.damage;
            GameScript.playerHealth-=GameScript.enemyDamage;
        }
    }


    void Update()
    {
        //check game statics
        speed = GameScript.playerSpeed;
    }

    
    void FixedUpdate(){

        //PLAYER MOVEMENT
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(xDir, 0.0f, yDir);
        moveDir.Normalize();
        rigid.AddForce(moveDir*speed);
        

        if(moveDir != Vector3.zero)
        {
            moved=true;
            //ANIMATE WALK
            anim = GetComponent<Animator>();
            RootMotion();
            anim.SetTrigger("Crawl");

            //ROTATE PLAYER
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
        }
        else//STOP ANIMATION
        {
            if(moved==true)
            {
                anim.SetTrigger("Idle");
            }
        }
        
    }

    //AUTO DISABLES ROOTMOTION TO FIX BROKEN ANIMATION
    void RootMotion()
    {
        if (anim.applyRootMotion)
        {
            anim.applyRootMotion = false;
        }
    }
}