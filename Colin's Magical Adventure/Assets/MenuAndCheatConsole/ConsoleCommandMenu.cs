using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class ConsoleCommandMenu : MonoBehaviour
{
    private Toggle m_MenuToggle;
    private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    private bool m_Paused;
    private PlayerMovement player;
    [SerializeField] private InputField commandField;
    private List<string> commandList;
    private string commandString;
    private ConsoleCommandProcessing ConsoleCommandProcessing;

    void Awake()
    {
        m_MenuToggle = GetComponent<Toggle>();     
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        ConsoleCommandProcessing = new ConsoleCommandProcessing();
    }


    private void MenuOn()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        m_Paused = true;
        /*commandField.ActivateInputField();
        commandField.Select();*/
        EventSystem.current.SetSelectedGameObject(commandField.gameObject, null);
        commandField.OnPointerClick(new PointerEventData(EventSystem.current));
        player.enabled = false;
        
    }


    public void MenuOff()
    {
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        m_Paused = false;
        player.enabled = true;
    }


    public void OnMenuStatusChange()
    {
        if (m_MenuToggle.isOn && !m_Paused)
        {
            MenuOn();
        }
        else if (!m_MenuToggle.isOn && m_Paused)
        {
            MenuOff();
        }
    }


#if !MOBILE_INPUT
    void Update()
    {
        if(m_MenuToggle.isOn)
            commandField.Select();

        if (Input.GetKey(KeyCode.Escape))
        {
            m_MenuToggle.isOn = false;
            if (Cursor.visible)
                Cursor.visible = false;
            else
                Cursor.visible = true;
        }

        if (commandField.text != "" && Input.GetKey(KeyCode.Return))
        {
            m_MenuToggle.isOn = false;
            commandString = commandField.text;
            commandField.text = "";
            ConsoleCommandProcessing.processing(commandString);
            
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            m_MenuToggle.isOn = !m_MenuToggle.isOn;
            //Cursor.visible = false;
        }

    }
    
#endif

}
