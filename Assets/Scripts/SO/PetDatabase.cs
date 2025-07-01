using UnityEngine;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor;
[CreateAssetMenu(fileName = "PetDatabase", menuName = "SO/PetDatabase")]
public class PetDatabase : ScriptableObject
{
    public static PetDatabase Instance => _instance ??= Resources.Load<PetDatabase>("SO/PetDatabase/PetDatabase");
    private static PetDatabase _instance;

    public List<PetSO> pets;

    public PetSO GetPetSO(string id)
    {
        return pets.Find(pet => pet.idName == id);
    }
    #if UNITY_EDITOR
    [ContextMenu("Reset Pet List")]
    public void ResetHeroList()
    {
        pets.Clear();

        // Load all HeroSO in the project (including subfolders)
        string[] guids = AssetDatabase.FindAssets("t:PetSO");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            PetSO pet = AssetDatabase.LoadAssetAtPath<PetSO>(path);
            if (pet != null)
            {
                pets.Add(pet);
            }
        }

        EditorUtility.SetDirty(this); // Mark the asset dirty so it can be saved
        AssetDatabase.SaveAssets();   // Save the change

        Debug.Log($"PetDatabase Reset: Loaded {pets.Count} pets.");
    }
#endif
}
