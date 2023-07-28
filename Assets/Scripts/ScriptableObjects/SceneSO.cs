using UnityEngine;

[CreateAssetMenu(fileName ="NewScene", menuName = "ScriptableObjects/Scene")]
public class SceneSO : ScriptableObject
{
    [Header("SceneInformation")]
    public string sceneName;
}
