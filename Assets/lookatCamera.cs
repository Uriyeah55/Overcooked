using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class lookatCamera : MonoBehaviour
{
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt (mainCamera.gameObject.transform.position);
    }
}
