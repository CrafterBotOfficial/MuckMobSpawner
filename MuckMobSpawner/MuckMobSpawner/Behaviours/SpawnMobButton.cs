﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MuckMobLoader.Behaviours
{
    internal class SpawnMobButton : MonoBehaviour
    {
        public int MobIndex;
        private TextMeshProUGUI textMesh;

        internal static int SpawnedMobs;

        private void Start()
        {
            textMesh = GetComponentInChildren<TextMeshProUGUI>();
            textMesh.text = MobSpawner.Instance.allMobs[MobIndex].name;

            Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
            buttonClickedEvent.AddListener(OnClick);
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SpawnedMobs++;
            MobSpawner.Instance.ServerSpawnNewMob(MobSpawner.Instance.allMobs.Length + SpawnedMobs, MobIndex, PlayerMovement.Instance.transform.position, 1, 1);
        }
    }
}
