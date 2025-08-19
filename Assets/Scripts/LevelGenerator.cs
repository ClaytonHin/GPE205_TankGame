using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Create an enum to choose the type of level generation
    public enum mapRandomizationType { Random, Seeded, MapOfTheDay };
    // Create a mapRandomizationType object, to hold the chosen randomization type
    public mapRandomizationType randomizationType;
    // Create a mapSeed variable to store the current seed for the map
    public int mapSeed;
    // Create a grid to create the rooms in, (collumns, rows) format
    private Room[,] grid;
    // Create a list of roomPrefabs avaiable to the LevelSpawner
    public List<Room> roomPrefabs;
    // Create a variable to store the number of rows in the grid
    public int numRows;
    // Create a variable to store the number of collumns in the grid
    public int numCols;
    // Create a variable to store the width per tile
    public int tileWidth;
    // create a variable to store the height per tile
    public int tileHeight;

    public void SeedRandomNumberGenerator()
    {
        // Use a switch case to change behavior based on the randomization type
        switch (randomizationType)
        {
            // If the randomization type is Random
            case mapRandomizationType.Random:
                // Create a random map based on the current system time
                Random.InitState((int)System.DateTime.Now.Ticks);
                break;
            // If the randomization type is Seeded
            case mapRandomizationType.Seeded:
                // Create a random seed to be used for a map. (The same seed will create the same map over and over again until the seed changes)
                Random.InitState(mapSeed);
                break;
            // If the randomization type is Map Of The Day
            case mapRandomizationType.MapOfTheDay:
                // Create a random map based on the day, so it is different every day
                Random.InitState((int)System.DateTime.Today.Ticks);
                break;
        }
    }

    // Create a funtion that will generate the level once the game is loaded
    public void GenerateLevel()
    {
        // Assign the grid to create rooms together based on the number of collumns and rows provided/assigned
        grid = new Room[numCols, numRows];

        // Seed the level
        SeedRandomNumberGenerator();

        // Loop throughout the rows based on the number of rows within the grid
        for (int currentRow = 0; currentRow < numRows; currentRow++)
        {
            // Loop throughout the collumns based on the number of collumns within the grid
            for (int currentCol = 0; currentCol < numCols; currentCol++)
            {
                // Instantiate a room based on one of the random prefabs
                GameObject tempRoom = Instantiate(GetRandomRoomPrefab(), Vector3.zero, Quaternion.identity) as GameObject;

                // Get the X position based off from the current collumn and the tile width
                float xPosition = currentCol * tileWidth;
                // Get the Y position base off from the current row and the tile height
                float zPosition = currentRow * tileHeight;
                // Get the updated room position based on the updated x, and z position values
                tempRoom.transform.position = new Vector3(xPosition, -1, zPosition);
                // Grab any objects tranforms that have the RespawnPoint component attached
                RespawnPoint[] respawnPoints = tempRoom.GetComponentsInChildren<RespawnPoint>();
                // Add the respawn points to the GameManager's respawn points list
                GameManager.instance.addRespawnPoints(respawnPoints);
                // Update the grid
                grid[currentCol, currentRow] = tempRoom.GetComponent<Room>();

                

                // Check if the bottom row is 0, if so then open the north door
                if (currentRow == 0)
                {
                    // If the currentRow is at the bottom/0, then remove the north door
                    grid[currentCol, currentRow].doorNorth.SetActive(false);
                }
                // Else if the current row is at the top
                else if (currentRow == numRows - 1)
                {
                    // Open the south door
                    grid[currentCol, currentRow].doorSouth.SetActive(false);
                }
                // If in the middle then open both north and south doors
                else
                {
                    grid[currentCol, currentRow].doorNorth.SetActive(false);
                    grid[currentCol, currentRow].doorSouth.SetActive(false);
                }

                // If the currentCollumn is on the left/0, open the east door
                if (currentCol == 0)
                {
                    grid[currentCol, currentRow].doorEast.SetActive(false);

                }
                // Else if the current collumn is on the east
                else if (currentCol == numCols - 1)
                {
                    grid[currentCol, currentRow].doorWest.SetActive(false);
                }
                // If in the middle open both east and west doors
                else
                {
                    grid[currentCol, currentRow].doorEast.SetActive(false);
                    grid[currentCol, currentRow].doorWest.SetActive(false);
                }
            }
        }
    }

    // Create a function that will pull a random room based on our roomPrefabs list
    public GameObject GetRandomRoomPrefab()
    {
        // Get a random prefab in our roomPrefabs Array
        Room randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
        // Return it's value as a gameObject so it can be instantiated
        return randomRoom.gameObject;
    }


}
