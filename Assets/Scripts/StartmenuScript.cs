using UnityEngine;
using UnityEngine.SceneManagement;

public class StartmenuScript : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneName:"MainScene");
        }
    }
}
