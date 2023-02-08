using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private bool ownedByEnemy = false;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (player.GetIsGameOver())
        {
            if (!ownedByEnemy) { return; }

            DestroySelf();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
