using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 3;
    public Text countdownText;
    private bool paused = true;
    private bool checkPaused;
    private bool startGame;
    public GameObject startBuffer;
    public GameObject OnScreenButtons;
    float pauseEndTime;

    // Use this for initialization
    void Start()
    {
        OnScreenButtons.SetActive(false);
        pauseEndTime = Time.realtimeSinceStartup + 3;
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Get Ready! " + timeLeft);

        if (timeLeft < 0)
        {
            StopCoroutine("LoseTime");
            paused = false;
        }

        /*if(paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            GameObject.Find("Main Camera").SendMessage("EndCountdownPause", false);
            Time.timeScale = 1;
        }*/
    }

    IEnumerator LoseTime()
    {
        Time.timeScale = 0;

        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            //Debug.Log(timeLeft);
            yield return new WaitForSecondsRealtime(1);
            timeLeft--;
            //Debug.Log(timeLeft + "after");
            yield return 0;
        }

        GameObject.Find("Main Camera").SendMessage("EndCountdownPause", false);
        Time.timeScale = 1;
        startBuffer.SetActive(false);
        OnScreenButtons.SetActive(true);

    }

    public void EndCountdownPause(bool check)
    {
        checkPaused = check;
        startGame = check;
    }

}