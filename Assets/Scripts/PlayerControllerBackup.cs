 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using MidiJack;

namespace PianoRun.Player {

    [RequireComponent(typeof(CharacterController), typeof(PlayerInput))]

    public class PlayerControllerBackup : MonoBehaviour
    {
        [SerializeField]
        private float initialPlayerSpeed = 4f;
        [SerializeField]
        private float maximumPlayerSpeed = 30f;
        [SerializeField]
        private float playerSpeedIncreaseRate = .1f;
        [SerializeField]
        private float jumpHeight = 1.0f;
        [SerializeField]
        private float initialGravityValue = -9.81f;
        [SerializeField]
        private LayerMask groundLayer;
        [SerializeField]
        private LayerMask turnLayer;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private AnimationClip slideAnimationClip;

        private float playerSpeed;
        private float gravity;
        private Vector3 movementDirection = Vector3.forward;
        private Vector3 playerVelocity;

        private PlayerInput playerInput;
        private InputAction turnAction;
        private InputAction jumpAction;
        private InputAction slideAction;

        private CharacterController controller;

        private int slidingAnimationId;

        private bool sliding = false;

        [SerializeField]
        private UnityEvent<Vector3> turnEvent;

        float C1; // 48 -
        float Cs1; // 49
        float D1; // 50
        float Ds1; // 51
        float E1; // 52 -
        float F1; // 53
        float Fs1; // 54
        float G1; // 55 -
        float Gs1; // 56
        float A1; // 57
        float As1; // 58
        float B1; // 59

        float C2; // 60
        float Cs2; // 61
        float D2; // 62
        float Ds2; // 63
        float E2; // 64
        float F2; // 65
        float Fs2; // 66
        float G2; // 67
        float Gs2; // 68
        float A2; // 69
        float As2; // 70
        float B2; // 71

        float C3; // 72

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            controller = GetComponent<CharacterController>();

            slidingAnimationId = Animator.StringToHash("Sliding");

            turnAction = playerInput.actions["Turn"];
            jumpAction = playerInput.actions["Jump"];
            slideAction = playerInput.actions["Slide"];
        }

        private void OnEnable()
        {
            turnAction.performed += PlayerTurn;
            //slideAction.performed += PlayerSlide;
            //jumpAction.performed += PlayerJump;
        }

        private void OnDisable()
        {
            turnAction.performed -= PlayerTurn;
            //slideAction.performed -= PlayerSlide;
            //jumpAction.performed -= PlayerJump;
        }

        private void Start()
        {
            playerSpeed = initialPlayerSpeed;
            gravity = initialGravityValue;
        }

        private void PlayerTurn(InputAction.CallbackContext context)
        {
            Vector3? turnPosition = CheckTurn(context.ReadValue<float>());
            if (!turnPosition.HasValue)
            {
                return;
            }
            Vector3 targetDirection = Quaternion.AngleAxis(90 * context.ReadValue<float>(), Vector3.up) *
            movementDirection;
            turnEvent.Invoke(targetDirection);
            Turn(context.ReadValue<float>(), turnPosition.Value);
        }

