using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAndFarm : MonoBehaviour
{
   public int inFarm;

    private void Start() {
        inFarm = 0;
    }

    void Update()
    {
        if (inFarm > 0) {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Debug.Log("break");
            }

            if (Input.GetKeyDown(KeyCode.Mouse1)) {
                Debug.Log("Place");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 8) {
            inFarm++;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == 8) {
            inFarm--;
        }
    }
}
