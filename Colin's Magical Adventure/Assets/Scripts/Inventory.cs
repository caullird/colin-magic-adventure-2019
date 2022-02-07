using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> sheets;
    // Start is called before the first frame update
    void Start()
    {
        sheets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> getSheets()
    {
        return sheets;
    }

    public void addSheet(GameObject gameObject)
    {
        if(gameObject != null)
            sheets.Add(gameObject);
    }
}
