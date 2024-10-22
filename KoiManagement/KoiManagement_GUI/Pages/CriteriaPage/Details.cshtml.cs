﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Services.IService;

namespace KoiManagement_GUI.Pages.CriteriaPage
{
    public class DetailsModel : PageModel
    {
        private readonly ICriteriaService criteriaService;


        public DetailsModel(ICriteriaService criteriaService)
        {
            this.criteriaService = criteriaService;
        }

        public Criteria Criteria { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criteria = criteriaService.GetCriteria(id);
            if (criteria == null)
            {
                return NotFound();
            }
            else
            {
                Criteria = criteria;
            }
            return Page();
        }
    }
}
