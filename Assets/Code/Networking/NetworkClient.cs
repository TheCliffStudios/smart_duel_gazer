using UnityEngine;
using SocketIO;
using Project.Extensions;
using System.Linq;

// Followed a tutorial on YouTube by Alex Hicks
// URL: https://www.youtube.com/watch?v=J0udhTJwR88&ab_channel=AlexHicks
namespace Project.Networking
{
    public class NetworkClient : SocketIOComponent
    {
        private const string RESOURCES_MONSTERS_FOLDER_NAME = "Monsters";
        private const string SUMMON_EVENT_NAME = "summonEvent";

        [SerializeField]
        private GameObject _interaction;

        private GameObject[] _cardModels;

        public override void Start()
        {
            base.Start();

            Init();
            SetupEvents();
        }

        public override void Update()
        {
            base.Update();
        }

        private void Init()
        {
            _cardModels = Resources.LoadAll<GameObject>(RESOURCES_MONSTERS_FOLDER_NAME);
        }

        private void SetupEvents()
        {
            On(SUMMON_EVENT_NAME, (E) =>
            {
                string id = E.data["yugiohCardId"].ToString().RemoveQuotes();

                var arTapToPlaceObject = _interaction.GetComponent<ARTapToPlaceObject>();
                var speedDuelField = arTapToPlaceObject.PlacedObject;
                var cardModel = _cardModels.SingleOrDefault(cm => cm.name == id);

                if (cardModel != null)
                {
                    Instantiate(cardModel, speedDuelField.transform.position, speedDuelField.transform.rotation);
                }

                Debug.Log($"Card played with ID: {id}");
            });
        }
    }
}
