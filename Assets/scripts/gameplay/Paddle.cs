using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb2D;
    float halfColliderWidth;
    float halfColliderHeight;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    //freezer effect support
    bool frozen = false;
    Timer freezerTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        BoxCollider2D bc2D = GetComponent<BoxCollider2D>();
        halfColliderWidth = bc2D.size.x / 2;
        halfColliderHeight = bc2D.size.y / 2;

        freezerTimer = gameObject.AddComponent<Timer>();
        EventManager.AddFrezerEffectListener(HandleFreezerEffectActivatedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if (freezerTimer.Finished)
        {
            frozen = false;
            freezerTimer.Stop();
        }
    }

    void FixedUpdate()
    {

        // move the paddle
        float horizontalInput = Input.GetAxis("Horizontal");
        if (!frozen && horizontalInput != 0)
        {
            Vector3 position = transform.position;
            position.x += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            rb2D.MovePosition(position);
        }
    }

    /// <summary>
    /// Calculates the x position to keep the paddle in playfield
    /// </summary>
    float CalculateClampedX(float x)
    {
        if (x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - halfColliderWidth;
        }

        return x;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball")&&
            CheckTopCollision(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    /// <summary>
    /// Checks if the collision is on the top of the paddle
    /// </summary>
    /// <param name="coll"></param>
    /// <returns></returns>
    bool CheckTopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        ContactPoint2D[] contacts = coll.contacts;

        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    void HandleFreezerEffectActivatedEvent(float duration)
    {
        frozen = true;
        if (!freezerTimer.Running)
        {
            freezerTimer.Duration = duration;
            freezerTimer.Run();
        }
        else
        {
            freezerTimer.AddTime(duration);
        }
    }

}
