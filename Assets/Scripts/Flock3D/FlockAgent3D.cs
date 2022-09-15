using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent3D : MonoBehaviour
{
    //Filter
    Flock3D agentFlock;
    public Flock3D AgentFlock { get { return agentFlock; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    public bool isVerticalMovement = true;
    Rigidbody rb;
    float speedMultiplier = 0.25f;
    Vector3 defaultUp;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();

        if (!isVerticalMovement)
        {
            rb = GetComponent<Rigidbody>();
            defaultUp = transform.up;
        }
    }

    public void Initialize(Flock3D flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector3 velocity)
    {
        
        if (isVerticalMovement)
        {
            transform.up = velocity;
            transform.position += (Vector3)velocity * Time.deltaTime;
        }
        else
        {
            //transform.position += new Vector3(velocity.x, 0, velocity.z) * Time.deltaTime;
            //Note tadi ga disable
            //transform.up = velocity;
            //transform.up = defaultUp;
            rb.velocity += new Vector3(velocity.x, 0, velocity.z) * Time.deltaTime * speedMultiplier;
            transform.forward = new Vector3(rb.velocity.normalized.x, 0, rb.velocity.normalized.z);

            /*
            if (transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.identity;
            }
            */
        }
    }
}
