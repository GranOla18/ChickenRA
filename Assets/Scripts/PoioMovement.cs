using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoioMovement : MonoBehaviour
{
    public static PoioMovement instance;
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotationSpeed;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movementDirection;
    private FixedJoystick joystick;

    private Animator animator;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        if(movementDirection != Vector3.zero)
        {
            if (Mathf.Abs(horizontalInput) > 0.5 || Mathf.Abs(verticalInput) > 0.5)
            {
                movement(runSpeed);
                animator.SetFloat("Walk", 2);
            }
            else
            {
                movement(speed);
                animator.SetFloat("Walk", 1);
            }
        }
        else
        {
            animator.SetFloat("Walk", 0);
        }
        
    }

    void movement(float speed)
    {
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
