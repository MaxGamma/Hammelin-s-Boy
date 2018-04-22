using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    //Attach these in the Inspector
    public Sprite player;
    public Sprite rat;
    //Use this for getting the toggle data

    private SpriteRenderer spriteRenderer;

    private BoxCollider2D box;
    private CapsuleCollider2D capsule;

    bool Activate;

    void Start()
    {
        //Deactivate parent GameObject and toggle
        Activate = false;

        box = GetComponent<BoxCollider2D>();
        capsule = GetComponent<CapsuleCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = player;

        /*Player.GetComponent<SpriteRenderer>().enabled = true;
        //Player.GetComponent<BoxCollider2D>().enabled = true;
        RatCon.GetComponent<SpriteRenderer>().enabled = false;
        //RatCon.GetComponent<BoxCollider2D>().enabled = false;*/
    }

    void Update()
    {
       if (Input.GetKey(KeyCode.R)&& (Activate==false))
        {
            Activate = true;

            spriteRenderer.sprite = rat;
            box.GetComponent<BoxCollider2D>().enabled = false;
            capsule.GetComponent<CapsuleCollider2D>().enabled = true;
            gameObject.tag = "Rat";

        }
        else if (Input.GetKey(KeyCode.T)&& (Activate==true))
        {
            Activate = false;

            spriteRenderer.sprite = player;
            box.GetComponent<BoxCollider2D>().enabled = true;
            capsule.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.tag = "Player";

        }


        ////Activate the GameObject you attach depending on the toggle output
        //m_ParentObject.SetActive(m_Activate);*/
    }


}
