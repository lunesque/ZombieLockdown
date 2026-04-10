using OscJack;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private string m_OSCAddress = "/room";
    [SerializeField] private string m_OSCHost = "127.0.0.1";
    [SerializeField] private int m_OSCPort = 9000;
 
    private OscClient m_OSCClient;
 
    private void Awake()
    {
        m_OSCClient = new OscClient(m_OSCHost, m_OSCPort);
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        m_OSCClient.Send(m_OSCAddress, 1);
    }

}