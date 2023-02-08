using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunController : MonoBehaviour
{
    private ActionBasedController controller;
    private Gun gun;
    private bool initialize = true;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<ActionBasedController>();
        controller.selectAction.action.performed += ChangeGunTrigger;
        controller.activateAction.action.performed += ShootTrigger;
    }

    private void ShootTrigger(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        gun.Fire();
    }

    private void Update()
    {
        if (initialize)
        {
            gun = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Gun>();
            initialize = false;
        }
    }

    private void ChangeGunTrigger(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        gun.ChangeGun();
    }
}
