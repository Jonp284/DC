using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room
{
    private string name;
    private Exit[] theExits;
    private int numberOfExits;
    private Player[] thePlayers;
    private int currentNumberOfPlayers;
    private Room northRoom;
    private Room southRoom;
    private Room eastRoom;
    private Room westRoom;
    
    public Room(string name)
    {
        this.name = name;
        this.theExits = new Exit[4];
        this.numberOfExits = 0;
        this.thePlayers = new Player[25];
        this.currentNumberOfPlayers = 0;
    }
    
    public int getNumberOfPlayers()
    {
        return this.currentNumberOfPlayers;
    }
    
    public bool hasExit(string direction)
    {
        for(int i = 0; i < this.numberOfExits; i++)
        {
            if(this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }
    
    
    
    public void takeExit(Player who, string direction, Room newRoom)
    {
        Exit theExitToTake = null;
        for(int i = 0; i < this.numberOfExits; i++)
        {
            if(this.theExits[i].getDirection().Equals(direction))
            {
                theExitToTake = this.theExits[i];
                break;
            }
        }
        
        //did we find an exit?
        if(theExitToTake == null)
        {
            //Console.WriteLine("****** Exit not found! ******");
        }
        else
        {
            //remove player from this room
            this.removePlayerFromRoom(who);
            theExitToTake.addPlayer(who);

            MasterData.cs.setCurrentRoom(newRoom);
            MasterData.cs.getCurrentRoom().addPlayer(who);
            MasterData.cs.getCurrentRoom().setExits(who.transform.position);
        }
    }
    
    private void removePlayerFromRoom(Player p)
    {
        for(int i = 0; i < this.currentNumberOfPlayers; i++)
        {
            if(this.thePlayers[i] == p)
            {
                for(int j = i+1; j < this.currentNumberOfPlayers; j++)
                {
                    this.thePlayers[j-1] = this.thePlayers[j];
                }
                this.currentNumberOfPlayers--;
                return;
            }
        }
    }
    
    public void addPlayer(Player p)
    {
        this.thePlayers[this.currentNumberOfPlayers] = p;
        this.currentNumberOfPlayers++;
        
        p.setCurrentRoom(this);
    }
    
    public void addExit(Exit e)
    {
        if(this.numberOfExits < 4)
        {
            this.theExits[this.numberOfExits] = e;
            this.numberOfExits++;
        }
        else
        {
            //System.err.println("Too Many Exits!!!!");
        }
    }

    public void setExits(Vector3 playerPosition)
    {
        if (this.northRoom != null && Vector3.Dot(playerPosition - this.transform.position, this.northExit.transform.position - this.transform.position) > 0)
        {
            this.northExit.SetActive(true);
        }
        else
        {
            this.northExit.SetActive(false);
        }

        if (this.southRoom != null && Vector3.Dot(playerPosition - this.transform.position, this.southExit.transform.position - this.transform.position) > 0)
        {
            this.southExit.SetActive(true);
        }
        else
        {
            this.southExit.SetActive(false);
        }

        if (this.eastRoom != null && Vector3.Dot(playerPosition - this.transform.position, this.eastExit.transform.position - this.transform.position) > 0)
        {
            this.eastExit.SetActive(true);
        }
        else
        {
            this.eastExit.SetActive(false);
        }

        if (this.westRoom != null && Vector3.Dot(playerPosition - this.transform.position, this.westExit.transform.position - this.transform.position) > 0)
        {
            this.westExit.SetActive(true);
        }
        else
        {
            this.westExit.SetActive(false);
        }
    }
    
}