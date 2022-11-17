using UnityEngine;
public class LevelTimer : MonoBehaviour
{
    [SerializeField] private FloatVariable _levelTimerVariable;

    private bool _timerRunning = false;
    
    #region MonoBehaviour Methods
    private void Start()
    {
        Time.timeScale = 0.0f;
        _levelTimerVariable.Value = 0.0f;
        _timerRunning = true;
    }

    private void Update()
    {
        if (_timerRunning)
        {
            _levelTimerVariable.Value += Time.deltaTime;
        }
    }
    #endregion
    
    /// <summary>
    /// Stops the level timer.
    /// </summary>
    public void StopTimer()
    {
        _timerRunning = false;
    }
}
