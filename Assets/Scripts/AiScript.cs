using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AiScript : MonoBehaviour
{
    public float MaxMovementSpeed;
    //public GameObject AiRed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D wall;

    public Rigidbody2D Puck;

    public Transform LimiteAi;
    private Limit AiLimit;

    public Transform LimitePuck;
    private Limit puckLimit;

    private Vector2 targetPosition;
    private Vector2 futurePosition;
    private Vector2 ToGoal;
    private Vector2 ToPuck;

    public Transform goalPlayer;
    float avoidingValue;
    bool isBehind = false;
    bool avoidingCenter = false;
    bool avoidingLeft = false;
    bool avoidingRight = false;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = new Vector2(0f,4f);

        AiLimit = new Limit(LimiteAi.GetChild(0).position.y, LimiteAi.GetChild(1).position.y, LimiteAi.GetChild(2).position.x, LimiteAi.GetChild(3).position.x);
        puckLimit = new Limit(LimitePuck.GetChild(0).position.y, LimitePuck.GetChild(1).position.y, LimitePuck.GetChild(2).position.x, LimitePuck.GetChild(3).position.x);
    }

    

    private void FixedUpdate()
    {
        if (!Score.Goal)
        {   

            AvoidingObject();
            float movementSpeed;
            
           // Debug.Log("Ai Position: " + rb.position.y);
           // if (rb.position.y > Puck.position.y)
            //{
                //movementSpeed = MaxMovementSpeed;
                //targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, AiLimit.Left, AiLimit.Right), rb.position.y+2);
                
               // futurePosition = Puck.position + Puck.velocity * .15f;
            double half_t_squared = 0.5 * Time.deltaTime * Time.deltaTime;
            // }

            // futurePosition = -(Puck.position + Puck.velocity);
            //  futurePosition = new Vector2(0, 4);


            if (Puck.position.y < puckLimit.Up)
                {
                    movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                    //targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + Random.Range(0f, 1f), AiLimit.Left, AiLimit.Right), startingPosition.y);
                    targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, AiLimit.Left, AiLimit.Right), startingPosition.y);
               
                
                }
                else
                {
                    movementSpeed = Random.Range(0f, MaxMovementSpeed);
                /*
                Vector2 DesiredVelocity = new Vector2(goalPlayer.position.x - Puck.position.x, goalPlayer.position.y - Puck.position.y);
                DesiredVelocity = DesiredVelocity.normalized;
                Vector2 DesiredPosition = new Vector2(DesiredVelocity.x - Puck.velocity.x, DesiredVelocity.y - Puck.velocity.y);
                Debug.Log("SSS: " + DesiredPosition);
                Debug.Log("Puck Position: " + Puck.position);
                Debug.Log("Playe Goal Field Position: " + goalPlayer.position);
                */
                ToPuck = new Vector2(Puck.position.x - rb.position.x, Puck.position.y - rb.position.y);
                // Debug.Log("To Puck:" + ToPuck);
                //  Debug.Log("Puck:" + Puck.position);
                float lookAhead = Vector2.Distance(rb.position, Puck.position) / MaxMovementSpeed;
              //  Debug.Log("LOOK: " + lookAhead);

                futurePosition = Puck.position + Puck.velocity * lookAhead;

                ToGoal = new Vector2( goalPlayer.position.x - Puck.position.x, goalPlayer.position.y - Puck.position.y);
                
                Vector2 ToGoalNormalized = ToGoal.normalized;
                Vector2 ut = Puck.velocity * Time.deltaTime;
                
                Vector2 ScalartoVector = new Vector2((float)half_t_squared * Puck.velocity.normalized.x,(float)half_t_squared * Puck.velocity.normalized.y);
                Vector2 DesiredPosition = new Vector2(Puck.position.x + ut.x + ScalartoVector.x, Puck.position.y + ut.y + ScalartoVector.y);
               // Debug.Log("DesiredPosition" + DesiredPosition);
              /*  Debug.Log("Puck Velocity" + Puck.velocity);
                Debug.Log("UT" + ut);
                Debug.Log("Half" + half_t_squared);
                Debug.Log("ScalarToVector" + ScalartoVector);
                Debug.Log("Desired Position: " + DesiredPosition);
*/
                //targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, AiLimit.Left, AiLimit.Right), Mathf.Clamp(Puck.position.y, AiLimit.Up, AiLimit.Down));
                targetPosition = new Vector2(Mathf.Clamp(futurePosition.x, AiLimit.Left, AiLimit.Right), Mathf.Clamp(futurePosition.y, AiLimit.Up, AiLimit.Down));
                /*
                if (Puck.position.x < 0)
                {
                    targetPosition = new Vector2(Mathf.Clamp(futurePosition.x - 0.1f, AiLimit.Left, AiLimit.Right), Mathf.Clamp(futurePosition.y, AiLimit.Up, AiLimit.Down));
                }
                else if(Puck.position.x ==0)
                {
                    targetPosition = new Vector2(Mathf.Clamp(futurePosition.x , AiLimit.Left, AiLimit.Right), Mathf.Clamp(futurePosition.y, AiLimit.Up, AiLimit.Down));
                }
                 else
                {
                    targetPosition = new Vector2(Mathf.Clamp(futurePosition.x + 0.1f, AiLimit.Left, AiLimit.Right), Mathf.Clamp(futurePosition.y, AiLimit.Up, AiLimit.Down));
                }
                */
                //targetPosition = new Vector2(DesiredVelocity.x, DesiredVelocity.y);

               
                //Puck.position = ToGoal;
                /*
                if (rb.position.y == Puck.position.y)
                {
                    Puck.MovePosition(Vector2.MoveTowards(Puck.position, ToGoal, movementSpeed * Time.fixedDeltaTime));
                    Debug.Log("MoveTowards");
                }
                */
            }

            

            //if (!avoidingCenter && !avoidingLeft && !avoidingRight) rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));
            if (!avoidingCenter) rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));
            //else if (avoidingCenter && rb.position.x < 0 ) rb.transform.position.x += 0.5f;
            else if (avoidingCenter && Puck.position.x < 0)
           // else if (avoidingCenter )
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, rb.position - new Vector2(2f, 0) + new Vector2(0f,1f), movementSpeed * Time.fixedDeltaTime));
               // avoidingCenter = false;
                // avoidingRight = false;
                //  avoidingLeft = false;
            }
            
            
            else if (avoidingCenter && Puck.position.x > 0)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, rb.position + new Vector2(2f, 1f), movementSpeed * Time.fixedDeltaTime));
               // avoidingCenter = false;
                avoidingRight = false;
                avoidingLeft = false;
            }
            avoidingCenter = false;
            /*
            else if (avoidingLeft && rb.position.x < 0 && rb.position.x > -2.3f)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, rb.position - new Vector2(1f, 0), movementSpeed * Time.fixedDeltaTime));
                avoidingLeft = false;
                avoidingRight = false;
                avoidingCenter = false;
            }
            else if (avoidingLeft && rb.position.x < 0)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, rb.position + new Vector2(1f, 0), movementSpeed * Time.fixedDeltaTime));
                avoidingLeft = false;
                avoidingRight = false;
                avoidingCenter = false;
            }
            else if (avoidingLeft && rb.position.x > 0)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, rb.position - new Vector2(1f, 0), movementSpeed * Time.fixedDeltaTime));
                avoidingLeft = false;
                avoidingRight = false;
                avoidingCenter = false;
            }
            else if (avoidingRight && rb.position.x > 0 && rb.position.x < 2.3f)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, rb.position + new Vector2(1f, 0), movementSpeed * Time.fixedDeltaTime));
                avoidingRight = false;
                avoidingLeft = false;
                avoidingCenter = false;
            }
            else if (avoidingRight && rb.position.x > 0)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, rb.position - new Vector2(1f, 0), movementSpeed * Time.fixedDeltaTime));
                avoidingRight = false;
                avoidingLeft = false;
                avoidingCenter = false;
            }
            else if (avoidingRight && rb.position.x < 0)
            {
                rb.MovePosition(Vector2.MoveTowards(rb.position, rb.position + new Vector2(1f, 0), movementSpeed * Time.fixedDeltaTime));
                avoidingRight = false;
                avoidingLeft = false;
                avoidingCenter = false;
            }

            */



            // Debug.Log("FuturePosition: " + futurePosition);

            // Debug.Log("CurrentPosition: " + Puck.position);
        }
    }

    private void AvoidingObject()
    {
        
        RaycastHit2D hit;
        RaycastHit2D hitLeft;
        RaycastHit2D hitRight;
        
        Vector2 startPosition = rb.position - new Vector2(0,0.4f);
        Vector2 startPositionLeft;
        Vector2 startPositionRight;
        

        // startPosition += transform.up * 0.2f;

         hit = Physics2D.Raycast(startPosition, Vector2.zero,0.5f);
        // hit = Physics2D.Raycast(rb.transform.position, rb.transform.forward, 2f);
        //Center Ai
        // if (Physics2D.Raycast(startPosition, transform.forward, out hit, 0.1f))
        if (hit)
        {
            Debug.DrawLine(hit.point, hit.point - new Vector2(0f, 0.5f));
        }
        //  Debug.Log(hit.point + "hit");
      //  Debug.Log(hit.collider.name + " Asta ");
        if (hit.collider.name.ToString()=="AiRed") {
        //   Debug.Log(hit.collider.name + " ce cct");
       }
        


            //Left Edge Ai 
            // startingPosition -=new Vector2(rb.GetComponent<Renderer>().bounds.size.x , rb.position.y);
            startPositionLeft =new Vector2 (rb.position.x-0.4f, rb.position.y);
        hitLeft = Physics2D.Raycast(startPositionLeft, Vector2.zero);
        //if (!hitLeft.collider.CompareTag("wall"))
           // Debug.Log(hitLeft.collider.name + " ss");
        
            Debug.DrawLine(hitLeft.point, hitLeft.point - new Vector2(0f, 2f));
        /*
        if (hitLeft.collider.name == "AiRed")
        {
            Debug.Log(hitLeft.collider.name + " ce cct");
        }
        */
        //hitLeft = 

        //Right Edge Ai
        startPositionRight = new Vector2(rb.position.x + 0.4f, rb.position.y);
        hitRight = Physics2D.Raycast(startPositionRight, Vector2.zero, 2f);
        Debug.DrawLine( hitRight.point,hitRight.point - new Vector2(0f,2f));

        Vector2 edgePosCenter = new Vector2(hit.point.x,hit.point.y-2f);
        Vector2 edgePosLeft = new Vector2(hitLeft.point.x,hitLeft.point.y-2f);
        Vector2 edgePosRight = new Vector2(hitRight.point.x,hitRight.point.y-2f);


        //Debug.Log("Edge:" + edgePos + " Hit:" + hitLeft.point + "Wall:" + wall.position );

        

        if (edgePosCenter.x >=wall.position.x-0.4f && edgePosCenter.x <=wall.position.x+0.4f && edgePosCenter.y <= wall.position.y && edgePosCenter.y > wall.position.y-2f)
        {
            Debug.Log("HIT!! Center:" + wall.position);
            avoidingCenter = true;
           // avoidingLeft = false;
           // avoidingRight = false;
            
        }
        /*
       else if (edgePosLeft.x >=wall.position.x-0.4f && edgePosLeft.x <=wall.position.x+0.4f && edgePosLeft.y <= wall.position.y && edgePosLeft.y > wall.position.y-2f)
        {
            Debug.Log("HIT!! Left:" + wall.position);
           // avoidingLeft = true;
            //avoidingCenter = true;
           // avoidingRight = false;

        }
       else if (edgePosRight.x >=wall.position.x-0.4f && edgePosRight.x <=wall.position.x+0.4f && edgePosRight.y <= wall.position.y && edgePosRight.y > wall.position.y-2f)
        {
            Debug.Log("HIT!! Right:" + wall.position);

           // avoidingRight = true;
           // avoidingLeft = false;
          //  avoidingCenter = true;

        }
        */

    }
    
}
