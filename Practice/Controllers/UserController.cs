using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.ModelExtensions;
using Practice.Models;

namespace Practice.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly PracticeContext _practiceContext;

        public UserController(ILogger<HomeController> logger, IMapper mapper, PracticeContext practiceContext)
        {
            _logger = logger;
            _mapper = mapper;
            _practiceContext = practiceContext;
        }

        // GET: UserController
        public ActionResult Index()
        {
            var userViewModelList = _mapper.Map<IEnumerable<UserViewModel>>(_practiceContext.Users.ToList());
            return View(userViewModelList);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var userDetails = _practiceContext.Users
               .Include(x => x.UserDetails)
               .FirstOrDefault(x => x.Id == id)?.UserDetails
               ?? throw new Exception();

                var userDetailsViewModel = _mapper.Map<UserDetailsViewModel>(userDetails);
                return View(userDetailsViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = collection.AsObject<CreateUserViewModel>();
                if (model == null)
                {
                    throw new ArgumentNullException("Create user model form has been null or empty.");
                }

                var dbModel = _mapper.Map<User>(model);

                dbModel.UserDetails = new UserDetails()
                {
                    Address = model.Address
                };

                _practiceContext.Users.Add(dbModel);
                _practiceContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _practiceContext.Users.Find(id);

            //TODO:
            // convert user db model to business logic model then 
            // convert business logic model to edit view model
            //Note: Skip for this step

            var editUserViewModel = _mapper.Map<EditUserViewModel>(user);
            return View(editUserViewModel);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var editModel = collection.AsObject<EditUserViewModel>();
                if (editModel == null)
                {
                    throw new ArgumentNullException("Create user model form has been null or empty.");
                }
                var originModel = _practiceContext.Find<User>(id);

                // assign username field only as it has been considered as editable
                originModel.Username = editModel.Username;
                try
                {
                    _practiceContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var user = _practiceContext.Find<User>(id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var editUser = _mapper.Map<EditUserViewModel>(user);// map to edituserviewmodel
                return View(editUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var user = _practiceContext.Find<User>(id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                // mode to Business logic layer
                _practiceContext.Users.Remove(user);
                _practiceContext.SaveChanges(true);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
