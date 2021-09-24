using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropManage : MonoBehaviour
{
    public GameObject plants;
    Stack<GameObject> plantedFarms;
    Stack<GameObject> emptyFarms;
    public int tomatoCount;
    public int seedCount = 1;
    public int money;
    
    private void Start() {
        plantedFarms = new Stack<GameObject>();
        emptyFarms = new Stack<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) { //left click
            if (plantedFarms.Count != 0) { //make sure there is at least one planted farm
                emptyFarms.Push(plantedFarms.Pop()); //transfer the first farm from the planted farms to the empty farms
                emptyFarms.Peek().transform.GetChild(1).gameObject.SetActive(false); //dissable the plants on the farm
                tomatoCount += 12;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) { //right click
            if (emptyFarms.Count != 0) { //make sure there is at least one empty farms
                plantedFarms.Push(emptyFarms.Pop()); //transfer the first farm from the empty farms to the planted farms
                plantedFarms.Peek().transform.GetChild(1).gameObject.SetActive(true); //enable the plants on the farm
                seedCount -= 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 8) { //is it a farmland tigger?
            if(other.gameObject.transform.GetChild(1).gameObject.activeInHierarchy) { //is it active?
                plantedFarms.Push(other.gameObject); //add the farmland to the planted farms
            } else {
                emptyFarms.Push(other.gameObject); //add the farmland to the empty farms
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == 8) { //is it a farmland trigger?
            if (plantedFarms.Contains(other.gameObject)) { //is the object in the planted farms?
                List<GameObject> plantedFarmsList = new List<GameObject>(plantedFarms.ToArray()); //turn the planted farms into a list so we can remove the farmland
                for (int i = 0; i < plantedFarmsList.Count; i++) { 
                    if (plantedFarmsList[i] == other.gameObject) { //check every farmland in the planted farms to see if it is our farmland
                        plantedFarmsList.RemoveAt(i); //remove the farmland for the planted farms
                    }
                }
                plantedFarms = new Stack<GameObject>(plantedFarmsList); //put the new planted farms list back in the correct stack
            }

            if (emptyFarms.Contains(other.gameObject)) { //is the object in the empth farms?
                List<GameObject> emptyFarmsList = new List<GameObject>(emptyFarms.ToArray()); //turn the empty farms into a list so we can remove the farmland
                for (int i = 0; i < emptyFarmsList.Count; i++) {
                    if (emptyFarmsList[i] == other.gameObject) { //check every farmland in the empty farms to se if it is our farmland
                        emptyFarmsList.RemoveAt(i); //remove the farmland form the empty farms
                    }
                }
                emptyFarms = new Stack<GameObject>(emptyFarmsList); //put the new empty farms list back in the correct stack
            }
        }
    }

        void OnTriggerStay(Collider other) { // checking for shop trigger
            if(other.gameObject.tag == "shop") 
            {
                if (Input.GetKeyDown(KeyCode.E)) { // stuff happens here
                    tomatoCount -= 6;
                    money += 5;
                    Debug.Log("Sold!");
                }

                if (money < 0) // idk if this works maybe
                {
                    if (Input.GetKeyDown(KeyCode.E)) {
                        Debug.Log("Nope");
                    }
                }
            }
    }
}
