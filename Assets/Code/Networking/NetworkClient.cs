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
        private const string SummoningTriggerName = "SummoningTrigger";
        private const string SUMMON_EVENT_NAME = "summonEvent";

        private static readonly int SummoningAnimatorId = Animator.StringToHash(SummoningTriggerName);

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
                string yugiohCardId = E.data["yugiohCardId"].ToString().RemoveQuotes();
                string zoneName = E.data["zoneName"].ToString().RemoveQuotes();

                var arTapToPlaceObject = _interaction.GetComponent<ARTapToPlaceObject>();
                var speedDuelField = arTapToPlaceObject.PlacedObject;
                var zone = speedDuelField.transform.Find(zoneName);

                var cardModel = _cardModels.SingleOrDefault(cm => cm.name == yugiohCardId);

                if (cardModel != null && zone != null)
                {
                    var instantiatedModel = Instantiate(cardModel, zone.transform.position, zone.transform.rotation);

                    var animator = instantiatedModel.GetComponentInChildren<Animator>();
                    if (animator != null)
                    {
                        animator.SetTrigger(SummoningAnimatorId);
                    }
                }

                Debug.Log($"Card played with ID: {yugiohCardId}");
            });
        }
    }
}
