using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    #region Fields
    public static int score;

    private Text text;
    #endregion

    #region Awake
    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }
    #endregion

    #region Update
    void Update ()
    {
        text.text = "Score: " + score;
    }
    #endregion
}
