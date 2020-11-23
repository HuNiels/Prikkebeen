namespace Acupunctuur.Models {
    public class File {
        public int Id { get; set; }
        public byte[] FileData { get; set; }
        public string FileMimeType { get; set; }
    }
}
