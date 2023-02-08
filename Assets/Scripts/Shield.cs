using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject hotShield = null;
    [SerializeField] private GameObject coldShield = null;
    [SerializeField] private bool hotShieldStatus = true;

    private void Update()
    {
        SwapShield();
    }

    public void ChangeShield()
    {
        hotShieldStatus = !hotShieldStatus;
    }

    private void SwapShield()
    {
        if (hotShieldStatus) {
            hotShield.SetActive(hotShieldStatus);
            coldShield.SetActive(!hotShieldStatus); 
        } else
        {   
            coldShield.SetActive(!hotShieldStatus);
            hotShield.SetActive(hotShieldStatus);
        }
    }

}
