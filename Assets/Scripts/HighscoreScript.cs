using UnityEngine;
using TMPro;

public class HighscoreScript : MonoBehaviour
{
    void Start()
    {
        //DRAW SCORE
        GetComponent<TextMeshPro>().text=GameScript.highScore.ToString();
    }
}
