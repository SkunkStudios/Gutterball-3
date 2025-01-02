using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpriteAnim
{
	public Sprite[] sprites;
    public int animNext;
    public bool isStompAnim;
    public bool isLandAnim;
}

public class AnimList : MonoBehaviour
{
	public SpriteAnim[] spriteAnim;
    public Renderer meshBall;

    private SpriteRenderer[] renderers;
	private float stompTime;
	private float animTime;
	private int animIndex;
	private int spriteIndex = 1;
    private bool isStompAnim;
    private bool isLandAnim;

    void Start ()
	{
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }
	
	void Update ()
	{
        animTime += Time.deltaTime * 2;
        if (animTime > 0.03f)
        {
            animTime = 0;
            spriteIndex++;
        }
        if (isStompAnim)
        {
            stompTime -= 30 * Time.deltaTime;
        }
        if (stompTime < 0 && isStompAnim)
        {
            animIndex = spriteAnim[animIndex].animNext;
            spriteIndex = 1;
            isStompAnim = false;
        }
        if (spriteIndex < spriteAnim[animIndex].sprites.Length)
        {
            foreach (SpriteRenderer renderer in renderers)
            {
                renderer.sprite = spriteAnim[animIndex].sprites[spriteIndex];
            }
            if (meshBall != null)
            {
                meshBall.material.mainTexture = spriteAnim[animIndex].sprites[spriteIndex].texture;
            }
        }
        if (spriteIndex >= spriteAnim[animIndex].sprites.Length && !isLandAnim)
        {
            spriteIndex = 1;
        }
        else if (spriteIndex >= spriteAnim[animIndex].sprites.Length && isLandAnim)
        {
            animIndex = spriteAnim[animIndex].animNext;
            spriteIndex = 1;
            isLandAnim = false;
        }
    }

    public void PlayAnim(int playIndex, float fallGravity)
    {
        animTime = 0;
        animIndex = playIndex;
        stompTime = fallGravity * 0.25f;
        spriteIndex = 1;
        isStompAnim = spriteAnim[playIndex].isStompAnim;
        isLandAnim = spriteAnim[playIndex].isLandAnim;
    }

    public void PlaySFX(string clipName)
    {
        Game.PlayClip(clipName);
    }
}
