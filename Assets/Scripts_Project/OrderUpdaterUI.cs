using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUpdaterUI : MonoBehaviour
{
    int maxOrders=5;
    public GameObject prefabSlot;
    public GameObject orderPanel;
    private Vector3 scaleChange;


   // public GameObject OrderSlot
    //public GameObject s
    // Start is called before the first frame update
    void Start()
    {
     
        //scaleChange = new Vector3(-0.001f, 0.02f, -0.05f);
        for(int i=0;i<maxOrders;i++)
        {
             GameObject nouPref= Instantiate(prefabSlot, new Vector3(1.0f, 0, 0), Quaternion.identity);
             //funciona pero dona msg consola
                //nouPref.transform.parent = orderPanel.gameObject.transform;
                //test
                nouPref.transform.SetParent (orderPanel.gameObject.transform); 
                 var rectTransform = nouPref.GetComponent<RectTransform>();
                 rectTransform.localScale = new Vector3 (0.38f, 1.2f, rectTransform.localScale.z);
                nouPref.transform.localScale += scaleChange;
               

                 

           // var scale = rectTransform.localScale;
          //  scale.x = 3f;
           // recTransform.localScale = scale;

           
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
