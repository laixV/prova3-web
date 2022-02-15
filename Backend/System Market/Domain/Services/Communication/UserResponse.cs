using System;
using Super_Market.Domain.Models;

namespace Super_Market.Domain.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; private set; }

        public UserResponse(bool sucess, string message, User user) : base(sucess, message)
        {
            User = user;
        }

        public UserResponse(User user) : this(true, String.Empty, user)
        {

        }

        public UserResponse(string message) : this(false, message, null)
        {

        }
    }
}
