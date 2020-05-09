using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    public Animator anim;

    PhotonView pw; //PhotonView component'ini alıyoruz.


    // Start is called before the first frame update
    void Start()
    {
        pw = GetComponent<PhotonView>(); //PhotonView component'ini alıyoruz.

        if (pw.IsMine) //Eğer sunucuya bağlanan bizsek
        {
            GetComponent<Renderer>().material.color = Color.red; //sadece kendimizin göreceği şekilde rengimizi kırmızı yaptık
        }
        else //Kendimiz dışındaki bütün nesneler
        {
            GetComponent<Renderer>().material.color = Color.blue; //sadece kendimizin göreceği şekilde rengimizi kırmızı yaptık
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (pw.IsMine)
        {
            move();

            turn();
        }
       
    }

    void move()
    {
        float X = Input.GetAxis("Mouse X") * Time.deltaTime * 30.0f;
        float Y = Input.GetAxis("Mouse Y") * Time.deltaTime * 30.0f;

        transform.Translate(X, Y, 0);
    }

    void turn()
    {
        if (Input.GetMouseButtonDown(0))
        {

            anim.SetBool("Turn", !anim.GetBool("Turn"));

        }
    }
}
