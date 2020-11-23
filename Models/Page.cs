namespace Acupunctuur.Models {
    public class Page {
        public int Id { get; set; }
        public string InternalName { get; set; }
        public string DisplayName { get; set; }
        public Content Content { get; set; }
        public bool IsEmail { get; set; }
    }
}
