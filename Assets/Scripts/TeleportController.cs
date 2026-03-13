using UnityEngine;
 
public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject m_Destination;
    private CharacterController m_CharacterController;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_CharacterController = other.GetComponent<CharacterController>();
            if (m_CharacterController != null) m_CharacterController.enabled = false;
 
            other.transform.SetPositionAndRotation(
                m_Destination.transform.position,
                m_Destination.transform.rotation
            );
            
            if (m_CharacterController != null) m_CharacterController.enabled = true;
        }
    }
}