using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private float footstepTimerMax = 0.1f;
    [SerializeField] private float volume = 1f;

    private Player player;
    private float footstepTimer;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if(footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax;
            if (player.IsWalking())
            {
                SoundManager.Instance.PlayFootstepsSound(player.transform.position, volume);
            }           
        }
    }
}
