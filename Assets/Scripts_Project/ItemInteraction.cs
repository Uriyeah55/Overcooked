using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace StarterAssets
{
public class ItemInteraction : MonoBehaviour
{
      [SerializeField] private float indicatorTimer=1f;
    [SerializeField] private float maxIndicatorTimer=1f;
    [SerializeField] private Image radialIndicatorUI=null;

    [SerializeField] private KeyCode selectKey=KeyCode.Mouse0;

    [SerializeField] private UnityEvent myEvent=null;

    private bool shouldUpdate=false;

    GameObject player;
    public GameObject holdingObjectPosition;
    GameObject currentObj;

   public GameObject rayCastOrigin;
   private bool currentObjLookingAtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        currentObj=null;
        player = GameObject.Find("Player");
           
    }

    // Update is called once per frame
    void Update()
    {
        if(currentObj != null)
        {
        Debug.Log ("current obj: " + currentObj.name);
        Debug.Log ("current obj is chopped?: " + currentObj.GetComponent<Ingredient>().isChopped);

        }

        if(currentObj != null)
        {
        currentObj.transform.position=holdingObjectPosition.transform.position;
        if(currentObjLookingAtPlayer){
        currentObj.gameObject.transform.LookAt (this.gameObject.transform.position);
        }
        }

        Ray ray = new Ray (rayCastOrigin.transform.position + Camera.main.transform.forward * 0.3f, rayCastOrigin.transform.forward);
        Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);

        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 20))  
        {

        Debug.Log (hit.collider.name);
        Debug.Log (hit.collider.tag);

            if (hit.collider != null)
            {
                if(hit.collider.tag=="Pickable")
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if(hit.transform.gameObject.GetComponent<Ingredient>() != null)
                        {
                            if(hit.transform.gameObject.GetComponent<Ingredient>().isBoiled == true || hit.transform.gameObject.GetComponent<Ingredient>().isChopped == true){
                            Debug.Log ("pop up menu");
                            }
                            else{
                                currentObjLookingAtPlayer=false;
                         currentObj=hit.transform.gameObject;
                        }
                        }
                        
                         
                    }
                }     
                //interactua amb una taula per tallar si té un ingredient a la ma
               if(hit.collider.tag=="CuttingBoard" && currentObj != null && currentObj.GetComponent<Ingredient>().canBeChopped==true 
               && currentObj.GetComponent<Ingredient>().isChopped==false)
                {
                 StartCoroutine("chopIngredient");
                 currentObj.transform.position=new Vector3(hit.transform.position.x,hit.transform.position.y + 2f, hit.transform.position.z); 
                  
                }  
            }
        }    
    }
    IEnumerator chopIngredient(){
        //cridar metode per tallar, radial
        if( Input.GetKey(KeyCode.E) &&  currentObj.GetComponent<Ingredient>().isChopped==false){
            //desactivar moviment
            player.GetComponent<ThirdPersonController>().enabled=false;
            shouldUpdate=false;
            indicatorTimer -= Time.deltaTime;
            radialIndicatorUI.enabled=true;
            radialIndicatorUI.fillAmount=indicatorTimer;

            if(indicatorTimer <=0){
                currentObj.GetComponent<Ingredient>().isChopped=true;
            player.GetComponent<ThirdPersonController>().enabled=true;

            indicatorTimer=maxIndicatorTimer;
            radialIndicatorUI.fillAmount=maxIndicatorTimer;
            radialIndicatorUI.enabled=false;
            myEvent.Invoke();
            }
        }
        else{
            if(shouldUpdate){
                indicatorTimer += Time.deltaTime;
                radialIndicatorUI.fillAmount=indicatorTimer;

                if(indicatorTimer >= maxIndicatorTimer){
                indicatorTimer=maxIndicatorTimer;
                radialIndicatorUI.fillAmount=maxIndicatorTimer;
                radialIndicatorUI.enabled=false;
                shouldUpdate=false;
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.E)){
         shouldUpdate=true;
        }
        yield return null;
    }
}
}