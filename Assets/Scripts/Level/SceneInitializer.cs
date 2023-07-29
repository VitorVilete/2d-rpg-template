using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    // At Start, will cycle through all scene dependencies and load them.
    // When it finishes, will invoke the "onDependenciesLoaded" event if a method is bound to it.

    [Header("Dependencies")]
    public SceneSO[] sceneDependencies;

    [Header("On Scene Ready")]
    public UnityEvent onDependenciesLoaded;

    private void Start()
    {
        StartCoroutine(LoadDependencies());
    }

    private IEnumerator LoadDependencies()
    {
        for (int i = 0; i <= this.sceneDependencies.Length - 1; i++)
        {
            SceneSO sceneToLoad = this.sceneDependencies[i];
            if (SceneManager.GetSceneByName(sceneToLoad.name).isLoaded == false) 
            {
                // Loads a scene without closing the current one(additive form).
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneToLoad.name, LoadSceneMode.Additive);
                while (loadOperation.isDone == false)
                {
                    yield return null;
                }
            }
        }


        if(onDependenciesLoaded != null)
        {
            onDependenciesLoaded.Invoke();
        }
    }
}
