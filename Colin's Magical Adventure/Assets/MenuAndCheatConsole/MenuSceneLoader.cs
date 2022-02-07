using System;
using UnityEngine;

public class MenuSceneLoader : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject CommandMenuUI;

    private GameObject PauseMenu;
    private GameObject CommandMenu;

    void Awake()
    {
        if (PauseMenu == null && CommandMenu == null)
        {
            PauseMenu = Instantiate(menuUI);
            CommandMenu = Instantiate(CommandMenuUI);
        }
    }
}
