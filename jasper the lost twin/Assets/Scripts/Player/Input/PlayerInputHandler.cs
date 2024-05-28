using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;
    public Vector2 MovementInput { get; set; }
    public Vector2 RawDashDirectionInput { get; set; }
    public Vector2Int DashDirectionInput { get; set; }
    public int InputX { get; set; }
    public int InputY { get; set; }
    [SerializeField] private float inputHoldTime = 0.2f;
    private float jumpInputStartTime;
    private float dashInputStartTime;
    public bool JumpInput { get; set; }
    public bool JumpInputStop { get; set; }
    public bool PrimaryAttackInput { get; set; }
    public bool DashInput { get; set; }
    public bool DashInputStop { get; set; }


    public void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }


    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PrimaryAttackInput = true;
        }

        if (context.canceled)
        {
            PrimaryAttackInput = false;
        }
    }

    public void OnEscapeInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PauseMenuManager.Instance?.TogglePauseMenu();
        }
    }


    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void OnDashDirection(InputAction.CallbackContext context)
    {
        RawDashDirectionInput = context.ReadValue<Vector2>();
        if (playerInput.currentControlScheme == "Keyboard")
        {
            RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;
        }

        DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        InputX = (int)MovementInput.x;
        InputY = (int)MovementInput.y;
    }

    protected void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }


    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;


    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if (Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
}