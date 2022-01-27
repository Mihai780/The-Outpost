using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSlide : MonoBehaviour
{
    public Animator slideAnimator;
    public GameObject upButton, downButton;

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
}
