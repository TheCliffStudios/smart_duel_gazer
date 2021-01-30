namespace Project.Player
{
    public class ZoneType
    {
        private string _zoneTypeName;

        private ZoneType(string zoneTypeName)
        {
            _zoneTypeName = zoneTypeName;
        }

        public override string ToString()
        {
            return _zoneTypeName;
        }

        public static ZoneType MainMonster1 = new ZoneType("mainMonster1");
        public static ZoneType MainMonster2 = new ZoneType("mainMonster2");
        public static ZoneType MainMonster3 = new ZoneType("mainMonster3");
    }
}
