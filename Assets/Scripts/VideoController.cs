using OscJack;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer m_VideoPlayer;
    private OscClient m_OSCClient;

    void Start()
    {
        m_VideoPlayer = GetComponent<VideoPlayer>();
        m_VideoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video has finished playing!");

        gameObject.SetActive(false);
        m_OSCClient = new OscClient("127.0.0.1", 9000);
        m_OSCClient.Send("/classroom", 1);
    }
}