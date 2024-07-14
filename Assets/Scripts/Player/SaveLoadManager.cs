using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    private void SavePlayerData()
    {
        Vector3 position = player.transform.position;
        Vector3 rotation = player.transform.eulerAngles;
        int tickets = player.GetComponent<Player>().GetTickets(); 

        PlayerData data = new PlayerData(position, rotation, tickets);
        string jsonData = PlayerData.Serialize(data);
        PlayerPrefs.SetString("PlayerData", jsonData);
        PlayerPrefs.Save();

        Debug.Log("Player Data Saved: " + jsonData);
    }

    private void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            string jsonData = PlayerPrefs.GetString("PlayerData");
            PlayerData data = PlayerData.Deserialize(jsonData);

            player.transform.position = new Vector3(data.posX, data.posY, data.posZ);
            player.transform.eulerAngles = new Vector3(data.rotX, data.rotY, data.rotZ);
            player.GetComponent<Player>().LoadTickets(data.tickets);

            Debug.Log("Player Data Loaded: " + jsonData);
        }
        else
        {
            Debug.LogWarning("No player data found to load.");
        }
    }
}
