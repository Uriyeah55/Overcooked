using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace StarterAssets
    {
    public class ItemInteraction : MonoBehaviour
    {
        [Header("Radial Settings")]
        [SerializeField] private float indicatorTimer=1f;
        [SerializeField] private float maxIndicatorTimer=1f;
        [SerializeField] private Image radialIndicatorUI=null;
        [SerializeField] private KeyCode selectKey=KeyCode.Mouse0;
        [SerializeField] private UnityEvent myEvent=null;
        private bool shouldUpdate=false;

        float distanceToRaycastObject;
        public GameObject panelPlates;
        public GameObject panelPlateIngredients;
        GameObject player;
        public GameObject holdingObjectPosition;
        public GameObject currentObj;

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
            Ray ray = new Ray (rayCastOrigin.transform.position + Camera.main.transform.forward * 0.3f, rayCastOrigin.transform.forward);
            Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);
            

            if(currentObj != null)
            {
                Debug.Log ("current obj: " + currentObj.name);
                Debug.Log ("current obj is chopped?: " + currentObj.GetComponent<Ingredient>().isChopped);
            }

            if(currentObj != null)
            {
                currentObj.transform.position=holdingObjectPosition.transform.position;
                //while a item is being carried is forced to look to the player
                if(currentObjLookingAtPlayer)
                {
                    currentObj.gameObject.transform.LookAt (this.gameObject.transform.position);
                }
            }

            RaycastHit hit;
            if (Physics.Raycast (ray, out hit, 20))  
            {
            Debug.Log (hit.collider.name);
            Debug.Log (hit.collider.tag);
            distanceToRaycastObject = Vector3.Distance (rayCastOrigin.gameObject.transform.position, hit.transform.position);
            //Debug.Log ("la distancia es " + distanceToRaycastObject.ToString ());

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
                                else
                                {
                                    currentObjLookingAtPlayer=false;
                                    currentObj=hit.transform.gameObject;
                                }
                            } 
                        }
                    }     
                    //interactua amb una taula per tallar si té un ingredient a la ma
                if(hit.collider.tag=="CuttingBoard" && currentObj != null && currentObj.GetComponent<Ingredient>().canBeChopped==true 
                && currentObj.GetComponent<Ingredient>().isChopped==false && distanceToRaycastObject <=2.5f)
                    {
                    StartCoroutine("chopIngredient");
                    currentObj.transform.position=new Vector3(hit.transform.position.x,hit.transform.position.y + 2f, hit.transform.position.z); 
                    }  

                       //interactua amb olla
                if(hit.collider.tag=="Boiler" && currentObj != null && currentObj.GetComponent<Ingredient>().canBeBoiled==true 
                && currentObj.GetComponent<Ingredient>().isBoiled==false && distanceToRaycastObject <=2.5f)
                    {
                    StartCoroutine("boilIngredient");
                    currentObj.transform.position=new Vector3(hit.transform.position.x,hit.transform.position.y + 2f, hit.transform.position.z); 
                    } 
                    if(hit.collider.tag=="Plate" && distanceToRaycastObject <=3f)
                    {
                         if (Input.GetKeyDown(KeyCode.E))
                        {
                             switch(hit.collider.name)
                        {

                            case "Plate 1":
                            panelPlateIngredients.SetActive(true);
                            break;
                        }
                        }
                       //TODO desactivar quan tregui el raycast buscar raycast out
                        
                    }
                }
            }    
        }

          IEnumerator boilIngredient()
        {
            //cridar metode per tallar, radial
            if( Input.GetKey(KeyCode.E) && currentObj.GetComponent<Ingredient>().isBoiled==false){
                //desactivar moviment
                player.GetComponent<ThirdPersonController>().enabled=false;
                shouldUpdate=false;
                indicatorTimer -= Time.deltaTime;
                radialIndicatorUI.enabled=true;
                radialIndicatorUI.fillAmount=indicatorTimer;

                if(indicatorTimer <=0){
                    currentObj.GetComponent<Ingredient>().isBoiled=true;
                    panelPlates.gameObject.SetActive(true);

                player.GetComponent<ThirdPersonController>().enabled=true;

                indicatorTimer=maxIndicatorTimer;
                radialIndicatorUI.fillAmount=maxIndicatorTimer;
                radialIndicatorUI.enabled=false;
                myEvent.Invoke();
                }
            }
            else
            {
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
            if(Input.GetKeyUp(KeyCode.E))
            {
            shouldUpdate=true;
            }
            yield return null;
        }

        IEnumerator chopIngredient()
        {
            //cridar metode per tallar, radial
            if( Input.GetKey(KeyCode.E) && currentObj.GetComponent<Ingredient>().isChopped==false){
                //desactivar moviment
                player.GetComponent<ThirdPersonController>().enabled=false;
                shouldUpdate=false;
                indicatorTimer -= Time.deltaTime;
                radialIndicatorUI.enabled=true;
                radialIndicatorUI.fillAmount=indicatorTimer;

                if(indicatorTimer <=0){
                    currentObj.GetComponent<Ingredient>().isChopped=true;
                    panelPlates.gameObject.SetActive(true);

                player.GetComponent<ThirdPersonController>().enabled=true;

                indicatorTimer=maxIndicatorTimer;
                radialIndicatorUI.fillAmount=maxIndicatorTimer;
                radialIndicatorUI.enabled=false;
                myEvent.Invoke();
                }
            }
            else
            {
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
            if(Input.GetKeyUp(KeyCode.E))
            {
            shouldUpdate=true;
            }
            yield return null;
        }
    }
}