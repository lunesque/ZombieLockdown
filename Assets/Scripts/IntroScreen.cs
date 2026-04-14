using UnityEngine;
using StarterAssets;

public class IntroScreen : MonoBehaviour
{
    [SerializeField] private GameObject m_PlayerCapsule;

    private StarterAssetsInputs m_Input;

    private void Start()
    {
        m_Input = m_PlayerCapsule.GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (m_Input.interact)
        {
            m_Input.interact = false;
            gameObject.SetActive(false);
        }
    }
}