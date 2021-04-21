using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bang;
    public AudioSource finish;
    public AudioSource death;
    public AudioSource bdmusic;

    public void bangPlay()
    {
        bang.Play();
    }

    public void finishPlay()
    {
        finish.Play();
    }

    public void deathPlay()
    {
        death.Play();
    }

    public void bdPlay()
    {
        bdmusic.Play();
        DontDestroyOnLoad(this.gameObject);
    }
}
