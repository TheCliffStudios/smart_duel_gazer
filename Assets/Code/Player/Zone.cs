using UnityEngine;

namespace Project.Player
{
    public class Zone
    {
        private ZoneType _zoneType;
        private GameObject _cardModel;

        public Zone(ZoneType zoneType, GameObject cardModel)
        {
            _zoneType = zoneType;
            _cardModel = cardModel;
        }
    }
}
