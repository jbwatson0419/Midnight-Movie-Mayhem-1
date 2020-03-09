using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRooms : MonoBehaviour
{
    public bool facing;
    public bool colliding;

    public string level; //what level are you loading?
  
    public GameObject Player;

    //where is the player going to spawn in that level
    public float temp_position_x;
    public float temp_position_y;
    public float temp_position_z;
    public float temp_rotation_x;
    public float temp_rotation_y;
    public float temp_rotation_z;
    
    

    //Detect if player is close enough to object to interact with it
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colliding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colliding = false;
        }
    }


    private void Update()
    {
        //check if the player is facing the interactable object
        IsFacingObject();

        
        if ((facing) && (colliding) && (Input.GetKey(KeyCode.Space)))
        {
            ChangeScene(level);

        }
        
    }

    //Change Scene By Name
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        PlayerSpawner.x_point = temp_position_x;
        PlayerSpawner.y_point = temp_position_y;
        PlayerSpawner.z_point = temp_position_z;
        PlayerSpawner.xr_point = temp_rotation_x;
        PlayerSpawner.yr_point = temp_rotation_y;
        PlayerSpawner.zr_point = temp_rotation_z;
    }










    private bool IsFacingObject()
    {
        // Check if the player is facing this object
        Vector3 forward = Player.transform.forward;
        Vector3 toOther = (gameObject.transform.position - Player.transform.position).normalized;

        if (Vector3.Dot(forward, toOther) < 0.1f)
        {
            //Debug.Log("Not facing the object");
            facing = false;
            return false;
        }
        
            //Debug.Log("Facing the object");
            facing = true;
            return true;
        
    }
}
