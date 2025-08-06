using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image characterImage;
    public Button arrowButton;

    // public CharacterDataList characterList;

    //     TextAsset jsonFile = Resources.Load<TextAsset>("Data/characters");
    //     CharacterDataList list = JsonUtility.FromJson<CharacterDataList>(jsonFile.text);
    //     CharacterData[] characterList = list.characters;

    //     Debug.Log(list);
    //     Debug.Log($"Personajes cargados: {characterList.Length}");

    void Awake()
    {
        string path = Application.streamingAssetsPath + "/Data/characters.json";

        Debug.Log(path);

        string json = File.ReadAllText(path);
        CharacterDataList characterList = JsonUtility.FromJson<CharacterDataList>(json);

        foreach (var character in characterList.characters)
        {
            Debug.Log($"Nombre: {character.name}, Vida: {character.life}, Velocidad: {character.speed}");
        }

        string fullPath = Path.Combine(Application.streamingAssetsPath, characterList.characters[0].pathSprite);
        byte[] imageData = File.ReadAllBytes(fullPath);

        Texture2D tex = new(2, 2);
        tex.LoadImage(imageData);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);

        characterImage.sprite = sprite;
        // Resources.Load<Sprite>(characterList.characters[0].pathSprite);
    }

    void Start()
    {
        // Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Player");

        // characterImage.sprite = sprites[0];
        // arrowButton.onClick.AddListener(() =>
        // {
        //     Debug.Log(sprites[0]);
        //     characterImage.sprite = sprites[3];

        // });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
