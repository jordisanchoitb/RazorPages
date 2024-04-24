using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRazor.Domain.Entities;
using WebRazor.Service.Models;

namespace WebRazor.Service.Services
{
    public class UserServices : IUserService
    {
        public List<UsersModel> UserList { get; set; }

        private int _loggedIn;

        public UserServices(List<UsersModel> userList)
        {
            UserList = userList;
        }
        /// <summary>
        /// Add new user to table Users.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void NewUser(string username, string password, string firstName, string lastName, string email)
        {
            UserList.Add(
                new UsersModel {
                 User_Id = UserList.Count + 1,
                 UserName = username,
                 Password = password,
                 FirstName = firstName,
                 LastName = lastName,
                 Email = email
            });
        }
        /// <summary>
        /// Get all Users from DB.
        /// </summary>
        /// <returns>List with all users</returns>
        public List<UsersModel> ShowAllUsers()
        {
            List<UsersModel> myList = UserList.ToList();
            List<UsersModel> newList = new();
            if (myList == null)
            {
                return newList;
            }
            else
            {
                foreach (var item in myList)
                {
                    newList.Add(new UsersModel
                    {
                        User_Id = item.User_Id,
                        UserName = item.UserName,
                        Password = item.Password,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email
                    });
                }
                return newList;
            }
        }
        /// <summary>
        /// Get a Users Object and transfer to UsersModel object.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UsersModel object</returns>
        public UsersModel ShowUserById(int userId)
        {
            UsersModel users = UserList.FirstOrDefault(x => x.User_Id == userId);
            UsersModel myModel = new UsersModel
            {
                UserName = users.UserName,
                Password = users.Password,
                FirstName = users.FirstName,
                LastName = users.LastName ,
                Email = users.Email 
            };
            return myModel;
        }
        /// <summary>
        /// Set the user row to IsDeleted in the DB, so is "deleted"!
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUserById(int userId) 
        { 
            UserList.FirstOrDefault(x => x.User_Id == userId).IsDeleted = true;
        }
        /// <summary>
        /// Update one User by input UserID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstname"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void UpdateUserById(int id, string username, string password, string firstname, string lastName, string email)
        {
            UsersModel usersModel = UserList.FirstOrDefault(x => x.User_Id == id);
            usersModel.UserName = username;
            usersModel.Password = password;
            usersModel.FirstName = firstname;
            usersModel.LastName = lastName;
            usersModel.Email = email;
        }

        //LOGIN VALIDATION
        /// <summary>
        /// Check if the username and password is correct and returns a boolean.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>false if the login is not correct</returns>
        public bool LoginValidation(string username, string password) 
        {
            bool login = UserList.Any(x => x.UserName == username && x.Password == password);
            return login;
        }
        /// <summary>
        /// Get logged user id by input username and id.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Users Id object</returns>
        public void GetUserIdByUsername(string username, string password)
        {
            int userid = UserList.FirstOrDefault(x => x.UserName == username && x.Password == password).User_Id;
            _loggedIn = userid;
        }
        /// <summary>
        /// Returns logged ID.
        /// </summary>
        /// <returns>int = User Id</returns>
        public int LoggedIndId() => _loggedIn;

        /// <summary>
        /// Get one User by input ID.
        /// </summary>
        /// <returns>UsersModel object.</returns>
        public UsersModel LoadLoggedIn()
        {
            UsersModel myUser  = ShowUserById(_loggedIn);
            return myUser;
        }
        
    }
}
