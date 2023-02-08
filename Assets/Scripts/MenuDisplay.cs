using UnityEngine;
using TMPro;

public class MenuDisplay : MonoBehaviour
{
    [SerializeField] private GameObject menuDisplay = null;
    [SerializeField] private TMP_Text highScoreText = null;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScoreText.text = $"Highscore: {PlayerPrefs.GetInt("highscore")}";
        }

        if (player.GetIsGameOver()) { return; }
            
        menuDisplay.SetActive(false);
    }

}
