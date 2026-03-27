using UnityEngine;
using StarterAssets;

/// <summary>
/// SETUP:
///   1. Create an empty GameObject in your scene called "OSCBridge"
///   2. Attach this script to it
///   3. Assign the PlayerCapsule to the "Player Capsule" field
///   4. Point OSCQuery Root Object to "OSCBridge" with no filters needed
///
/// Chataigne will see and control:
///   - /OSCBridge/OSCBridge/interact  (bool)
///   - /OSCBridge/OSCBridge/look      (Vector2)
/// </summary>
public class OSCBridge : MonoBehaviour
{
    [SerializeField] private GameObject m_PlayerCapsule;

    // These are the only fields OSCQuery will see and expose to Chataigne
    public bool interact;
    public Vector2 look;
    public Vector2 move;

    private StarterAssetsInputs m_Input;

    private void Start()
    {
        m_Input = m_PlayerCapsule.GetComponent<StarterAssetsInputs>();

        if (m_Input == null)
            Debug.LogError("[OSCBridge] StarterAssetsInputs not found on PlayerCapsule!", this);
    }

    private void Update()
    {
        if (!m_Input == null) return;

        // Push OSCQuery values into the actual StarterAssetsInputs each frame
        m_Input.look    = look;
        m_Input.interact = interact;
        m_Input.move = move;
    }
}