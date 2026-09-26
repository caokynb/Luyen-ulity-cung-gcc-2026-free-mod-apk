using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathEvent : MonoBehaviour
{
    public void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
