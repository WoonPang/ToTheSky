using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    public Text timeText;
    private float playTime = 0f;
    private bool isTracking = true;

    void Update()
    {
        if (!isTracking) return;

        playTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(playTime / 60f);
        int seconds = Mathf.FloorToInt(playTime % 60f);
        int hundredths = Mathf.FloorToInt((playTime % 1f) * 100);

        timeText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }

    public void StopTimer()
    {
        isTracking = false;
        Debug.Log("플레이 타임 종료: " + timeText.text);
    }

    public float GetTime()
    {
        return playTime;
    }
}