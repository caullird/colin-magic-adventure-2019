using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUp : MonoBehaviour
{
    public AudioSource sound;
    public GameObject image;
    public Sprite imageToOpen;
    public Sprite imageNull;
    public Inventory inventoryScript;
    public GameObject textObject;
    private Text text;
    public GameObject inventoryGameObject;

    private bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        text = textObject.GetComponent<Text>();
    }
    

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!open)
                {
                    sound.Play();
                    PlayerPrefs.SetInt("SheetOpen", 1);
                    image.transform.parent.gameObject.SetActive(true);
                    image.GetComponent<Image>().sprite = imageToOpen;
                    open = true;
                    text.text = "Prendre la copie(E)";

                }
                else
                {
                    PlayerPrefs.SetInt("SheetOpen", 0);
                    image.transform.parent.gameObject.SetActive(false);
                    open = false;
                    text.text = "";
                    PlayerPrefs.SetInt("SheetTaken", PlayerPrefs.GetInt("SheetTaken")+1);
                    image.GetComponent<Image>().sprite = imageNull;
                    GameObject n = Instantiate(
                            gameObject,
                            inventoryGameObject.transform
                            );
                    inventoryScript.addSheet(n);
                        
                    Destroy(this.gameObject);

                }
            }
        }
     }
    
}
