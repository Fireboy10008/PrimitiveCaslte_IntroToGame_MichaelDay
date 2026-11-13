using UnityEngine;
using UnityEngine.Playables; // Required for PlayableDirector

public class TimelineTrigger : MonoBehaviour
{
    [Header("Timeline Setup")]
    [Tooltip("The Playable Director component that controls your Timeline.")]
    public PlayableDirector playableDirector;

    [Header("Trigger Settings")]
    [Tooltip("If checked, the timeline will play when something enters this object's 3D trigger collider.")]
    public bool triggerOnCollision = true;

    [Tooltip("The tag required to trigger the timeline (e.g., 'Player'). Leave empty to allow any object.")]
    public string targetTag = "Player";

    public void PlayTimeline()
    {
        if (playableDirector != null)
        {
            // Only play if it's not already running
            if (playableDirector.state != PlayState.Playing)
            {
                playableDirector.Play();
            }
        }
        else
        {
            Debug.LogWarning($"PlayableDirector is missing on {gameObject.name}!", this);
        }
    }

    public void PauseTimeline()
    {
        if (playableDirector != null && playableDirector.state == PlayState.Playing)
        {
            playableDirector.Pause();
        }
    }

    public void StopTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Stop();
        }
    }

    // 3D Collision Detection
    private void OnTriggerEnter(Collider other)
    {
        if (!triggerOnCollision) return;

        // Check if the entering object has the required tag
        if (string.IsNullOrEmpty(targetTag) || other.CompareTag(targetTag))
        {
            PlayTimeline();
        }
    }
}
