using System;
using System.Collections.Generic;

namespace KoiManagement_Business;

public partial class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double Size { get; set; }

    public string Variety { get; set; } = null!;

    public int Age { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<CompetitionCategory> CompetitionCategories { get; set; } = new List<CompetitionCategory>();
}
