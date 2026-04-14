using UnityEngine;

public class AirDuctController : TriggerController
{
    [SerializeField] private ItemController m_ItemController;
    [SerializeField] private GameObject m_Destination;
    private CharacterController m_CharacterController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (m_ItemController != null)
            {
                if (!InventorySystem.Instance.HasItem(m_ItemController.UniqueID))
                {
                    UISystem.Instance.ShowPlayerWarning("Air duct is <b>screwed shut</b>. You need to find the <b>screwdriver</b>.");
                    return;
                }
            }

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