using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Super_Market.Domain.Models;
using Super_Market.Domain.Repositories;
using Super_Market.Domain.Services;
using Super_Market.Domain.Services.Communication;


namespace Super_Market.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IUnityOfWork _unityOfWork;

        public UserService(IUserRepository userRepository, IUnityOfWork unityOfWork)
        {
            _userRepository = userRepository;
            _unityOfWork = unityOfWork;

        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            try
            {
                var user = await _userRepository.FindByIdAsync(id);

                if (user == null)
                    return new UserResponse($"User cannot be deleted, id = {id} not exists!");

                _userRepository.Delete(user);
                await _unityOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<User> FirstOrDefaultAsync(string email, string password)
        {
            return await _userRepository.FirstOrDefaultAsync(email, password);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unityOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"problem occured {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            try
            {
                var _user = await _userRepository.FindByIdAsync(id);

                if (_user != null)
                {
                    _user.Email = user.Email;
                    _user.Password = user.Password;
                    _userRepository.Update(_user);

                    await _unityOfWork.CompleteAsync();

                    return new UserResponse(_user);
                }

                return new UserResponse($"Product by id {id} not found!");

            }
            catch (Exception e)
            {
                return new UserResponse($"Problem occured : {e.Message}");
            }
        }
    }
}
