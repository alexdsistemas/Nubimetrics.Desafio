namespace ViewModels
{
    public class CreateUserViewModel
    {
        public int UserId { get; private set; }

        public CreateUserViewModel(int userId)
        {
            UserId = userId;
        }
    }
}
