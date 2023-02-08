using UnityEngine;

public class QuitButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            bullet.DestroySelf();
            Application.Quit();
        }
    }
}
