using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public GameObject westStart, eastStart, northStart, southStart;
    public float movementSpeed = 40.0f;
    private bool isMoving;
    private Room currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.isMoving = false;

        if (!MasterData.whereDidIComeFrom.Equals("?"))
        {
            if(MasterData.whereDidIComeFrom.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.rb.AddForce(Vector3.forward * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.rb.AddForce(Vector3.back * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.rb.AddForce(Vector3.left * 150.0f);
            }
            else if (MasterData.whereDidIComeFrom.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.rb.AddForce(Vector3.right * 150.0f);
            }
        }
        
        this.currentRoom = MasterData.cs.getCurrentRoom();
        this.currentRoom.setExits();
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("center"))
        {
            this.currentRoom = MasterData.cs.getCurrentRoom();
            this.currentRoom.setExits();
            this.rb.velocity = Vector3.zero;
            this.rb.Sleep();
            //this.rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Exit") && MasterData.isExiting)
        {
            this.currentRoom = MasterData.cs.getCurrentRoom();


            if(other.gameObject == this.northExit && this.currentRoom.getNorthRoom() != null)
            {
                this.currentRoom = this.currentRoom.getNorthRoom();
                MasterData.cs.setCurrentRoom(this.currentRoom);
                MasterData.whereDidIComeFrom = "north";
            }
            else if (other.gameObject == this.southExit && this.currentRoom.getSouthRoom() != null)
            {
                this.currentRoom = this.currentRoom.getSouthRoom();
                MasterData.cs.setCurrentRoom(this.currentRoom);
                MasterData.whereDidIComeFrom = "south";
            }
            else if (other.gameObject == this.eastExit && this.currentRoom.getEastRoom() != null)
            {
                this.currentRoom = this.currentRoom.getEastRoom();
                MasterData.cs.setCurrentRoom(this.currentRoom);
                MasterData.whereDidIComeFrom = "east";
            }
            else if (other.gameObject == this.westExit && this.currentRoom.getWestRoom() != null)
            {
                this.currentRoom = this.currentRoom.getWestRoom();
                MasterData.cs.setCurrentRoom(this.currentRoom);
                MasterData.whereDidIComeFrom = "west";
            }
            MasterData.isExiting = false;
            SceneManager.LoadScene("DungeonRoom");
        }
        else if(other.gameObject.CompareTag("Exit") && !MasterData.isExiting)
        {
            MasterData.isExiting = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && this.isMoving == false)
        {
            this.rb.AddForce(this.northExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && this.isMoving == false)
        {
            this.rb.AddForce(this.westExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && this.isMoving == false)
        {
            this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
            this.isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && this.isMoving == false)
        {
            this.rb.AddForce(this.southExit.transform.position * movementSpeed);
            this.isMoving = true;
        }

    }
}
