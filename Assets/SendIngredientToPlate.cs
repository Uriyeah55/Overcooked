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
    public void sendIngredientTo1()
    {
       
        if(plate1.GetComponent<Plate>().plateIngredients.Count<2)
        {
                player.GetComponent<ThirdPersonController>().enabled=true;

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
        }
        else{
            Debug.Log("el plat 1 té dos ingredients ja");
        }
    }
      public void sendIngredientTo2(){

        if(plate2.GetComponent<Plate>().plateIngredients.Count<2)
        {
                player.GetComponent<ThirdPersonController>().enabled=true;

        panelPlates.gameObject.SetActive(false);
        Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate2.GetComponent<Plate>().plateIngredients.Add(ing);
        
        GameObject newIngredientImage= Instantiate(ingredientImgPrefab, new Vector3(panelPlate2.transform.position.x, panelPlate2.transform.position.y, panelPlate2.transform.position.z), Quaternion.identity);
        newIngredientImage.transform.SetParent (panelPlate2.gameObject.transform);
        newIngredientImage.GetComponent<Image>().sprite=ing.IngredientImg.sprite;
        var rectTransform = newIngredientImage.GetComponent<RectTransform>();

        rectTransform.localScale = new Vector3 (3.6f, 3.11f, 0);
        newIngredientImage.transform.localScale += scaleChange;
       //float RotateX=panelPlate1.transform.rotation;

       float zRotation = panelPlate2.GetComponent<RectTransform>().eulerAngles.z;
       float xRotation = panelPlate2.GetComponent<RectTransform>().eulerAngles.x;
       float yRotation = panelPlate2.GetComponent<RectTransform>().eulerAngles.y;


        rectTransform.Rotate( new Vector3(xRotation, yRotation, zRotation ) );
        Destroy(player.GetComponent<ItemInteraction>().currentObj);
        }
        else{
            Debug.Log("el plat 2 té dos ingredients ja");
        }
    }
     
      public void sendIngredientTo3(){

        if(plate3.GetComponent<Plate>().plateIngredients.Count<2)
        {
                player.GetComponent<ThirdPersonController>().enabled=true;

        panelPlates.gameObject.SetActive(false);
        Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate3.GetComponent<Plate>().plateIngredients.Add(ing);
        
        GameObject newIngredientImage= Instantiate(ingredientImgPrefab, new Vector3(panelPlate3.transform.position.x, panelPlate3.transform.position.y, panelPlate3.transform.position.z), Quaternion.identity);
        newIngredientImage.transform.SetParent (panelPlate3.gameObject.transform);
        newIngredientImage.GetComponent<Image>().sprite=ing.IngredientImg.sprite;
        var rectTransform = newIngredientImage.GetComponent<RectTransform>();

        rectTransform.localScale = new Vector3 (3.6f, 3.11f, 0);
        newIngredientImage.transform.localScale += scaleChange;
       //float RotateX=panelPlate1.transform.rotation;

       float zRotation = panelPlate3.GetComponent<RectTransform>().eulerAngles.z;
       float xRotation = panelPlate3.GetComponent<RectTransform>().eulerAngles.x;
       float yRotation = panelPlate3.GetComponent<RectTransform>().eulerAngles.y;


        rectTransform.Rotate(new Vector3(xRotation, yRotation, zRotation ));
        Destroy(player.GetComponent<ItemInteraction>().currentObj);
        }
        else{
            Debug.Log("el plat 3 té dos ingredients ja");
        }
    }
      public void sendIngredientTo4(){

        if(plate4.GetComponent<Plate>().plateIngredients.Count<2)
        {
                player.GetComponent<ThirdPersonController>().enabled=true;

        panelPlates.gameObject.SetActive(false);
        Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate4.GetComponent<Plate>().plateIngredients.Add(ing);
        
        GameObject newIngredientImage= Instantiate(ingredientImgPrefab, new Vector3(panelPlate4.transform.position.x, panelPlate4.transform.position.y, panelPlate4.transform.position.z), Quaternion.identity);
        newIngredientImage.transform.SetParent (panelPlate4.gameObject.transform);
        newIngredientImage.GetComponent<Image>().sprite=ing.IngredientImg.sprite;
        var rectTransform = newIngredientImage.GetComponent<RectTransform>();

        rectTransform.localScale = new Vector3 (3.6f, 3.11f, 0);
        newIngredientImage.transform.localScale += scaleChange;
       //float RotateX=panelPlate1.transform.rotation;

       float zRotation = panelPlate4.GetComponent<RectTransform>().eulerAngles.z;
       float xRotation = panelPlate4.GetComponent<RectTransform>().eulerAngles.x;
       float yRotation = panelPlate4.GetComponent<RectTransform>().eulerAngles.y;


        rectTransform.Rotate(new Vector3(xRotation, yRotation, zRotation ));
        Destroy(player.GetComponent<ItemInteraction>().currentObj);
        }
        else{
            Debug.Log("el plat 4 té dos ingredients ja");
        }
    }
    public void sendIngredientTo5(){

        if(plate5.GetComponent<Plate>().plateIngredients.Count<2)
        {
                player.GetComponent<ThirdPersonController>().enabled=true;

        panelPlates.gameObject.SetActive(false);
        Ingredient ing = player.GetComponent<ItemInteraction>().currentObj.GetComponent<Ingredient>();
        plate5.GetComponent<Plate>().plateIngredients.Add(ing);
        
        GameObject newIngredientImage= Instantiate(ingredientImgPrefab, new Vector3(panelPlate5.transform.position.x, panelPlate5.transform.position.y, panelPlate5.transform.position.z), Quaternion.identity);
        newIngredientImage.transform.SetParent (panelPlate5.gameObject.transform);
        newIngredientImage.GetComponent<Image>().sprite=ing.IngredientImg.sprite;
        var rectTransform = newIngredientImage.GetComponent<RectTransform>();

        rectTransform.localScale = new Vector3 (3.6f, 3.11f, 0);
        newIngredientImage.transform.localScale += scaleChange;
       //float RotateX=panelPlate1.transform.rotation;

       float zRotation = panelPlate5.GetComponent<RectTransform>().eulerAngles.z;
       float xRotation = panelPlate5.GetComponent<RectTransform>().eulerAngles.x;
       float yRotation = panelPlate5.GetComponent<RectTransform>().eulerAngles.y;


        rectTransform.Rotate(new Vector3(xRotation, yRotation, zRotation ));
        Destroy(player.GetComponent<ItemInteraction>().currentObj);
        }
        else{
            Debug.Log("el plat 5 té dos ingredients ja");
        }
    }
}
}
