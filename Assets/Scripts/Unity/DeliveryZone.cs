using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerStay(Collider other)
    {
        PlayerInteraction player = other.GetComponent<PlayerInteraction>();

        if (player != null && player.HasHostage() && Input.GetKeyDown(KeyCode.F))
        {
            player.DeliverHostage();

            if (gameManager != null)
            {
                gameManager.HostageDelivered();
            }
        }
    }
}