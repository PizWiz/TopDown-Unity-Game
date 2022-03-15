using UnityEngine;
using TMPro;

public class ScoreUIScript : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshPro>().text=GameScript.score.ToString();
    }
}
