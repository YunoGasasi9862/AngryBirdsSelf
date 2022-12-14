
using UnityEngine;
using Cinemachine;
using UnityEngine.Windows.Speech;

public class MoveTowardFish : MonoBehaviour
{
    [SerializeField] Transform Fish;
    Rigidbody2D rb;
    [SerializeField] bool Allow = true;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] GameObject targetgroup;
    Camera camera;
    private void Awake()
    {
        cam.m_Lens.OrthographicSize = 5f;
        camera = Camera.main;
    }
    void Start()
    {
        Fish = GameObject.FindGameObjectWithTag("Fish").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
         if(cam.m_Lens.OrthographicSize <= 10f)
        {
            cam.m_Lens.OrthographicSize +=1f * Time.deltaTime;
        }
   
        
        if(Allow)
        {
            Vector3 move = Fish.position - transform.position;
            rb.AddForce(move * 3f * Time.deltaTime);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Fish")
        {
            Allow = false;
            Vector3 velocity = rb.velocity;
            velocity.x = 0f;
            velocity.y = 0f;
            rb.velocity = velocity;

            //the moment the inivisble object touches the fish, change the target object!!
            cam.m_Follow = targetgroup.transform;


        }
    }
}
