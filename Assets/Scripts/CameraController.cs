using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private PlayerInput m_PlayerInput;
    [SerializeField] private CharacterController m_PlayerController;
    private StarterAssetsInputs m_Inputs;
    public GameObject CinemachineCameraTarget;
    
    private float _rotationVelocity;
    private const float _threshold = 0.01f;
    private float _cinemachineTargetPitch;
    
    public float RotationSpeed = 1.0f;
    
    private void Start()
    {
        m_Inputs = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM
        m_PlayerInput = GetComponent<PlayerInput>();
#endif
        // m_SwitchAction.performed += OnSwitchActionPerformed;
    }

    private void Update()
    {
        m_PlayerController.transform.Rotate(Vector3.up * _rotationVelocity);
    }
    
    private void CameraRotation()
    {
        // if there is an input
        if (m_Inputs.look.sqrMagnitude >= _threshold)
        {
            _cinemachineTargetPitch += m_Inputs.look.y * RotationSpeed * Time.deltaTime;
            _rotationVelocity = m_Inputs.look.x * RotationSpeed * Time.deltaTime;

            // clamp our pitch rotation
            // _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Update Cinemachine camera target pitch
            CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
            m_PlayerController.transform.Rotate(Vector3.up * _rotationVelocity);
        }
    }
}
