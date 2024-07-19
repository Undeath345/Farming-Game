using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutter : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] GameObject pickDownDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            GameObject go1 = Instantiate(pickDownDrop);
            go.transform.position = position;
            go1.transform.position = position;
        }
        Destroy(gameObject);
    }
}
