using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class checkPlateCompletion : MonoBehaviour
{
    public Order[] objectiveOrders;
    public GameObject OrdersContainer;
    public List<Ingredient> currentPlateIngredients;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPlateIngredients=this.GetComponent<Plate>().plateIngredients;
    }
    public void processPlate()
    {
        currentPlateIngredients.Sort();

   


        Debug.Log("process plate. " + OrdersContainer.name + " has " + OrdersContainer.transform.childCount + " children");

        bool coincidence=false;
        if(currentPlateIngredients.Count==2)
        {
        Debug.Log("current plate ingredients count 2");

            for(int i = 0; i < OrdersContainer.transform.childCount; i++)
            {
                //OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients.Sort();
                //Debug.Log("bucle amb child: " + OrdersContainer.transform.GetChild(i).name);

                if(!coincidence)
                {
                    //test
    



                    //
                    bool currentIngredientsMatch=DoListsMatch(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients,currentPlateIngredients);
                    
                    //bool currentIngredientsMatch=DoListsMatch(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients,currentPlateIngredients);
                    if(currentIngredientsMatch)
                    {
                        coincidence=true;
                        Debug.Log("ha coincidit amb el plat " + i);
                    }
                }
            }
        }
        else{
            //no hi ha prous ingredients al plat
            }

/*
  
        List<Order> ordersObjective;
        //plate has enough ingredients to check
        if(currentPlateIngredients.Count==2){
            //check for every order
            
            foreach(GameObject slot in ordersPanel.GetComponentInChildren){
                if(!coincidence)
                {
                    if(currentPlateIngredients==slot.GetComponent<OrderSlot>().OrderToUpdate.orderIngredients){

                    }
                }
            }
         
        }
        */
    }

     private bool CheckMatch(List<Ingredient> l1, List<Ingredient> l2) {
 if (l1.Count != l2.Count)
     return false;
 for (int i = 0; i < l1.Count; i++) {
     if (l1[i] != l2[i])
         return false;
 }
 return true;
 }

    private bool DoListsMatch(List<Ingredient> list1, List<Ingredient> list2)
{
    var areListsEqual = true;

    if (list1.Count != list2.Count)
        return false;

    list1.Sort(); // Sort list one
    list2.Sort(); // Sort list two

    for (var i = 0; i < list1.Count; i++)
    {
        if (list2[i] != list1[i])
        {
            areListsEqual = false;
        }
    }

    return areListsEqual;
}
}
