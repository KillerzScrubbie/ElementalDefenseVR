using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShieldController : MonoBehaviour
{
    private ActionBasedController controller;
    private Shield shield;
    private bool initialize = true;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.selectAction.action.performed += ChangeShieldTrigger;
    }

    private void Update()
    {
        if (initialize)
        {
            shield = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Shield>();
            initialize = false;
        }
    }

    private void ChangeShieldTrigger(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    { 
        shield.ChangeShield();
    }
}
