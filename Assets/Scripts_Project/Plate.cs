using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
   public List<Ingredient> plateIngredients= new List<Ingredient>();
   GameObject stock;

    // Start is called before the first frame update
    void Start()
    {
         stock = GameObject.Find("STOCK");
        //plateIngredients=stock.GetComponent<IngredientGenerator>().ingredientsList;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
