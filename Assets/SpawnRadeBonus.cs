using System.Collections.Generic;
using UnityEngine;

public class SpawnRadeBonus : MonoBehaviour
{
    static public List<SpawnRadeBonus> m_SpawnRadeBonusList = new();
    void Start()
    {
        List<int> indexNull = new();
        for (int i = 0;i< m_SpawnRadeBonusList.Count;i++)
        {
            if (m_SpawnRadeBonusList[i] == null)
            {
                indexNull.Add(i);
            }
        }
        for (int i = 0; i < indexNull.Count; i++)
        {
            m_SpawnRadeBonusList.Remove(null);
        }
        m_SpawnRadeBonusList.Add(this);
    }
    void OnDestroy()
    {
        List<int> indexNull = new();
        for (int i = 0; i < m_SpawnRadeBonusList.Count; i++)
        {
            if (m_SpawnRadeBonusList[i] == null)
            {
                indexNull.Add(i);
            }
        }
        for (int i = 0; i < indexNull.Count; i++)
        {
            m_SpawnRadeBonusList.Remove(null);
        }
    }
}
