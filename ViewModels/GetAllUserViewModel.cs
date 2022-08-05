using DTOs;

namespace ViewModels
{
    public class GetAllUserViewModel
    {
        public List<GetAllUserDto> Users { get; private set; }

        public GetAllUserViewModel(List<GetAllUserDto> users)
        {
            Users = users;
        }
    }
}