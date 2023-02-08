using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int kills = 0;
    [SerializeField] private GameObject menuDisplay = null;
    [SerializeField] private EnemySpawner[] spawners = null;

    private int health;
    private bool isGameOver = true;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health < 1 && !isGameOver)
        {
            isGameOver = true;
            menuDisplay.SetActive(true);

            if (PlayerPrefs.HasKey("highscore"))
            {  
                int highscore = PlayerPrefs.GetInt("highscore");
                if (highscore < kills)
                {
                    PlayerPrefs.SetInt("highscore", kills);
                    PlayerPrefs.Save();
                }    
            } 
            else
            {
                PlayerPrefs.SetInt("highscore", kills);
                PlayerPrefs.Save();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            bullet.DestroySelf();
            health -= 1;
        }
        
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.DestroySelf();
            health = 0;
        }
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public int GetHealth() => health;

    public void AddKillCount()
    {
        kills += 1;
    }

    public int GetKillCount() => kills;

    public void ResetPlayer()
    {
        kills = 0;
        health = maxHealth;
        isGameOver = false;
        foreach(var spawner in spawners)
        {
            spawner.ResetSpawner();
        }
    }

    public bool GetIsGameOver() => isGameOver;
}
