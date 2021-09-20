using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAndFarm : MonoBehaviour
{
    public GameObject plants;
    Stack<GameObject> plantedFarms;
    Stack<GameObject> emptyFarms;

    private void Start() {
        plantedFarms = new Stack<GameObject>();
        emptyFarms = new Stack<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (plantedFarms.Count != 0) {
                emptyFarms.Push(plantedFarms.Pop());
                emptyFarms.Peek().transform.GetChild(1).gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            if (emptyFarms.Count != 0) {
                plantedFarms.Push(emptyFarms.Pop());
                plantedFarms.Peek().transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 8) {
            if(other.gameObject.transform.GetChild(1).gameObject.activeInHierarchy) {
                plantedFarms.Push(other.gameObject);
            } else {
                emptyFarms.Push(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == 8) {
            if (plantedFarms.Contains(other.gameObject)) {
                List<GameObject> plantedFarmsList = new List<GameObject>(plantedFarms.ToArray());
                for (int i = 0; i < plantedFarmsList.Count; i++) {
                    if (plantedFarmsList[i] == other.gameObject) {
                        plantedFarmsList.RemoveAt(i);
                    }
                }
                plantedFarms = new Stack<GameObject>(plantedFarmsList);
            }

            if (emptyFarms.Contains(other.gameObject)) {
                List<GameObject> emptyFarmsList = new List<GameObject>(emptyFarms.ToArray());
                for (int i = 0; i < emptyFarmsList.Count; i++) {
                    if (emptyFarmsList[i] == other.gameObject) {
                        emptyFarmsList.RemoveAt(i);
                    }
                }
                emptyFarms = new Stack<GameObject>(emptyFarmsList);
            }
        }
    }
}
