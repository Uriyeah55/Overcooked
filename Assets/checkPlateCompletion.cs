using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlateCompletion : MonoBehaviour
{
    public Order[] objectiveOrders;
    public GameObject OrdersContainer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void processPlate(List<Ingredient> ingredientsList)
    {
        bool coincidence=false;
        if(ingredientsList.Count==2)
        {
            for(int i = 0; i < OrdersContainer.transform.childCount; i++)
            {
                /// All your stuff with transform.GetChild(i) here...
                if(!coincidence)
                {
                    bool currentIngredientsMatch=DoListsMatch(transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients,ingredientsList);
                    if(currentIngredientsMatch){
                        coincidence=true;
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
        if(ingredientsList.Count==2){
            //check for every order
            
            foreach(GameObject slot in ordersPanel.GetComponentInChildren){
                if(!coincidence)
                {
                    if(ingredientsList==slot.GetComponent<OrderSlot>().OrderToUpdate.orderIngredients){

                    }
                }
            }
         
        }
        */
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
