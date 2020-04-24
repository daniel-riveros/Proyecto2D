using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDepth : MonoBehaviour
{
    // Start is called before the first frame update
    public bool fixEveryFrame;
    SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sortingLayerName = "Player";
        spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }

    // Update is called once per frame
    void Update()
    {
         if (fixEveryFrame) {
            spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        }
    }
}
