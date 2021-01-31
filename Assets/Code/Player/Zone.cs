using UnityEngine;

namespace Project.Player
{
    public class Zone
    {
        private ZoneType _zoneType;
        public ZoneType ZoneType
        {
            get => _zoneType;
            set => _zoneType = value;
        }

        private GameObject _cardModel;
        public GameObject CardModel
        {
            get => _cardModel;
            set => _cardModel = value;
        }

        public Zone(ZoneType zoneType)
        {
            _zoneType = zoneType;
        }
    }
}
