using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControll : MonoBehaviour
{

    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject bounceText;
    [SerializeField] GameObject bigButton;
    [SerializeField] GameObject animCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject menuControls;
    [SerializeField] AudioSource buttonSelect;
    public static bool hasClicked;
    [SerializeField] GameObject staticCam;
    [SerializeField] GameObject fadeIn;

    [SerializeField] int loadedCoins;
    [SerializeField] int loadedGems;
    [SerializeField] int loadedDistance;
    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject gemDisplay;
    [SerializeField] GameObject distanceDisplay;


    void Start()
    {

            // loadedCoins = PlayerPrefs.GetInt("COINSAVE");
            // loadedGems = PlayerPrefs.GetInt("GEMSAVE");
            // loadedDistance = PlayerPrefs.GetInt("DISTANCESAVE");
            // coinDisplay.GetComponent<TMPro.TMP_Text>().text = "" + loadedCoins;
            // gemDisplay.GetComponent<TMPro.TMP_Text>().text = "" + loadedGems;
            // distanceDisplay.GetComponent<TMPro.TMP_Text>().text = "" + loadedDistance;

            StartCoroutine(FadeInTurnOff());
            if (hasClicked)
        {
            staticCam.SetActive(true);
            animCam.SetActive(false);
            menuControls.SetActive(true);
            bigButton.SetActive(false);
            bounceText.SetActive(false);
        }   
    }


    void Update()
    {
 
    }

    public void MenuBeginButton()
    {
        StartCoroutine(AnimCam());
    }


    public void StartGame()
    {
        // SceneManager.LoadScene(1);
        StartCoroutine(StartButton());
    }

    IEnumerator StartButton()
    {
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    IEnumerator AnimCam()
    {
        animCam.GetComponent<Animator>().Play("AnimMenuCam");
        bounceText.SetActive(false);
        bigButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControls.SetActive(true);
        hasClicked = true;
    }

    IEnumerator FadeInTurnOff()
    {
            yield return new WaitForSeconds(0.05f);
            loadedCoins = PlayerPrefs.GetInt("COINSAVE");
            loadedGems = PlayerPrefs.GetInt("GEMSAVE");
            loadedDistance = PlayerPrefs.GetInt("DISTANCESAVE");
            coinDisplay.GetComponent<TMPro.TMP_Text>().text = "" + loadedCoins;
            gemDisplay.GetComponent<TMPro.TMP_Text>().text = "" + loadedGems;
            distanceDisplay.GetComponent<TMPro.TMP_Text>().text = "" + loadedDistance;

        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }
}
