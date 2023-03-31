using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    public KeyCode restartKey = KeyCode.R;

    void Update()
    {
        if (Input.GetKeyDown(restartKey))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}