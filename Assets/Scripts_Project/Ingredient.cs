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

    public Ingredient(string name, bool canBeChopped, bool canBeBoiled)
    {
        this.name=name;
        this.canBeChopped=canBeChopped;
        this.canBeBoiled=canBeBoiled;
    }

    public bool compareIngredients(Ingredient ingReceived){
        bool match=false;
        if(ingReceived.name.Equals(name)){
            match=true;
        }
        return match;
    }
    //test
    	private static int CompareIngredientsByName(Ingredient first, Ingredient second){
		return first.name.CompareTo(second.name);
	}
    class IngredientsComparison : IComparer<Ingredient> {
	public int Compare(Ingredient first, Ingredient second)
    {
		return first.name.CompareTo(second.name);
	}
}
}
