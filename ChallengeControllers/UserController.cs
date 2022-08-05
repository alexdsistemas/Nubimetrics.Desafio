using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;
using UseCases.Usuarios.Services;
using ViewModels;

namespace Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        readonly ICreateUserInputPort CreateUserInputPort;
        readonly ICreateUserOutputPort CreateUserOutputPort;
        readonly IUpdateUserInputPort UpdateUserInputPort;
        readonly IDeleteUserInputPort DeleteUserInputPort;
        readonly IGetAllUsersInputPort GetAllUsersInputPort;
        readonly IGetAllUsersOutputPort GetAllUsersOutputPort;

        public UserController(ICreateUserInputPort createUserInputPort, ICreateUserOutputPort createUserOutputPort, IUpdateUserInputPort updateUserInputPort, IDeleteUserInputPort deleteUserInputPort, IGetAllUsersInputPort getAllUsersInputPort, IGetAllUsersOutputPort getAllUsersOutputPort)
        {
            CreateUserInputPort = createUserInputPort;
            CreateUserOutputPort = createUserOutputPort;
            UpdateUserInputPort = updateUserInputPort;
            DeleteUserInputPort = deleteUserInputPort;
            GetAllUsersInputPort = getAllUsersInputPort;
            GetAllUsersOutputPort = getAllUsersOutputPort;
        }


        /// <summary>
        /// Busca todos los usuarios del sistemas
        /// </summary>
        /// <returns>lista de usuarios</returns>
        [HttpGet()]
        public async Task<ActionResult<List<GetAllUserDto>>> GetAllUsers()
        {
            await GetAllUsersInputPort.Handle();
            return ((IPresenter<GetAllUserViewModel>)GetAllUsersOutputPort).Content.Users;
        }
        /// <summary>
        /// Crear usuarios
        /// </summary>
        /// <param name="user"></param>
        /// <returns>el id del usuario</returns>
        [HttpPost()]
        public async Task<ActionResult<int>> CrearUser(CreateUserDto user)
        {
            await CreateUserInputPort.Handle(user);
            return ((IPresenter<CreateUserViewModel>)CreateUserOutputPort).Content.UserId;
        }
        /// <summary>
        /// Modificar Datos del usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<ActionResult> UpdateUser(UpdateUserDto user)
        {
            await UpdateUserInputPort.Handle(user);

            return Ok("Usuario Modificado Correctamente.");
        }

        /// <summary>
        /// Eliminar un usuario por id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete()]
        public async Task<ActionResult> DeleteDocumento(int userId)
        {
            await DeleteUserInputPort.Handle(userId);

            return Ok("Se elimino el usuario correctamente.");

        }


    }
}
