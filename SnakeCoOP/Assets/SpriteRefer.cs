using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRefer : MonoBehaviour
{
    public static SpriteRefer instance;
    public Sprite SnakeHeadSprite;
    public Sprite FoodSprite;
    public Sprite snakeBodySprite;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
