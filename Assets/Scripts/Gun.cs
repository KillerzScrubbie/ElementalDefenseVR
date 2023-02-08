using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject hotGun = null;
    [SerializeField] private GameObject coldGun = null;
    [SerializeField] private bool hotGunStatus = true;

    [SerializeField] private float bulletSpeed = 40;
    [SerializeField] private GameObject hotBulletPrefab = null;
    [SerializeField] private GameObject coldBulletPrefab = null;
    [SerializeField] private Transform barrel = null;
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioClip audioClip = null;
    [SerializeField] private float gunCooldown = 0.3f;

    private bool canShoot = true;

    private void Update()
    {
        SwapGun();
    }

    public void ChangeGun()
    {
        hotGunStatus = !hotGunStatus;
    }

    private void SwapGun()
    {
        hotGun.SetActive(hotGunStatus);
        coldGun.SetActive(!hotGunStatus);
    }

    public void Fire()
    {
        if (canShoot) 
        {
            GameObject spawnedBullet = (hotGunStatus) ? Instantiate(hotBulletPrefab, barrel.position, barrel.rotation) :  Instantiate(coldBulletPrefab, barrel.position, barrel.rotation);

            spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpeed * barrel.forward;
            audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, 4);
            canShoot = false;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(gunCooldown);
        canShoot = true;
    }
}
