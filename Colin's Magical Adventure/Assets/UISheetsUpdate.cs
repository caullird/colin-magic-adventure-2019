using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISheetsUpdate : MonoBehaviour
{
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = PlayerPrefs.GetInt("SheetTaken") + "/" + PlayerPrefs.GetInt("SheetToWin") + " feuilles trouvées";
    }
}
