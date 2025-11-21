using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    public float boostedJumpForce = 25f;

    public bool hasJumpBoost = false;

    private playerMovement movementScript;
    private float originalJumpSpeed;

    void Start()
    {
        movementScript = GetComponent<playerMovement>();

        originalJumpSpeed = movementScript.jumpSpeed;
    }

    public void ApplyJumpBoost(float duration)
    {
        if (!hasJumpBoost)
        {
            hasJumpBoost = true;
            movementScript.jumpSpeed = boostedJumpForce;
            StartCoroutine(RemoveJumpBoostAfter(duration));
            Debug.Log("Jump boost picked up");
        }
    }

    private System.Collections.IEnumerator RemoveJumpBoostAfter(float duration)
    {
        yield return new WaitForSeconds(duration);

        movementScript.jumpSpeed = originalJumpSpeed;
        hasJumpBoost = false;

        if (hasJumpBoost == false)
        {
            Debug.Log("Jump Boost has ended");
        }
    }
}
