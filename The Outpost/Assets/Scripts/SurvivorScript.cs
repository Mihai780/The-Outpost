using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SurvivorScript : MonoBehaviour
{
    public SurvivorDataSO data;

    #region data
    public int id;
    public string nameSurv;
    public int buildingLevel;
    public int scavangeingLevel;
    public int strenghtLevel;
    public int researchLevel;
    public int leaderLevel;
    public int enduranceLevel;
    public int speedLevel;
    #endregion

    #region Vectors
    Vector2 mousePos;
    Vector3 prevPos;
    Vector3Int mousePosInt;
    #endregion

    #region Rest
    public Tilemap mainTM;
    Animator animator;
    GameObject currReferenceObject;
    [SerializeField] private Image circularSlider;
    [SerializeField] private GameObject circularSliderGO;
    float time;
    int repetari = 0;

    static int count = -1;

    #endregion

    #region Counstructor / Destructor
    public SurvivorScript()
    {
        count++;
    }

    ~SurvivorScript()
    {
        count--;
    }
    #endregion

    #region Unity functions
    void Start()
    {
        mainTM = GameObject.Find("Main").GetComponent<Tilemap>();
        int index = Random.Range(0, StaticManager.instance.survData.Count);
        data = StaticManager.instance.survData[index];

        buildingLevel = data.buildingLevel;
        scavangeingLevel = data.scavangeingLevel;
        strenghtLevel = data.strenghtLevel;
        Instantiate(data.prefabWithScript, this.gameObject.transform);
        id = data.id;

        

        animator = GetComponentInChildren<Animator>();

    }
    
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosInt = mainTM.WorldToCell(mousePos);
        
    }
    #endregion

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
        time = currReferenceObject.GetComponent<SmallBuilding>().timeToWork - 2 * (1+data.scavangeingLevel);

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
