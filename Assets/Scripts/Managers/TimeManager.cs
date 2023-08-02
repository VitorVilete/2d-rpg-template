using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void OnSetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
