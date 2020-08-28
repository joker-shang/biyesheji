using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public List<GameObject> ais = new List<GameObject>();
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "AI")
        {
            ais.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "AI")
        {
            ais.Remove(col.gameObject);
        }
    }
    public float attackRateTime = 1;//攻击频率
    private float timer = 0;

    public Transform firePosition;
    public Rigidbody bullet1;

    public float launchForce = 10;

    public Transform head;
    void Update()
    {
        timer += Time.deltaTime;
        if (ais.Count>0&&timer >=attackRateTime)
        {
            timer = 0;
            Attack();
        }
        if (ais.Count > 0 && ais[0] != null)
        {
            Vector3 targetPosition = ais[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        else
        {
            UpgradeAis();
        }
    }
    void Attack()
    {
        var shellInstance = Instantiate(bullet1, firePosition.position, firePosition.rotation) as Rigidbody;
        shellInstance.velocity = launchForce * firePosition.forward;

    }

    void UpgradeAis()
    {
        List<int> emptyIndex = new List<int>();
        for (int index = 0; index < ais.Count; index++)
        {
            if (ais[index] == null)
            {
                emptyIndex.Add(index);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            ais.RemoveAt(emptyIndex[i] - i);
        }
    }
}
