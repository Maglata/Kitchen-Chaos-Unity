using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [Space(15)]
    [SerializeField] private TextMeshProUGUI keyInteract;
    [SerializeField] private TextMeshProUGUI keyInteractAlternate;
    [SerializeField] private TextMeshProUGUI keyPause;
    [Space(15)]
    [SerializeField] private TextMeshProUGUI keyGamepadInteract;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAlternate;
    [SerializeField] private TextMeshProUGUI keyGamepadPause;

    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        UpdateVisual();
        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if(KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {

        // Movement
        keyMoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);

        // Interact Keyboard
        keyInteract.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        keyInteractAlternate.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        keyPause.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);

        // Interact Gamepad
        keyGamepadInteract.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAlternate.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        keyGamepadPause.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
