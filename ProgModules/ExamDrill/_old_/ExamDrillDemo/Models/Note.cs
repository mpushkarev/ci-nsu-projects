namespace ExamDrillDemo.Models {
    public class Note {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
