﻿using RT.Comb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.Context;

namespace Ventra.Infrastructure.Repositories
{
    public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(VentraDbContext context, ICombProvider comb) : base(context, comb)
        {
        }
    }
}
