using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image characterImage;
    public Button buttonLeft;
    public Button buttonRight;

    public TextMeshProUGUI characterName;

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
        Debug.Log(jsonFile);

        characterList = JsonUtility.FromJson<CharacterDataList>(jsonFile.text);

        //Load First character
        CharacterData firstCharacter = characterList.characters[0];
        characterImage.sprite = Resources.Load<Sprite>(firstCharacter.pathSprite);
        characterName.text = firstCharacter.name;

        buttonLeft.onClick.AddListener(() =>
        {
            ChangeCharacter(true);
        });

        buttonRight.onClick.AddListener(() =>
        {
            ChangeCharacter(false);
        });

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
        characterName.text = currentCharacter.name;
    }

    void Start()
    {
        // Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Player");

        // characterImage.sprite = sprites[0];

    }

    // Update is called once per frame
    void Update()
    {

    }
}
