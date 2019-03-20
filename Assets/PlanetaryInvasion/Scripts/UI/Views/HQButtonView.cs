using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class MissionControlButtonView : MonoBehaviour
{
    [Inject]
    GameStateMachine sm;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => sm.ChangeState<HQGameState>());
    }

}
