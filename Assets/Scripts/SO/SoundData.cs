using UnityEngine;

[CreateAssetMenu(fileName = "SoundData", menuName = "SO/SoundData")]
public class SoundData : ScriptableObject
{
    public string id;
    public AudioClip clip;
    public SoundType soundType;
    public bool loop;
}
