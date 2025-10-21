using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
