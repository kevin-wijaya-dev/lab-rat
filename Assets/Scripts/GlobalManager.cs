using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    public static bool isPaused;

    private void Start() {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() {
        HandlePausing();
    }
    void HandlePausing(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                isPaused = false;
                Time.timeScale = 1;
                _pauseUI.SetActive(false);
            }else{
                isPaused = true;
                Time.timeScale = 0;
                _pauseUI.SetActive(true);
            }
            HandleCursorLock();
        }
    }
    void HandleCursorLock(){
        if(Cursor.lockState != CursorLockMode.None){
            Cursor.lockState = CursorLockMode.None;
            return;
        }else{
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
    }
}
