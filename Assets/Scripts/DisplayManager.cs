using TMPro;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text killsText = null;
    [SerializeField] private TMP_Text healthText = null;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        killsText.text = player.GetKillCount().ToString();
        healthText.text = player.GetHealth().ToString();
    }
}
