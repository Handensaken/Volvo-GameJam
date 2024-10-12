using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    public Transform groundObject;
    public LayerMask layerMask;
    public float speed = 5f;
    private Vector2 movementInput;
    public Rigidbody2D rB;

    [SerializeField]
    private float JumpForce;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnJump()
    {
        if (!Keyboard.current.spaceKey.wasPressedThisFrame && isgrounded())
        {
            rB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Debug.Log("ran");
        }
    }

    private bool isgrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            groundObject.position,
            0.45f,
            Vector2.down,
            0.1f,
            layerMask
        );
        Color raycolor;
        if (hit.collider != null)
        {
            raycolor = Color.green;
        }
        else
        {
            raycolor = Color.red;
        }
        Debug.DrawRay(groundObject.position, Vector2.down * 0.1f, raycolor);
        return hit.collider != null;
    }
}
