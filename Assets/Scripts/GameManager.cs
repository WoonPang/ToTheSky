using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            GameObject.Find("UIManager").GetComponent<UIManager>().GameFinishUI();
            Debug.Log("∞‘¿” ≥°!");
            Time.timeScale = 0f;
        }
    }
}
