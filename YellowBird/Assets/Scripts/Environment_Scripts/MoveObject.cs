using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float objectSpeed = 5f;
    public Direction moveDirection = Direction.Left;

    public enum Direction
    {
        Left,
        Right
    }

    private float screenEdge;
    [SerializeField] private float addedDistanceScreenEdge = 1f;

    private void Start()
    {
        CalculateScreenEdge();
        MoveObjectDirection();
        CheckOffScreen();
    }

    private void Update()
    {
        MoveObjectDirection();
        CheckOffScreen();
    }

    private void CalculateScreenEdge()
    {
        screenEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + addedDistanceScreenEdge;
    }

    private void MoveObjectDirection()
    {
        transform.position += (moveDirection == Direction.Right ? Vector3.right : Vector3.left) * objectSpeed * Time.deltaTime;
    }

    private void CheckOffScreen()
    {
        if (moveDirection == Direction.Right && transform.position.x > screenEdge)
        {
            Destroy(gameObject);
        }
        else if (moveDirection == Direction.Left && transform.position.x < -screenEdge)
        {
            Destroy(gameObject);
        }
    }
}