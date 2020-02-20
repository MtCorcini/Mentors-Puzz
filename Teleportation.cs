using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Portal, Player;
    
    public static int StartTeleport = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Teleportation.StartTeleport == 1)
        {
            Teleportation.StartTeleport = 0;
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);

    }
}