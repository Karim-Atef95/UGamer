namespace UGamer.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }

        //navigation prop
        public Game? Game { get; set; }

        public int DeviceId  { get; set; }

        //navigation prop
        public Device? Device { get; set; }
    }
}
