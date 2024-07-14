using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int tickets;

    public int GetTickets()
    {
        return tickets;
    }

    public void LoadTickets(int ammount)
    {
        tickets = ammount;
    }
}
