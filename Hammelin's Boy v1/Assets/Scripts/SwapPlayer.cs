using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    //Attach these in the Inspector
    public GameObject player;
    public GameObject rat;
    
    public Transform groundCheckPoint;

    public AudioSource musicSource;
    public AudioClip changeSound;

    public GameObject particles;

    //Use this for getting the toggle data

    private BoxCollider2D box;
    private CapsuleCollider2D capsule;

    private SpriteRenderer ratSprite;
    private SpriteRenderer playerSprite;

    bool value3;

    void Start()
    {
        ratSprite = rat.GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        box = player.GetComponent<BoxCollider2D>();
        capsule = rat.GetComponent<CapsuleCollider2D>();

        capsule.enabled = false;
        ratSprite.enabled = false;
    }

    void Update()
    {
        value3 = Input.GetKeyDown("joystick button 1");

        if (Input.GetKeyDown(KeyCode.RightShift) || value3)
        {
            changeSprite();

        }
    }

    void changeSprite()
    {
        musicSource.clip = changeSound;
        musicSource.Play();
        if (gameObject.tag == "Player")
        {
            ratSprite.enabled = true;
            playerSprite.enabled = false;
            box.enabled = false;
            capsule.enabled = true;
            gameObject.tag = "Rat";
            Instantiate(particles, new Vector3(player.transform.position.x, player.transform.position.y - 1.1f,player.transform.position.z - 3), particles.transform.rotation);

        }
        else if (gameObject.tag == "Rat")
        {
            playerSprite.enabled = true;
            ratSprite.enabled = false;
            box.enabled = true;
            capsule.enabled = false;
            gameObject.tag = "Player";
            Instantiate(particles, new Vector3(player.transform.position.x, player.transform.position.y - 1.1f, player.transform.position.z - 3), particles.transform.rotation);
        }
    }

}
