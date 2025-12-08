using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TitleLoadLevel : MonoBehaviour
{
    private InputAction spaceAction;

    private void OnEnable()
    {
        spaceAction = new InputAction(binding: "<Keyboard>/space");
        spaceAction.Enable();
        spaceAction.performed += OnSpacePressed;
    }

    private void OnDisable()
    {
        spaceAction.performed -= OnSpacePressed;
        spaceAction.Disable();
    }

    private void OnSpacePressed(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene("FP_Level 1");
    }
}
