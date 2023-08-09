using ScriptableObjectArchitecture;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Configuration")]
    public string interactableTag;

    [Header("Broadcasting events")]
    public BoolGameEvent interactionRequestEvent;

    private Interactable interactable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(interactableTag))
        {
            var collidingInteractable = collision.GetComponent<Interactable>();
            interactable = collidingInteractable;
        }
        interactionRequestEvent.Raise((interactable != null));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(interactableTag))
        {
            interactable = null;
        }
        interactionRequestEvent.Raise((interactable != null));
    }

    public void EnableInteractable()
    {
        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}
