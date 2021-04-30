using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Player.name);
    }

    // Update is called once per frame
    void Update()
    {
        var x = Player.transform.position.x + 6;
        var y = Player.transform.position.y + 3 ;
        transform.position = new Vector3(x,y,transform.position.z);
    }
}
