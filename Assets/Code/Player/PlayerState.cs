using UnityEngine;

namespace Project.Player
{
    public class PlayerState : MonoBehaviour
    {
        private Zone _mainMonsterZone1;
        public Zone MainMonsterZone1
        {
            get => _mainMonsterZone1;
            set => _mainMonsterZone1 = value;
        }


        private Zone _mainMonsterZone2;
        public Zone MainMonsterZone2
        {
            get => _mainMonsterZone2;
            set => _mainMonsterZone2 = value;
        }


        private Zone _mainMonsterZone3;
        public Zone MainMonsterZone3
        {
            get => _mainMonsterZone3;
            set => _mainMonsterZone3 = value;
        }

        public PlayerState()
        {
            _mainMonsterZone1 = new Zone(ZoneType.MainMonster1);
            _mainMonsterZone2 = new Zone(ZoneType.MainMonster2);
            _mainMonsterZone3 = new Zone(ZoneType.MainMonster3);
        }
    }
}
