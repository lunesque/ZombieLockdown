using OscJack;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class EndingScreen : MonoBehaviour
{
    private string m_OSCAddress = "/no-blood";
    [SerializeField] private string m_OSCHost = "127.0.0.1";
    [SerializeField] private int m_OSCPort = 9000;
 
    private OscClient m_OSCClient;
    
    private void Awake()
    {
        m_OSCClient = new OscClient(m_OSCHost, m_OSCPort);
    }
    public void Show()
    {
        gameObject.SetActive(true);
        m_OSCClient.Send(m_OSCAddress, 1);
    }
 
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}