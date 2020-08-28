using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCharacter character;

    private void Start()
    {
        character = GetComponent<PlayerCharacter>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            character.Attack();
        }

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        character.Move(new Vector3(h, 0, v));


        var lookDir = Vector3.forward * v + Vector3.right * h;

        if (lookDir.magnitude != 0)
        {
            character.Rotate(lookDir);
        }

    }
}