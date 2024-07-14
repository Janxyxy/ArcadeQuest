using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;

    public static bool IsMenuOpen { get; private set; }
    private bool canOpen;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsMenuOpen)
            {
                closeMenu();
            }
            else
            {
                openMenu();

            }
        }
    }

    public void closeMenu()
    {
        menuUI.SetActive(false);
        IsMenuOpen = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void openMenu()
    {
        menuUI.SetActive(true);
        IsMenuOpen = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
