 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody2D rb2d;
  [SerializeField] float torqueAmount = 10f;
  [SerializeField] float baseSpeed = 30f;
  [SerializeField] float boostSpeed = 40f;
  SurfaceEffector2D SurfaceEffector2D;
  bool canMove = true;

  // Start is called before the first frame update
  void Start()
  {
    rb2d =  GetComponent<Rigidbody2D>();
    SurfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if(canMove){
      RotatePlayer();
      RespondeToBoost();
    }
  }

  public void DisableControls(){
    canMove = false;
  }

  void RespondeToBoost(){
    if(Input.GetKey(KeyCode.UpArrow)){
      SurfaceEffector2D.speed = boostSpeed;
    }
    else{
      SurfaceEffector2D.speed = baseSpeed;
    }
  }

  void RotatePlayer(){
    if(Input.GetKey(KeyCode.LeftArrow))
    {
      rb2d.AddTorque(torqueAmount);
    }
    else if(Input.GetKey(KeyCode.RightArrow)){
      rb2d.AddTorque(-torqueAmount);
    }
  }
}
