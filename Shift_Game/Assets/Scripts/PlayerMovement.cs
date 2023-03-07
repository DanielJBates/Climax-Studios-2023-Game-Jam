using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 8.0f;
    private float jumpPower = 15.0f;
    private bool IsFacingRight = true;
    private LayerMask colourLayer;

    private bool onRightWall;

    private bool IsWallSliding;
    [SerializeField] private float wallSlideSpeed;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float rayDistance;

    Palette playerPalette;

    private void Start()
    {
        playerPalette = GetComponent<Palette>();
        var colName = playerPalette.CurrentPalette.CurrentPalette[playerPalette.Index];
        colourLayer = LayerMask.GetMask(colName, "Default");
        GameEvents.onColourChange += GameEvents_onColourChange;
    }

    private void GameEvents_onColourChange()
    {
        var colName = playerPalette.CurrentPalette.CurrentPalette[playerPalette.Index];
        colourLayer = LayerMask.GetMask(colName, "Default");
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 

        if (vertical > 0.0f && isOnFloor())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

       if (IsWallSliding && vertical > 0.0f)
        {
            if (onRightWall)
            { 
                rb.velocity = new Vector2(-speed, jumpPower);
                if(IsFacingRight)
                {
                    transform.localScale *= new Vector2(-1.0f, 1.0f);
                    IsFacingRight = false;
                    //flip();
                }

            }
            else
            {
                rb.velocity = new Vector2(speed, jumpPower);
                if (!IsFacingRight)
                {
                    transform.localScale *= new Vector2(-1.0f, 1.0f);
                    IsFacingRight = true;
                    //flip();
                }
            }
        }
        else if (!IsWallSliding && horizontal != 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

       if(IsWallSliding && onRightWall && horizontal < 0.0f || IsWallSliding && !onRightWall && horizontal > 0.0f)
        {
            IsWallSliding = false;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
 

        WallSlide();

        flip();
    }

    private void WallSlide()
    {
        if (isOnWall() && !isOnFloor())
        {
            IsWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else
        {
            IsWallSliding = false;
        }
    }

    private bool isOnFloor()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayDistance, colourLayer);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, new Vector2(0.5f, -0.5f), rayDistance, colourLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, new Vector2(-0.5f, -0.5f), rayDistance, colourLayer);
        if (hit.collider != null && hit.collider.CompareTag("Floor") 
            || hit1.collider != null && hit1.collider.CompareTag("Floor")
            || hit2.collider != null && hit2.collider.CompareTag("Floor"))
        {
            
            return true;
        }

        return false;
    }

    private bool isOnWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0.5f, -0.5f), rayDistance, colourLayer);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, new Vector2(-0.5f, -0.5f), rayDistance, colourLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, new Vector2(0.5f, 0.5f), rayDistance, colourLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, new Vector2(-0.5f, 0.5f), rayDistance, colourLayer);
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, colourLayer);
        RaycastHit2D hit5 = Physics2D.Raycast(transform.position, Vector2.left, rayDistance, colourLayer);
        if (hit.collider != null && hit.collider.CompareTag("Wall") 
            || hit2.collider != null && hit2.collider.CompareTag("Wall") 
            || hit4.collider != null && hit4.collider.CompareTag("Wall"))
        {
            onRightWall = true;
            return true;
        }
        if (hit1.collider != null && hit1.collider.CompareTag("Wall") 
            || hit3.collider != null && hit3.collider.CompareTag("Wall")
            || hit5.collider != null && hit5.collider.CompareTag("Wall"))
        {
            onRightWall = false;
            return true;
        }
        return false;
    }

    private void flip()
    {
            if (IsFacingRight && horizontal < 0.0f || !IsFacingRight && horizontal > 0.0f)
            {
                IsFacingRight = !IsFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1.0f;
                transform.localScale = localScale;
            }

    }
}
