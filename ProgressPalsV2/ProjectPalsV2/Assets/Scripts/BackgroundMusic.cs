using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    //public TimerManager timermanager;
    
    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
            //DontDestroyOnLoad(timermanager);
        } 
        else
        {
            Destroy(gameObject);
        }
    } 

}
