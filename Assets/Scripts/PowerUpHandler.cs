using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    public float boostedJumpForce = 25f;
    public float boostedSpeed = 20f;

    public bool hasJumpBoost = false;
    public bool hasSpeedBoost = false;

    playerMovement movementScript;
    playerMovement speedScript;
    private float originalJumpSpeed;
    private float originalMoveSpeed;

    void Start()
    {
        movementScript = GetComponent<playerMovement>();
        speedScript = GetComponent<playerMovement>();

        originalJumpSpeed = movementScript.jumpSpeed;
        originalMoveSpeed = speedScript.moveSpeed;
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

        public void ApplySpeedBoost(float duration)
    {
        if (!hasSpeedBoost)
        {
            hasSpeedBoost = true;
            speedScript.moveSpeed = boostedSpeed;
            StartCoroutine(RemoveSpeedBoostAfter(duration));
            Debug.Log("Speed boost picked up");
        }
    }

    System.Collections.IEnumerator RemoveJumpBoostAfter(float duration)
    {
        yield return new WaitForSeconds(duration);

        movementScript.jumpSpeed = originalJumpSpeed;
        hasJumpBoost = false;

        if (hasJumpBoost == false)
        {
            Debug.Log("Jump Boost has ended");
        }
    }

        System.Collections.IEnumerator RemoveSpeedBoostAfter(float duration)
    {
        yield return new WaitForSeconds(duration);

        movementScript.jumpSpeed = originalJumpSpeed;
        hasJumpBoost = false;

        if (hasJumpBoost == false)
        {
            Debug.Log("Speed Boost has ended");
        }
    }
}
