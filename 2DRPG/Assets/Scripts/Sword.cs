using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;
    private PlayerInputActions playerInput;
    private Animator animator;
    private void Awake()
    {
        playerInput = new PlayerInputActions();
        animator = GetComponent<Animator>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        playerController = GetComponentInParent<PlayerController>();
    }
    private void Start()
    {
        playerInput.Player.Atack.started += ctx => Atack();
    }
    private void Update()
    {
        FollowMouse();
    }

    private void Atack()
    {
        if (!playerController.IsPaused)
            animator.SetTrigger("Attack");
    }

    private void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (!playerController.IsPaused)
        {
            if (mousePos.x < playerScreenPos.x)
            {
                activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
            }
            else
            {
                activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
