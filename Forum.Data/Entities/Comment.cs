namespace Forum.Data.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }

        public virtual User User { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
