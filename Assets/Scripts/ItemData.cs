using UnityEditor.Search;
using UnityEngine;

public enum ItemColer
{
    White,
    Blue,
    Green,
    Red
}

public class ItemData : MonoBehaviour
{
    public ItemColer colors = ItemColer.White;
    public Sprite[] itemSprites;

    public int value = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        switch (colors)
        {
            case ItemColer.White:
                spriteRenderer.sprite = itemSprites[0];
                break;
            case ItemColer.Blue:
                spriteRenderer.sprite = itemSprites[1];
                break;
            case ItemColer.Green:
                spriteRenderer.sprite = itemSprites[2];
                break;
            case ItemColer.Red:
                spriteRenderer.sprite = itemSprites[3];
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
