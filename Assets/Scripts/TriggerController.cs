using StarterAssets;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class TriggerController : MonoBehaviour
{
    private static readonly string PLAYER_TAG = "Player";
    
    //private static readonly string INTERACT_ACTION = "Interact";

    private StarterAssetsInputs m_Input;

    public bool CanInteract { get; protected set; } = true;
    
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(PLAYER_TAG)) return;

        if (m_Input == null) 
        {
            m_Input = other.GetComponent<StarterAssetsInputs>();
        }
            

        Assert.IsNotNull(m_Input, "StarterAssetsInputs not found on Player.");

        if (m_Input.interact && CanInteract)
        {
            m_Input.interact = false;
            Interact();
        }
    }
    
    protected virtual void Interact() 
    {
    }

    protected void DisableInteraction()
    {
        CanInteract = false;
    }
    
}