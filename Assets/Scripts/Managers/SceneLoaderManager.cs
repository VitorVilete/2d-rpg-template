using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    [Header("Dependencies")]
    public LoadingScreenUI LoadingScreenUI;

    private LoadSceneRequest pendingRequest;

    // will be called from a listener
    public void OnLoadMenuRequest(LoadSceneRequest request)
    {
        if (IsSceneAlreadyLoaded(request.scene) == false)
        {
            SceneManager.LoadScene(request.scene.sceneName);
        }
    }

    // will be called from a listener
    public void OnLoadLevelRequest(LoadSceneRequest request)
    {
        if (IsSceneAlreadyLoaded(request.scene))
        {
            //Level already loaded. Activate.
            ActivateLevel(request);
        }
        else
        {
            //Level is not loaded
            if (request.loadingScreen)
            {
                //if a loading screen is requested, show it and wait
                pendingRequest = request;
                LoadingScreenUI.ToggleScreen(true);
            }
            else
            {
                //no loading screen requested, load the scene
                StartCoroutine(ProcessLevelLoading(request));
            }

        }
    }

    // will be called from a listener
    public void OnLoadingScreenToggled(bool enabled)
    {
        if (enabled && pendingRequest != null) 
        {
            //When the loading screen is shown, this event will start a coroutine to load the new level
            StartCoroutine(ProcessLevelLoading(pendingRequest));
        }
    }

    private bool IsSceneAlreadyLoaded(SceneSO scene)
    {
        Scene loadedScene = SceneManager.GetSceneByName(scene.name);
        if (loadedScene != null && loadedScene.isLoaded)
            return true;
        else 
            return false;
    }

    private IEnumerator ProcessLevelLoading(LoadSceneRequest request)
    {
        if (request.scene != null)
        {
            var currentLoadedLevel = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentLoadedLevel);

        }
    }
}
