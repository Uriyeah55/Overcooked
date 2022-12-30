using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray (this.transform.position + Camera.main.transform.forward * 0.3f, this.transform.forward);
        Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);

        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 20))  
            Debug.Log (hit.collider.name);
    }
}
