using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    //Attach these in the Inspector
    public GameObject player;
    public GameObject rat;

    public Transform groundCheckPoint;

    //Use this for getting the toggle data

    private BoxCollider2D box;
    private CapsuleCollider2D capsule;

    private SpriteRenderer ratSprite;
    private SpriteRenderer playerSprite;


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
        if ( Input.GetKeyDown(KeyCode.RightShift))
        {
            changeSprite();
        }
    }

    void changeSprite()
    {
        if (gameObject.tag == "Player")
        {
            ratSprite.enabled = true;
            playerSprite.enabled = false;
            box.enabled = false;
            capsule.enabled = true;
            gameObject.tag = "Rat";
            
        }
        else if (gameObject.tag == "Rat")
        {
            playerSprite.enabled = true;
            ratSprite.enabled = false;
            box.enabled = true;
            capsule.enabled = false;
            gameObject.tag = "Player";
            
        }
    }

}
