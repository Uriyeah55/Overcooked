using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OrderSlot : MonoBehaviour
{
    public GameObject stockOBj;
    public Order OrderToUpdate;
    public GameObject prefabImageIngredient;
    //Image orderImg;
   // List<Ingredient> ingList;

    // Start is called before the first frame update
    void Start()
    {
        stockOBj = GameObject.Find("STOCK");
        OrderToUpdate=stockOBj.gameObject.GetComponent<OrderGenerator>().generateOrder();
        this.gameObject.transform.GetChild(1).GetComponent<Image>().sprite=OrderToUpdate.orderImg.sprite;
        //netegem els childs o s'acumulen
         foreach (Transform child in this.gameObject.transform.GetChild(0)) {
            GameObject.Destroy(child.gameObject);
        }

        foreach(Ingredient ing in OrderToUpdate.orderIngredients)
        {
            GameObject nouPref= Instantiate(prefabImageIngredient, this.gameObject.transform.GetChild(0).transform.position, Quaternion.identity);
            nouPref.transform.parent = this.gameObject.transform.GetChild(0);
            //object1 is now the child of object2
        Debug.Log("spawn" + nouPref.name);

            nouPref.GetComponent<Image>().sprite=ing.IngredientImg.sprite;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
