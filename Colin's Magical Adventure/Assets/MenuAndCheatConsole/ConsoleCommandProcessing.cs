using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConsoleCommandProcessing : MonoBehaviour {

    private GameObject player;
    private PlayerMovement playerMovement;
    private List<string> commandList;

    // Use this for initialization
    public void processing(string commandString)
    {
        player = GameObject.FindGameObjectWithTag("Player");


        playerMovement = player.GetComponent<PlayerMovement>();

        List<string> commandList = new List<string>();
        //Parse string command into list
        commandList = commandString.Split(' ').ToList();

        //Teleportation command
        if (commandList[0] == "tp")
        {
            if (commandList.Count == 4)
            {
                float x, y, z;
                bool resX, resY, resZ;
                resX = float.TryParse(commandList[1], out x);
                resY = float.TryParse(commandList[2], out y);
                resZ = float.TryParse(commandList[3], out z);
                if (resX && resY && resZ)
                    Teleportation(x, y, z);
                else
                    Debug.Log("Erreur");
            }
            /*else
            {
                switch (commandList[1])
                {
                    case "checkpoint":
                        //if(commandList[2] <= GameObject.FindGameObjectsWithTag("CheckPoint").)
                        if (commandList[2] != null)
                            Teleportation("CheckPoint" + commandList[2]);
                        else
                            Teleportation("CheckPoint1");
                        break;
                    case "startpoint":
                        Teleportation("StartPoint");
                        break;
                    default:
                        Debug.Log("Erreur");
                        break;
                }
            } */
        }
        
        //Speed change command
        else if ((commandList[0] == "speedmultiplier") && commandList.Count == 2)
        {

            if (commandList[1] == "reset")
            {
                Debug.Log("Vitesse réinitialisée");
                SpeedMultiplier(1);
            }
            else
            {
                float number;
                bool res;
                //Try to parse into float
                res = float.TryParse(commandList[1], out number);
                if (res)
                {
                    Debug.Log("Vitesse multipliée par " + number.ToString());
                    SpeedMultiplier(number);
                }
                else
                    Debug.Log("Erreur");
            }
        }
        else if ((commandList[0] == "jumpmultiplier") && commandList.Count == 2)
        {

            if (commandList[1] == "reset")
            {
                Debug.Log("Force de saut réinitialisée");
                JumpMultiplier(1);
            }
            else
            {
                float number;
                bool res;
                //Try to parse into float
                res = float.TryParse(commandList[1], out number);
                if (res)
                {
                    Debug.Log("Force de saut multipliée par " + number.ToString());
                    JumpMultiplier(number);
                }
                else
                    Debug.Log("Erreur");
            }
        }
        else if (commandList[0] == "openall")
        {
            GameObject[] objects= GameObject.FindGameObjectsWithTag("Door");

            foreach (GameObject objet in objects)
                objet.GetComponent<OpenDetection>().openDoor();
            
            Debug.Log("Toutes les portes sont ouvertes");
        }
        else if (commandList[0] == "closeall")
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Door");
            foreach (GameObject objet in objects)
                objet.GetComponent<OpenDetection>().closeDoor();

            Debug.Log("Toutes les portes sont fermées");
        }
        /*else if (commandList[0] == "gotomenu")
        {
            SceneManager.LoadScene("MenuScene");
            Cursor.lockState = CursorLockMode.None;
        }
        else if (commandList[0] == "resetgame")
        {
            SceneManager.LoadScene("SampleScene");
        }*/
        else
            Debug.Log("Erreur");
    }
    

    //Use RespawnManager.cs method
    /*public void Teleportation(string place)
    {
        respMana.Respawn(player, place);
    }*/
    public void Teleportation(float x, float y, float z)
    {
        playerMovement.transform.position = new Vector3(x, y, z);
    }

    //Change Multiplier value into player
    public void SpeedMultiplier(float number)
    {
        playerMovement.speedMultiplier = number;
    }
    public void JumpMultiplier(float number)
    {
        playerMovement.jumpMultiplier = number;
    }
}
