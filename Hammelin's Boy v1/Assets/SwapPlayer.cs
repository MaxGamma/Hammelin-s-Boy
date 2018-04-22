using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    //Attach these in the Inspector
    public GameObject Player, RatCon;
    //Use this for getting the toggle data
    bool Activate;

    void Start()
    {
        //Deactivate parent GameObject and toggle
        Activate = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R)&& (Activate==false))
        {
            Activate = true;
            
            RatCon.SetActive(true);
            Player.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.T)&& (Activate==true))
        {
            Activate = false;
            
            Player.SetActive(true);
            RatCon.SetActive(false);
        }


        ////Activate the GameObject you attach depending on the toggle output
        //m_ParentObject.SetActive(m_Activate);
    }


}
