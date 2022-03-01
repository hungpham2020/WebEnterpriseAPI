namespace WebEnterpriseAPI.Model
{
    public class UserLikePost
    {
        public int Id { get; set; }
        
        public CustomUser? CustomUser { get; set; }

        public Post? Post { get; set; }

        public bool? Status { get; set; }
    }
}
