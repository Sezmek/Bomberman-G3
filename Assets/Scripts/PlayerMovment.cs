using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody2D Rb { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public Animations Up;
    public Animations Down;
    public Animations Left;
    public Animations Right;
    private Animations activeAnimation;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        activeAnimation = Down;
    }
    private void Update()
    {
        if (Input.GetKey(inputUp)) SetDirection(Vector2.up, Up);
        else if (Input.GetKey(inputDown)) SetDirection(Vector2.down, Down);
        else if (Input.GetKey(inputLeft)) SetDirection(Vector2.left, Left);
        else if (Input.GetKey(inputRight)) SetDirection(Vector2.right, Right);
        else SetDirection(Vector2.zero, activeAnimation);
    }
    private void FixedUpdate()
    {
       Vector2 position = Rb.position;
       Vector2 translation = direction * speed * Time.fixedDeltaTime;
       Rb.MovePosition(position +  translation);
    }
    private void SetDirection(Vector2 newDirection, Animations spriteRenderer)
    {
        direction = newDirection;

        Up.enabled = spriteRenderer == Up;
        Down.enabled = spriteRenderer == Down;
        Left.enabled = spriteRenderer == Left;
        Right.enabled = spriteRenderer == Right;
        activeAnimation = spriteRenderer;
        activeAnimation.idlle = direction == Vector2.zero;
    }
}
