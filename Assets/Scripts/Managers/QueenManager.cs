using UnityEngine;
using System.Collections;

public class QueenManager : MonoBehaviour
{

    public GameObject[] textOb;
    public GameObject button;
    int i = 0;
    int secondCount = 0;

    float timer = 2.0f;

    void Update()
    {

        timer -= Time.deltaTime;
        if(timer <= 0 )
        {
            if (textOb[0].activeSelf == false && secondCount == 0)
            {
                textOb[i].SetActive(true);
                button.SetActive(true);
                secondCount++;
            }

        }

        if (i == 4)
        {
            Application.LoadLevel(0);
        }
        
    }

    public void ActivateText()
    {
        i++;
        textOb[i - 1].SetActive(false);
        textOb[i].SetActive(true);
    }
}
