using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //GAMEPLAY VARIABLES
    private GameObject player;
    public GameObject deadFrog;
    private Rigidbody rigid;
    public float damage;
    private float speed;
    private float health;
    public float jumpFrequency;
    private int randomNum;
    public Vector3 moveDir;
    
    //ANIMATION VARIABLES
    Animator anim;
    

    void Start()
    {
        //GRAB STATIC VARIABLES
        speed = GameScript.enemySpeed;
        health = GameScript.enemyHealth;


        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        //ANIMATION STUFF
        anim = GetComponent<Animator>();
        RootMotion();
        anim.SetTrigger("Crawl");
    }


    void OnCollisionEnter(Collision other) 
    {
        //COLLIDE WITH BULLET
        if(other.collider.tag == "bullet")
        {
            //Debug.Log("bullet hit");
            health-=GameScript.playerBulletDamage;
            Destroy(other.collider.gameObject);
        }

        if(other.collider.tag == "Player")
        {
            GameScript.screenShake=0.4f;
            rigid.AddRelativeForce(moveDir*speed*-20);
        }

    }



    void Update()
    {


        //FACE PLAYER DIRECTION
        transform.LookAt(player.transform.position);
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);

        //DESTROY IF RUN OUT OF HEALTH
        if(health<=0)
        {
            GameScript.screenShake=0.2f;
            GameScript.score+=10;
            Instantiate(deadFrog,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }



    void FixedUpdate()
    {
        //POINT TOWARDS PLAYER
        moveDir = new Vector3(0, 0, 1);
        moveDir.Normalize();

        //MOVE TOWARDS PLAYER
        rigid.AddRelativeForce(moveDir*speed);

        //RANDOMLY JUMP BASED ON FREQUENCY
        randomNum=Mathf.RoundToInt(Random.Range(0,jumpFrequency));
        if(randomNum==1)
        {
            Vector3 jumpDir = new Vector3(Random.Range(-0.3f,0.3f),Random.Range(-0.3f,0.3f),Random.Range(-0.3f,0.3f));
            jumpDir=jumpDir+moveDir;
            rigid.AddRelativeForce(jumpDir*speed*30);
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
