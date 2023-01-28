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
        int ing1Coincidence;
        int ing2Coincidence;

        int ing1CoincidenceMethod2;
        int ing2CoincidenceMethod2;


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

                ing1Coincidence=-1;
                ing2Coincidence=-1;

                ing1CoincidenceMethod2=-1;
                 ing1CoincidenceMethod2=-1;
                if(!coincidence)
                {
                    //check ingredient 1 - 1
                     ing1Coincidence=CompareIngredientsByName(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0],currentPlateIngredients[0]);
                    Debug.Log("match entre " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0].name +
                    " i " + currentPlateIngredients[0].name + ":" + ing1Coincidence);

                    ing2Coincidence=CompareIngredientsByName(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[1],currentPlateIngredients[1]);
                    Debug.Log("match entre " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0].name +
                    " i " + currentPlateIngredients[0].name + ":" + ing2Coincidence);
                    //check ingredient 1 - 2
                    ing1CoincidenceMethod2=CompareIngredientsByName(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0],currentPlateIngredients[1]);
                    Debug.Log("match entre " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[1].name +
                    " i " + currentPlateIngredients[0].name + ":" + ing1CoincidenceMethod2);

                    ing2CoincidenceMethod2=CompareIngredientsByName(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[1],currentPlateIngredients[0]);
                    Debug.Log("match entre " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[1].name +
                    " i " + currentPlateIngredients[0].name + ":" + ing2CoincidenceMethod2);

                    if((ing1Coincidence==0 && ing2Coincidence==0) || (ing1CoincidenceMethod2==0 && ing2CoincidenceMethod2==0)){
                        coincidence=true;
                        Debug.Log("han coincidit el ingredient 0 i 1 a la order " + i + " que es diu " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.name);
                    }
                    else{
                        Debug.Log("no ha coincidit amb el plat " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.name);
                    }
                    
                    /*
                    if(CompareIngredientsByName(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[0],currentPlateIngredients[0])){
                        Debug.Log("ingredient 1 coincideix");
                        if(OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.orderIngredients[1].CompareIngredientsByName(),currentPlateIngredients[1]){
                        Debug.Log("ingredient 2 coincideix");
                    }
                    }*/
                 
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
