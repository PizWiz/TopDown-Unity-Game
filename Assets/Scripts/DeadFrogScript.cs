using UnityEngine;

public class DeadFrogScript : MonoBehaviour
{
    int timer = 120;
    // Update is called once per frame
    void FixedUpdate()
    {
        timer-=1;
        if(timer<=0)
        {
            Destroy(gameObject);
        }
    }
}
