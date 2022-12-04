using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TarodevController
{
    public class PlayerAnimation : MonoBehaviour
    {
        private enum animationState
        {
            IDLE,
            RUNNING,
            ATTACK1,
            ATTACK2
        }
        
        private Animator animator;
        private IPlayerController playerController;
        private SpriteRenderer playerSprite;
        private float playerYScale;
        private float playerXScale;

        void Start()
        {
            animator = GetComponent<Animator>(); 
            playerSprite = GetComponent<SpriteRenderer>();
            playerXScale = transform.localScale.x;
            playerYScale = transform.localScale.y;
        }

        void Update()
        {
            //Flipping the Sprite
            //if (playerController.Input.X != 0) transform.localScale = new Vector3(playerController.Input.X > 0 ? playerXScale : (-1)*playerXScale, playerYScale, 1);
            
            Debug.Log(playerController.Velocity.x.ToString() + " | " + playerController.Velocity.y.ToString());
        }
    }
}
