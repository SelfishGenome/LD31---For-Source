using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelTargetManager : MonoBehaviour
{
    #region Fields

    private Text text;
    #endregion

    #region Awake
    void Awake()
    {
        text = GetComponent<Text>();
    }
    #endregion

    #region Update
    void Update()
    {
        text.text = "Enemies Remaining: " + EnemyManager.enemiesRemaining;
    }
    #endregion
}
