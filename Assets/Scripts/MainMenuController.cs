using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //public objects
    public Button playButton;
    public Button statsButton;
    public Button optionsButton;
    public Button quitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        playButton.onClick.AddListener(() =>
    {
        SceneManager.LoadSceneAsync("CreateCharacter");
    });

        statsButton.onClick.AddListener(() =>
        {
            Debug.Log("play!");
        });

        optionsButton.onClick.AddListener(() =>
        {
            Debug.Log("play!");
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}