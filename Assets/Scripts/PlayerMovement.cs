using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator _animator;
    Camera _camera;
    CharacterController _controller;

    public float speed = 5f;
    public float runSpeed = 10f;
    public float finalSpeed;

    public float jumpPower = 10f;
    private float gravity = -9.81f;

    private Rigidbody rb;

    private Vector3 moveDirection;

    public bool toggleCameraRotation;
    public bool isRun;
    public bool isForward;
    public bool isBackward;
    public bool isLeft;
    public bool isRight;

    public float smoothness = 10f;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector3.zero;

        rb = GetComponent<Rigidbody>();

        _animator = GetComponent<Animator>();
        _camera = Camera.main;
        _controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        
        moveDirection = right * Input.GetAxisRaw("Horizontal") + forward * Input.GetAxisRaw("Vertical");


        // 둘러보기 (Left Alt)
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            toggleCameraRotation = true;
        }
        else
        {
            toggleCameraRotation = false;
        }

        // 달리기 (Left Shift)
        if (Input.GetKey (KeyCode.LeftShift))
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }

        // 앞으로 (W)
        if (Input.GetKey(KeyCode.W))
        {
            isForward = true;
        }
        else
        {
            isForward = false;
        }

        // 왼쪽 (A)
        if (Input.GetKey(KeyCode.A))
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }

        // 뒷걸음질 (S)
        if (Input.GetKey(KeyCode.S))
        {
            isBackward = true;
        }
        else
        {
            isBackward = false;
        }

        // 오른쪽 (D)
        if (Input.GetKey(KeyCode.D))
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }

        // 마우스 왼쪽 클릭
        if (Input.GetMouseButtonDown(0))
        {
            _animator.Play("RightHand@Attack01", -1);
            
        }

        // 점프 (Space)
        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded == true)
        {
            moveDirection.y = jumpPower;
        }

        // 캐릭터가 공중에 있을 때 중력 적용
        if (_controller.transform.position.y > 1 )
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        _controller.Move(moveDirection * finalSpeed * Time.deltaTime);

        InputMovement();

    }
    private void LateUpdate()
    {
        if(toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
    }
    void InputMovement()
    {
        finalSpeed = (isRun) ? runSpeed : speed;
        float percent = ((isRun) ? 1 : 0.5f) * moveDirection.magnitude;
        _animator.SetFloat("finalSpeed", percent, 0.1f, Time.deltaTime);

        setBools();
    }

    void setBools()
    {
        if (isForward == true)
        {
            _animator.SetBool("isForward", true);
        }
        else
        {
            _animator.SetBool("isForward", false);
        }

        if (isBackward == true)
        {
            _animator.SetBool("isBackward", true);
        }
        else
        {
            _animator.SetBool("isBackward", false);
        }

        if (isLeft == true)
        {
            _animator.SetBool("isLeft", true);
        }
        else
        {
            _animator.SetBool("isLeft", false);
        }

        if (isRight == true)
        {
            _animator.SetBool("isRight", true);
        }
        else
        {
            _animator.SetBool("isRight", false);
        }
    }


}
