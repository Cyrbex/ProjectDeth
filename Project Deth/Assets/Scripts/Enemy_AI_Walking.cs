using UnityEngine;
using Pathfinding;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class Enemy_AI_Walking : MonoBehaviour
{
    // Public Variables
    public bool m_FacingRight = true;
    public Transform target;
    public float AggroRange = 10f;
    public float updateRate = 2f;

    // Private variables
    private Animator anim;
    private Seeker seeker;
    private Rigidbody2D rb;
    private Vector3 m_Velocity = Vector3.zero;
    private bool PathStarted = false;
    [Range(0, 3)] [SerializeField] private float MovementSpeed = 1.5f;
    
    // The calculated path
    public Path path;

    // The AI Speed (Per Second)
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    // Max distance form the AI to waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null) { return; }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        // Start pathfinding when player is in aggrorange
        if (distanceToPlayer < AggroRange && !PathStarted)
        {
            PathStarted = true;
            seeker.StartPath(transform.position, target.position, OnPathComplete);
            StartCoroutine(UpdatePath());
        }
    }

    IEnumerator UpdatePath ()
    {
        if (target == null)
        {
            FindPlayer();
            yield return false;
            StartCoroutine(UpdatePath());
        }

        if (target != null)
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);

            yield return new WaitForSeconds(1f / updateRate);
            StartCoroutine(UpdatePath());
        }
    }
    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    
    void FindPlayer()
    {
        GameObject SearchResult = GameObject.FindGameObjectWithTag("Player");
        if (SearchResult != null)
        {
            target = SearchResult.transform;
        }
    }

    void FixedUpdate()
    {
     if (target == null)
        {
            FindPlayer();
            return;
        }

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        // Direction to the next waypoint
        Vector2 dir = (path.vectorPath[currentWaypoint] - transform.position);
        dir *= speed * Time.fixedDeltaTime;
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        
        rb.velocity = dir * MovementSpeed;

        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
        // Flip the enemy if...
        if (rb.velocity.x > 0 && !m_FacingRight) { Flipper(); }
        else if (rb.velocity.x < 0 && m_FacingRight) { Flipper(); }
    }
    // Flip the enemy
    public void Flipper()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
