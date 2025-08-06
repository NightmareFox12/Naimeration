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
    void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("CreateCharacter");
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

    // Update is called once per frame
    void Update()
    {

    }
}
