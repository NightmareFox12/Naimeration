[System.Serializable]
public class CharacterData
{
  public string name;
  public int life;
  public float speed;
  public string pathSprite;
}

[System.Serializable]
public class CharacterDataList
{
  public CharacterData[] characters;
}
