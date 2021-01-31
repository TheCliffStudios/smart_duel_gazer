using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using Project.Extensions;

// Followed a tutorial on YouTube by Alex Hicks
// URL: https://www.youtube.com/watch?v=J0udhTJwR88&ab_channel=AlexHicks
namespace Project.Networking
{
    public class NetworkClient : SocketIOComponent
    {
        private const string SUMMON_EVENT_NAME = "summonEvent";

        [SerializeField]
        private GameObject _interaction;
        [SerializeField]
        private GameObject _bewd;

        public override void Start()
        {
            base.Start();

            SetupEvents();
        }

        public override void Update()
        {
            base.Update();
        }

        private void SetupEvents()
        {
            On(SUMMON_EVENT_NAME, (E) =>
            {
                string id = E.data["yugiohCardId"].ToString().RemoveQuotes();

                var arTapToPlaceObject = _interaction.GetComponent<ARTapToPlaceObject>();
                var speedDuelField = arTapToPlaceObject.SpeedDuelPlayMat;
                Instantiate(_bewd, speedDuelField.transform);

                Debug.Log($"Card played with ID: {id}");
            });
        }
    }
}
