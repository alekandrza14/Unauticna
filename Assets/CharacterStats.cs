using UnityEngine;
[System.Serializable]
public class CharacterStatsData
{
    public int IQ = 20;
    public string[] nameAdditionalVaribles;
    public string[] varibleAdditionalVaribles;
}
public class CharacterStats : MonoBehaviour
{
    public CharacterStatsData data = new();
}
