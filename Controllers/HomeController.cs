using HelloDoc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
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
        public async Task<IActionResult> PatientInfo(PatientView pv)
        {
            var userEmail = "";
            var MyUser = _context.Users.Where(x => x.Email == pv.Email).FirstOrDefault();
            if (MyUser != null)
            {
                var MyUser1 = _context.AspNetUsers.Where(x => x.Email == pv.Email).FirstOrDefault();
                if (MyUser1.PasswordHash == null)
                {
                    return RedirectToAction("SignUp");
                }
                else
                {
                    return RedirectToAction("Login");
                }
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

                userEmail = pv.Email;

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

                requestclient.Notes = pv.Discription;
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

            return RedirectToAction("SignUp", "Home", new { email = userEmail });

        }

        public IActionResult famfrdInfo()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> famfrdInfo(FamFrdView fr)
        {

            var MyUser = _context.Users.Where(x => x.Email == fr.Email).FirstOrDefault();
            if (MyUser != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                //

                var request = new Request();

                request.Status = 1;

                request.RequestTypeId = 1;
                request.IsUrgentEmailSent = true;
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

                //

                var requestclient = new RequestClient();

                requestclient.RequestId = request.RequestId;
                requestclient.FirstName = fr.FirstName;
                requestclient.LastName = fr.LastName;
                requestclient.Email = fr.Email;
                requestclient.PhoneNumber = fr.Mobile;
                requestclient.State = fr.State;
                requestclient.City = fr.City;
                requestclient.Notes = fr.Discription;
                requestclient.ZipCode = fr.ZipCode;
                requestclient.Street = fr.Street;

                requestclient.Location = fr.City + "," + fr.State + ".";
                var createdDate = DateTime.Now;
                requestclient.IntDate = createdDate.Day;
                requestclient.StrMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(createdDate.Month);
                requestclient.IntYear = createdDate.Year;





                if (!string.IsNullOrEmpty(requestclient.PhoneNumber))
                {
                    requestclient.IsMobile = true;
                }
                else
                {
                    requestclient.IsMobile = false;
                }

                await _context.RequestClients.AddAsync(requestclient);
                await _context.SaveChangesAsync();

                //

                var rwf = new RequestWiseFile()
                {
                    Requestid = request.RequestId,
                    FileName = fr.ImgPath.FileName,
                    CreatedDate = DateTime.Now

                };
                if (fr.ImgPath != null)
                {
                    var fileName = Path.GetFileName(fr.ImgPath.FileName);
                    var filePath = Path.Combine("wwwroot/PatientFiles", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        fr.ImgPath.CopyTo(fileStream);
                    }
                }
                await _context.RequestWiseFiles.AddAsync(rwf);
                await _context.SaveChangesAsync();



                return RedirectToAction("SignUp");
            }



        }
        public IActionResult ConciergeInfo()
        {
            return View();
        }

          [HttpPost]
        public async Task<IActionResult> ConciergeInfo(ConciergeViewModel Cg)
        {
            var MyUser = _context.Users.Where(x => x.Email == Cg.Email).FirstOrDefault();
            if (MyUser != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                // concierge

                var req = new Request();

                req.FirstName = Cg.CFirstName;
                req.LastName = Cg.CLastName;
                req.PhoneNumber = Cg.CPhoneNumber;
                req.Email = Cg.CEmail;
                req.Status = 1;
                req.CreatedDate = DateTime.Now;
                req.ModifiedDate = DateTime.Now;
                req.IsUrgentEmailSent = true;
                req.RelationName = Cg.CRelationName;

                await _context.Requests.AddAsync(req);
                await _context.SaveChangesAsync();




                var requestclient = new RequestClient();

                requestclient.RequestId = req.RequestId;
                requestclient.FirstName = Cg.FirstName;
                requestclient.LastName = Cg.LastName;
                requestclient.Email = Cg.Email;
                requestclient.PhoneNumber = Cg.Mobile;
                requestclient.Notes = Cg.Discription;
                var createdDate = DateTime.Now;
                requestclient.IntDate = createdDate.Day;
                requestclient.StrMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(createdDate.Month);
                requestclient.IntYear = createdDate.Year;


                if (!string.IsNullOrEmpty(requestclient.PhoneNumber))
                {
                    requestclient.IsMobile = true;
                }
                else
                {
                    requestclient.IsMobile = false;
                }

                await _context.RequestClients.AddAsync(requestclient);
                await _context.SaveChangesAsync();

                var concierge = new Concierge()
                {
                    ConciergeName = Cg.CFirstName + " " + Cg.CLastName,
                    Street = Cg.CStreet,
                    City = Cg.CCity,
                    State = Cg.CState,
                    ZipCode = Cg.CZipCode,
                    CreatedDate = DateTime.Now,
                    Address = Cg.CStreet + " " + Cg.CCity + " " + "(" + Cg.CZipCode + ")",

                };

                await _context.Concierges.AddAsync(concierge);
                await _context.SaveChangesAsync();

                var emailTo = Convert.ToString(Cg.Email);

                string emailtext = "test";

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("prudentcorporate82@gmail.com"));
                email.To.Add(MailboxAddress.Parse(emailTo));
                email.Subject = "Please Set Your Password";
                email.Body = new TextPart(TextFormat.Html) { Text = emailtext };

                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("prudentcorporate82@gmail.com", "yuejjylpdlyxkknm");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }

                return RedirectToAction("Index");

            }
        }
        public IActionResult BissunessInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BissunessInfo(BusinessViewModel Bu)
        {
            var MyUser = _context.Users.Where(x => x.Email == Bu.Email).FirstOrDefault();
            if (MyUser != null)
            {
                return RedirectToAction("Login");
            }
            else
            {


                var request = new Request()
                {
                    FirstName = Bu.BFirstName,
                    LastName = Bu.BLastName,
                    PhoneNumber = Bu.BPhoneNumber,
                    Email = Bu.BEmail,
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsUrgentEmailSent = true,
                    RelationName = Bu.BName,
                };

                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();


                var rc = new RequestClient()
                {
                    RequestId = request.RequestId,
                    FirstName = Bu.FirstName,
                    LastName = Bu.LastName,
                    PhoneNumber = Bu.Mobile,
                    Email = Bu.Email,
                    Notes = Bu.Discription,
                    Location = Bu.Street,
                    Address = Bu.Street + " " + "(" + Bu.ZipCode + ")" + " " + Bu.City,
                    IntDate = Bu.BirthDate.Day,
                    StrMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Bu.BirthDate.Month),
                    IntYear = Bu.BirthDate.Year,
                    Street = Bu.Street,
                    City = Bu.City,
                    ZipCode = Bu.ZipCode,
                    State = Bu.State,
                };

                await _context.RequestClients.AddAsync(rc);
                await _context.SaveChangesAsync();

                var emailTo = Convert.ToString(Bu.Email);

                string emailtext = "test";

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("prudentcorporate82@gmail.com"));
                email.To.Add(MailboxAddress.Parse(emailTo));
                email.Subject = "Please Set Your Password";
                email.Body = new TextPart(TextFormat.Html) { Text = emailtext };

                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("prudentcorporate82@gmail.com", "yuejjylpdlyxkknm");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }

                return RedirectToAction("Index");
            }
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("UDashBoard");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModelView lg)
        {

            if (string.IsNullOrWhiteSpace(lg.Email) && string.IsNullOrWhiteSpace(lg.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Please enter valid details.");
                return View(lg);
            }
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Email == lg.Email);


            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Please enter valid details.");
                return View(lg);
            }
            if (lg.PasswordHash == null)
            {
                ModelState.AddModelError(string.Empty, "Please Enter Password.");
                return View(lg);
            }

            if (!user.PasswordHash.Equals(lg.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Invalid password.");
                return View(lg);
            }

            HttpContext.Session.SetString("UserSession", user.Email);
            return RedirectToAction("UDashBoard", "Home");
        }

        public IActionResult SignUp(string email)
        {
            ViewBag.isNavbar = false;
            var pl = new PasswordModelView { Email = email };
            return View(pl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(PasswordModelView ps)
        {
            if (ps.Email == null)
            {
                ViewBag.error = "Username field can not be null";
                return View(ps);
            }

            var aspUser = await _context.AspNetUsers.FirstOrDefaultAsync(x => x.Email == ps.Email);

            if (aspUser == null)
            {
                ViewBag.error = "Please Enter your registed Email..";
                return View(ps);
            }
            else
            {
                aspUser.PasswordHash = ps.Password;
                _context.AspNetUsers.Update(aspUser);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Login", "Home");
        }
        public IActionResult UDashBoard(DashBoard ds)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
                string email = ViewBag.MySession;
                var query = from t1 in _context.RequestClients
                            join t2 in _context.RequestWiseFiles on t1.RequestId equals t2.Requestid
                            where t1.Email == email
                            select new DashBoard
                            {
                                StrMonth = t1.StrMonth,
                                IntYear = t1.IntYear,
                                IntDate = t1.IntDate,
                                FileName = t2.FileName,
                                CurrentStatus = "Pending",
                            };



                var userSpecificData = query.ToList();
                return View(userSpecificData);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult MyRequest()
        {
            ViewBag.isNavbar = false;
            return View();
        }

        public IActionResult SomeElse()
        {
            ViewBag.isNavbar = false;
            return View();
        }

        public async Task<IActionResult> Profile()
        {

            ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            string email = ViewBag.MySession;

            var reqcli = await _context.RequestClients.FirstOrDefaultAsync(x => x.Email == email);

           
            return View(reqcli);

        }

        [HttpPost]
        public async Task<IActionResult> Profile(PatientView pv)
        {
            

            var aspNetUser = new AspNetUser();

            aspNetUser.Id = Guid.NewGuid().ToString();
            aspNetUser.Email = pv.Email;
            aspNetUser.UserName = pv.Email;
            aspNetUser.PhoneNumber = pv.Mobile;
            aspNetUser.CreatedDate = DateTime.Now;


             _context.AspNetUsers.Update(aspNetUser);
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


            _context.Users.Update(user);
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


            _context.Requests.Update(request);
            await _context.SaveChangesAsync();


            var requestclient = new RequestClient();

            requestclient.Notes = pv.Discription;
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

            _context.RequestClients.Update(requestclient);
            await _context.SaveChangesAsync();

            return RedirectToAction("UDashBoard");
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
