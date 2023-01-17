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
        Debug.Log("plate 1 ingredients number: " + currentPlateIngredients.Count);
    }
    public void processPlate()
    {
//        currentPlateIngredients.Sort();

       // Debug.Log("process plate. " + currentPlateIngredients.name + " has " + currentPlateIngredients.transform.childCount + " children");
        bool ing1Coincidence=false;
        bool ing2Coincidence=false;

        bool coincidence=false;
        if(currentPlateIngredients.Count==2)
        {
        Debug.Log("current plate ingredients count 2");

            for(int i = 0; i < OrdersContainer.transform.childCount; i++)
            {
                //OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients.Sort();
                //Debug.Log("bucle amb child: " + OrdersContainer.transform.GetChild(i).name);

                //ordenar llistes
                OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients.Sort(CompareIngredientsByName);
                currentPlateIngredients.Sort(CompareIngredientsByName);

                 int ingMatchPRE=CompareIngredientsByName(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0],currentPlateIngredients[0]);
                    Debug.Log("match entre " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0].name +
                    " i " + currentPlateIngredients[0].name + ":" + ingMatchPRE);
                if(!coincidence)
                {
                    int ingMatch=CompareIngredientsByName(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0],currentPlateIngredients[0]);
                    Debug.Log("match entre " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0].name +
                    " i " + currentPlateIngredients[0].name + ":" + ingMatch);
                    
                    /*
                    if(CompareIngredientsByName(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0],currentPlateIngredients[0])){
                        Debug.Log("ingredient 1 coincideix");
                        if(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[1].CompareIngredientsByName(),currentPlateIngredients[1]){
                        Debug.Log("ingredient 2 coincideix");
                    }
                    }*/
                   for(int a=0;a<2;a++){

                   }
                    //bool currentIngredientsMatch=DoListsMatch(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients,currentPlateIngredients);
                    
                    //bool currentIngredientsMatch=DoListsMatch(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients,currentPlateIngredients);
                    /*
                    if(currentIngredientsMatch)
                    {
                        coincidence=true;
                        Debug.Log("ha coincidit amb el plat " + i);
                    }*/
                }
            }
        }
        else{
            //no hi ha prous ingredients al plat
            }
        }

 //test
    	private static int CompareIngredientsByName(Ingredient first, Ingredient second){
		return first.name.CompareTo(second.name);
	}
     private bool CheckMatch(List<Ingredient> l1, List<Ingredient> l2) 
     {

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
