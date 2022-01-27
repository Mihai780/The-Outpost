using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasSlide : MonoBehaviour
{
    public Animator slideAnimator;
    public GameObject upButton, downButton; // TOP

    private float seconds, minutes;
    private TMP_Text timer; //TOP_RIGHT

    #region Unity Functions

    private void Start()
    {
        timer = GameObject.Find("Clock").GetComponent<TMP_Text>();
        timer.text = "_"; //CLOCk
    }

    private void Update()
    {
        ChangeTime();
    }

    #endregion

    #region TOP
    IEnumerator WaitThenSwitchButton(GameObject disable, GameObject enable)
    {
        yield return new WaitForSeconds(1f);
        disable.SetActive(false);
        enable.SetActive(true);
    }


    public void GoSlideDown()
    {
        slideAnimator.SetBool("goDown", true);
        StartCoroutine(WaitThenSwitchButton(downButton, upButton));

    }

    public void GoSlideUp()
    {
        slideAnimator.SetBool("goDown", false);
        StartCoroutine(WaitThenSwitchButton(upButton, downButton));

    }
    #endregion

    #region TOP_RIGHT

    public void ChangeTimeScale(float speed)
    {
        Time.timeScale = speed;
    }

    public void ChangeTime()
    {
        seconds = (int)(Time.time % 60);
        minutes = (int)(Time.time / 60);
        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    #endregion
}
