using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public List<AudioSource> powerSounds;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ChangeScene(int scene)
    {
        Application.LoadLevel(scene);
    }

    public void PlaySound(int sound)
    {
        powerSounds[sound].Play();
    }
}
