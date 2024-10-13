using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    public Transform groundObject;
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

    // Start is called before the first frame update
    void Start() { Debug.Log("hihi"); }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);
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
        if (isgrounded())
        {
            if (anim != null)
            {
                anim.SetBool("IsJumping", true);
            }
            rB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
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

    /*  private void OnCollisionEnter2D(Collision2D col)
      {
          Debug.Log(col.gameObject.name);
          if (col.gameObject.CompareTag("Hazard"))
          {
              Debug.Log("huhrensohn");
              sceneManager.LoadSceneDelayed("Max", 3);
              Destroy(gameObject);
          }
      }
  */
}
