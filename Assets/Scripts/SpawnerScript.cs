using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private int randomNum;
    private Vector3 spawnPosition;
    public GameObject enemy1;
    void FixedUpdate()
    {
        randomNum = Mathf.RoundToInt(Random.Range(0,GameScript.spawnFrequency));
        if(randomNum==1)
        {
            spawnPosition = transform.position + new Vector3(Random.Range(-3,3),1.1f,Random.Range(-3,3));
            Instantiate(enemy1,spawnPosition,transform.rotation);
        }
    }
}
