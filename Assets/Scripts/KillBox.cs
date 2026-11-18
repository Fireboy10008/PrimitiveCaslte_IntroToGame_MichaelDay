using UnityEngine;

/// <summary>
/// KillBox script: Teleports a CharacterController-based player to a respawn point.
/// </summary>
public class KillBox : MonoBehaviour
{
    [Tooltip("The Transform where the player will respawn.")]
    public Transform respawnPoint;

    [Tooltip("Tag assigned to the player GameObject.")]
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
            return;

        if (respawnPoint == null)
        {
            Debug.LogWarning("Respawn point not set on KillBox.");
            return;
        }

        // Get CharacterController if present
        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            // Disable controller to allow manual position change
            controller.enabled = false;

            // Teleport player
            other.transform.position = respawnPoint.position;
            other.transform.rotation = respawnPoint.rotation;

            // Re-enable controller
            controller.enabled = true;
        }
        else
        {
            // No CharacterController — just move transform
            other.transform.position = respawnPoint.position;
            other.transform.rotation = respawnPoint.rotation;
        }
    }
}
