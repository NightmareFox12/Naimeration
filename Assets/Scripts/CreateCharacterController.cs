using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateCharacterController : MonoBehaviour
{
    public Button buttonBack;
    public Image characterImage;
    public Button buttonLeft;
    public Button buttonRight;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI speedText;
    public Button buttonSelect;
    public SceneFader sceneFader;

    // string path = Application.streamingAssetsPath + "/Data/characters.json";

    // Debug.Log(path);

    // string json = File.ReadAllText(path);
    // CharacterDataList characterList = JsonUtility.FromJson<CharacterDataList>(json);

    // foreach (var character in characterList.characters)
    // {
    //     Debug.Log($"Nombre: {character.name}, Vida: {character.life}, Velocidad: {character.speed}");
    // }

    // string fullPath = Path.Combine(Application.streamingAssetsPath, characterList.characters[0].pathSprite);
    // byte[] imageData = File.ReadAllBytes(fullPath);

    // Texture2D tex = new(2, 2);
    // tex.LoadImage(imageData);
    // Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);
    // characterImage.sprite = sprite;


    //private vars
    private CharacterDataList characterList;
    private int nextCharacterID = 0;

    void Awake()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/characters");
        characterList = JsonUtility.FromJson<CharacterDataList>(jsonFile.text);

        //Load First character
        CharacterData firstCharacter = characterList.characters[0];
        characterImage.sprite = Resources.Load<Sprite>(firstCharacter.pathSprite);
        nameText.text = firstCharacter.name;
        lifeText.text = firstCharacter.life.ToString();
        speedText.text = firstCharacter.speed.ToString();

        buttonLeft.onClick.AddListener(() =>
        {
            ChangeCharacter(true);
        });
        buttonRight.onClick.AddListener(() =>
        {
            ChangeCharacter(false);
        });
        buttonBack.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("MainMenu");
        });
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSelect.onClick.AddListener(() =>
        {
            StartCoroutine(ChangeScene());
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeCharacter(bool leftPressed)
    {
        if (leftPressed)
        {
            nextCharacterID = nextCharacterID > 0 ? nextCharacterID - 1 : characterList.characters.Length - 1;
        }
        else
        {
            nextCharacterID = nextCharacterID < characterList.characters.Length - 1 ? nextCharacterID + 1 : 0;
        }

        CharacterData currentCharacter = characterList.characters[nextCharacterID];

        characterImage.sprite = Resources.Load<Sprite>(currentCharacter.pathSprite);
        nameText.text = currentCharacter.name;
        lifeText.text = currentCharacter.life.ToString();
        speedText.text = currentCharacter.speed.ToString();
    }

    private IEnumerator ChangeScene()
    {
        yield return StartCoroutine(sceneFader.FadeOutCoroutine(1));
        GameManager.Instance.playerSelected = characterList.characters[nextCharacterID];
        SceneManager.LoadSceneAsync("Level1");
    }

}
