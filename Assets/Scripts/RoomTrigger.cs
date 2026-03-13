using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [Header("Assign these from the Room's children")]
    [SerializeField] private GameObject m_Ceiling;
    [SerializeField] private GameObject m_CeilingPlane;
    private RoomController m_RoomController;


    private void Start()
    {
        m_RoomController = GetComponent<RoomController>();
    }
    public void ShowRoom()
    {
        if (m_Ceiling)
        {
            m_Ceiling.SetActive(false);
        }

        if (m_CeilingPlane)
        {
            m_CeilingPlane.SetActive(true);
        }
    }
 
    public void HideRoom()
    {
        if (m_Ceiling)
        {
            m_Ceiling.SetActive(true);
        }

        if (m_CeilingPlane)
        {
            m_CeilingPlane.SetActive(false);
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        m_RoomController.SetActiveRoom(this);
    }
}