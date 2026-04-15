using OscJack;
using UnityEngine;
using StarterAssets;
using UnityEngine.Video;

public class IntroScreen : MonoBehaviour
{
    [SerializeField] private GameObject m_PlayerCapsule;
    [SerializeField] private GameObject  m_VideoPlayer;

    private StarterAssetsInputs m_Input;
    private OscClient m_OSCClient;


    private void Start()
    {
        m_Input = m_PlayerCapsule.GetComponent<StarterAssetsInputs>();
        m_OSCClient = new OscClient("127.0.0.1", 9000);
        m_OSCClient.Send("/fullscreen", 1);
    }

    private void Update()
    {
        if (m_Input.interact)
        {
            m_Input.interact = false;
            m_VideoPlayer.SetActive(true);
            Invoke(nameof(DisableSelf), 0.8f);
        }
    }

    private void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}