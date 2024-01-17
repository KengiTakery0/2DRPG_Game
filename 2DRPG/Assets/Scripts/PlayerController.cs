using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    public bool IsPaused { get; private set; }


    [SerializeField] float _speed;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _renderer;

    private PlayerInputActions _playerInput;

    private Vector2 moveDir;
    private float facingDir;

    private void Awake()
    {
        _playerInput = new PlayerInputActions();

        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _playerInput.UI.EnterPauseMenu.performed += ctx => EnterPauseMenu();
    }

    private void Update()
    {
        Input();
    }

    private void FixedUpdate()
    {
        FacingPlayer();
        Move();
    }

    private void Input()
    {
        moveDir = _playerInput.Player.Move.ReadValue<Vector2>();
        facingDir = _playerInput.Player.MouseFlip.ReadValue<float>();
        _animator.SetFloat("MoveX", moveDir.x);
        _animator.SetFloat("MoveY", moveDir.y);
    }
    private void Move()
    {
        /*    
          _rb.AddForce(moveDir,ForceMode2D.Impulse);
          _rb.AddForce(moveDir,ForceMode2D.Force);*/
        //_rb.velocity = new Vector2();
        _rb.MovePosition(_rb.position + (moveDir * _speed) * Time.deltaTime);

    }

    private void FacingPlayer()
    {
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (facingDir < playerScreenPos.x)
        {
            _renderer.flipX = true;
          
        }
        else
        {
            _renderer.flipX = false;
        }
    }

    private void EnterPauseMenu()
    {
        if (IsPaused)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
        else
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }
    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
