using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update

    //public Text text;
    private bool TimerActive;
    public Animator anim;
    void Start()
    {
        TimerActive = true;
    }
    private void Update()
    {
        if (anim != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
            {
                PauseTheGame();
            }
        }
    }
    public void PauseTheGame()
    {
        TimerActive = !TimerActive;
        anim.Play(TimerActive ?  "PauseDown" : "PauseUp");
        //text.text = TimerActive ? "Pause" : "Start";
        Time.timeScale = TimerActive ? 1 : 0;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        //scenefader behozása ennek a megírása helyett a játékba!
    }

    //https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
}
