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
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
        _controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
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

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");

        _controller.Move(moveDirection.normalized * finalSpeed * Time.deltaTime);

        float percent = ((isRun) ? 1 : 0.5f) * moveDirection.magnitude;

        _animator.SetFloat("finalSpeed", percent, 0.1f, Time.deltaTime);

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
