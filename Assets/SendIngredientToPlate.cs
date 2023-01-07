using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
    {
public class SendIngredientToPlate : MonoBehaviour
{
    public GameObject manager;
    GameObject player;
    public Plate plate1;
    public Plate plate2;
    public Plate plate3;
    public Plate plate4;
    public Plate plate5;
        public GameObject panelPlates;


    // Start is called before the first frame update
    void Start()
    {
            player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("plate 1 ingr num: " + plate1.plateIngredients.Count);
    }
    public void sendIngredientTo1(){
        panelPlates.gameObject.SetActive(false);
        Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate1.GetComponent<Plate>().plateIngredients.Add(ing);
        Debug.Log("s'ha afegit ingredient " + ing.name);
    }
     public void sendIngredientTo2(){
        panelPlates.gameObject.SetActive(false);

Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate2.GetComponent<Plate>().plateIngredients.Add(ing);
    }
     public void sendIngredientTo3(){
        panelPlates.gameObject.SetActive(false);

Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate3.GetComponent<Plate>().plateIngredients.Add(ing);
    }
     public void sendIngredientTo4(){
        panelPlates.gameObject.SetActive(false);

Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate4.GetComponent<Plate>().plateIngredients.Add(ing);
    }
     public void sendIngredientTo5(){
        panelPlates.gameObject.SetActive(false);

Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate5.GetComponent<Plate>().plateIngredients.Add(ing);
    }
}
}
