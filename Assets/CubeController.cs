using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<PhotonView>().IsMine)
            {
                anim.SetBool("Turn", !anim.GetBool("Turn"));
            }
        }
    }
}
