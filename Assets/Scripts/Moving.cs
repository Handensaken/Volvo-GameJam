using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    public Transform groundObject;
    public float groundRange = 0.45f;
    public LayerMask layerMask;
    public float speed = 5f;
    private Vector2 movementInput;
    public Rigidbody2D rB;

    //[SerializeField]
    //private SceneBehaviour sceneManager;
    [SerializeField]
    private float JumpForce;

    public Animator anim;

    private bool walkAnimPlaying;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start() { Debug.Log("hihi"); }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(movementInput.x, 0) * speed * Time.deltaTime);
        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(movementInput.x));
        }
        if (isgrounded() && rB.velocity.y <= 0)
            OnLanding();
    }

    void OnLanding()
    {
        if (anim != null)
        {
            anim.SetBool("IsJumping", false);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {

        movementInput = ctx.ReadValue<Vector2>();
        walkAnimPlaying = true;
    }
    public void OnJump()
    {
        if (isgrounded() && canJump)
        {
            if (anim != null)
            {
                anim.SetBool("IsJumping", true);
            }
            rB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            canJump = false;
            StartCoroutine(JumpDeley(0.2f));
        }
    }
    private bool isgrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            groundObject.position,
            groundRange,
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundObject.transform.position, groundRange);
    }
    private IEnumerator JumpDeley(float delay)
    {
        float counter = delay;
        while (counter > 0)
        {
            yield return new WaitForSeconds(0.1f);
            counter--;
        }
        canJump = true;
    }
}
