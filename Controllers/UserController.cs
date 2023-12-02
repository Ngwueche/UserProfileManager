using Microsoft.AspNetCore.Mvc;
using UserProfileManager.Data;
using UserProfileManager.Model;

namespace UserProfileManager.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        //create
        [HttpPost]
        public JsonResult Create(User user)
        {
            var _getUser = _context.Users.Find(user.Id);
            if (_getUser != null)
                BadRequest();
            _context.Users.Add(user);
            _context.SaveChanges();
            return new JsonResult(Ok("User saved"));

        }

        //Edit
        [HttpPost]
        public JsonResult Edit(User user, int id)
        {
            var isUser = _context.Users.Find(id);
            if (isUser is null) return new JsonResult(BadRequest());
            // if (user.Id != id) return new JsonResult(BadRequest(""));
            var updatedUser = new User
            {
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DOB = user.DOB,
                MaritalStatus = user.MaritalStatus,
                Phone = user.Phone,

            };

            var response = _context.Users.Update(updatedUser);
            _context.SaveChanges();
            if (response == null) return new JsonResult(BadRequest());
            return new JsonResult(Ok("User profile updated"));
        }

        //Fetch
        [HttpGet]
        public JsonResult Get(int Id)
        {
            var getUser = _context.Users.Find(Id);
            if (getUser == null)
                return new JsonResult(NotFound("User does not exist"));
            return new JsonResult(Ok(getUser));
        }

        //Fetch All
        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var allUsers = _context.Users.ToList();
            return new JsonResult(Ok(allUsers));

        }

        //Delete
        [HttpGet("/Delete")]
        public JsonResult Delete(int userId)
        {
            var getUser = _context.Users.Find(userId);
            if (getUser == null)
                return new JsonResult(NotFound());
            _context.Users.Remove(getUser);
            _context.SaveChanges();
            return new JsonResult(Ok("user deleted"));
        }
    }
}
