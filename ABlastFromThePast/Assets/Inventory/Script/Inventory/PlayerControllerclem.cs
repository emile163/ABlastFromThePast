using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class PlayerControllerclem : MonoBehaviour
    {

     private static float moveSpeed = 2f;
     private Animator anim;
     private bool playerMoving;
     private Vector2 lastMove;
     public List<Queteobjet> listeQuete;
     public QuestGiver quests;

        void Start() {
        anim = GetComponent<Animator>();
        //listeQuete = quests.GiveQuests();
        }

        void Update() {
            playerMoving = false;

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical")*Time.deltaTime);
            }
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
    public static void incrementation(PlayerControllerclem play, int i)
    {
        play.incrementeGoal(i);

    }

    public void incrementeGoal(int i)
    {
        listeQuete[i].qG.currentAmount++;
    }

    public void SetSpeed(float speedmultiplier)
	{
        moveSpeed = moveSpeed * (1 + speedmultiplier);
	}
    }
    