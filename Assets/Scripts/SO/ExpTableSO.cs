using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpTableSO", menuName = "SO/ExpTable")]
public class ExpTableSO : ScriptableObject
{
    public List<int> expPerLevel;

    public int GetExpForLevel(int level)
    {
        if (level <= 0 || level > expPerLevel.Count)
            return int.MaxValue; 

        return expPerLevel[level - 1];
    }
}
