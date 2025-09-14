namespace ExamDrillDemo.Models {
    public class Category {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Item>? Items { get; set; }
    }
}
