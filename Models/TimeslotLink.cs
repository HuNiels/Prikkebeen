namespace Acupunctuur.Models {
    public class TimeslotLink {
        public int Id { get; set; }
        public Timeslot Base { get; set; }
        public int BaseId { get; set; }
        public Timeslot Link { get; set; }
        public int LinkId { get; set; }
    }
}
