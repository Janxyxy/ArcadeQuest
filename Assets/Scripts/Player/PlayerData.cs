using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float posX;
    public float posY;
    public float posZ;
    public float rotX;
    public float rotY;
    public float rotZ;
    public int tickets;

    public PlayerData(Vector3 position, Vector3 rotation, int tickets)
    {
        posX = position.x;
        posY = position.y;
        posZ = position.z;
        rotX = rotation.x;
        rotY = rotation.y;
        rotZ = rotation.z;
        this.tickets = tickets;
    }

    public static string Serialize(PlayerData data)
    {
        return JsonUtility.ToJson(data);
    }

    public static PlayerData Deserialize(string jsonData)
    {
        return JsonUtility.FromJson<PlayerData>(jsonData);
    }
}
