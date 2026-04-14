using UnityEngine;
using UnityEngine.SceneManagement;
 
public class EndingScreen : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);

    }
 
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}