using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Bullet bullet))
        {
            bullet.DestroySelf();
            player.ResetPlayer();
        }
    }
}
