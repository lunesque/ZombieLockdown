using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController Instance { get; private set; }

    private RoomTrigger m_ActiveRoom;

    private void Start()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    public void SetActiveRoom(RoomTrigger newRoom)
    {
        if (newRoom == m_ActiveRoom) return;

        if (m_ActiveRoom != null)
            m_ActiveRoom.HideRoom();

        m_ActiveRoom = newRoom;
        m_ActiveRoom.ShowRoom();
    }
}