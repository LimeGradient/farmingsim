using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAndFarm : MonoBehaviour
{
    int inFarm;
    public GameObject plants;

    private void Start() {
        inFarm = 0;
    }

    void Update()
    {
        if (inFarm > 0) {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                plants.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Mouse1)) {
                plants.SetActive(true);
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
