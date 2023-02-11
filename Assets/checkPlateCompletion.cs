using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class checkPlateCompletion : MonoBehaviour
{
    public Order[] objectiveOrders;
    public GameObject OrdersContainer;
    public List<Ingredient> currentPlateIngredients;
    GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("MANAGER");
        manager.GetComponent<UpdateScore>().AddScore(50);
    }

    // Update is called once per frame
    void Update()
    {
        currentPlateIngredients=this.GetComponent<Plate>().plateIngredients;
        Debug.Log("plate 1 ingredients number: " + currentPlateIngredients.Count);
    }
    public void processPlate()
    {
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
                        manager.GetComponent<UpdateScore>().AddScore(50);
                    }
                    else{
                        Debug.Log("no ha coincidit amb el plat " + OrdersContainer.transform.GetChild(i).GetComponent<OrderSlot>().OrderToUpdate.name);
                    }
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
