using UnityEngine;

public class HealthbarScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(GameScript.playerHealth/100,0.02f,0.1f);
    }
}
