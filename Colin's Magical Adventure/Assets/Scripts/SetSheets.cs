using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSheets : MonoBehaviour
{
    public GameObject character;
    public GameObject SheetDefault;

    private List<GameObject> inventory;
    private List<GameObject> containers;
    private List<GameObject> itemsToRemove;
    // Start is called before the first frame update
    void Start()
    {
        
        containers = new List<GameObject>(GameObject.FindGameObjectsWithTag("SheetContainers"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Hi");
                inventory = character.GetComponent<Inventory>().getSheets();
                if(inventory.Count >= PlayerPrefs.GetInt("SheetToWin"))
                {
                    foreach (GameObject gamo in inventory.ToArray())
                    {
                        GameObject current = containers[inventory.IndexOf(gamo)];
                        GameObject newSheet = Instantiate(gamo, current.transform.position, Quaternion.Euler(-90f, 226.1f, 0));
                        Destroy(newSheet.GetComponent<Collider>());
                        PlayerPrefs.SetInt("SheetsPut", PlayerPrefs.GetInt("SheetsPut") + 1);
                        
                        Destroy(newSheet.GetComponent<OpenUp>());
                        containers.Remove(current);
                        inventory.Remove(gamo);

                    }
                }                
            }
        }
    }
}
