using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Load next scene
    void Start() => UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
}
