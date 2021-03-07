using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A standard block
/// </summary>
public class StandardBlock : Block
{
    [SerializeField] Sprite blockSprite0;
    [SerializeField] Sprite blockSprite1;
    [SerializeField] Sprite blockSprite2;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    override protected void Start()
    {
        base.Start();

        points = ConfigurationUtils.StandardBlockPoints;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int choice = Random.Range(0, 3);

        if (choice == 0)
            spriteRenderer.sprite = blockSprite0;

        else if (choice == 1)
            spriteRenderer.sprite = blockSprite1;

        else spriteRenderer.sprite = blockSprite2;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }
}
