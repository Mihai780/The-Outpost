using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SupplyShow : MonoBehaviour 
{
    [SerializeField] private bool show=false;
    [SerializeField] GameObject hover;
    private TMP_Text text;

    public int currSupply;
    public int maxSupply=100;

    private void Start()
    {
        text = hover.GetComponentInChildren<TMP_Text>();
    }
    void Update()
    {
       if(show && hover.activeInHierarchy==false)
        {
            hover.SetActive(true);
        }

        text.text = currSupply.ToString() + "/" + maxSupply.ToString();

    }



    #region activation
    public void CallTimer()
    {
        StartCoroutine(BeginTimer());
    }

    public void StopTimer()
    {
        show = false;
        StopAllCoroutines();
        hover.SetActive(false);
        
        
    }

    private IEnumerator BeginTimer()
    {
        yield return new WaitForSeconds(1f);
        show = true;
    }


    #endregion
}
