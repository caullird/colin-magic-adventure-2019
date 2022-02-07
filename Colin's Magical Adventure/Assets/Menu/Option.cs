using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public AudioMixer audioMixer;

    Resolution[] resolutions; // creation d'une liste de résolution

    public Dropdown resolutionDropdown;
    public Dropdown qualite;
    public Slider sheet;
    private void Start()
    {
        int currentResolution = 0; // index de la résolution actif en se moment 
        int qualiteIndex = QualitySettings.GetQualityLevel();

        resolutions = Screen.resolutions; //on va prendre les résolution possible

        resolutionDropdown.ClearOptions(); // on efface la dropdown d'avant 

        List<string> options = new List<string>(); // on créée une liste d'option

        for (int i = 0; i < resolutions.Length; i++) // loop chaque éléments qui sont inférieur à notre ordinateur
        {
            
            
                string option = resolutions[i].width + "x" + resolutions[i].height; // si oui bah on va l'écrire comme ceci ****x****
                options.Add(option);// et on va rajouté le contenu dans la liste d'option qui sera affichée

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)// on vérifie que la résolution current = à celle hauteur et largeur et on la met donc dans la variable i
                {
                    currentResolution = i;
                }
            
               
        }
       
        resolutionDropdown.AddOptions(options);// on prend le contenu de la liste options
        resolutionDropdown.value = currentResolution;//valeur index de la résolution qu'on va mettre en value 
        resolutionDropdown.RefreshShownValue();// on refresh la value pour la voir affiché
        qualite.value = qualiteIndex;
        qualite.RefreshShownValue();

        PlayerPrefs.SetInt("SheetToWin", 9);

    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume); //changer le volume, "Volume" c'est le nom du audiomixer qu'on généré en script
        // et volume c'est notre variable float qui varie obligatoirement de -80 à 0 db


    }

    public void SetVolumeMus(float volume)
    {
        audioMixer.SetFloat("VolumeMus", volume); //changer le volume, "Volume" c'est le nom du audiomixer qu'on généré en script
        // et volume c'est notre variable float qui varie obligatoirement de -80 à 0 db
    }

    public void SetVolumeFx(float volume)
    {
        audioMixer.SetFloat("VolumeFx", volume); //changer le volume, "Volume" c'est le nom du audiomixer qu'on généré en script
        // et volume c'est notre variable float qui varie obligatoirement de -80 à 0 db
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); // changement de la qualité de l'image
        // chosie dans edit, setting et ensuite quality
        // les index est donc de 0 1 2 0= low et 2 = high
    }
    public void SetFullscreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen; // on regarde si le fullscreen est actif (bool)
    }




    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex]; // variable resolution
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);// propriété resolution
    }

    public void SetSheetNumber()
    {
        PlayerPrefs.SetInt("SheetToWin", (int)sheet.value);
    }
}
