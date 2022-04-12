using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelsBehaviour : MonoBehaviour
{

    #region Canvas
    [SerializeField]
    private Canvas LogInCanvas;
    [SerializeField]
    private Canvas SignInCanvas;
    [SerializeField]
    private Canvas ConfigCanvas;
    [SerializeField]
    private Canvas SoundConfigCanvas;
    [SerializeField]
    private Canvas ContactCanvas;
    [SerializeField]
    private Canvas TutorialCanvas;
    #endregion

    #region LogIn Elements
    [SerializeField]
    private InputField usernameL;
    [SerializeField]
    private InputField passwordL;
    [SerializeField]
    private Image black;
    #endregion

    #region SignIn Elements
    [SerializeField]
    private InputField usernameS;
    [SerializeField]
    private InputField passwordS;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
        }
    }

    public void OnClickLogIn()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("LogIn Pulsado");
        //if (usernameL.text != "" && passwordL.text != "")
       
        if (usernameL.text != "" )
        {
            Debug.Log("user: " + usernameL.text + " pass: " + passwordL.text);
            StaticInfo.name = usernameL.text;
            if (PlayerPrefs.GetInt(StaticInfo.tutorialKey, 0) == 0)
            {
                StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.storyScene));
            }
            else
            {
                StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.navigationScene));
            }
        }
    }

    public void OnClickStart()
    {
        if (PlayerPrefs.GetInt(StaticInfo.tutorialKey, 0) == 0)
        {
            StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.storyScene));
        }
        else
        {
            StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.navigationScene));
        }
    }

    public void OnClickSignIn()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("SignIn Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(true);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
    }
    public void OnClickContact()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("Contact Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(true);
        TutorialCanvas.gameObject.SetActive(false);
    }
    public void OnClickConfiguration()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("Opciones Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(true);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
    }

    public void OnClickTutorial()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("Tutorial Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(true);
    }

    public void OnClickGoBack()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        if (ConfigCanvas.gameObject.activeSelf == true || SignInCanvas.gameObject.activeSelf == true)
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
        else if (SoundConfigCanvas.gameObject.activeSelf == true)
        {
            LogInCanvas.gameObject.SetActive(false);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(true);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
        else if (ContactCanvas.gameObject.activeSelf == true)
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
        else if (TutorialCanvas.gameObject.activeSelf == true)
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
    }
    public void OnClickSoundConfig()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("Opciones Sonido Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(true);
        ContactCanvas.gameObject.SetActive(false);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void StartTutorial(int n)
    {
        StaticInfo.tutorialID = n;
        switch (n)
        {
            case 1:
                PlayerPrefs.SetInt(StaticInfo.tutorialNavKey, 1);
                break;
            case 2:
                PlayerPrefs.SetInt(StaticInfo.tutorialFishKey, 1);
                break;
            case 3:
                PlayerPrefs.SetInt(StaticInfo.tutorialShopKey, 1);
                break;
        }
        StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.tutorialScene));
    }
}
