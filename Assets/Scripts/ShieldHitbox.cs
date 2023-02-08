using UnityEngine;

public class ShieldHitbox : MonoBehaviour
{
    [SerializeField] private Collider shieldHitbox = null;
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip hitAudio = null;
    [SerializeField] private AudioClip blockedAudio = null;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.DestroySelf();
            TakeDamage();
            return;
        }

        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            // Verify only hot and cold tags
            if (!other.CompareTag(shieldHitbox.tag))
            {
                TakeDamage();
            } else
            {
                audioSource.SetScheduledStartTime(0);
                audioSource.PlayOneShot(blockedAudio, 2f);
            }

            bullet.DestroySelf();
        }
    }

    private void TakeDamage()
    {
        int oldHealth = player.GetHealth();
        player.SetHealth(oldHealth - 1);
        audioSource.SetScheduledStartTime(1.2f);
        audioSource.PlayOneShot(hitAudio);
    }
}
