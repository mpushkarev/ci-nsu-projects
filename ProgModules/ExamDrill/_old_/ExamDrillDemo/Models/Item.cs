namespace ExamDrillDemo.Models {
    public class Item {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Note>? Notes { get; set; }
        public List<ItemTag>? ItemTags { get; set; }
    }
}
