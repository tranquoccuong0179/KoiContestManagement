using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.Service;
using KoiManagement_Services.IService;
using KoiManagement_Services.AuthenticationServices.DTO;
using KoiManagement_Service.Service;


namespace KoiManagement_GUI.Pages.RefereeMarkPages
{
    public class CreateModel : PageModel
    {
        private readonly IRefereeMarkService refereeMarkService;
        private readonly IAuthenticationService authenticationService;
        private readonly IKoiService koiService;
        private readonly ICriteriaService criteriaService;
        private readonly ICriteriaPointService criteriaPointService;

        public CreateModel(
            IRefereeMarkService refereeMarkService,
            IAuthenticationService authenticationService,
            IKoiService koiService,
            ICriteriaService criteriaService,
            ICriteriaPointService criteriaPointService)
        {
            this.refereeMarkService = refereeMarkService;
            this.authenticationService = authenticationService;
            this.koiService = koiService;
            this.criteriaService = criteriaService;
            this.criteriaPointService = criteriaPointService;
        }

        [BindProperty]
        public RefereeMark RefereeMark { get; set; } = new RefereeMark();

        public List<Criteria> Criterias { get; set; } = new List<Criteria>();
        public UserForReturnDto UserForReturnDto { get; set; }

        public async Task<IActionResult> OnGet(string competitionRoundId)
        {
            string userId = HttpContext.Session.GetString("Id");
            UserForReturnDto = await authenticationService.GetUserById(userId);
            var koi = await koiService.GetAllWithKois(competitionRoundId);
            //ViewData["CompetitionRoundId"] = koi.KoiName;
            //ViewData["UserId"] = UserForReturnDto.FullName;
            ViewData["CompetitionRoundId"] = new SelectList(new[] { koi }, "CompetitionRoundId", "KoiName");
            ViewData["UserId"] = new SelectList(new[] { UserForReturnDto }, "Id", "FullName");
            Criterias = criteriaService.GetCriterias();
            RefereeMark.CriteriaPoints = Criterias
                .Select(c => new CriteriaPoint { CriteriaId = c.Id, Point = 0 })
                .ToList();
            return Page();
        }


        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            RefereeMark.CompetitionRoundId = Request.Form["RefereeMark.CompetitionRoundId"];
            RefereeMark.UserId = Request.Form["RefereeMark.UserId"];
            RefereeMark? refereeMark = refereeMarkService.GetExistRefereeMark(RefereeMark.CompetitionRoundId, RefereeMark.UserId);
            if (refereeMark != null)
            {
                return RedirectToPage("./Details");
            }
            refereeMarkService.AddRefereeMark(RefereeMark);
            double totalPoints = 0;
            foreach (var criteriaPoint in RefereeMark.CriteriaPoints)
            {
                var criteria = criteriaService.GetCriteria(criteriaPoint.CriteriaId);
                double percent = (criteria.Percent) / 100;
                criteriaPoint.Point *= percent;
                totalPoints += criteriaPoint.Point;
                criteriaPointService.AddCriteriaPoint(criteriaPoint, RefereeMark.Id, criteriaPoint.CriteriaId);
            }
            RefereeMark.Point = totalPoints;
            refereeMarkService.UpdateRefereeMark(RefereeMark);

            return RedirectToPage("./Index");
        }
    }

}
