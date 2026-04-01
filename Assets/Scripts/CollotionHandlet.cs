using UnityEngine;
using UnityEngine.SceneManagement;

public class CollotionHandlet : MonoBehaviour
{
private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is looking good");
                break;
            case "Finish":
                Debug.Log("You win");
                break;
            case "Fuel":
                Debug.Log("You get fuel");
                break;
            default:
                ReloadLevel();
                break;
        }

        void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
