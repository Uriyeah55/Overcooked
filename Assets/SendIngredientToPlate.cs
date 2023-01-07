using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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

    public GameObject panelPlate1;
    public GameObject panelPlate2;
    public GameObject panelPlate3;
    public GameObject panelPlate4;
    public GameObject panelPlate5;

    public GameObject panelPlates;
    public GameObject ingredientImgPrefab;

 private Vector3 scaleChange;

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
        
        GameObject newIngredientImage= Instantiate(ingredientImgPrefab, new Vector3(panelPlate1.transform.position.x, panelPlate1.transform.position.y, panelPlate1.transform.position.z), Quaternion.identity);
        newIngredientImage.transform.SetParent (panelPlate1.gameObject.transform);
        newIngredientImage.GetComponent<Image>().sprite=ing.IngredientImg.sprite;
        var rectTransform = newIngredientImage.GetComponent<RectTransform>();

        rectTransform.localScale = new Vector3 (3.6f, 3.11f, 0);
        newIngredientImage.transform.localScale += scaleChange;
       //float RotateX=panelPlate1.transform.rotation;

       float zRotation = panelPlate1.GetComponent<RectTransform>().eulerAngles.z;
       float xRotation = panelPlate1.GetComponent<RectTransform>().eulerAngles.x;
       float yRotation = panelPlate1.GetComponent<RectTransform>().eulerAngles.y;


        rectTransform.Rotate( new Vector3(xRotation, yRotation, zRotation ) );
Destroy( player.GetComponent<ItemInteraction>().currentObj);
    


       // gameObjectToMove.transform.position = new Vector3(x, y, z);

       //Debug.Log("plate 1 ingr num: " + plate1.plateIngredients.Count);


        //Debug.Log("s'ha afegit ingredient " + ing.name);
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
