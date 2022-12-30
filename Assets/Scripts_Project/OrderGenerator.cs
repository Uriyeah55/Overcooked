using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrderGenerator : MonoBehaviour
{
   // Order generatedOrder;
  //  GameObject ingredientsManager;
    // List<Ingredient> allIngredients= new List<Ingredient>();
	List<Ingredient> ingredientsList = new List<Ingredient>();
	public List<Order> ordersList = new List<Order>();


    // Start is called before the first frame update
    void Start()
    {
        //get ingredients from previous script
        ingredientsList=this.GetComponent<IngredientGenerator>().ingredientsList;
       // Debug.Log(ordersList[0].name);
      
        generateOrder();
    }

    // Update is called once per frame
    void Update()
    {
       // int ingredientsNumber  = Random.Range(0, allIngredients.Count);  // creates a number between 1 and 3
       // Debug.Log(allIngredients[ingredientsNumber].name);
    }
    public Order generateOrder()
    {
       // Debug.Log("generating order");
        int randomNumber = Random.Range(0, ordersList.Count);
        //random todo
        Order orderToReturn= ordersList[randomNumber];

       // Debug.Log("returning order..." + orderToReturn.name);
        foreach (Ingredient _ing in orderToReturn.orderIngredients)
        {
        // Debug.Log(orderToReturn.name + ",ingredient: " + _ing.name);
        }

        //test
       // orderToReturn=ordersList[2];
        return orderToReturn;
    }

}
