using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ingredient : MonoBehaviour
{
    public string name;
    public bool canBeChopped;
    public bool isChopped=false;
    public bool canBeBoiled;
    public bool isBoiled=false;
    public Image IngredientImg;

    //public List<Ingredient> allIngredients = new List<Ingredient>();  // Create list
    
   // Ingredient ing = stockOBj.AddComponent<Ingredient>();
    public Ingredient(string name, bool canBeChopped, bool canBeBoiled)
    {
        this.name=name;
        this.canBeChopped=canBeChopped;
        this.canBeBoiled=canBeBoiled;
    }
}
