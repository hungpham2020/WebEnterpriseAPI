namespace WebEnterpriseAPI.Model
{
    public class UserDislikePost
    {
        public int Id { get; set; }
        public CustomUser? CustomUser { get; set; }

        public Post? Post { get; set; }
    }
}
