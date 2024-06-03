using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEditor;

public class Player : Singleton<Player>
{

    public const float walkSpeed = 3f;
    public const float dashSpeed = 5f;

    public Inventory inventory;

    private Rigidbody2D rb;
    private float playerDir;

    [SerializeField] private AudioSource walk;

    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;

    public Animator animator;
    public string animationTrigger = "AnimationTrigger";

    private Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        inventory = new Inventory(12);

        mainCamera = GetComponent<Camera>();
    }

    public void Drop(Collectable item)
    {
        Vector3 spawnLocation = transform.position;
        //float randX = Random.Range(-1f, 1f);
        //float randY = Random.Range(-1f, 1f);

        Vector3 offSet = Random.insideUnitCircle * 1.25f;

        Collectable droppedItem = Instantiate(item, spawnLocation + offSet, Quaternion.identity);
        droppedItem.rb.AddForce(offSet * 5f, ForceMode2D.Impulse);
    }
    private void Update()
    {
        #region Player Input
        PlayerMove();
        #endregion
    }


    private void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput * walkSpeed, verticalInput * walkSpeed);
        rb.velocity = movement;

        // Flip the character sprite based on horizontal movement
        if (horizontalInput > 0 && transform.localScale.x < 0 || horizontalInput < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        // Play or stop walking audio based on movement
        // if (horizontalInput != 0 || verticalInput != 0)
        // {
        //     // walk.Play();
        // }
        // else
        // {
        //     // walk.Stop();
        // }
    }

    private void PlayAnimation()
    {
        // Check if the Animator and animation trigger are assigned
        if (animator != null && !string.IsNullOrEmpty(animationTrigger))
        {
            // Play the animation
            animator.SetTrigger(animationTrigger);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.C))
        {
            PlayAnimation();
        }

    }
  /*  public Vector3 GetPlayerViewportPosition()
    {
        return mainCamera.transform.position;
        Camera camera = GetComponent<Camera>();
      //  Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

    } */
}