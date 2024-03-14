using HelloDoc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HelloDoc.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly HelloDocContext _context;

        public HomeController(HelloDocContext context)
        {
            _context = context;
        }





        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubAreq()
        {

            return View();

        }

        public IActionResult PatientInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PatientInfo(PatientViewModel pv)
        {
            var MyUser = _context.Users.Where(x => x.Email == pv.Email).FirstOrDefault();
            if (MyUser != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var aspNetUser = new AspNetUser();

                aspNetUser.Id = Guid.NewGuid().ToString();
                aspNetUser.Email = pv.Email;
                aspNetUser.UserName = pv.Email;
                aspNetUser.PhoneNumber = pv.Mobile;
                aspNetUser.CreatedDate = DateTime.Now;


                await _context.AspNetUsers.AddAsync(aspNetUser);
                await _context.SaveChangesAsync();


                var user = new User();
                user.FirstName = pv.FirstName;
                user.LastName = pv.LastName;
                user.Email = pv.Email;
                user.Mobile = pv.Mobile;
                user.State = pv.State;
                user.City = pv.City;
                user.ZipCode = pv.ZipCode;
                user.Street = pv.Street;
                user.BirthDate = pv.BirthDate;
                user.CreatedDate = DateTime.Now;
                user.CreatedBy = user.FirstName;

                var createdDate = user.CreatedDate;
                user.IntDate = createdDate.Day;
                user.StrMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(createdDate.Month);
                user.IntYear = createdDate.Year;


                user.CreatedBy = pv.FirstName;
                user.AspNetUserId = aspNetUser.Id;


                if (!string.IsNullOrEmpty(user.Mobile))
                {
                    user.IsMobile = true;
                }
                else
                {
                    user.IsMobile = false;
                }


                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                var request = new Request();

                request.Status = 1;
                request.RequestTypeId = 1;
                request.IsUrgentEmailSent = true;
                request.UserId = user.UserId;
                request.FirstName = pv.FirstName;
                request.LastName = pv.LastName;
                request.CreatedDate = DateTime.Now;
                request.PhoneNumber = pv.Mobile;
                request.Email = pv.Email;
                request.PhoneNumber = pv.Mobile;
                request.CreatedDate = DateTime.Now;


                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();


                var requestclient = new RequestClient();

                requestclient.RequestId = request.RequestId;
                requestclient.FirstName = pv.FirstName;
                requestclient.LastName = pv.LastName;
                requestclient.Email = pv.Email;
                requestclient.PhoneNumber = pv.Mobile;
                requestclient.City = pv.City;
                requestclient.State = pv.State;
                requestclient.Address = pv.City + "," + pv.State + ".";
                requestclient.Notes = pv.Discription;
                requestclient.ZipCode = pv.ZipCode;
                requestclient.IntDate = createdDate.Day;
                requestclient.StrMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(createdDate.Month);
                requestclient.IntYear = createdDate.Year;

                await _context.RequestClients.AddAsync(requestclient);
                await _context.SaveChangesAsync();


                var rp = new RequestWiseFile()
                {
                    Requestid = request.RequestId,
                    FileName = pv.ImgPath.FileName,
                    CreatedDate = DateTime.Now

                };
                if (pv.ImgPath != null)
                {
                    var fileName = Path.GetFileName(pv.ImgPath.FileName);
                    var filePath = Path.Combine("wwwroot/PatientFiles", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        pv.ImgPath.CopyTo(fileStream);
                    }
                }
                await _context.RequestWiseFiles.AddAsync(rp);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("SignUp");

        }

        public IActionResult famfrdInfo()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> famfrdInfo(FamFrdViewModel fr)
        {

            var MyUser = _context.Users.Where(x => x.Email == fr.Email).FirstOrDefault();
            if (MyUser != null)
            {
                return RedirectToAction("Login");
            }
            else
            {

                //

                var aspNetUser = new AspNetUser();

                aspNetUser.Id = Guid.NewGuid().ToString();
                aspNetUser.Email = fr.Email;
                aspNetUser.UserName = fr.Email;
                aspNetUser.PhoneNumber = fr.Mobile;
                aspNetUser.CreatedDate = DateTime.Now;
                aspNetUser.ModifiedDate = DateTime.Now;
                await _context.AspNetUsers.AddAsync(aspNetUser);
                await _context.SaveChangesAsync();

                //

                var user = new User();

                user.FirstName = fr.FirstName;
                user.LastName = fr.LastName;
                user.Email = fr.Email;
                user.Mobile = fr.Mobile;
                user.State = fr.State;
                user.City = fr.City;
                user.ZipCode = fr.ZipCode;
                user.Street = fr.Street;
                user.BirthDate = fr.BirthDate;
                var birthDate = fr.BirthDate;
               


                user.CreatedBy = fr.FirstName;
                user.CreatedDate = DateTime.Now;
                var createdDate = user.CreatedDate;
                user.IntDate = createdDate.Day;
                user.StrMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(createdDate.Month);
                user.IntYear = createdDate.Year;
                user.ModifiedDate = DateTime.Now;
                user.AspNetUserId = aspNetUser.Id;


                if (!string.IsNullOrEmpty(user.Mobile))
                {
                    user.IsMobile = true;
                }
                else
                {
                    user.IsMobile = false;
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();


                //

                var request = new Request();

                request.Status = 1;
                request.RequestTypeId = 1;
                request.IsUrgentEmailSent = true;
                request.UserId = user.UserId;
                request.FirstName = fr.FFirstName;
                request.LastName = fr.FFirstName;
                request.PhoneNumber = fr.FPhoneNumber;
                request.Email = fr.FEmail;
                request.RelationName = fr.FRelationName;
                request.CreatedDate = DateTime.Now;
                request.ModifiedDate = DateTime.Now;
                request.AcceptedDate = DateTime.Now;
                request.LastReservationDate = DateTime.Now;
                request.LastWellnessDate = DateTime.Now;




                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();


                return RedirectToAction("SignUp");
            }



        }
        public IActionResult ConciergeInfo()
        {
            return View();
        }
        public IActionResult BissunessInfo()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {


            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
