using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class fillRadial : MonoBehaviour
{
    [SerializeField] private float indicatorTimer=1f;
    [SerializeField] private float maxIndicatorTimer=1f;
    [SerializeField] private Image radialIndicatorUI=null;

    [SerializeField] private KeyCode selectKey=KeyCode.Mouse0;

    [SerializeField] private UnityEvent myEvent=null;

    private bool shouldUpdate=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(selectKey)){
            shouldUpdate=false;
            indicatorTimer -= Time.deltaTime;
            radialIndicatorUI.enabled=true;
            radialIndicatorUI.fillAmount=indicatorTimer;

            if(indicatorTimer <=0){
                indicatorTimer=maxIndicatorTimer;
                radialIndicatorUI.fillAmount=maxIndicatorTimer;
                radialIndicatorUI.enabled=false;
                myEvent.Invoke();
            }
        }
        else{
            if(shouldUpdate){
                indicatorTimer += Time.deltaTime;
                radialIndicatorUI.fillAmount=indicatorTimer;

                if(indicatorTimer >= maxIndicatorTimer){
                    indicatorTimer=maxIndicatorTimer;
                    radialIndicatorUI.fillAmount=maxIndicatorTimer;
                    radialIndicatorUI.enabled=false;
                    shouldUpdate=false;
                }
            }
        }
        if(Input.GetKeyUp(selectKey)){
            shouldUpdate=true;
        }
    }
    /*
    IEnumerator filRadialMethod(){
        
    }*/
}
