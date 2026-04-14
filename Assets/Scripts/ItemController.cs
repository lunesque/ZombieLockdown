using System;
using UnityEngine;
using UnityEngine.Assertions;

public class ItemController : TriggerController
{
    private static readonly int INVALID_ID = 0;

    [SerializeField] private GameObject m_Item;
    [SerializeField] private EndingScreen m_EndingScreen;
    [SerializeField] private AudioClip m_ItemSound;
    private AudioSource m_AudioSource;
    public int UniqueID { get; private set; } = INVALID_ID;

    private void Awake()
    {
        Assert.IsNotNull(m_Item, "Please assign a valid GameObject to the item member.");

        UniqueID = m_Item.GetInstanceID();
        m_AudioSource = GetComponent<AudioSource>();
    }

    protected override void Interact()
    {
        PickItem();
        if (m_EndingScreen) m_EndingScreen.Show();

        CanInteract = false;
    }

    private void PickItem()
    {
        InventorySystem.Instance.StoreItem(UniqueID);
        m_AudioSource.clip = m_ItemSound;
        m_AudioSource.Play();
        
        DisableInteraction();
        
        m_Item.SetActive(false);
    }
}