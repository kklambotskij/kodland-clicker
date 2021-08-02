using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene(1);
    }
    
}
