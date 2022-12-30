using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    GameObject player;
    public GameObject holdingObjectPosition;
    GameObject currentObj;

   public GameObject rayCastOrigin;

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
        currentObj.transform.position=holdingObjectPosition.transform.position;
        currentObj.gameObject.transform.LookAt (this.gameObject.transform.position);
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
                            if(hit.transform.gameObject.GetComponent<Ingredient>().isBoiled == true || hit.transform.gameObject.GetComponent<Ingredient>().isChopped == true)
                            Debug.Log ("pop up menu");
                        }
                         
                         //currentObj=hit.transform.gameObject;
                    }
                }       
            }
        }    
    }
}
