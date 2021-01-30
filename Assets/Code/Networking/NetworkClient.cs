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

        [Header("Network Client")]
        [SerializeField]
        private Transform _networkContainer;

        // TODO: not sure lol
        private Dictionary<string, GameObject> _serverObjects;

        public override void Start()
        {
            base.Start();

            Initialize();
            SetupEvents();
        }

        public override void Update()
        {
            base.Update();
        }

        private void Initialize()
        {
            _serverObjects = new Dictionary<string, GameObject>();
        }

        private void SetupEvents()
        {
            On(SUMMON_EVENT_NAME, (E) =>
            {
                string id = E.data["yugiohCardId"].ToString().RemoveQuotes();

                var go = new GameObject($"Card ID: {id}");
                go.transform.SetParent(_networkContainer);
                _serverObjects.Add(id, go);

                Debug.Log($"Card played with ID: {id}");
            });
        }
    }
}
