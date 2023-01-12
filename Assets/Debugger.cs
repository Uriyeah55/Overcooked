using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
     public GameObject OrdersContainer;
    // Start is called before the first frame update
    void Start()
    {
          for(int i = 0; i < OrdersContainer.transform.childCount; i++){
            Debug.Log("aa" + transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients);
          }
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(OrdersContainer.name + " has " + OrdersContainer.transform.childCount + " children");
        
    }
}
