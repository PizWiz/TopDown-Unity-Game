using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject gObj;
    public Vector3 cameraHeight = new Vector3(0,90,0); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenshake = new Vector3(Random.Range(-GameScript.screenShake,GameScript.screenShake),Random.Range(-GameScript.screenShake,GameScript.screenShake),Random.Range(-GameScript.screenShake,GameScript.screenShake));
        transform.position = gObj.transform.position + cameraHeight + screenshake;
    }
}
