using System.Collections;
using UnityEngine;

public class EnemyBulletSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip[] audioClips = null;
    [SerializeField] private float soundCooldown = 2f;

    private bool canPlaySound = true;

    private void Update()
    {
        if (canPlaySound)
        {
            audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            canPlaySound = false;
            StartCoroutine(SoundCooldown());
        }
    }

    private IEnumerator SoundCooldown()
    {
        yield return new WaitForSeconds(soundCooldown);
        canPlaySound = true;
    }
}
