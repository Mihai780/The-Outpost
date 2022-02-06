using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SurvivorScript : MonoBehaviour
{
    public SurvivorDataSO data;
    Vector2 mousePos;
    Vector3 prevPos;
    Vector3Int mousePosInt;
    public Tilemap mainTM;
    Animator animator;
    GameObject currReferenceObject;
    [SerializeField] private Image circularSlider;
    [SerializeField] private GameObject circularSliderGO;
    float time;
    int repetari = 0;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Firefighter ff = new Firefighter();
    }
    
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInt = mainTM.WorldToCell(mousePos);
        
    }

    #region Mouse Events
    private void OnMouseDown()
    {
        prevPos = transform.position;

        //inchide meniul
        animator.SetBool("Show", false);
    }

    public void OnMouseDrag()
    {
        transform.position = new Vector3(mousePos.x,mousePos.y ,0);
    }

    private void OnMouseUp()
    {
        //movement
        if(mainTM.GetTile(mousePosInt) == buildingSpawner.instance.base1
            || mainTM.GetTile(mousePosInt) == buildingSpawner.instance.one
            || mainTM.GetTile(mousePosInt) == buildingSpawner.instance.three)
        {
            //deschide meniurile
            animator.SetBool("Show", true);

            transform.position = mainTM.GetCellCenterLocal(mousePosInt);
            this.GetComponent<CircleCollider2D>().enabled = false;
            currReferenceObject = Physics2D.CircleCast(mousePos, 0.1f, mousePos).collider.gameObject;

            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            transform.position = prevPos;

            //inchide meniul
            animator.SetBool("Show", false);
        }
    }
    #endregion

    #region Buttons
    public void ScavangeButton()
    {   
        //inchide meniul
        animator.SetBool("Show", false);

        //deschide sliderGO
        circularSliderGO.SetActive(true);

        //set time to work
        time = currReferenceObject.GetComponent<SmallBuildingGeneration>().timeToWork - 2 * (1+data.scavangeingLevel);

        //start the work
        StartCoroutine(Working(time));
        
    }

    IEnumerator Working(float time)
    {
        repetari++;
        yield return new WaitForSeconds(time);
        if(repetari<=time)
        {
            Debug.Log("Repetare"+repetari);
            circularSlider.fillAmount = (float)(repetari / (time + 1));
            StartCoroutine(Working(time));
        } 
        else
        {
            circularSlider.fillAmount = 1f;
            repetari = 0;
            Debug.Log("Done");
        }
        
    }
    #endregion

    
}
