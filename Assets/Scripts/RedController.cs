using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedController : MonoBehaviour
{
    public bool isWalking;
    public int walkDir; //0 - Down, 1 - Up, 2 - Left, 3 - Right (-1 is unset)
    public int walkedFrames;
    public int fps;
    public float walkspeed;
    public float holder;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("nextFootLeft", false);

        isWalking = false;
        walkDir = -1;
        walkedFrames = 0;
        fps = 30;
        holder = fps;
        walkspeed = 1/holder;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWalking) {
            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(new Vector3(0, -walkspeed, 0));
                isWalking = true;
                walkDir = 0;
                walkedFrames = 1;
                anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
                anim.SetBool("isMoving", true);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                transform.Translate(new Vector3(0, walkspeed, 0));
                isWalking = true;
                walkDir = 1;
                walkedFrames = 1;
                anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
                anim.SetBool("isMoving", true);
            }
            else if(Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(new Vector3(-walkspeed, 0, 0));
                isWalking = true;
                walkDir = 2;
                walkedFrames = 1;
                anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetBool("isMoving", true);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                transform.Translate(new Vector3(walkspeed, 0, 0));
                isWalking = true;
                walkDir = 3;
                walkedFrames = 1;
                anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetBool("isMoving", true);
            }
             
        }
        
        else
        {
            if (walkDir == 0)
            {
                if (walkedFrames < fps)
                {
                    transform.Translate(new Vector3(0, -walkspeed, 0));
                    walkedFrames++;
                }
                else
                {
                    isWalking = false;
                    walkedFrames = 0;
                    anim.SetFloat("MoveY", 0);
                    anim.SetFloat("LastX", 0);
                    anim.SetFloat("LastY", -1);
                    anim.SetBool("nextFootLeft", !anim.GetBool("nextFootLeft"));
                    anim.SetBool("isMoving", false);
                    walkDir = -1;
                }
            }
            else if (walkDir == 1)
            {
                if (walkedFrames < fps)
                {
                    transform.Translate(new Vector3(0, walkspeed, 0));
                    walkedFrames++;
                }
                else
                {
                    isWalking = false;
                    walkedFrames = 0;
                    anim.SetFloat("MoveY", 0);
                    anim.SetFloat("LastX", 0);
                    anim.SetFloat("LastY", 1);
                    anim.SetBool("nextFootLeft", !anim.GetBool("nextFootLeft"));
                    anim.SetBool("isMoving", false);
                    walkDir = -1;
                }
            }
            else if (walkDir == 2)
            {
                if (walkedFrames < fps)
                {
                    transform.Translate(new Vector3(-walkspeed, 0, 0));
                    walkedFrames++;
                }
                else
                { 
                    isWalking = false;
                    walkedFrames = 0;
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("LastX", -1);
                    anim.SetFloat("LastY", 0);
                    anim.SetBool("nextFootLeft", !anim.GetBool("nextFootLeft"));
                    anim.SetBool("isMoving", false);
                    walkDir = -1;
                }
            }
            else if (walkDir == 3)
            {
                if (walkedFrames < fps)
                {
                    transform.Translate(new Vector3(walkspeed, 0, 0));
                    walkedFrames++;
                }
                else
                {
                    isWalking = false;
                    walkedFrames = 0;
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("LastX", 1);
                    anim.SetFloat("LastY", 0);
                    anim.SetBool("nextFootLeft", !anim.GetBool("nextFootLeft"));
                    anim.SetBool("isMoving", false);
                    walkDir = -1;
                }
            }
        }
        
        /*
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * walkspeed, 0f, 0f));
        }
        else if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * walkspeed, 0f));
        }
        */

    }
}
