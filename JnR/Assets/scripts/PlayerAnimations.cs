using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {
    public List<Texture2D> idleAnimationRight;
    public List<Texture2D> idleAnimationLeft;
    public List<Texture2D> runAnimationRight;
    public List<Texture2D> runAnimationLeft;
    public List<Texture2D> jumpAnimationRight;
    public List<Texture2D> jumpAnimationLeft;
    public List<Texture2D> attackAnimationRight;
    public List<Texture2D> attackAnimationLeft;


    public float speed = 10;

    public enum AniType
    {
        idleLeft,
        idleRight,
        runLeft,
        runRight,
        jumpLeft,
        jumpRight,
        attackRight,
        attackLeft
    }

    public AniType currAnimation = AniType.idleRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (currAnimation) {
            case AniType.idleLeft:
                setAnimation(idleAnimationLeft);
                break;
            case AniType.idleRight:
                setAnimation(idleAnimationRight);
                break;
            case AniType.runLeft:
                setAnimation(runAnimationLeft);
                break;
            case AniType.runRight:
                setAnimation(runAnimationRight);
                break;
            case AniType.jumpLeft:
                setAnimation(jumpAnimationLeft);
                break;
            case AniType.jumpRight:
                setAnimation(jumpAnimationRight);
                break;
            case AniType.attackRight:
                setAnimation(attackAnimationRight);
                break;
            case AniType.attackLeft:
                setAnimation(attackAnimationLeft);
                break;
        }
	}

    void setAnimation(List<Texture2D> listAnimations)
    {
        Renderer rend = GetComponent<Renderer>();
        int index = (int)(Time.time * speed);
        index %= listAnimations.Count;
        rend.material.mainTexture = listAnimations[index];
    }
}
