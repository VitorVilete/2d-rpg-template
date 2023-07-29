
using ScriptableObjectArchitecture;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LoadingScreenUI : MonoBehaviour
{
    [Header("Broadcasting on channels")]
    public BoolGameEvent loadingScreenToggled;

    [Header("Private Dependencies")]
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Function will be called from SceneLoaderManager
    public void ToggleScreen(bool enable)
    {
        if (enable)
        {
            animator.SetTrigger("Show");
        }
        else
        {
            animator.SetTrigger("Hide");
        }
    }

    // Function will be called from Animator at the end of the animation clip
    public void SendLoadingScreenShownEvent()
    {
        loadingScreenToggled.Raise(true);
    }

    // Function will be called from Animator at the end of the animation clip
    public void SendLoadingScreenHiddenEvent()
    {
        loadingScreenToggled.Raise(false);
    }
}
