using UnityEngine;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor;
[CreateAssetMenu(fileName = "HeroDatabase", menuName = "SO/HeroDatabase")]
public class HeroDatabase : ScriptableObject
{
    public static HeroDatabase Instance => _instance ??= Resources.Load<HeroDatabase>("SO/HeroDatabase/HeroDatabase");
    private static HeroDatabase _instance;

    public List<HeroSO> heroes;

    public HeroSO GetHeroSO(string id)
    {
        return heroes.Find(hero => hero.heroId == id);
    }
    #if UNITY_EDITOR
    [ContextMenu("Reset Hero List")]
    public void ResetHeroList()
    {
        heroes.Clear();

        // Load all HeroSO in the project (including subfolders)
        string[] guids = AssetDatabase.FindAssets("t:HeroSO");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            HeroSO hero = AssetDatabase.LoadAssetAtPath<HeroSO>(path);
            if (hero != null)
            {
                heroes.Add(hero);
            }
        }

        EditorUtility.SetDirty(this); // Mark the asset dirty so it can be saved
        AssetDatabase.SaveAssets();   // Save the change

        Debug.Log($"HeroDatabase Reset: Loaded {heroes.Count} heroes.");
    }
#endif
}
