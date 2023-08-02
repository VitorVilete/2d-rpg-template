using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour
{
    [Header("Broadcasting on channels")]
    public FloatGameEvent TimeChangedEvent;

    public void GamePauseEvent()
    {
        TimeChangedEvent.Raise(0);
    }

    public void GameResumeEvent()
    {
        TimeChangedEvent.Raise(1);
    }
}
