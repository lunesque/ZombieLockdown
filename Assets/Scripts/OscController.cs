using UnityEngine;

public class OscController : MonoBehaviour
{
    [SerializeField] private GameObject m_Object;

    void Start()
    {
        
    }
    
    void Update()
    {
        m_Object.transform.rotation = Quaternion.Euler(m_Object.transform.eulerAngles.x, m_Object.transform.eulerAngles.y, m_Object.transform.eulerAngles.z);
    }
}
