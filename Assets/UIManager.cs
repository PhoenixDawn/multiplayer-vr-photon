using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private BNG.VRKeyboard keyboard;

    [SerializeField]
    private InputField userInput;
    [SerializeField]
    private InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (userInput.isFocused)
        {
            keyboard.AttachToInputField(userInput);
        }else if (passwordInput.isFocused)
        {
            keyboard.AttachToInputField(passwordInput);
        }
    }
}