        private Vector3? CheckTurn(float turnValue) // questionmark is called "nullable" and means that it can either be Vector3 or null.
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, .1f, turnLayer); // creates a sphere that checks if we are  overlapping with ant other colliders.
            if (hitColliders.Length != 0)
            {
                Tile tile = hitColliders[0].transform.parent.GetComponent<Tile>();
                TileType type = tile.type;
                if ((type == TileType.LEFT && turnValue == -1) ||
                   (type == TileType.RIGHT && turnValue == 1) ||
                   (type == TileType.SIDEWAYS))
                {
                    return tile.pivot.position;
                }
            }
            return null;
        }

        private void Turn(float turnValue, Vector3 turnPosition)
        {
            Vector3 tempPlayerPosition = new Vector3(turnPosition.x, transform.position.y, turnPosition.z);
            controller.enabled = false;
            transform.position = tempPlayerPosition;
            controller.enabled = true;

            Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 90 * turnValue, 0);
            transform.rotation = targetRotation;
            movementDirection = transform.forward.normalized;
        }

        /*
        private void PlayerSlide(InputAction.CallbackContext context)
        {
            if (!sliding && IsGrounded())
            {
                StartCoroutine(Slide());
            }
        }
        */

        private IEnumerator Slide()
        {
            sliding = true;
            // shrinks collider
            Vector3 originalControllerCenter = controller.center;
            Vector3 newControllerCenter = originalControllerCenter;
            controller.height /= 2;
            newControllerCenter.y -= controller.height / 2;
            controller.center = newControllerCenter;

            // plays slide animation
            animator.Play(slidingAnimationId);
            yield return new WaitForSeconds(slideAnimationClip.length);
            // sets the character controller collider back to normal after sliding
            controller.height *= 2;
            controller.center = originalControllerCenter;
            sliding = false;
        }

        /*
        private void PlayerJump(InputAction.CallbackContext context)
        {
            if (IsGrounded())
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * gravity * -3f);
                controller.Move(playerVelocity * Time.deltaTime);
            }
        }
        */

        private void Update()
        {
            C1 = MidiMaster.GetKey(48);
            Cs1 = MidiMaster.GetKey(49);
            D1 = MidiMaster.GetKey(50);
            Ds1 = MidiMaster.GetKey(51);
            E1 = MidiMaster.GetKey(52);
            F1 = MidiMaster.GetKey(53);
            Fs1 = MidiMaster.GetKey(54);
            G1 = MidiMaster.GetKey(55);
            Gs1 = MidiMaster.GetKey(56);
            A1 = MidiMaster.GetKey(57);
            As1 = MidiMaster.GetKey(58);
            B1 = MidiMaster.GetKey(59);

            C2 = MidiMaster.GetKey(60);
            Cs2 = MidiMaster.GetKey(61);
            D2 = MidiMaster.GetKey(62);
            Ds2 = MidiMaster.GetKey(63);
            E2 = MidiMaster.GetKey(64);
            F2 = MidiMaster.GetKey(65);
            Fs2 = MidiMaster.GetKey(66);
            G2 = MidiMaster.GetKey(67);
            Gs2 = MidiMaster.GetKey(68);
            A2 = MidiMaster.GetKey(69);
            As2 = MidiMaster.GetKey(70);
            B2 = MidiMaster.GetKey(71);

            C3 = MidiMaster.GetKey(72);

            controller.Move(transform.forward * playerSpeed * Time.deltaTime);

            if (IsGrounded() && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            playerVelocity.y += gravity * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            if (playerSpeed < maximumPlayerSpeed)
            {
                playerSpeed += Time.deltaTime * playerSpeedIncreaseRate;
            }

            // Slide, Chord G
            if (G1 > 0.0f && B1 > 0.0f && D2 > 0.0f && !sliding && IsGrounded())
            {
                StartCoroutine(Slide());
            }
            
            // Jump, Chord F
            if (F1 > 0.0f && A1 > 0.0f && C2 > 0.0f && IsGrounded())
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * gravity * -3f);
                controller.Move(playerVelocity * Time.deltaTime);
            }

            // Left turn, Chord C
            if (C1 > 0.0f && E1 > 0.0f && G1 > 0.0f)
            {
                // Turn left
            }

            //Right turn, Chord Am
            if (A1 > 0.0f && C2 > 0.0f && E2 > 0.0f)
            {
                // Turn right 
            }
        }

        private bool IsGrounded(float length = .2f)
        {
            Vector3 raycastOriginFirst = transform.position;
            raycastOriginFirst.y -= controller.height / 2f;
            raycastOriginFirst.y += .1f;

            Vector3 raycastOriginSecond = raycastOriginFirst;
            raycastOriginFirst -= transform.forward * .2f;
            raycastOriginSecond += transform.forward * .2f;

            //Debug.DrawLine(raycastOriginFirst, Vector3.down, Color.green, 2f);
            //Debug.DrawLine(raycastOriginSecond, Vector3.down, Color.red, 2f);

            if (Physics.Raycast(raycastOriginFirst, Vector3.down, out RaycastHit hit, length, groundLayer) ||
            Physics.Raycast(raycastOriginSecond, Vector3.down, out RaycastHit hit2, length, groundLayer))
            {
                return true;
            }
            return false;
        }
    }
}
