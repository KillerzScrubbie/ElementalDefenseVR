using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy = null;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform bulletSpawnPoint = null;
    [SerializeField] private float minAttackTime = 0.5f;
    [SerializeField] private float maxAttackTime = 2f;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private AudioSource footstepSource = null;
    [SerializeField] private AudioSource shootSource = null;
    [SerializeField] private AudioClip footStepAudioClip = null;
    [SerializeField] private AudioClip shootAudioClip = null;

    private readonly float footstepCooldown = 2.5f;
    private float nextAttackTime = 1f;
    private bool canShoot = true;
    private bool canStep = true;
    private bool isKilled = false;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerTransform = GameObject.FindGameObjectWithTag("Target").transform;
    }

    void Update()
    {
        if (player.GetIsGameOver())
        {
            DestroySelf();
            return;
        }

        enemy.SetDestination(playerTransform.position);

        TryAttack();

        if (canStep) PlayFootstep();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            if (!other.gameObject.CompareTag(tag))
            {
                if (!isKilled)
                {
                    player.AddKillCount();
                    isKilled = true;
                }
                DestroySelf();
            }

            bullet.DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void TryAttack()
    {
        if (!canShoot) { return; }

        transform.LookAt(playerTransform);
        GameObject spawnedBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpeed * bulletSpawnPoint.forward;
        Destroy(spawnedBullet, 10f);
        shootSource.PlayOneShot(shootAudioClip);
        canShoot = false;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(nextAttackTime);
        nextAttackTime = Random.Range(minAttackTime, maxAttackTime);
        canShoot = true;
    }

    private void PlayFootstep()
    {
        footstepSource.PlayOneShot(footStepAudioClip);
        canStep = false;
        StartCoroutine(FootstepCooldown());
    }

    private IEnumerator FootstepCooldown()
    {
        yield return new WaitForSeconds(footstepCooldown);
        canStep = true;
    }
}
