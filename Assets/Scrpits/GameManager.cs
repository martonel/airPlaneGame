using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        isMute = false;
        DontDestroyOnLoad(this.gameObject);
    }

    private bool isMute;
    private void Start()
    {
        isMute = false;
    }
    public void SetMute()
    {
        isMute = !isMute;
        GameObject[] audio = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject item in audio)
        {
            AudioSource[] sources = item.GetComponents<AudioSource>();
            foreach (AudioSource a in sources)
            {
                if (isMute)
                {
                    a.Stop();
                }
            }
            
        }
    }
}
