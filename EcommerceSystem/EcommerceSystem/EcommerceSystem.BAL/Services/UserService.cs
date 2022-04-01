using EcommerceSystem.BAL.Interfaces;
using EcommerceSystem.DAL.Interfaces;
using EcommerceSystem.Domain.Identites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<string> Authenticate(LoginRequest request)
        {
            return _userRepository.Authenticate(request);
        }

        public Task<bool> Register(RegisterRequest request)
        {
            return _userRepository.Register(request);
        }
    }
}
