using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAndFarm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Hello");
        }
    }
    }
}
