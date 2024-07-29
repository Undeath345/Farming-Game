using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockbreaker: ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    Character character;
    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;
            character.GetTired(10);
        }
        Destroy(gameObject);
    }
}
